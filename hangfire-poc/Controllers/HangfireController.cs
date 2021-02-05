using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hangfire_poc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Test");
        }

        [HttpPost]
        [Route("[action]")]

        public IActionResult hangfireJob()
        {
            var jobId = BackgroundJob.Enqueue(() => SendEmail("POC"));

            return Ok($"Job Id: {jobId} | POC Success");
        }

        public void SendEmail(string text)
        {
            Console.WriteLine(text);
        }
    }
}
