using AutoMapper;
using SecLog.Application.IServices;
using SecLog.Data.IRepository;
using SecLog.Domain.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;


namespace SecLog.Application.Services
{
    public class LogServices : ILogServices
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;
        public LogServices(IBaseRepository baseRepository,ILogRepository logRepository, IMapper mapper )
        { 
        _baseRepository = baseRepository;
        _logRepository = logRepository;
        _mapper = mapper;
        }

        public async Task<object> SaveLogContent()
        {
            var logContent = await _logRepository.GetItemsLogByLimit(10);
            if (logContent.Count() > 0) return "the log has already been imported";
            Stopwatch stopwatch = Stopwatch.StartNew();
            var log = ReadLogFile();                
                _baseRepository.Add(log);   
            if (await _baseRepository.SaveChangesAsync())
            {
                stopwatch.Stop();
                return $"the log file was successfully imported, total of {log.Count()} items in {stopwatch.Elapsed}";
            }
            return null; 
        }
        public IEnumerable<LogModel> ReadLogFile()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload/auth.log");
                string content = string.Empty;
                List<LogModel> logs = new List<LogModel>();
                if (File.Exists(filePath))
                {

                    content =  File.ReadAllText(filePath);
                    string[] lines = content.Split('\n');
                    foreach (string line in lines)
                    {

                        if (!String.IsNullOrEmpty(line))
                        {
                            string month = line.Substring(0, 3);
                            string day = line.Substring(4,2).Replace(" ","0");
                            string time = line.Substring(7, 8);
                            DateTime date = DateTime.ParseExact((month+" "+day+" "+time), "MMM dd HH:mm:ss", CultureInfo.InvariantCulture);
                            DateTime dateFormated = date.Month > DateTime.Now.Month? date.AddYears(-1) : date;                           
                            string Server = line.Substring(19, 14).Replace("-", ".");
                            string Process = line.Substring(33, 11);
                            string Description = line.Substring(46);
                            LogModel log = new LogModel
                            {
                                DateTime = dateFormated,
                                Server = Server,
                                Process = Process,
                                Description = Description
                            };
                            logs.Add(log);
                        }   

                    }


                }
                
                return logs;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public async Task<IEnumerable<LogModel>> GetItemsLogByLimit(int limit)
        {
            try
            {
                var log = await _logRepository.GetItemsLogByLimit(limit);
                if (log == null) return null;
 
                return log;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<LogModel>> GetItemsByInterval(DateTime startDate, DateTime endDate, int limit)
        {
            try
            {
                var log = await _logRepository.GetItemsByInterval(startDate, endDate, limit);
                if (log == null) return null;

                return log;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<LogModel>> GetItemsByDescription(string search, int limit)
        {
            try
            {
                var log = await _logRepository.GetItemsByDescription(search, limit);
                if (log == null) return null;

                return log;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<LogModel>> GetItemsByIpServer(string ipServer, int limit)
        {
            try
            {
                var log = await _logRepository.GetItemsByIpServer(ipServer, limit);
                if (log == null) return null;

                return log;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<LogModel>> GetItemsByProcess(string process, int limit)
        {
            try
            {
                var log = await _logRepository.GetItemsByProcess(process, limit);
                if (log == null) return null;

                return log;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
