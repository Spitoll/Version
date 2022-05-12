using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            StringBuilder sb = new StringBuilder();

            var section = Configuration.GetSection("GitVersion");
            if (section != null)
            {
                sb.AppendLine("Section - GitVersion: " + section.Value);
                foreach (var i in section.GetChildren())
                {
                    sb.AppendLine("key = " + i.Key + " ::: Value = " + i.Value);
                }
            }
            else
            {
                sb.AppendLine("Section GitVersion is not exists.");
            }

            sb.AppendLine(Configuration["GitVersion_NuGetVersion"] + " ffffff1"
                + " --- "  + GetType().Assembly.GetName().Version.ToString());

            return sb.ToString();
        }
    }
}
