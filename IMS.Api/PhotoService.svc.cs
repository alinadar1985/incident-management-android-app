using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Net;
using System.Web.Security;
using System.Threading.Tasks;
using System.IO;

namespace IMS.Api
{
	public class PhotoService : IPhotoService
	{
		private CloudBlobClient _BlobClient { get; set; }
		private OutgoingWebResponseContext Response { get { return WebOperationContext.Current.OutgoingResponse; } }
		private IncomingWebRequestContext Request { get { return WebOperationContext.Current.IncomingRequest; } }
		public PhotoService()
		{
			var connectionString =
				RoleEnvironment.GetConfigurationSettingValue("DataConnectionString");
			this._BlobClient =
				CloudStorageAccount.Parse(connectionString).CreateCloudBlobClient();
			this._BlobClient.WriteBlockSizeInBytes = 4 * 1024 * 1024;
		}


		public void UploadPhoto(Guid reportID, System.IO.Stream file)
		{
			if (Request.ContentLength <= 0)
				throw new WebFaultException<string>("No Content-Length Header", HttpStatusCode.BadGateway);
			if (Request.ContentLength > 5 * 1024 * 1024)
				throw new WebFaultException(HttpStatusCode.RequestEntityTooLarge);
			var blob = _BlobClient.GetContainerReference("photos")
				.GetBlobReference(reportID.ToString() + ".jpg");
			blob.UploadFromStream(file);
			blob.Properties.ContentType = "image/jpeg";
			blob.SetProperties();
			Response.SetStatusAsCreated(blob.Uri);
		}

		public Stream GetPhoto(Guid reportID)
		{
			var blob = _BlobClient.GetContainerReference("photos")
				.GetBlobReference(reportID.ToString() + ".jpg");
			byte[] image = blob.DownloadByteArray();
			Response.ContentType = "image/jpeg";
			Response.ContentLength = image.Length;
			return new MemoryStream(image, false);
		}
	}
}
