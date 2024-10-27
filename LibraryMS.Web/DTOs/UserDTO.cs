namespace LibraryMS.Web.DTOs;

public class UserDTO
{
    public required string Id { get; set; }
    public required string FullName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
}