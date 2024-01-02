using RestSharp;
using RestSharp.Serializers.Json;
using ShopeeReplayDownloader.JsonInterfaces;
using System.Diagnostics;

namespace ShopeeReplayDownloader;
internal class ShopeeReplayDownloader : IDisposable
{
    private readonly RestClient client = new(configureSerialization: e => e.UseSystemTextJson());

    public void Dispose()
    {
        client.Dispose();
    }

    public async Task<long[]> GetRecordIdsFromSessionAsync(string session)
        => await GetRecordIdsFromSessionAsync(long.Parse(session));

    public async Task<long[]> GetRecordIdsFromSessionAsync(long session)
    {
        var request = new RestRequest($"https://live.shopee.co.id/api/v1/replay?session_id={session}");
        var response = await client.GetAsync<ShopeeSession>(request);
        return response?.Data.RecordIds ?? Array.Empty<long>();
    }
    public async Task<Dictionary<long, ShopeeRecordData>> GetRecordsFromSessionAsync(string session)
        => await GetRecordsFromSessionAsync(long.Parse(session));

    public async Task<Dictionary<long, ShopeeRecordData>> GetRecordsFromSessionAsync(long session)
    {
        var ids = await GetRecordIdsFromSessionAsync(session);
        var map = new Dictionary<long, ShopeeRecordData>();
        foreach (var id in ids)
        {
            map.Add(id, await GetRecordAsync(id));
        }
        return map;
    }

    public async Task<ShopeeRecordData> GetRecordAsync(string record)
        => await GetRecordAsync(long.Parse(record));
    public async Task<ShopeeRecordData> GetRecordAsync(long record)
    {
        var request = new RestRequest($"https://live.shopee.co.id/api/v1/replay/{record}");
        var response = await client.GetAsync<ShopeeRecord>(request);
        return response!.Data;
    }

    public async Task<List<Uri>> DownloadHlsPlaylistAsync(
        ShopeeRecordData data, string directoryPath)
    {
        var playlistPath = Path.Combine(directoryPath, "playlist.m3u8");
        if (!File.Exists(playlistPath))
        {
            var request = new RestRequest(data.ReplayInfo.RecordUrl);
            var buffer = await client.DownloadDataAsync(request);
            await File.WriteAllBytesAsync(playlistPath, buffer!);
        }

        var partitions = new List<Uri>();
        var lines = File.ReadAllLines(playlistPath);
        foreach (var line in lines)
        {
            if (line.StartsWith("#")) continue;
            var uri = new Uri(data.ReplayInfo.RecordUrl, line);
            partitions.Add(uri);
        }
        return partitions;
    }
    private static async Task LoopThroughParitionsAsync(
        List<Uri> partitions,
        string directoryPath,
        int? start,
        int? end,
        Func<Uri, string, int, int, int, Task> callback)
    {
        start ??= 0;
        start = Math.Max((int)start, 0);
        end ??= partitions.Count;
        end = Math.Min((int)end, partitions.Count);
        var length = (int)end - (int)start;
        var startInt = (int)start;
        var endInt = (int)end;
        for (var i = startInt; i <= endInt; i++)
        {
            var uri = partitions[i];
            var file = Path.Join(directoryPath, Path.GetFileName(uri.LocalPath));
            await callback(uri, file, startInt, endInt, i);
        }
    }

    public async Task DownloadAllVideoPartitionsAsync(
        List<Uri> partitions,
        string directoryPath,
        int? start = null,
        int? end = null,
        Action<int, int>? onProgress = null)
    {
        await LoopThroughParitionsAsync(partitions, directoryPath, start, end,
            async (uri, file, start, end, i) =>
            {
                if (File.Exists(file)) return;
                var buffer = await client.DownloadDataAsync(
                    new RestRequest(uri)
                );
                await File.WriteAllBytesAsync(file, buffer!);
                onProgress?.Invoke(i - start + 1, end - start);
            });
    }

    public async Task ConvertPartitionsToMp4Async(
        List<Uri> partitions,
        string directoryPath,
        int? start = null,
        int? end = null,
        Action<int, int>? onProgress = null)
    {
        var mp4File = Path.Join(directoryPath, $"__convert_{start}-{end}.mp4");
        if (File.Exists(mp4File)) return;
        var tsFile = Path.Join(directoryPath, $"__convert_{start}-{end}.ts");
        if (!File.Exists(tsFile))
        {
            using var stream = new FileStream(tsFile, FileMode.Create);
            await LoopThroughParitionsAsync(partitions, directoryPath, start, end,
                async (uri, file, start, end, i) =>
                {
                    onProgress?.Invoke(i - start, end - start);
                    using var current = new FileStream(file, FileMode.Open);
                    await current.CopyToAsync(stream);
                });
        }

        var task = Task.Run(delegate
        {
            using var ffmpeg = new Process()
            {
                StartInfo = {
                FileName = "ffmpeg.exe",
                ArgumentList = {
                    "-i", tsFile,
                    "-c:a", "copy",
                    "-c:v", "copy",
                    mp4File
                }
            },
            };
            ffmpeg.Start();
            ffmpeg.WaitForInputIdle();
            ffmpeg.WaitForExit();
        });
        var tsSize = new FileInfo(tsFile).Length;
        while (!task.IsCompleted)
        {
            var progress = (double)(new FileInfo(mp4File).Length / tsSize);
            onProgress?.Invoke(Math.Min(95, (int)(progress * 95)), 100);
        }
        await task;
    }
}
