using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace WebAPISampleAPI.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger _logger;

        public ErrorController(ILogger logger)
        {
            _logger = logger;
        }

        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.Error(context.Error, "Error:");

            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException("Houston, we have a problem:");
            }
            
            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

        [Route("/error")]
        public IActionResult Error() 
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.Error(context.Error, "Error: ");
            return Problem(); 
        }
    }
}