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
    public class AppointmentsController : ControllerBase
    {
        private readonly DataContext _context;

        public AppointmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: /Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment()
        {
            return await _context.Appointment.ToListAsync();
        }

        // GET: /Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }
        
        // PUT: /Appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, AppointmentUpdateModel appointmentUpdateModel)
        {
            var appointmentReq = await _context.Appointment.FindAsync(id);

            if (appointmentReq == null)
            {
                return NotFound();
            }
            appointmentReq.doc_id = appointmentUpdateModel.doc_id;
            appointmentReq.pat_id = appointmentUpdateModel.pat_id;

            _context.Entry(appointmentReq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
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

        // POST: /Appointments
        
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(AppointmentCreateModel appointmentCreateModel)
        {
            var appointment = new Appointment();
            appointment.appointment_date = appointmentCreateModel.appointment_date;
            appointment.doc_id = appointmentCreateModel.doc_id;
            appointment.pat_id = appointmentCreateModel.pat_id;

            _context.Appointment.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.appointment_id }, appointment);
        }

        // DELETE: /Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.appointment_id == id);
        }
    }
}
