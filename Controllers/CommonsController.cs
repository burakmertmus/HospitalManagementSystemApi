using HospitalManagementSystemApi.Data;
using HospitalManagementSystemApi.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonsController : ControllerBase
    {
        private readonly DataContext _context;

        public CommonsController(DataContext context)
        {
            _context = context;
        }

        // GET /Commons
        [HttpGet]
        public ActionResult<CommonModel> GetCounts()
        {
            CommonModel commonModel = new CommonModel();
            commonModel.app_count = _context.Appointment.Count();
            commonModel.doc_count = _context.Doctor.Count();
            commonModel.pat_count = _context.Patient.Count();

            return commonModel;
        }
    }
}
