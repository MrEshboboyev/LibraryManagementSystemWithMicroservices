using LibraryMS.Web.DTOs;
using LibraryMS.Web.Services.IServices;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static LibraryMS.Web.Utility.SD;

namespace LibraryMS.Web.Services;

public class BaseService(IHttpClientFactory httpClientFactory, 
    ITokenProvider tokenProvider) : IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ITokenProvider _tokenProvider = tokenProvider;

    public async Task<ResponseDTO?> SendAsync(RequestDTO requestDTO, bool withBearer = true)
    {
        try
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("LibraryMSAPI");
            HttpRequestMessage message = new();

            // add content type
            message.Headers.Add("Accept", "application/json");

            // token handling
            if (withBearer)
            {
                var token = _tokenProvider.GetToken();

                // add token to message header
                message.Headers.Add("Authorization", $"Bearer {token}");
            }

            // request URI initialize
            message.RequestUri = new Uri(requestDTO.Url);

            // data handling for message content
            if (requestDTO.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), 
                    Encoding.UTF8,
                    mediaType: "application/json");
            }

            HttpResponseMessage? apiResponse = null;

            // HTTP method handling
            message.Method = requestDTO.ApiType switch
            {
                ApiType.POST => HttpMethod.Post,
                ApiType.DELETE => HttpMethod.Delete,
                ApiType.PUT => HttpMethod.Put,
                _ => HttpMethod.Get
            };

            // getting response from API
            apiResponse = await httpClient.SendAsync(message);


            // error handling or response serialize
            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { IsSuccess = false, Message = "Not Found" };
                case HttpStatusCode.Forbidden:
                    return new() { IsSuccess = false, Message = "Access Denied" };
                case HttpStatusCode.Unauthorized:
                    return new() { IsSuccess = false, Message = "Unauthorized" };
                case HttpStatusCode.InternalServerError:
                    return new() { IsSuccess = false, Message = "Internal Server Error" };
                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                    return apiResponseDto;
            }
        }
        catch (Exception ex)
        {
            ResponseDTO responseDTO = new()
            {
                Message = ex.Message.ToString(),
                IsSuccess = false
            };
            return responseDTO;
        }
    }
}

