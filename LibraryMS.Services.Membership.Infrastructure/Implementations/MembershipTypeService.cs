using AutoMapper;
using LibraryMS.Services.Membership.Application.Common.Interfaces;
using LibraryMS.Services.Membership.Application.DTOs;
using LibraryMS.Services.Membership.Application.Services;
using LibraryMS.Services.Membership.Domain.Entities;

namespace LibraryMS.Services.Membership.Infrastructure.Implementations;

public class MembershipTypeService(IUnitOfWork unitOfWork, IMapper mapper) : 
    BaseService(unitOfWork, mapper), IMembershipTypeService
{
    // Retrieves all membership types
    public async Task<IEnumerable<MembershipTypeDTO>> GetAllMembershipTypesAsync()
    {
        var allMembershipTypes = await _unitOfWork.MembershipType.GetAllAsync(
            includeProperties: "Members");

        var mappedMembershipTypes = _mapper.Map<IEnumerable<MembershipTypeDTO>>(allMembershipTypes);

        return mappedMembershipTypes;
    }

    // Retrieves a membership type by ID
    public async Task<MembershipTypeDTO?> GetMembershipTypeByIdAsync(Guid membershipTypeId)
    {
        var membershipType = await _unitOfWork.MembershipType.GetAsync(
            filter : m => m.Id == membershipTypeId,
            includeProperties: "Members")
            ?? throw new Exception("MembershipType not found!");

        var mappedMembershipType = _mapper.Map<MembershipTypeDTO>(membershipType);

        return mappedMembershipType;
    }

    // Adds a new membership type to the system
    public async Task<MembershipTypeDTO> AddMembershipTypeAsync(MembershipTypeDTO membershipTypeDTO)
    {
        var membershipTypeForDb = _mapper.Map<MembershipType>(membershipTypeDTO);

        await _unitOfWork.MembershipType.AddAsync(membershipTypeForDb);
        await _unitOfWork.SaveAsync();

        // mapping db fields
        _mapper.Map(membershipTypeForDb, membershipTypeDTO);

        return membershipTypeDTO;
    }

    // Updates an existing membership type
    public async Task<bool> UpdateMembershipTypeAsync(MembershipTypeDTO membershipTypeDTO)
    {
        var memberFromDb = await _unitOfWork.MembershipType.GetAsync(m => m.Id == membershipTypeDTO.Id)
            ?? throw new Exception("MembershipType not found!");

        // mapping fields
        _mapper.Map(membershipTypeDTO, memberFromDb);

        await _unitOfWork.MembershipType.UpdateAsync(memberFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Deletes a membership type by ID
    public async Task<bool> DeleteMembershipTypeAsync(Guid membershipTypeId)
    {
        var memberFromDb = await _unitOfWork.MembershipType.GetAsync(m => m.Id == membershipTypeId)
            ?? throw new Exception("MembershipType not found!");

        await _unitOfWork.MembershipType.RemoveAsync(memberFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }
}

