using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS.DataAccess;
namespace IMS.WWW.ControlCenter.Controllers
{
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/

		private IMSORMModelContainer _context = new IMSORMModelContainer();
		public ReportsController()
		{
			if (!_context.DatabaseExists())
				_context.CreateDatabase();
		}

		private Report GetReportById(Guid id)
		{
			return _context.Reports.First(r => r.ID == id);
		}

		private IEnumerable<SelectListItem> GetOperatorList()
		{
			return from op in _context.OnSiteOperators.ToList()
				   select new SelectListItem {
					   Text = op.Name,
					   Value = op.ID.ToString(),
					   Selected = false
				   };
		}

		private IEnumerable<SelectListItem> GetPreselectedOperatorList(Guid operatorID)
		{
			return from op in _context.OnSiteOperators.ToList()
				   select new SelectListItem {
					   Text = op.Name,
					   Value = op.ID.ToString(),
					   Selected = op.ID == operatorID
				   };
		}

        public ActionResult Index()
        {
			var reports = _context.Reports;
			ViewData.Model = reports;
            return View("List");
        }

        //
        // GET: /Reports/Details/5

        public ActionResult Details(Guid id)
        {
			var report = GetReportById(id);
			ViewData.Model = report;
            return View();
        }

        //
        // GET: /Reports/Create

        public ActionResult Create()
        {
			ViewBag.OperatorList = GetOperatorList();
			ViewData.Model = new Report { CreateDate = DateTime.Now };
            return View();
        } 

        //
        // POST: /Reports/Create

        [HttpPost]
        public ActionResult Create(Report report)
        {
            try
            {
				_context.Reports.AddObject(report);
				_context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Reports/Edit/5
 
        public ActionResult Edit(Guid id)
        {
			var report = GetReportById(id);
			ViewData.Model = report;
			ViewBag.OperatorList = GetPreselectedOperatorList(report.OperatorID);
            return View();
        }

        //
        // POST: /Reports/Edit/5

        [HttpPost]
        public ActionResult Edit(Report report)
        {
            try
            {
				var old = GetReportById(report.ID);
				old.OperatorID = report.OperatorID;
				old.Text = report.Text;
				old.CreateDate = report.CreateDate;
				_context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Reports/Delete/5
 
        public ActionResult Delete(Guid id)
        {
			var report = GetReportById(id);
			ViewData.Model = report;
            return View();
        }

        //
        // POST: /Reports/Delete/5

        [HttpPost]
        public ActionResult Delete(Report report)
        {
            try
            {
				_context.Reports.DeleteObject(GetReportById(report.ID));
				_context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
