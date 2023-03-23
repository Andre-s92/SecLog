using SecLog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecLog.Application.IServices
{
    public interface ILogServices
    {
        Task<object> SaveLogContent();
        Task<IEnumerable<LogModel>> GetItemsLogByLimit(int limit);
        Task<IEnumerable<LogModel>> GetItemsByInterval(DateTime startDate, DateTime endDate, int limit);
        Task<IEnumerable<LogModel>> GetItemsByDescription(string search, int limit);
        Task<IEnumerable<LogModel>> GetItemsByIpServer(string ipServer, int limit);
        Task<IEnumerable<LogModel>> GetItemsByProcess(string process, int limit);
    }
}
