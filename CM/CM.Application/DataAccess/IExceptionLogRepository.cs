using CM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Application.DataAccess
{
	public interface IExceptionLogRepository: IRepository<ExceptionLog>
	{
		Task<List<ExceptionLog>> SelectExceptionData(int count, int pageIndex);
        Task<ExceptionLog> GetMostRecentException();

    }
}
