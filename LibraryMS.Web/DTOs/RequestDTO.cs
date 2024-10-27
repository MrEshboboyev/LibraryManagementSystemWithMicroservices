using static LibraryMS.Web.Utility.SD;

namespace LibraryMS.Web.DTOs;

public class RequestDTO
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public required string Url { get; set; }
    public required object Data { get; set; }
    public string? AccessToken { get; set; }
}
