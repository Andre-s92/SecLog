using Microsoft.EntityFrameworkCore;
using SecLog.Data.Context;
using SecLog.Data.IRepository;
using SecLog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SecLog.Data.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly DataContext _context;
        public LogRepository(DataContext context) 
        {
         _context = context;
        }
         //aqui filtramos todo os registro por limite.
        public async Task<IEnumerable<LogModel>> GetItemsLogByLimit(int limit)
        {
            IQueryable<LogModel> query = _context.Logs.AsNoTracking();
            return await query.OrderBy(e => e.Id).Take(limit).ToArrayAsync();
        }
        //aqui pesquisamos os logs por um intervalo de datas e um limite de registro.
        public async Task<IEnumerable<LogModel>> GetItemsByInterval(DateTime startDate, DateTime endDate, int limit)
        {
            IQueryable<LogModel> query = _context.Logs.AsNoTracking()
                .Where(e => e.DateTime >= startDate && e.DateTime <= endDate);
            return await query.OrderBy(e => e.Id).Take(limit).ToArrayAsync();
        }

        //aqui filtramos os registros por descrição que contenha uma palavra que o usuario digitou com limite de registro.
        public async Task<IEnumerable<LogModel>> GetItemsByDescription(string Search, int limit)
        {
            IQueryable<LogModel> query = _context.Logs.AsNoTracking()
                .Where(e => e.Description.Contains(Search));
            return await query.OrderBy(e => e.Id).Take(limit).ToArrayAsync();
        }
        //aqui filtramos os registros por ip do servidor e limite de registro.
        public async Task<IEnumerable<LogModel>> GetItemsByIpServer(string ipServer, int limit)
        {
            IQueryable<LogModel> query = _context.Logs.AsNoTracking()
                .Where(e => e.Server.Contains(ipServer));
            return await query.OrderBy(e => e.Id).Take(limit).ToArrayAsync();
        }
        //aqui filtramos os registros por processo e limite de registros.
        public async Task<IEnumerable<LogModel>> GetItemsByProcess(string process, int limit)
        {
            IQueryable<LogModel> query = _context.Logs.AsNoTracking()
                .Where(e => e.Process.Contains(process));
            return await query.OrderBy(e => e.Id).Take(limit).ToArrayAsync();
        }

    }
}
