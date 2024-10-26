using AutoMapper;
using LibraryMS.Services.Catalog.Application.Common.Interfaces;
using LibraryMS.Services.Catalog.Application.DTOs;
using LibraryMS.Services.Catalog.Application.Services;
using LibraryMS.Services.Catalog.Domain.Entities;

namespace LibraryMS.Services.Catalog.Infrastructure.Implementations;

public class PublisherService(IUnitOfWork unitOfWork, IMapper mapper) : 
    BaseService(unitOfWork, mapper), IPublisherService
{
    // Retrieves all publishers
    public async Task<IEnumerable<PublisherDTO>> GetAllPublishersAsync()
    {
        var allPublishers = await _unitOfWork.Publisher.GetAllAsync(
            includeProperties: "Books");

        var mappedPublishers = _mapper.Map<IEnumerable<PublisherDTO>>(allPublishers);

        return mappedPublishers;
    }

    // Retrieves a publisher by ID
    public async Task<PublisherDTO?> GetPublisherByIdAsync(Guid publisherId)
    {
        var publisher = await _unitOfWork.Publisher.GetAsync(
            filter : m => m.Id == publisherId,
            includeProperties: "Books")
            ?? throw new Exception("Publisher not found!");

        var mappedPublisher = _mapper.Map<PublisherDTO>(publisher);

        return mappedPublisher;
    }

    // Adds a new publisher to the catalog
    public async Task<PublisherDTO> AddPublisherAsync(PublisherDTO publisherDTO)
    {
        var publisherForDb = _mapper.Map<Publisher>(publisherDTO);

        await _unitOfWork.Publisher.AddAsync(publisherForDb);
        await _unitOfWork.SaveAsync();

        // mapping db fields
        _mapper.Map(publisherForDb, publisherDTO);

        return publisherDTO;
    }

    // Updates an existing publisher's information
    public async Task<bool> UpdatePublisherAsync(PublisherDTO publisherDTO)
    {
        var memberFromDb = await _unitOfWork.Publisher.GetAsync(m => m.Id == publisherDTO.Id)
            ?? throw new Exception("Publisher not found!");

        // mapping fields
        _mapper.Map(publisherDTO, memberFromDb);

        await _unitOfWork.Publisher.UpdateAsync(memberFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Deletes a publisher by their ID
    public async Task<bool> DeletePublisherAsync(Guid publisherId)
    {
        var memberFromDb = await _unitOfWork.Publisher.GetAsync(m => m.Id == publisherId)
            ?? throw new Exception("Publisher not found!");

        await _unitOfWork.Publisher.RemoveAsync(memberFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }
}

