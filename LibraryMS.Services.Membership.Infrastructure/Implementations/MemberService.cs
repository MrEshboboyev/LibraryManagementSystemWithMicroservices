using AutoMapper;
using LibraryMS.Services.Membership.Application.Common.Interfaces;
using LibraryMS.Services.Membership.Application.DTOs;
using LibraryMS.Services.Membership.Application.Services;
using LibraryMS.Services.Membership.Domain.Entities;

namespace LibraryMS.Services.Membership.Infrastructure.Implementations;

public class MemberService(IUnitOfWork unitOfWork, IMapper mapper) : 
    BaseService(unitOfWork, mapper), IMemberService
{
    public async Task<IEnumerable<MemberDTO>> GetAllMembersAsync()
    {
        var allMembers = await _unitOfWork.Member.GetAllAsync(
            includeProperties: "MembershipType,LoanHistories");

        var mappedMembers = _mapper.Map<IEnumerable<MemberDTO>>(allMembers);

        return mappedMembers;
    }

    // Retrieves a member by their unique ID
    public async Task<MemberDTO?> GetMemberByIdAsync(Guid memberId)
    {
        var member = await _unitOfWork.Member.GetAsync(
            filter: m => m.Id == memberId,
            includeProperties: "MembershipType,LoanHistories")
            ?? throw new Exception("Member not found!");

        var mappedMember = _mapper.Map<MemberDTO>(member);

        return mappedMember;
    }

    // Adds a new member to the system
    public async Task<MemberDTO> AddMemberAsync(MemberDTO memberDTO)
    {
        var memberForDb = _mapper.Map<Member>(memberDTO);

        await _unitOfWork.Member.AddAsync(memberForDb);
        await _unitOfWork.SaveAsync();

        // mapping db fields
        _mapper.Map(memberForDb, memberDTO);

        return memberDTO;
    }

    // Updates the information of an existing member
    public async Task<bool> UpdateMemberAsync(MemberDTO memberDTO)
    {
        var memberFromDb = await _unitOfWork.Member.GetAsync(m => m.Id == memberDTO.Id)
            ?? throw new Exception("Member not found!");

        // mapping fields
        _mapper.Map(memberDTO, memberFromDb);

        await _unitOfWork.Member.UpdateAsync(memberFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Deletes a member by their ID
    public async Task<bool> DeleteMemberAsync(Guid memberId)
    {
        var memberFromDb = await _unitOfWork.Member.GetAsync(m => m.Id == memberId)
            ?? throw new Exception("Member not found!");

        await _unitOfWork.Member.RemoveAsync(memberFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Checks if a member is active based on their ID
    public async Task<bool> IsMemberActiveAsync(Guid memberId)
    {
        var memberFromDb = await _unitOfWork.Member.GetAsync(m => m.Id == memberId)
            ?? throw new Exception("Member not found!");

        return memberFromDb.IsActive;
    }
}