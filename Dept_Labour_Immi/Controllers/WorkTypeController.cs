using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Authorization;

namespace Dept_Labour_Immi.Controllers
{
    public class WorkTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkType
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkType.OrderByDescending(x => x.Id).ToList();
            return View(applicationDbContext);
        }
        // GET: WorkType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkType == null)
            {
                return NotFound();
            }

            var worktype = await _context.WorkType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (worktype == null)
            {
                return NotFound();
            }

            return View(worktype);
        }

        // GET: worktype/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: worktype/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DemandType")] WorkType worktype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worktype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }

        // GET: workType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkType == null)
            {
                return NotFound();
            }

            var worktype = await _context.WorkType.FindAsync(id);
            if (worktype == null)
            {
                return NotFound();
            }
            return View(worktype);
        }

        // POST: worktype/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DemandType")] WorkType worktype)
        {
            if (id != worktype.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(worktype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkTypeExists(worktype.Id))
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
            return View(worktype);
        }

        // GET: Agencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkType == null)
            {
                return NotFound();
            }

            var worktype = await _context.WorkType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (worktype == null)
            {
                return NotFound();
            }

            return View(worktype);
        }

        // POST: Agencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WorkType'  is null.");
            }
            var workType = await _context.WorkType.FindAsync(id);
            if (workType != null)
            {
                _context.WorkType.Remove(workType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkTypeExists(int id)
        {
            return _context.WorkType.Any(e => e.Id == id);
        }
    }
}
