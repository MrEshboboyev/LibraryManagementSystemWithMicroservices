using LibraryMS.Services.Catalog.Application.DTOs;

namespace LibraryMS.Services.Catalog.Application.Services;

public interface IPublisherService
{
    // Retrieves all publishers
    Task<IEnumerable<PublisherDTO>> GetAllPublishersAsync();

    // Retrieves a publisher by their unique ID
    Task<PublisherDTO?> GetPublisherByIdAsync(Guid publisherId);

    // Adds a new publisher to the catalog
    Task<PublisherDTO> AddPublisherAsync(PublisherDTO publisherDTO);

    // Updates an existing publisher's information
    Task<bool> UpdatePublisherAsync(PublisherDTO publisherDTO);

    // Deletes a publisher by their ID
    Task<bool> DeletePublisherAsync(Guid publisherId);
}