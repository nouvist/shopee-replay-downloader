using ShopeeReplayDownloader.JsonInterfaces;
using System.Text.RegularExpressions;

namespace ShopeeReplayDownloader;
public partial class MainForm : Form
{
    ShopeeReplayDownloader downloader = new();
    Dictionary<long, ShopeeRecordData> dictionary = new();
    List<Uri> partitions = new();

    public MainForm()
    {
        InitializeComponent();
        SetStatusReady();
    }

    private void SetStatusReady()
    {
        statusLabel.Text = "Siap";
    }
    private void SetStatusBusy(string text)
    {
        statusLabel.Text = text;
    }

    private long? SelectedId => (long?)recordListBox.SelectedItem;
    private ShopeeRecordData? SelectedRecord
    {
        get
        {
            var id = SelectedId;
            if (id == null) return null;
            return dictionary[(long)id];
        }
    }


    private void OnSelectRecord(object sender, EventArgs e)
    {
        var obj = SelectedRecord;
        if (obj == null) return;
        partitions.Clear();
        startNumeric.Value = 0;
        endNumeric.Value = 0;

        var formattedDuration = "";
        var seconds = obj.ReplayInfo.EstimatedDuration / 1e3;
        var minutes = double.Floor(seconds / 60);
        seconds %= 60;
        var hours = double.Floor(minutes / 60);
        minutes %= 60;

        if (hours > 0)
            formattedDuration += $"{hours}jam ";
        if (minutes > 0)
            formattedDuration += $"{minutes}menit ";
        if (seconds > 0)
            formattedDuration += $"{seconds}detik ";

        titleRichText.Text = obj.ReplayInfo.Title;
        usernameLabel.Text = obj.ReplayInfo.Username;
        durationLabel.Text = formattedDuration;
        likesLabel.Text = obj.ReplayInfo.LikeCount.ToString();
        viewsLabel.Text = obj.ReplayInfo.ViewCount.ToString();
        directoryTextBox.Text = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
            $"Shopee\\{obj.ReplayInfo.SessionId}\\{obj.ReplayInfo.RecordId}"
        );
    }

    private void OnSession(object sender, EventArgs e)
    {
        var button = (Button)sender;

        SetStatusBusy("Membaca session...");
        button.Enabled = false;
        OnSessionAsync().ContinueWith(task => Invoke(delegate
        {
            button.Enabled = true;
            SetStatusReady();
        }));
    }

    private async Task OnSessionAsync()
    {
        var id = sessionTextBox.Text.Trim();
        if (id.StartsWith("http"))
        {
            var groups = CaptureSessionRegex().Match(id).Groups;
            id = groups[1].Value.Trim();
            Invoke(delegate { sessionTextBox.Text = id; });
        }
        if (!ValidSessionRegex().IsMatch(id))
        {
            Invoke(delegate
            {
                MessageBox.Show(
                    "ID harus berupa numerik.",
                    "ID tidak valid!"
                );
            });
            return;
        }

        dictionary = await downloader.GetRecordsFromSessionAsync(id);

        Invoke(delegate
        {
            recordListBox.Items.Clear();
            foreach (var key in dictionary.Keys)
            {
                recordListBox.Items.Add(key);
            }
        });
    }

    [GeneratedRegex("session(?:%3D|%3d|=)([\\d]+)(?:%26|&)?")]
    private static partial Regex CaptureSessionRegex();
    [GeneratedRegex("(\\d+)")]
    private static partial Regex ValidSessionRegex();

    private void OnPrepare(object sender, EventArgs e) { _ = OnPrepareAsync(); }
    private async Task OnPrepareAsync()
    {
        var obj = SelectedRecord;
        if (obj == null) return;
        var path = directoryTextBox.Text;

        Invoke(SetStatusBusy,"Mendownload playlist hls...");
        Directory.CreateDirectory(path);
        partitions = await downloader.DownloadHlsPlaylistAsync(obj, path);
        Invoke(delegate
        {
            SetStatusReady();
            startNumeric.Value = 0;
            endNumeric.Value = partitions.Count;
        });
    }

    private void OnDownload(object sender, EventArgs e)
    {
        var button = (Button)sender;
        button.Enabled = false;
        OnDownloadAsync().ContinueWith(
            task => Invoke(delegate { button.Enabled = true; })
        );
    }

    private async Task OnDownloadAsync()
    {
        Invoke(SetStatusBusy, "Mendownload partisi...");
        await downloader.DownloadAllVideoPartitionsAsync(
            partitions,
            directoryTextBox.Text,
            (int)startNumeric.Value,
            (int)endNumeric.Value,
            (current, length) => Invoke(
                SetStatusBusy,
                $"Mendownload partisi {current}/{length}..."
            )
        );
        Invoke(SetStatusReady);
    }

    private void OnMerge(object sender, EventArgs e)
    {
        var button = (Button)sender;
        button.Enabled = false;
        OnMergeAsync().ContinueWith(
            task => Invoke(delegate { button.Enabled = true; })
        );
    }

    private async Task OnMergeAsync()
    {
        Invoke(SetStatusBusy, "Mengonversikan video...");
        await downloader.ConvertPartitionsToMp4Async(
            partitions,
            directoryTextBox.Text,
            (int)startNumeric.Value,
            (int)endNumeric.Value,
            (current, max) => Invoke(
                SetStatusBusy,
                $"Mengonversikan video {current}/{max}..."
            ));
    }
}