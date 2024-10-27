namespace LibraryMS.Web.Utility;

public class SD
{
    public static string? AuthAPIBase { get; set; }
    public static string? CatalogAPIBase { get; set; }
    public static string? LoanAPIBase { get; set; }
    public static string? MembershipAPIBase { get; set; }

    public const string RoleArchitect = "Architect";
    public const string RoleUser = "User";
    public const string TokenCookie = "JWTToken";
    
    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}
