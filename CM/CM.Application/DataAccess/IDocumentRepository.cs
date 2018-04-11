using CM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Application.DataAccess
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task<List<Document>> SelectMetaData(string documentType, int patientId);
    }
}
