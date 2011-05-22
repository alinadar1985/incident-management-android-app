using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace IMS.Api
{
	// HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IReportService" sowohl im Code als auch in der Konfigurationsdatei ändern.
	[ServiceContract]
	public interface IReportService
	{
		[OperationContract]
		[WebInvoke(Method = "POST")]
		void UploadReport(ReportData report);
		
	}
}
