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
using System.Globalization;

namespace LabourReporting.Controllers
{
    public class NcrTagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NcrTagsController(ApplicationDbContext context)
        {
            this._context = context;
        }


        public IActionResult LVByMachineNum(LVSearchScreenerModel screener)
        {
            var model = _context.LengthVariances.AsQueryable();
            if (screener != null)
            {
               
                if (screener.fromDate.HasValue)
                {
                    model = model.Where(x => x.Date >= screener.fromDate);
                }
                if (screener.toDate.HasValue)
                {
                    model = model.Where(x => x.Date <= screener.toDate);
                }
                if (!string.IsNullOrEmpty(screener.defect))
                {
                    model = model.Where(x => x.DefectCode.Contains(screener.defect));


                }
                if (screener.valueMin.HasValue)
                {
                    model = model.Where(x => x.Value > screener.valueMin);
                }
                if (screener.valueMax.HasValue)
                {
                    model = model.Where(x => x.Value < screener.valueMax);
                }

            }


        // top  10 defects
           var defectCodesGroup = model.GroupBy(x => x.DefectCode).Take(10);
            var defectCode = new List<string>();
            var defectCodeCount = new List<int>();

            foreach (var defect in defectCodesGroup)
            {
                defectCode.Add(defect.Key);
                defectCodeCount.Add(defect.Count());
            }
            ViewBag.DefectCode = defectCode;
            ViewBag.DefectCodeCount = defectCodeCount;

            // monthly chart with dollar amount
            var monthlyLV2TotalByFlow = model.GroupBy(x => new { x.Date.Month, x.Cell })
                .OrderBy(g => g.Key.Month).ThenBy(g => g.Key.Cell).Select(g => new { month = g.Key.Month, flow = g.Key.Cell, value = g.OrderBy(x => x.Value) });

            var monthlyLVTotalByFlow2 = model.Where(x=>x.Cell.Equals(712)).GroupBy(x => new { x.Date.Month})
               .OrderBy(g => g.Key.Month).Select(g => new { month = g.Key.Month, values=g.Sum(x=>x.Value) });
            var monthlyLVTotalByFlow3 = model.Where(x => x.Cell.Equals(713)).GroupBy(x => new { x.Date.Month })
               .OrderBy(g => g.Key.Month).Select(g => new { month = g.Key.Month, values = g.Sum(x => x.Value) });
            var monthlyLVTotalByFlow4 = model.Where(x => x.Cell.Equals(714)).GroupBy(x => new { x.Date.Month })
               .OrderBy(g => g.Key.Month).Select(g => new { month = g.Key.Month, values = g.Sum(x => x.Value) });

            var month = new List<string>();          
            var flow2Total = new List<decimal>();
            var flow3Total = new List<decimal>();
            var flow4Total = new List<decimal>();

            foreach (var group in monthlyLVTotalByFlow2)
            {
                month.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName( group.month));
                flow2Total.Add(group.values);
            }

            foreach (var group in monthlyLVTotalByFlow3)
            {
                
                flow3Total.Add(group.values);
            }
            foreach (var group in monthlyLVTotalByFlow4)
            {
               
                flow4Total.Add(group.values);
            }

            ViewBag.MonthsLV = month;
            ViewBag.Flow2LvDollars = flow2Total;
            ViewBag.Flow3LvDollars = flow3Total;
            ViewBag.Flow4LvDollars = flow4Total;

            ViewBag.Flow2LvDollarsSum = flow2Total.Sum();
            ViewBag.Flow3LvDollarsSum = flow3Total.Sum();
            ViewBag.Flow4LvDollarsSum = flow4Total.Sum();
            // LV count by flow
            var Flow2Wk = new List<int?>();
            var Flow2LvCt = new List<int>();
            var Flow3Wk = new List<int?>();
            var Flow3LvCt = new List<int>();
            var Flow4Wk = new List<int?>();
            var Flow4LvCt = new List<int>();

            var LvCountByWorkstation = model.GroupBy(x => x.WorkStationId);

            foreach (var item in LvCountByWorkstation)
            {
                if (item.Key.ToString()[0] == '2')
                {
                    Flow2Wk.Add(item.Key);
                    Flow2LvCt.Add(item.Count());
                }
                else if ( item.Key.ToString()[0] == '3')
                {
                    Flow3Wk.Add(item.Key);
                    Flow3LvCt.Add(item.Count());
                }
                else if ( item.Key.ToString()[0] == '4')
                {
                    Flow4Wk.Add(item.Key);
                    Flow4LvCt.Add(item.Count());
                }
            }
            ViewBag.F2Workstations = Flow2Wk;
            ViewBag.F2LvCount = Flow2LvCt;
            ViewBag.F3Workstations = Flow3Wk;
            ViewBag.F3LvCount = Flow3LvCt;
            ViewBag.F4Workstations = Flow4Wk;
            ViewBag.F4LvCount = Flow4LvCt;

            return View(model);

        }

        public async Task<IActionResult> QualityByDept(int? dept, LVSearchScreenerModel screener)
        {
            if (dept == null || dept == 0)
            {
                dept = 2;
            }
            var extruderOne = 2101;
            var extruderTwo = 2102;
            if (dept == 3)
            {
                extruderOne = 3101;
                extruderTwo = 3102;
            }
            else if (dept == 4)
            {
                extruderOne = 4101;
                extruderTwo = 4701;
            }

            var model = _context.NcrTags.Include(x=>x.WorkStation).AsQueryable();
            var model2 = _context.FtBreakdowns.AsQueryable();
            if (screener != null)
            {
                if (screener.fromDate.HasValue)
                {
                    model = model.Where(x => x.Date_Rej >= screener.fromDate);
                    model2 = model2.Where(x => x.Date >= screener.fromDate);
                }
                if (screener.toDate.HasValue)
                {
                    model = model.Where(x => x.Date_Rej <= screener.toDate);
                    model2 = model2.Where(x => x.Date <= screener.toDate);
                }
                          

            }

            //await model.Where(x => Convert.ToInt32(x.WorkStation.Department).Equals(dept)).Inclu.ToListAsync();

            var viewModel = new WorkStationNcrTagViewModel();
            viewModel.NcrTags = await model.Where(x => x.WorkStation.Department.Equals(dept)).ToListAsync();
            viewModel.NcrTags = await model.Where(x => (x.WorkStationId == extruderOne || x.WorkStationId == extruderTwo) && x.Defect.Contains("FT")).OrderBy(x => x.Date_Rej).ToListAsync();
            viewModel.FtBreakdowns = await model2.ToListAsync();

            ViewBag.ContaminationType =  model2.Where(x => !string.IsNullOrEmpty(x.SecondLevel)).GroupBy(x => x.SecondLevel).Select(x => x.Key).ToList();
            ViewBag.ContaminationTypeCount = model2.Where(x=>!string.IsNullOrEmpty(x.SecondLevel)).GroupBy(x => x.SecondLevel).Select(x => x.Count()).ToList();

            var defectModel = await model.Where(x => Convert.ToInt32(x.WorkStation.Department).Equals(dept)).ToListAsync();
            ViewBag.Defects30Days = defectModel.GroupBy(x => x.Defect).Select(x => x.Key).ToList();
            ViewBag.Defects30DaysCount = defectModel.GroupBy(x => x.Defect).Select(x => x.Count()).ToList();
            var NumofTags = defectModel.Count();

            // ft blows dataset
            var model2101 = model.Where(x => x.WorkStationId == extruderOne && x.Defect.Contains("FT")).ToList();
            ViewBag.Operators2101 = model2101.GroupBy(x => x.OperatorId).Select(x => x.Key).ToList();
            ViewBag.Ftcount2101 = model2101.GroupBy(x => x.OperatorId).Select(x => x.Count()).ToList();

            // ft blows dataset                                                                                                                                                                                                                                                                                                                                                     
            var model2102 = model.Where(x => x.WorkStationId == extruderTwo && x.Defect.Contains("FT")).ToList();
            ViewBag.Operators2102 = model2102.GroupBy(x => x.OperatorId).Select(x => x.Key).ToList();
            ViewBag.Ftcount2102 = model2102.GroupBy(x => x.OperatorId).Select(x => x.Count()).ToList();

            ViewBag.extruderOne = extruderOne;
            ViewBag.extruderTwo = extruderTwo;
            ViewBag.dept = dept;
            return View(viewModel);
        }

        //  GET: NcrTags
        public async Task<IActionResult> Index(string filter)
        {
            var applicationDbContext = _context.NcrTags.Include(n => n.Operator).Include(n => n.WorkStation);

            if (string.IsNullOrWhiteSpace(filter))
            {
                ViewBag.type = "All";
                return View(await applicationDbContext.ToListAsync());
            }

            else
            {
                applicationDbContext = applicationDbContext.Where(x => x.Disposition.Contains(filter)).Include(n => n.Operator).Include(n => n.WorkStation);
                ViewBag.type = filter;
                return View(await applicationDbContext.ToListAsync());
            }

        }

        [HttpGet]
        public async Task<IActionResult> ByOperator(int? id)
        {
            var model = await _context.NcrTags.Where(x => x.OperatorId == id).ToListAsync();

            return View(model);
        }

        //GET: NcrTags/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ncrTag = await _context.NcrTags
                .Include(n => n.Operator)
                .Include(n => n.WorkStation)
                .FirstOrDefaultAsync(m => m.Tag_No == id);
            if (ncrTag == null)
            {
                return NotFound();
            }

            return View(ncrTag);
        }

        // GET: NcrTags/Create
        public IActionResult Create()
        {
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorID", "OperatorID");
            ViewData["WorkStationId"] = new SelectList(_context.WorkStations, "WorkStationId", "WorkStationName");
            return View();
        }

        // POST: NcrTags/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tag_No,Date_Rej,Disposition,Item,Colour,Put_Up,Qty,Order_number,Defect,NcrComments,SupervisorSignature,OperationNumber,OperatorId,WorkStationId")] NcrTag ncrTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ncrTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorID", "OperatorID", ncrTag.OperatorId);
            ViewData["WorkStationId"] = new SelectList(_context.WorkStations, "WorkStationId", "WorkStationName", ncrTag.WorkStationId);
            return View(ncrTag);
        }

        //GET: NcrTags/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ncrTag = await _context.NcrTags.FindAsync(id);
            if (ncrTag == null)
            {
                return NotFound();
            }
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorID", "OperatorID", ncrTag.OperatorId);
            ViewData["WorkStationId"] = new SelectList(_context.WorkStations, "WorkStationId", "WorkStationName", ncrTag.WorkStationId);
            return View(ncrTag);
        }

        // POST: NcrTags/Edit/5
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double id, [Bind("Tag_No,Date_Rej,Disposition,Item,Colour,Put_Up,Qty,Order_number,Defect,NcrComments,SupervisorSignature,OperationNumber,OperatorId,WorkStationId")] NcrTag ncrTag)
        {
            if (id != ncrTag.Tag_No)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ncrTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NcrTagExists(ncrTag.Tag_No))
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
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorID", "OperatorID", ncrTag.OperatorId);
            ViewData["WorkStationId"] = new SelectList(_context.WorkStations, "WorkStationId", "WorkStationName", ncrTag.WorkStationId);
            return View(ncrTag);
        }

        //GET: NcrTags/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ncrTag = await _context.NcrTags
                .Include(n => n.Operator)
                .Include(n => n.WorkStation)
                .FirstOrDefaultAsync(m => m.Tag_No == id);
            if (ncrTag == null)
            {
                return NotFound();
            }

            return View(ncrTag);
        }

        // POST: NcrTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var ncrTag = await _context.NcrTags.FindAsync(id);
            _context.NcrTags.Remove(ncrTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NcrTagExists(double id)
        {
            return _context.NcrTags.Any(e => e.Tag_No == id);
        }

    

   

    }
}
