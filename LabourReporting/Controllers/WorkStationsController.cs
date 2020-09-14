using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabourReporting.Data;
using LabourReporting.Models;
using LabourReporting.ViewModels;

namespace LabourReporting.Controllers
{
    public class WorkStationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkStationsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: WorkStations
        public async Task<IActionResult> Index()
        {
            var model = await _context.WorkStations.FromSql("select * from WorkStations w inner join dbo.OperatorWorkstations ow on w.WorkStationId = ow.WorkStationId join dbo.Operators op on ow.OperatorID = op.OperatorID").ToListAsync();

            return View(model);
        }

        // GET: WorkStations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workStation = await _context.WorkStations
                .FirstOrDefaultAsync(m => m.WorkStationId == id);
            if (workStation == null)
            {
                return NotFound();
            }

            return View(workStation);
        }

        // GET: WorkStations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkStations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkStationId,WorkStationName,Department")] WorkStation workStation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workStation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workStation);
        }

        // GET: WorkStations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workStation = await _context.WorkStations.FindAsync(id);
            if (workStation == null)
            {
                return NotFound();
            }
            return View(workStation);
        }

        // POST: WorkStations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkStationId,WorkStationName,Department")] WorkStation workStation)
        {
            if (id != workStation.WorkStationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workStation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkStationExists(workStation.WorkStationId))
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
            return View(workStation);
        }

        // GET: WorkStations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workStation = await _context.WorkStations
                .FirstOrDefaultAsync(m => m.WorkStationId == id);
            if (workStation == null)
            {
                return NotFound();
            }

            return View(workStation);
        }

        // POST: WorkStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workStation = await _context.WorkStations.FindAsync(id);
            _context.WorkStations.Remove(workStation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkStationExists(int id)
        {
            return _context.WorkStations.Any(e => e.WorkStationId == id);
        }
    }
}
