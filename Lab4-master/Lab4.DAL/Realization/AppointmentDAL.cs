using Lab4.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL.Realization
{
    public class AppointmentDAL
    {
        private readonly AppDbContext _context;

        public AppointmentDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAppointments()
        {
            return await _context.Appointment.ToListAsync();
        }

        public async Task<Appointment?> GetAppointment(int id)
        {
            return await _context.Appointment.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Appointment> Add(Appointment newAppointment)
        {
            var appointment = new Appointment()
            {
                Id = newAppointment.Id,
                Date = DateTime.Now,
                Client = newAppointment.Client,
                ProductId = newAppointment.ProductId,
                Salon = newAppointment.Salon,
                Service = newAppointment.Service,
                Staff = newAppointment.Staff,
            };
            await _context.Appointment.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment?> Update(int id, Appointment appointment)
        {
            var appointmentDb = await GetAppointment(id);
            if(appointmentDb != null) 
            {
                appointmentDb.Id = id;
                appointmentDb.Salon = appointment.Salon;
                appointmentDb.Staff = appointment.Staff;
                appointmentDb.Service = appointment.Service;
                await _context.SaveChangesAsync();
                return appointmentDb;
            }
            else
            {
                return null;
            }
        }

        public async Task<Appointment?> Delete(int id)
        {
            var appoinment = await GetAppointment(id);
            if(appoinment != null)
            {
                _context.Appointment.Remove(appoinment);
                _context.SaveChanges();
                return appoinment;
            }
            else
            {
                return null;
            }
        }
    }
}
