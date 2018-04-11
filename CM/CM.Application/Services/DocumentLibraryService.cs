using CM.Application.DataAccess;
using CM.Application.Interfaces;
using CM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Application.Services
{
    public class DocumentLibraryService : IDocumentLibraryService
    {
        private readonly IUnitOfWorkFactory uowFactory;
        private readonly IDocumentRepository documentLibraryRepository;

        public DocumentLibraryService(IUnitOfWorkFactory uowFactory, IDocumentRepository documentLibraryRepository)
        {
            this.uowFactory = uowFactory;
            this.documentLibraryRepository = documentLibraryRepository;
        }

        public async Task<IEnumerable<Document>> MakeUpdatesWithTransaction(string documentType, int patientId)
        {
            var list = new List<Document>();

            using (var db = uowFactory.GetUnitOfWork())
            {
                list = await db.DocumentMetaData.SelectMetaData(documentType, patientId);

                var item = await db.DocumentMetaData.FindByIdAsync(list[0].DocumentID);
                list.Remove(item);

                await db.SaveChangesAsync();
            }

            return list;
        }

        public async Task<IEnumerable<Document>> SelectCurrentMetaData(string documentType, int patientId)
        {
            var list = new List<Document>();

            list = await documentLibraryRepository.SelectMetaData(documentType, patientId);
            var documentIdToRemove = list[0].DocumentID; // leaky abstraction :(

            var item = await documentLibraryRepository.FindByAsync(d => d.DocumentID == documentIdToRemove);
            list.Remove(item[0]);

            return list;
        }
    }
}
