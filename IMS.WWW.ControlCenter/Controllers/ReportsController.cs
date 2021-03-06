﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS.DataAccess;
using IMS.WWW.ControlCenter.Models;
namespace IMS.WWW.ControlCenter.Controllers
{
	public class ReportsController : Controller
	{
		//
		// GET: /Reports/

		private IMSORMModelContainer _context = new IMSORMModelContainer();
		public ReportsController()
		{
			// Hack für leichteres Deployment
			if (!_context.DatabaseExists())
				_context.CreateDatabase();
		}

		private Report GetReportById(Guid id)
		{
			return _context.Reports.First(r => r.ReportID == id);
		}

		/// <summary>
		/// Gibt eine SelectList aller vorhandenen Operators zurück.
		/// </summary>
		/// <returns></returns>
		private IEnumerable<SelectListItem> GetOperatorList()
		{
			return from op in _context.OnSiteOperators.ToList()
				   select new SelectListItem {
					   Text = op.Name,
					   Value = op.OperatorID.ToString(),
					   Selected = false
				   };
		}
		/// <summary>
		/// Gibt eine SelectList für alle vorhandenen Operators zurück. Der Operator mit 
		/// der übergebenen operatorID ist der default Wert, d.h. wenn ich die ID von "Hans"
		/// übergebe, erscheint in der entsprechenden DropDownList "Hans" als Vorauswahl.
		/// </summary>
		/// <param name="operatorID">Die id des Operators der als Vorauswahl gewünscht ist</param>
		private IEnumerable<SelectListItem> GetPreselectedOperatorList(Guid operatorID)
		{
			return from op in _context.OnSiteOperators.ToList()
				   select new SelectListItem {
					   Text = op.Name,
					   Value = op.OperatorID.ToString(),
					   Selected = op.OperatorID == operatorID
				   };
		}

	

		public ActionResult List(ReportSortCriterium sortBy = ReportSortCriterium.ByDate, SortDirection orderBy = SortDirection.Ascending, string dateAfter = null)
		{
			IQueryable<Report> reports = 
				sortBy == ReportSortCriterium.ByDate
				? _context.Reports.OrderByOperator(orderBy).ThenByDescending(report=> report.CreateDate)
				: _context.Reports.OrderByDate(orderBy);
			if (dateAfter != null) {
				DateTime time = DateTime.Parse(dateAfter);
				reports = reports.CreatedAfter(time);
			}
			ViewBag.OrderBy = orderBy;
			ViewBag.SortBy = sortBy;
			ViewData.Model = reports;
			if (Request.IsAjaxRequest()) {
				return PartialView("ReportTableBodyPartial");
			} else {
				return View();
			}
		}

		public ActionResult Index()
		{
			return RedirectToAction("List", new { sortBy = ReportSortCriterium.ByDate, orderBy = SortDirection.Ascending });
		}

		//
		// GET: /Reports/Details/5

		public ActionResult Details(Guid id)
		{
			var baseUrl = "http://c88dafde179944689e633062115d4a2b.cloudapp.net/PhotoService.svc/photos?reportID={REPORTID}";
			var url = baseUrl.Replace("{REPORTID}", id.ToString());
			ViewBag.ImgUrl = url;
			var report = GetReportById(id);
			ViewData.Model = report;
			if (Request.IsAjaxRequest()) 
				return PartialView("ReportDetailsPartial");
			else
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
			try {
				_context.Reports.AddObject(report);
				_context.SaveChanges();
				return RedirectToAction("Index");
			} catch {
				return Content("Something went wrong");
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
			try {
				var old = GetReportById(report.ReportID);
				old.OperatorID = report.OperatorID;
				old.Text = report.Text;
				old.CreateDate = report.CreateDate;
				_context.SaveChanges();
				return RedirectToAction("Index");
			} catch {
				return Content("Something went wrong");
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
			try {
				_context.Reports.DeleteObject(GetReportById(report.ReportID));
				_context.SaveChanges();
				return RedirectToAction("Index");
			} catch {
				return Content("Something went wrong");
			}
		}

		public ActionResult Poll(Guid lastReceivedReportID)
		{
			var lastReceived = _context
				.Reports
				.First(report => report.ReportID == lastReceivedReportID);
			var polled =
				_context
				.Reports
				.OrderBy(report => report.CreateDate)
				// truly concurrent receiving of reports is unlikely but possible, therfore >=
				.Where(report => report.CreateDate >= lastReceived.CreateDate)
				.Skip(1)
				.ToList();
			if (polled.Count > 0) {
				ViewData.Model = polled;
				return PartialView("ReportTableBodyPartial");
			} else {
				return new EmptyResult();
			}
		}
	}
}
