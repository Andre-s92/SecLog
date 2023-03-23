using Microsoft.AspNetCore.Mvc;
using SecLog.Application.IServices;

namespace SecLog.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogServices _logServices;

        public LogController(ILogServices logServices) 
        {
        _logServices = logServices;
        }


        [HttpPost]
        [Route("importlog")]
        public async Task<IActionResult> SaveLogContent()
        {
            try
            {
               
                return Ok( await _logServices.SaveLogContent());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"log error : {ex.Message}");
            }

        }
        [HttpGet("GetItemsLogByLimit/{limit}")]
        public async Task<IActionResult> GetItemsLogByLimit(int limit)
        {
            try
            {
                var logs = await _logServices.GetItemsLogByLimit(limit);
                if (logs == null) return NotFound("Items log not found");
                return Ok(logs);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"log error : {ex.Message}");
            }

        }
        [HttpGet("GetItemsByInterval/{startDate}/{endDate}/{limit}")]
        public async Task<IActionResult> GetItemsByInterval(DateTime startDate, DateTime endDate, int limit)
        {
            try
            {
                var logs = await _logServices.GetItemsByInterval(startDate, endDate, limit);
                if (logs == null) return NotFound("Items log not found on this interval");
                return Ok(logs);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"log error : {ex.Message}");
            }

        }
        [HttpGet("GetItemsByDescription/{description}/{limit}")]
        public async Task<IActionResult> GetItemsByDescription(string description, int limit)
        {
            try
            {
                var logs = await _logServices.GetItemsByDescription(description, limit);
                if (logs == null) return NotFound("Items log not found");
                return Ok(logs);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"log error : {ex.Message}");
            }

        }
        [HttpGet("GetItemsByIpServer/{ipServer}/{limit}")]
        public async Task<IActionResult> GetItemsByIpServer(string ipServer, int limit)
        {
            try
            {
                var logs = await _logServices.GetItemsByIpServer(ipServer, limit);
                if (logs == null) return NotFound("Items log not found");
                return Ok(logs);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"log error : {ex.Message}");
            }

        }
        [HttpGet("GetItemsByProcess/{process}/{limit}")]
        public async Task<IActionResult> GetItemsByProcess(string process, int limit)
        {
            try
            {
                var logs = await _logServices.GetItemsByProcess(process, limit);
                if (logs == null) return NotFound("Items log not found");
                return Ok(logs);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"log error : {ex.Message}");
            }

        }
    }
}
