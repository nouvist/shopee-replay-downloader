using System.Text.Json.Serialization;

namespace ShopeeReplayDownloader.JsonInterfaces;

partial class ShopeeSession
{
    [JsonPropertyName("err_code")]
    public long ErrorCode { get; set; }

    [JsonPropertyName("err_msg")]
    public required string ErrorMessage { get; set; }

    [JsonPropertyName("data")]
    public required ShopeeSessionData Data { get; set; }
}

partial class ShopeeSessionData
{
    [JsonPropertyName("record_ids")]
    public required long[] RecordIds { get; set; }
}
public partial class ShopeeRecord
{
    [JsonPropertyName("err_code")]
    public long ErrorCode { get; set; }

    [JsonPropertyName("err_msg")]
    public required string ErrorMessage { get; set; }

    [JsonPropertyName("data")]
    public required ShopeeRecordData Data { get; set; }
}

public partial class ShopeeRecordData
{
    [JsonPropertyName("endpage_url")]
    public required Uri EndpageUrl { get; set; }

    [JsonPropertyName("replay_info")]
    public required ReplayInfo ReplayInfo { get; set; }

    [JsonPropertyName("share_url")]
    public required Uri ShareUrl { get; set; }
}

public partial class ReplayInfo
{
    [JsonPropertyName("record_id")]
    public long RecordId { get; set; }

    [JsonPropertyName("session_id")]
    public long SessionId { get; set; }

    [JsonPropertyName("file_format")]
    public required string FileFormat { get; set; }

    [JsonPropertyName("record_url")]
    public required Uri RecordUrl { get; set; }

    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [JsonPropertyName("view_count")]
    public long ViewCount { get; set; }

    [JsonPropertyName("room_id")]
    public long RoomId { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("cover")]
    public required string Cover { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("member_cnt")]
    public long MemberCnt { get; set; }

    [JsonPropertyName("like_cnt")]
    public long LikeCount { get; set; }

    [JsonPropertyName("items_cnt")]
    public long ItemsCount { get; set; }

    [JsonPropertyName("shop_id")]
    public long ShopId { get; set; }

    [JsonPropertyName("nickname")]
    public required string Nickname { get; set; }

    [JsonPropertyName("avatar")]
    public required string Avatar { get; set; }

    [JsonPropertyName("total_views")]
    public long TotalViews { get; set; }

    [JsonPropertyName("is_generated")]
    public bool IsGenerated { get; set; }

    [JsonPropertyName("is_passed")]
    public bool IsPassed { get; set; }

    [JsonPropertyName("is_show_on_shoppage")]
    public bool IsShowOnShoppage { get; set; }

    [JsonPropertyName("is_recommend")]
    public bool IsRecommend { get; set; }

    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }

    [JsonPropertyName("is_test")]
    public bool IsTest { get; set; }

    [JsonPropertyName("flag")]
    public long Flag { get; set; }

    [JsonPropertyName("share_cnt")]
    public long ShareCnt { get; set; }

    [JsonPropertyName("is_seller")]
    public bool IsSeller { get; set; }

    public long EstimatedDuration { get => EndTime - StartTime; }
}
