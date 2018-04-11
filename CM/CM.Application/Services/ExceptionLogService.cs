using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CM.Application.DataAccess;
using CM.Application.Interfaces;
using CM.Domain.Entities;

namespace CM.Application.Services
{
	public class ExceptionLogService : IExceptionLogService
	{
		private readonly IExceptionLogRepository exceptionLogRepository;
        private readonly IUnitOfWorkFactory uowFactory;


        public ExceptionLogService(IUnitOfWorkFactory uowFactory, IExceptionLogRepository exceptionLogRepository) {
			this.exceptionLogRepository = exceptionLogRepository;
            this.uowFactory = uowFactory;

        }

		public async Task<IEnumerable<ExceptionLog>> SelectCurrentExceptionData(int count, int pageIndex)
		{
			var list = new List<ExceptionLog>();
			list = await exceptionLogRepository.SelectExceptionData(count, pageIndex);
			return list;
		}

        public async Task LogException(Exception exception, int userId, int facilityId, int loginId, string pageName, string serverName)
        {
            try
            {
                using (var db = uowFactory.GetUnitOfWork())
                {
                    var ex = new ExceptionLog()
                    {
                        UserID = userId,
                        FacilityID = facilityId,
                        Message = exception.Message,
                        Method = exception.TargetSite?.ToString(),
                        StackTrace = exception.StackTrace,
                        Time = DateTime.Now,
                        LoginID = loginId,
                        PageName = pageName,
                        ServerName = serverName
                    };

                    db.Exceptions.Add(ex);

                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This is just a test method, it has no real use
        public async Task UpdateLastException()
        {
            try
            {
                using (var db = uowFactory.GetUnitOfWork())
                {
                    var ex = await db.Exceptions.GetMostRecentException();

                    ex.Message = "Updated Message!";

                    db.Exceptions.Update(ex);

                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This is just a test method, it has no real use
        public async Task DeleteLastException()
        {
            try
            {
                using (var db = uowFactory.GetUnitOfWork())
                {
                    var ex = await db.Exceptions.GetMostRecentException();

                    db.Exceptions.Delete(ex);

                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
