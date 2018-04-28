using CM.Application.DataAccess;
using CM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Data.Repositories
{
    public class RepresentativeRepository : BaseRepository<Representative>, IRepresentativeRepository
    {
        public RepresentativeRepository(IDboContext db) : base(db) { }
    }
}
