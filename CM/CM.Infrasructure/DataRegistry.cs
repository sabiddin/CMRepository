using CM.Application.DataAccess;
using CM.Data;
using CM.Data.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Infrasructure
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            Scan(s => {
                s.Assembly("CM.Data");
                s.IncludeNamespace("CM.Application.DataAccess");
                s.IncludeNamespace("CM.Data.Services");
                s.IncludeNamespace("CM.Data.Repositories");
                s.WithDefaultConventions();
            });
            Policies.SetAllProperties(p =>
            {
                p.WithAnyTypeFromNamespace("CM.Application.DataAccess");
                p.WithAnyTypeFromNamespace("CM.Data.Services");
                p.WithAnyTypeFromNamespace("CM.Data.Repositories");
                p.WithAnyTypeFromNamespace("CM.Data");
            });
            For<IUnitOfWorkFactory>().Use<UnitOfWorkFactory>();
            For<IUnitOfWork>().Use<UnitOfWork>().AlwaysUnique();
            For<ITransactionFactory>().Use<TransactionFactory>();
            For<IDbTransaction>().Use(t => t.GetInstance<ITransactionFactory>().GetTransaction());
            For<IDboContextFactory>().Use<DboContextFactory>();
            For<IDboContext>().Use(d => d.GetInstance<IDboContextFactory>().GetContext());
            Profile(Constants.Profile.UnitOfWork, p => p.For<IDboContext>().Use(c => c.GetInstance<IDboContextFactory>().GetContext()));   
            
        }
    }
}
