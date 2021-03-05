using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NICH_WebApp.Models;

namespace NICH_WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SRWStaffScheduleController : Controller
    {
        public IConfiguration Configuration { get; set; }
        private SRWStaffScheduleDataAccessLayer SRWStaffScheduleDataAccessLayer;

        public SRWStaffScheduleController(IConfiguration _configuration)
        {
            Configuration = _configuration;
            SRWStaffScheduleDataAccessLayer = new SRWStaffScheduleDataAccessLayer(Configuration);
        }

        public IEnumerable<SRWStaffSchedule> Get(int idSrw, int idDept)
        {
            return SRWStaffScheduleDataAccessLayer.GetSRWStaffSchedule(idSrw, idDept);
        }
    }
}
