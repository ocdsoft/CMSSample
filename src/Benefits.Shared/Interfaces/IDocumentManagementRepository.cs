using Benefits.Shared.Models.Repository;
using System.Collections.Generic;

namespace Benefits.Shared.Interfaces
{
    public interface IDocumentManagementRepository
    {
        List<Publication> GetPublications(string publicationName);
    }
}