using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace dotnet_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private static readonly DateTime StartTime = DateTime.UtcNow;
        private static int _totalRequests = 0;

        [HttpGet]
        public IActionResult GetMetrics()
        {
            // Total request
            Interlocked.Increment(ref _totalRequests);
            // Uptime
            var uptime = DateTime.UtcNow - StartTime;
            // Using memory
            var memoryKB = GC.GetTotalMemory(false) / 1024;

            var data = new
            {
                UptimeSeconds = Math.Round(uptime.TotalSeconds, 2),
                TotalRequests = _totalRequests,
                MemoryKB = memoryKB,    
                Time = DateTime.Now
            };

            return Ok(data);
        }
    }
}
