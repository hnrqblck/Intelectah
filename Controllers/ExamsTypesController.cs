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
    public class ExamsTypesController : Controller
    {
        private readonly intelectahContext _context;

        public ExamsTypesController(intelectahContext context)
        {
            _context = context;
        }

        // GET: ExamsTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExamsTypes.ToListAsync());
        }

        // GET: ExamsTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examsTypes = await _context.ExamsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examsTypes == null)
            {
                return NotFound();
            }

            return View(examsTypes);
        }

        // GET: ExamsTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamsTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExamName,ExamDescription")] ExamsTypes examsTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examsTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examsTypes);
        }

        // GET: ExamsTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examsTypes = await _context.ExamsTypes.FindAsync(id);
            if (examsTypes == null)
            {
                return NotFound();
            }
            return View(examsTypes);
        }

        // POST: ExamsTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExamName,ExamDescription")] ExamsTypes examsTypes)
        {
            if (id != examsTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examsTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamsTypesExists(examsTypes.Id))
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
            return View(examsTypes);
        }

        // GET: ExamsTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examsTypes = await _context.ExamsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examsTypes == null)
            {
                return NotFound();
            }

            return View(examsTypes);
        }

        // POST: ExamsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examsTypes = await _context.ExamsTypes.FindAsync(id);
            _context.ExamsTypes.Remove(examsTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamsTypesExists(int id)
        {
            return _context.ExamsTypes.Any(e => e.Id == id);
        }
    }
}
