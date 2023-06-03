using Lab4.DAL;
using Lab4.DAL.Realization;
using Lab4.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : Controller
    {
        private readonly AppointmentDAL _appointmentDAL;

        public AppointmentsController(AppointmentDAL appointmentDAL)
        {
            _appointmentDAL = appointmentDAL;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _appointmentDAL.GetAppointments();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment?>> GetAppointment(int id)
        {
            return await _appointmentDAL.GetAppointment(id);
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Appointment?>> PutAppointment(int id, Appointment appointment)
        {
            return await _appointmentDAL.Update(id, appointment);
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            return await _appointmentDAL.Add(appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment?>> DeleteAppointment(int id)
        {
            return await _appointmentDAL.Delete(id);
        }

    }
}
