using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabourReporting.Data;
using LabourReporting.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabourReporting.Controllers
{
    public class LengthVarianceController : Controller
    {
        private readonly ApplicationDbContext context;

        public LengthVarianceController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(LVSearchScreenerModel screener)
        {
            if (screener != null)
            {
                var model = context.LengthVariances.AsQueryable();
                if (screener.fromDate.HasValue)
                {
                    model = model.Where(x => x.Date > screener.fromDate);
                }
                if (screener.toDate.HasValue)
                {
                    model = model.Where(x => x.Date < screener.toDate);
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

                return View(model);
            }
            return View(context.LengthVariances.ToList());
        }
    }
}