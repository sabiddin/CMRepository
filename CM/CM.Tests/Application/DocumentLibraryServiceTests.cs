using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Application.DataAccess;
using CM.Services;
using CM.Domain.Entities;
using Moq;
using Xunit;

namespace CM.Tests.Application
{
	public class DocumentLibraryServiceTests
	{
		[Theory, AutoMoqData]
		public async Task ShouldRemoveFirstItem(Mock<IUnitOfWorkFactory> uowFactoryMock, Mock<IUnitOfWork> uowMock, Mock<IDocumentRepository> documentLibraryRepositoryMock, Mock<Document> documentLibraryMock)
		{
			uowFactoryMock.Setup(u => u.GetUnitOfWork()).Returns(uowMock.Object);
			uowMock.Setup(u => u.DocumentMetaData.SelectMetaData(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new List<Document> { documentLibraryMock.Object });
			uowMock.Setup(u => u.DocumentMetaData.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(documentLibraryMock.Object);

			var service = new DocumentLibraryService(uowFactoryMock.Object, documentLibraryRepositoryMock.Object);
			var documentList = await service.MakeUpdatesWithTransaction("document", 1);

			Assert.Empty(documentList);
			uowMock.Verify(u => u.SaveChangesAsync(), Times.Once);
		}

	}
}
