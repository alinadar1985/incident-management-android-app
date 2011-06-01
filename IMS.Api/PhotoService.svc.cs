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
		public PhotoService()
		{
			var connectionString =
				RoleEnvironment.GetConfigurationSettingValue("DataConnectionString");
			this._BlobClient =
				CloudStorageAccount.Parse(connectionString).CreateCloudBlobClient();
			this._BlobClient.WriteBlockSizeInBytes = 4 * 1024 * 1024;
		}


		public void UploadPhoto(string reportID, System.IO.Stream file)
		{
			Guid reportGuid = new Guid(reportID);
			if (WebOperationContext.Current.IncomingRequest.ContentLength <= 0)
				throw new WebFaultException<string>("No Content-Length Header", HttpStatusCode.BadGateway);
			if (WebOperationContext.Current.IncomingRequest.ContentLength > 5 * 1024 * 1024)
				throw new WebFaultException(HttpStatusCode.RequestEntityTooLarge);
			var blob = _BlobClient.GetContainerReference("photos")
				.GetBlobReference(reportID.ToString() + ".jpg");
			blob.UploadFromStream(file);
			blob.Properties.ContentType = "image/jpeg";
			blob.SetProperties();
			WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(blob.Uri);
			
		}

		public Stream GetPhoto(Guid reportID)
		{
			// HACK HACK HACK
			var blob = _BlobClient.GetContainerReference("photos")
				.GetBlobReference(reportID.ToString() + ".jpg");
			byte[] image = blob.DownloadByteArray();
			var response = WebOperationContext.Current.OutgoingResponse;
			response.ContentType = "image/jpeg";
			response.ContentLength = image.Length;
			return new MemoryStream(image, false);
		}
	}
}
