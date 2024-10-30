using LibraryMS.Web.DTOs;

namespace LibraryMS.Web.Services.IServices;

public interface IMembershipService
{
    Task<ResponseDTO?> GetMembershipDetailsAsync();
}