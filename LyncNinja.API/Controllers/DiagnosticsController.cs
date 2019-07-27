using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Reflection;

namespace LyncNinja.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticsController : Controller
    {
        /// <summary>
        /// Verifies system status and other diagnostics information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Status")]
        public IActionResult Status()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string version = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;

            return Ok(new
            {
                ApplicationName = assembly.GetName().Name,
                ApplicationHost = Environment.MachineName,
                Version = version
            });
        }
    }
}
