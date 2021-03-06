using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
/*
            var data = Configuration.GetChildren();
            if (data != null)
            {
                sb.AppendLine("Data: ");
                foreach (var i in data)
                {
                    sb.AppendLine("key = " + i.Key + " ::: Value = " + i.Value);
                }
            }
*/

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

            string text;
            using (StreamReader sr = new StreamReader("version.json"))
            {
                text = sr.ReadToEnd();
            }

            sb.AppendLine("===================");

            sb.AppendLine(text);

            return sb.ToString();
        }
    }
}
