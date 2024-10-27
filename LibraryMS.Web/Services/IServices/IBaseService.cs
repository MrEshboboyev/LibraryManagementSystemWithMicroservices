using LibraryMS.Web.DTOs;

namespace LibraryMS.Web.Services.IServices;

public interface IBaseService
{
    Task<ResponseDTO?> SendAsync(RequestDTO requestDTO, bool withBearer = true);
}

