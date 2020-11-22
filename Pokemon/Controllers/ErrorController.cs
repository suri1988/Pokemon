using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Models;

namespace Pokemon.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)] //needed for swagger
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public ActionResult<ApiException> Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error; 

            return new ApiException(System.Net.HttpStatusCode.NotFound, exception.Message); 
        }
    }
}
