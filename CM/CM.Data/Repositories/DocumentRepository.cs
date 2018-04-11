using CM.Application.DataAccess;
using CM.Domain.Entities;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Data.Repositories
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(IDboContext db) : base(db) { }

        public Task<List<Document>> SelectMetaData(string documentType, int patientId)
        {
            return db.DocumentMetaData.AsNoTracking()
                .Include(dl => dl.Visit)
                .Include(dl => dl.Visit.VisitType)
                .Include(dl => dl.LastUpdatedUser)
                .Where(doc => doc.RecActive == 1 && doc.DocumentType == documentType && doc.PatientID == patientId)
                .OrderByDescending(dl => dl.DocumentDate)
                .ThenByDescending(dl => dl.DocumentID)
                .ToListAsync();
        }
    }
}
