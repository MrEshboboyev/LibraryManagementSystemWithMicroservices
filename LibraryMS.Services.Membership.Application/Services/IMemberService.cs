using LibraryMS.Services.Membership.Application.DTOs;

namespace LibraryMS.Services.Membership.Application.Services;

public interface IMemberService
{
    // Retrieves all members
    Task<IEnumerable<MemberDTO>> GetAllMembersAsync();

    // Retrieves a member by their unique ID
    Task<MemberDTO?> GetMemberByIdAsync(Guid memberId);

    // Adds a new member to the system
    Task<MemberDTO> AddMemberAsync(MemberDTO memberDTO);

    // Updates the information of an existing member
    Task<bool> UpdateMemberAsync(MemberDTO memberDTO);

    // Deletes a member by their ID
    Task<bool> DeleteMemberAsync(Guid memberId);

    // Checks if a member is active based on their ID
    Task<bool> IsMemberActiveAsync(Guid memberId);
}