using LibraryMS.Web.DTOs;
using LibraryMS.Web.Services.IServices;
using LibraryMS.Web.Utility;
using static LibraryMS.Web.Utility.SD;

namespace LibraryMS.Web.Services;

public class MembershipService(IBaseService baseService) : IMembershipService
{
    private readonly IBaseService _baseService = baseService;

    public async Task<ResponseDTO?> GetMembershipDetailsAsync()
    {
        RequestDTO requestDTO = new()
        {
            ApiType = ApiType.GET,
            Url = SD.MembershipAPIBase + $"/api/members/by-user",
            Data = default!
        };

        return await _baseService.SendAsync(requestDTO, withBearer: true);
    }
}