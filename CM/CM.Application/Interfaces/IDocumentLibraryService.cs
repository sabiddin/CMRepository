using CM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Application.Interfaces
{
    public interface IDocumentLibraryService
    {
        Task<IEnumerable<Document>> MakeUpdatesWithTransaction(string documentType, int patientId);
        Task<IEnumerable<Document>> SelectCurrentMetaData(string documentType, int patientID);
    }
}
