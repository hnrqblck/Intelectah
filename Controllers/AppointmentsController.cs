using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using intelectah.Data;
using intelectah.Models;

namespace intelectah.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly intelectahContext _context;

        public AppointmentsController(intelectahContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var intelectahContext = _context.Appointments.Include(a => a.Exam).Include(a => a.ExamType).Include(a => a.Patients);
            return View(await intelectahContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments
                .Include(a => a.Exam)
                .Include(a => a.ExamType)
                .Include(a => a.Patients)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointments == null)
            {
                return NotFound();
            }

            return View(appointments);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["ExamsId"] = new SelectList(_context.Exams, "Id", "ExamName");
            ViewData["ExamsTypesId"] = new SelectList(_context.ExamsTypes, "Id", "ExamName");
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,ExamsTypesId,ExamsId,AppointmentTime,Protocol")] Appointments appointments)
        {
            if (ModelState.IsValid)
            {
                var foundAppointment = _context.Appointments.Where(p => p.AppointmentTime == appointments.AppointmentTime).FirstOrDefault();
                if (foundAppointment != null)
                {
                    return BadRequest();
                }

                _context.Add(appointments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamsId"] = new SelectList(_context.Exams, "Id", "ExamName", appointments.ExamsId);
            ViewData["ExamsTypesId"] = new SelectList(_context.ExamsTypes, "Id", "ExamName", appointments.ExamsTypesId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Name", appointments.PatientId);
            return View(appointments);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments.FindAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }
            ViewData["ExamsId"] = new SelectList(_context.Exams, "Id", "ExamName", appointments.ExamsId);
            ViewData["ExamsTypesId"] = new SelectList(_context.ExamsTypes, "Id", "ExamName", appointments.ExamsTypesId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Name", appointments.PatientId);
            return View(appointments);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,ExamsTypesId,ExamsId,AppointmentTime,Protocol")] Appointments appointments)
        {
            if (id != appointments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentsExists(appointments.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamsId"] = new SelectList(_context.Exams, "Id", "ExamName", appointments.ExamsId);
            ViewData["ExamsTypesId"] = new SelectList(_context.ExamsTypes, "Id", "ExamName", appointments.ExamsTypesId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Name", appointments.PatientId);
            return View(appointments);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments
                .Include(a => a.Exam)
                .Include(a => a.ExamType)
                .Include(a => a.Patients)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointments == null)
            {
                return NotFound();
            }

            return View(appointments);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointments = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentsExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
