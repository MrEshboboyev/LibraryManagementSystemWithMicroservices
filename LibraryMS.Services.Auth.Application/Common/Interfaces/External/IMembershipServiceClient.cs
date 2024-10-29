namespace LibraryMS.Services.Auth.Application.Common.Interfaces.External;

public interface IMembershipServiceClient
{
    Task<bool> CreateDefaultMembershipAsync(Guid userId);
}