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
    public class ExamsController : Controller
    {
        private readonly intelectahContext _context;

        public ExamsController(intelectahContext context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            var intelectahContext = _context.Exams.Include(e => e.ExamType);
            return View(await intelectahContext.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams
                .Include(e => e.ExamType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exams == null)
            {
                return NotFound();
            }

            return View(exams);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            ViewData["ExamsTypesId"] = new SelectList(_context.ExamsTypes, "Id", "ExamName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExamName,ExamDescription,ExamsTypesId")] Exams exams)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exams);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamsTypesId"] = new SelectList(_context.ExamsTypes, "Id", "ExamName", exams.ExamsTypesId);
            return View(exams);
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams.FindAsync(id);
            if (exams == null)
            {
                return NotFound();
            }
            ViewData["ExamsTypesId"] = new SelectList(_context.ExamsTypes, "Id", "ExamName", exams.ExamsTypesId);
            return View(exams);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExamName,ExamDescription,ExamsTypesId")] Exams exams)
        {
            if (id != exams.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exams);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamsExists(exams.Id))
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
            ViewData["ExamsTypesId"] = new SelectList(_context.ExamsTypes, "Id", "ExamName", exams.ExamsTypesId);
            return View(exams);
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams
                .Include(e => e.ExamType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exams == null)
            {
                return NotFound();
            }

            return View(exams);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exams = await _context.Exams.FindAsync(id);
            _context.Exams.Remove(exams);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamsExists(int id)
        {
            return _context.Exams.Any(e => e.Id == id);
        }
    }
}
