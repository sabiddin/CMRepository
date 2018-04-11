using CM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Application.Interfaces
{
	public interface IExceptionLogService
	{
		Task<IEnumerable<ExceptionLog>> SelectCurrentExceptionData(int count, int pageIndex);
        Task LogException(Exception exception, int userId, int facilityId, int loginId, string pageName, string serverName);
        Task UpdateLastException();
        Task DeleteLastException();
    }
}
