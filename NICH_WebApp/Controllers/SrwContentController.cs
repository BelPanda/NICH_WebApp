using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NICH_WebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NICH_WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SrwContentController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }
        private ClassifTypeSrwDataAccessLayer ClassifTypeSrwDataAccessLayer;
        private OrganizationDataAccessLayer OrganizationDataAccessLayer;
        private FinanceDataAccessLayer FinanceDataAccessLayer;
        private SRWDataAccessLayer SRWDataAccessLayer;
        public SrwContentController(IConfiguration _configuration)
        {
            Configuration = _configuration;
            ClassifTypeSrwDataAccessLayer = new ClassifTypeSrwDataAccessLayer(Configuration);
            OrganizationDataAccessLayer = new OrganizationDataAccessLayer(Configuration);
            FinanceDataAccessLayer = new FinanceDataAccessLayer(Configuration);
            SRWDataAccessLayer = new SRWDataAccessLayer(Configuration);
        }

        // GET: <SrwContentController>/TypeSrw
        [HttpGet]
        [Route("TypeSrw")]
        public IEnumerable<ClassifTypeSrw> GetTypeSrw()
        {
            return ClassifTypeSrwDataAccessLayer.GetClassifTypeSrw();
        }

        // GET: <SrwContentController>/Organization
        [HttpGet]
        [Route("Organization")]
        public IEnumerable<Organization> GetOrganizations()
        {
            return OrganizationDataAccessLayer.GetOrganization();
        }

        // GET: <SrwContentController>/Finance
        [HttpGet]
        [Route("Finance")]
        public IEnumerable<Finance> GetFinances()
        {
            return FinanceDataAccessLayer.GetFinance();
        }
        
        // POST: 
        [HttpPost]
        [Route("CreateSRW")]
        public int Create([FromBody] ListSRW listSRW)
        {
            SRWDataAccessLayer.UpdateSRW(listSRW);
            return 1;
        }
    }
}
