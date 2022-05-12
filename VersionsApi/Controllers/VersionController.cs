using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersionsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public VersionController(IConfiguration configuration)
            : base()
        {
            Configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            return Configuration["GitVersion.NuGetVersion"] + " ffffff";
            //return GetType().Assembly.GetName().Version.ToString();
        }
    }
}
