using CM.Application.DataAccess;
using CM.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Data.Repositories
{
    public class ExceptionLogRepository : BaseRepository<ExceptionLog>, IExceptionLogRepository
	{
		public ExceptionLogRepository(IDboContext db) : base(db) { }
        
		public Task<List<ExceptionLog>> SelectExceptionData(int count, int pageIndex)
		{
			var list =  db.ExceptionLogs.AsNoTracking()
				.Include(e => e.ExceptionUser)         
				.Include(e => e.ExceptionFacility)
				.OrderByDescending(e => e.ExceptionID)
				.Take(count)
				.ToListAsync();

			return list;
        }

        public Task<ExceptionLog> GetMostRecentException()
        {
            return db.ExceptionLogs
                .Include(e => e.ExceptionUser)
                .Include(e => e.ExceptionFacility)
                .OrderByDescending(e => e.ExceptionID)
                .FirstOrDefaultAsync();
        }
    }
}
