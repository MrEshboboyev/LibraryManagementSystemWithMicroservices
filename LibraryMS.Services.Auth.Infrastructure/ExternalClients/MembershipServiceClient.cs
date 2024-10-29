using LibraryMS.Services.Auth.Application.Common.Interfaces.External;
using System.Net.Http.Json;

namespace LibraryMS.Services.Auth.Infrastructure.ExternalClients;

public class MembershipServiceClient(HttpClient httpClient) : IMembershipServiceClient
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<bool> CreateDefaultMembershipAsync(string userId)
    {
        var response = await _httpClient.PostAsJsonAsync<bool>($"/api/members/create-default/{userId}", default);
        return response.IsSuccessStatusCode;
    }
}