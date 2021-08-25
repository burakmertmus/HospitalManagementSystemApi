using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystemApi.Data;
using HospitalManagementSystemApi.Models;
using HospitalManagementSystemApi.RequestModels;

namespace HospitalManagementSystemApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly DataContext _context;

        public PatientsController(DataContext context)
        {
            _context = context;
        }

        // GET: /Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
        {
            return await _context.Patient.ToListAsync();
        }

        // GET: /Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: /Patients/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, PatientCreateUpdateModel patientCreateUpdateModel)
        {
          


            var patient = await _context.Patient.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            
            patient.pat_first_name = patientCreateUpdateModel.pat_first_name;
            patient.pat_last_name = patientCreateUpdateModel.pat_last_name;
            patient.pat_insurance_no = patientCreateUpdateModel.pat_insurance_no;
            patient.pat_ph_no = patientCreateUpdateModel.pat_ph_no;
            patient.pat_address = patientCreateUpdateModel.pat_address;

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: /Patients
        
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(PatientCreateUpdateModel patientCreateUpdateModel)
        {
            var patient = new Patient();
            patient.pat_first_name = patientCreateUpdateModel.pat_first_name;
            patient.pat_last_name = patientCreateUpdateModel.pat_last_name;
            patient.pat_insurance_no = patientCreateUpdateModel.pat_insurance_no;
            patient.pat_ph_no = patientCreateUpdateModel.pat_ph_no;
            patient.pat_address = patientCreateUpdateModel.pat_address;

            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.patient_id }, patient);
        }

        // DELETE: /Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.patient_id == id);
        }
    }
}
