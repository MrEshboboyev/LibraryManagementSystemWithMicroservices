using LibraryMS.Services.Membership.Application.DTOs;

namespace LibraryMS.Services.Membership.Application.Services;

public interface IMembershipTypeService
{
    // Retrieves all membership types
    Task<IEnumerable<MembershipTypeDTO>> GetAllMembershipTypesAsync();

    // Retrieves a membership type by ID
    Task<MembershipTypeDTO?> GetMembershipTypeByIdAsync(Guid membershipTypeId);

    // Adds a new membership type to the system
    Task<MembershipTypeDTO> AddMembershipTypeAsync(MembershipTypeDTO membershipTypeDTO);

    // Updates an existing membership type
    Task<bool> UpdateMembershipTypeAsync(MembershipTypeDTO membershipTypeDTO);

    // Deletes a membership type by ID
    Task<bool> DeleteMembershipTypeAsync(Guid membershipTypeId);
}