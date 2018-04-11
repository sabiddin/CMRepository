using CM.Application.DataAccess;
using StructureMap;
using StructureMap.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CM.Data.Constants;

namespace CM.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IContainer container;

        public UnitOfWorkFactory(IContainer container)
        {
            this.container = container;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            var nested = container.GetNestedContainer(Profile.UnitOfWork);
            return nested.GetInstance<IUnitOfWork>();
        }
    }

    public class UnitOfWork : IUnitOfWork
    {
        public readonly IContainer container;
        public readonly IDboContext dboContext;

        [SetterProperty]
        public IDocumentRepository DocumentMetaData { get; set; }

        [SetterProperty]
        public IExceptionLogRepository Exceptions { get; set; }

        public UnitOfWork(IContainer container, IDboContext dboContext)
        {
            this.container = container;
            this.dboContext = dboContext;
        }
       

        public int SaveChanges()
        {
            return dboContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return dboContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            container.Dispose();
            dboContext.Dispose();
        }
    }
}
