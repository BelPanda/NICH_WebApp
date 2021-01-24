using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NICH_WebApp.Models;
using Microsoft.Extensions.Configuration;

namespace NICH_WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SRWController : ControllerBase
    {

        public IConfiguration Configuration { get; set; }
        private SRWDataAccessLayer SRWDataAccessLayer;

        public SRWController(IConfiguration _configuration)
        {
            Configuration = _configuration;
            SRWDataAccessLayer = new SRWDataAccessLayer(Configuration);
        }


        [HttpGet]
        public IEnumerable<SRW> Index()
        {
            return SRWDataAccessLayer.GetAllSRW();
        }

        public IEnumerable<SRW> GET(bool isAll)
        {
            return SRWDataAccessLayer.GetAllSRW();
        }

    }
}
