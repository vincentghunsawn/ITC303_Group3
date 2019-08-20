using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreFitness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;

namespace CoreFitness.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/HttpStatusErrorHandler/{statusCode}")]
        [AllowAnonymous]
        public IActionResult HttpStatusErrorHandler(int statusCode)
        {
            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "The requested resource can not be found";
                    break;
            }

            return View("NotFound");
        }

        [Route("Home/Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();


            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;

            return View("Error");

        }
    }
}
