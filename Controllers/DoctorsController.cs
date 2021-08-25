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
    [Route("/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DataContext _context;

        public DoctorsController(DataContext context)
        {
            _context = context;
        }

        // GET: /Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor()
        {
            return await _context.Doctor.ToListAsync();
        }

        // GET: /Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // PUT: /Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, DoctorCreateUpdateDto doctorCreateUpdateDto)
        {
            var doctor = await _context.Doctor.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }
       

            doctor.doc_first_name = doctorCreateUpdateDto.doc_first_name;
            doctor.doc_last_name = doctorCreateUpdateDto.doc_last_name;
            doctor.doc_ph_no = doctorCreateUpdateDto.doc_ph_no;
            doctor.doc_address = doctorCreateUpdateDto.doc_address;

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: /Doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(DoctorCreateUpdateDto doctorCreateUpdateDto)
        {
            var doctor = new Doctor();
            doctor.doc_first_name = doctorCreateUpdateDto.doc_first_name;
            doctor.doc_last_name = doctorCreateUpdateDto.doc_last_name;
            doctor.doc_ph_no = doctorCreateUpdateDto.doc_ph_no;
            doctor.doc_address = doctorCreateUpdateDto.doc_address;

            _context.Doctor.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.doctor_id }, doctor);
        }

        // DELETE: /Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.doctor_id == id);
        }
    }
}
