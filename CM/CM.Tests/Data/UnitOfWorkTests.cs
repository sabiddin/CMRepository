using CM.Application.DataAccess;
using CM.Data;
using CM.Data.Repositories;
using CM.Infrasructure;
using Moq;
using StructureMap;
using System.Data;
using Xunit;
using static CM.Data.Constants;

namespace CM.Tests.Data
{
    public class UnitOfWorkTests
    {
        [Theory, AutoMoqData]
        public void FactoryCreatesUnitOfWorkWithNewNestedContainer(Mock<IDbTransaction> transactionMock, Mock<IDboContext> contextMock)
        {
            var container = new Container(new DataRegistry());
            container.Configure(_ => _.For<IDbTransaction>().Use(transactionMock.Object));
            container.Configure(_ => _.For<IDboContext>().Use(contextMock.Object));

            var uowFactory = new UnitOfWorkFactory(container);

            var uow1 = uowFactory.GetUnitOfWork();
            var uow2 = uowFactory.GetUnitOfWork();

            Assert.IsType<UnitOfWork>(uow1);
            Assert.NotSame(container, ((UnitOfWork)uow1).container);
            Assert.NotSame(((UnitOfWork)uow1).container, ((UnitOfWork)uow2).container);
        }

        [Theory, AutoMoqData]
        public void UnitOfWorkReusesSameDbContext(Mock<IDbTransaction> transactionMock, Mock<IDboContextFactory> contextFactoryMock)
        {
            contextFactoryMock.Setup(c => c.GetContext()).Returns(() => new Mock<IDboContext>().Object);

            var container = new Container(new DataRegistry());
            container.Configure(_ => _.For<IDbTransaction>().Use(transactionMock.Object));
            container.Configure(_ => _.For<IDboContext>().Use(() => contextFactoryMock.Object.GetContext()).AlwaysUnique());
            container.Configure(_ => _.Profile(Profile.UnitOfWork, p => p.For<IDboContext>().Use(c => contextFactoryMock.Object.GetContext())));

            var uowFactory = new UnitOfWorkFactory(container);

            using (var uow = uowFactory.GetUnitOfWork())
            {
                Assert.Same(((UnitOfWork)uow).dboContext, ((DocumentRepository)((UnitOfWork)uow).DocumentMetaData).db);
                Assert.Same(((UnitOfWork)uow).dboContext, ((ExceptionLogRepository)((UnitOfWork)uow).Exceptions).db);
            }

            contextFactoryMock.Verify(cf => cf.GetContext(), Times.Once);
        }

        // Maybe move into different test class?
        [Theory, AutoMoqData]
        public void RepositoriesUseDifferentDbContext(Mock<IDbTransaction> transactionMock, Mock<IDboContextFactory> contextFactoryMock)
        {
            contextFactoryMock.Setup(c => c.GetContext()).Returns(() => new Mock<IDboContext>().Object);

            var container = new Container(new DataRegistry());
            container.Configure(_ => _.For<IDbTransaction>().Use(transactionMock.Object));
            container.Configure(_ => _.For<IDboContext>().Use(() => contextFactoryMock.Object.GetContext()).AlwaysUnique());
            container.Configure(_ => _.Profile(Profile.UnitOfWork, p => p.For<IDboContext>().Use(c => contextFactoryMock.Object.GetContext())));

            var documentLibraryRepository = container.GetInstance<IDocumentRepository>();
            var exceptionLogRepository = container.GetInstance<IExceptionLogRepository>();

            Assert.NotSame(((ExceptionLogRepository)exceptionLogRepository).db, ((DocumentRepository)documentLibraryRepository).db);

            contextFactoryMock.Verify(cf => cf.GetContext(), Times.Exactly(2));
        }

        [Theory, AutoMoqData]
        public void UnitOfWorkContainerProducesCorrectContext(Mock<IDbTransaction> transactionMock, Mock<IDboContextFactory> contextFactoryMock)
        {
            contextFactoryMock.Setup(c => c.GetContext()).Returns(() => new Mock<IDboContext>().Object);

            var container = new Container(new DataRegistry());
            container.Configure(_ => _.For<IDbTransaction>().Use(transactionMock.Object));
            container.Configure(_ => _.For<IDboContext>().Use(() => contextFactoryMock.Object.GetContext()).AlwaysUnique());
            container.Configure(_ => _.Profile(Profile.UnitOfWork, p => p.For<IDboContext>().Use(c => contextFactoryMock.Object.GetContext())));

            var uowFactory = new UnitOfWorkFactory(container);

            using (var uow = uowFactory.GetUnitOfWork())
            {
                var nestedContainer = ((UnitOfWork)uow).container;

                // Show that using the global container produces a new dbo context
                Assert.NotSame(((UnitOfWork)uow).dboContext, ((DocumentRepository)container.GetInstance<IDocumentRepository>()).db);

                // Nested container produces the same dbo context
                Assert.Same(((UnitOfWork)uow).dboContext, ((DocumentRepository)nestedContainer.GetInstance<IDocumentRepository>()).db);
            }

            // Once for the global container and a second time for the nested container
            contextFactoryMock.Verify(cf => cf.GetContext(), Times.Exactly(2));
        }

        [Theory, AutoMoqData]
        public void UnitOfWorkDisposesDbContextAndNestedContainer(Mock<IContainer> containerMock, Mock<IDboContext> contextMock)
        {
            using (var uow = new UnitOfWork(containerMock.Object, contextMock.Object))
            {

            }

            contextMock.Verify(c => c.Dispose(), Times.Once);
            containerMock.Verify(c => c.Dispose(), Times.Once);
        }
    }
}
