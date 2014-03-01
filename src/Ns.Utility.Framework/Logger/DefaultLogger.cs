using System;
using System.Collections.Generic;
using System.Linq;
using Ns.Utility.Framework.Common;
using Ns.Utility.Framework.Data.Contract;

namespace Ns.Utility.Framework.Logger
{
    /// <summary>
    /// Default logger
    /// </summary>
    public class DefaultLogger : ILogger
    {
        #region Fields

        private readonly IRepository<Log> repository;
        private IUnitOfWork unitOfWork;
        private readonly IWebHelper webHelper;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository">Log repository</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="webHelper">Web helper</param>
        public DefaultLogger(IRepository<Log> repository, IUnitOfWork unitOfWork, IWebHelper webHelper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.webHelper = webHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether a log level is enabled
        /// </summary>
        /// <param name="level">Log level</param>
        /// <returns>Result</returns>
        public virtual bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// Deletes a log item
        /// </summary>
        /// <param name="log">Log item</param>
        public virtual void DeleteLog(Log log)
        {
            if (log == null)
                throw new ArgumentNullException("log");

            repository.Delete(log.Id);
            unitOfWork.Commit();
        }

        /// <summary>
        /// Clears a log
        /// </summary>
        public virtual void ClearLog()
        {
            var log = repository.AsQueryable().ToList();
            foreach (var logItem in log)
            {
                repository.Delete(logItem.Id);
            }

            unitOfWork.Commit();
        }

        /// <summary>
        /// Gets all log items
        /// </summary>
        /// <param name="fromUtc">Log item creation from; null to load all records</param>
        /// <param name="toUtc">Log item creation to; null to load all records</param>
        /// <param name="message">Message</param>
        /// <param name="logLevel">Log level; null to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Log item collection</returns>
        public virtual IPagedList<Log> GetAllLogs(DateTime? fromUtc, DateTime? toUtc, string message, LogLevel? logLevel, int pageIndex, int pageSize)
        {
            var query = repository.AsQueryable();
            if (fromUtc.HasValue)
                query = query.Where(l => fromUtc.Value <= l.CreatedOnUtc);
            if (toUtc.HasValue)
                query = query.Where(l => toUtc.Value >= l.CreatedOnUtc);
            if (logLevel.HasValue)
            {
                int logLevelId = (int)logLevel.Value;
                query = query.Where(l => logLevelId == l.LogLevelId);
            }
            if (!String.IsNullOrEmpty(message))
                query = query.Where(l => l.ShortMessage.Contains(message) || l.FullMessage.Contains(message));
            query = query.OrderByDescending(l => l.CreatedOnUtc);

            var log = new PagedList<Log>(query, pageIndex, pageSize);
            return log;
        }

        /// <summary>
        /// Gets a log item
        /// </summary>
        /// <param name="logId">Log item identifier</param>
        /// <returns>Log item</returns>
        public virtual Log GetLogById(int logId)
        {
            if (logId == 0)
                return null;

            var log = repository.FindOne(x => x.Id == logId);
            return log;
        }

        /// <summary>
        /// Get log items by identifiers
        /// </summary>
        /// <param name="logIds">Log item identifiers</param>
        /// <returns>Log items</returns>
        public virtual IList<Log> GetLogByIds(IList<long> logIds)
        {
            if (logIds == null || logIds.Count == 0)
                return new List<Log>();

            var query = from l in repository.AsQueryable()
                        where logIds.Contains(l.Id)
                        select l;
            var logItems = query.ToList();
            //sort by passed identifiers
            var sortedLogItems = new List<Log>();
            foreach (int id in logIds)
            {
                var log = logItems.Find(x => x.Id == id);
                if (log != null)
                    sortedLogItems.Add(log);
            }
            return sortedLogItems;
        }

        /// <summary>
        /// Inserts a log item
        /// </summary>
        /// <param name="logLevel">Log level</param>
        /// <param name="shortMessage">The short message</param>
        /// <param name="fullMessage">The full message</param>
        /// <param name="user">The user.</param>
        /// <param name="userId">The user id.</param>
        /// <returns>
        /// A log item
        /// </returns>
        public Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", string user = "", int? userId = null)
        {
            var log = new Log
                {
                    LogLevel = logLevel,
                    ShortMessage = shortMessage,
                    FullMessage = fullMessage,
                    IpAddress = webHelper.GetCurrentIpAddress(),
                    User = user,
                    UserId = userId,
                    PageUrl = webHelper.GetThisPageUrl(true),
                    ReferrerUrl = webHelper.GetUrlReferrer(),
                    CreatedOnUtc = DateTime.UtcNow
                };

            repository.Add(log);
            unitOfWork.Commit();

            return log;
        }

        #endregion
    }
}
