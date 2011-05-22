using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS.DataAccess;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using System.Configuration;
using Microsoft.WindowsAzure.ServiceRuntime;
namespace IMS.WWW.ControlCenter.Controllers
{
	public class OnSiteOperatorsController : Controller
	{
		private IMSORMModelContainer _context = new IMSORMModelContainer();
		public OnSiteOperatorsController()
		{
			if (!_context.DatabaseExists())
				_context.CreateDatabase();
		}

		private OnSiteOperator GetOperatorByID(Guid id)
		{
			return _context.OnSiteOperators.First(op => op.OperatorID == id);
		}


		//
		// GET: /OnSiteOperators/

		public ActionResult Index()
		{
			var osOperators = _context.OnSiteOperators.ToList();
			ViewData.Model = osOperators;
			return View("List");
		}

		//
		// GET: /OnSiteOperators/Details/5

		public ActionResult Details(Guid id)
		{
			var osOperator = GetOperatorByID(id);
			ViewData.Model = osOperator;
			return View();
		}

		//
		// GET: /OnSiteOperators/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /OnSiteOperators/Create

		[HttpPost]
		public ActionResult Create(OnSiteOperator osOperator)
		{
			try {
				// TODO: Add insert logic here
				_context.OnSiteOperators.AddObject(osOperator);
				var oId = osOperator.OperatorID;
				var account = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("DataConnectionString"));
				var client = account.CreateCloudBlobClient();
				//var cntnr = client.GetContainerReference("blub").GetPermissions().SharedAccessPolicies.Add(
				var container = client.GetContainerReference(oId.ToString().ToLower());
				container.CreateIfNotExist();
				
				var sas = container.GetSharedAccessSignature(new SharedAccessPolicy {
					SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
					SharedAccessStartTime = DateTime.UtcNow,
					Permissions = SharedAccessPermissions.Write | SharedAccessPermissions.Read, 
				});
				
				var sap = new SharedAccessPolicy {
					Permissions = SharedAccessPermissions.Write,
					SharedAccessStartTime = DateTime.UtcNow,
					SharedAccessExpiryTime = DateTime.UtcNow.AddYears(1).ToUniversalTime()
				};

				var bcp = new BlobContainerPermissions() {
					PublicAccess = BlobContainerPublicAccessType.Off
				};
				


				_context.SaveChanges();

				return RedirectToAction("Index");
			} catch {
				return Content("Something went wrong");
			}
		}

		//
		// GET: /OnSiteOperators/Edit/5

		public ActionResult Edit(Guid id)
		{
			var osOperator = GetOperatorByID(id);
			ViewData.Model = osOperator;
			return View();
		}

		//
		// POST: /OnSiteOperators/Edit/5

		[HttpPost]
		public ActionResult Edit(Guid id, OnSiteOperator osOperator)
		{
			try {
				var old = GetOperatorByID(id);
				old.Name = osOperator.Name;
				_context.SaveChanges();
				return RedirectToAction("Index");
			} catch {
				return Content("Something went wrong");
			}
		}

		//
		// GET: /OnSiteOperators/Delete/5
		public ActionResult Delete(Guid id)
		{
			var osOperator = GetOperatorByID(id);
			ViewData.Model = osOperator;
			return View();
		}

		//
		// POST: /OnSiteOperators/Delete/5

		[HttpPost]
		public ActionResult Delete(OnSiteOperator osOperator)
		{
			try {
				// TODO: Add delete logic here
				_context.OnSiteOperators.DeleteObject(GetOperatorByID(osOperator.OperatorID));
				_context.SaveChanges();
				return RedirectToAction("Index");
			} catch {
				return Content("Something went wrong");
			}
		}
	}
}
