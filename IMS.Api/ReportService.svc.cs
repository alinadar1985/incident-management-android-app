using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using IMS.DataAccess;

namespace IMS.Api
{
	public class ReportService : IReportService
	{
		IMS.DataAccess.IMSORMModelContainer _context = null;
		private IMSORMModelContainer Context
		{
			get
			{
				if (_context == null)
					_context = new IMSORMModelContainer();
				return _context;
			}
		}
					
		public void UploadReport(ReportData report)
		{
			Context.Reports.AddObject(new DataAccess.Report {
				CreateDate = DateTime.Parse(report.DateTime),
				ReportID = report.ReportID,
				OperatorID = report.OperatorID,
				Priority = report.Priority,
				Text = report.Description,
				Location = report.Location
			});
			_context.SaveChanges();
			WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Created;
		}
	}
}
