using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace IMS.Api
{
	// HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IService1" sowohl im Code als auch in der Konfigurationsdatei ändern.
	[ServiceContract]
	public interface IPhotoService
	{
		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "photos?reportID={reportID}")]
		void UploadPhoto(string reportID, Stream file);

		[WebGet(UriTemplate="photos?reportID={reportID}")]
		Stream GetPhoto(Guid reportID);
	}


	// Verwenden Sie einen Datenvertrag, wie im folgenden Beispiel dargestellt, um Dienstvorgängen zusammengesetzte Typen hinzuzufügen.
	[DataContract(Name="photo-upload-authorization")]
	public class PhotoUploadAuthorizationResponse
	{
		[DataMember(IsRequired=true,Name="report-id")]
		public Guid ReportID { get; set; }

		[DataMember(IsRequired=true, Name="upload-url")]
		public String UploadUrl { get; set; }
	}
}
