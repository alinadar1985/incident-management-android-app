using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.StorageClient.Protocol;
using System.Globalization;
using System.Collections.Specialized;
using System.ServiceModel.Activation;
namespace DataService
{
	public static class ParemterExtensions {
		public static NameValueCollection AddStartTime(this NameValueCollection parameters, DateTime time) {
			parameters.Add("st", time.ToString("s", CultureInfo.InvariantCulture));
			return parameters;
		}
		public static NameValueCollection AddEndTime(this NameValueCollection parameters, DateTime time) {
			parameters.Add("se", time.ToString("s",CultureInfo.InvariantCulture));
			return parameters;
		}
		public static NameValueCollection AddParameter(this NameValueCollection parameters, string parameter, string value) {
			parameters.Add(parameter,value);
			return parameters;
		}
	}

	class SignStrategy : CanonicalizationStrategy
	{

		public static string SignPUT(CloudBlobClient blobClient, string container, string filename, long contentLength )
		{
			Uri address = new Uri(blobClient.BaseUri.ToString() + "/" + container + "/" + filename);
			var accountName = address.LocalPath.ToString();
			return CanonicalizeHttpRequestVersion2(
				address: address,
				accountName: accountName,
				method: "PUT",
				contentType: "image/jpeg",
				contentLength: contentLength,
				date: DateTime.UtcNow.ToString("s"),
				headers: new NameValueCollection()
			);

		}

		public override string CanonicalizeHttpRequest(System.Net.HttpWebRequest request, string accountName)
		{
			throw new NotImplementedException();
		}
		
	}


	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class Upload : IUpload
	{
		private CloudBlobClient _BlobClient = CloudStorageAccount.Parse(
				RoleEnvironment.GetConfigurationSettingValue("DataConnectionString"))
				.CreateCloudBlobClient();
		public SignUploadResponse SignUpload(Guid guid)
		{
			
			var blobReference = _BlobClient.GetBlobReference(string.Format("{0}/{1}.jpg",
				"photos", guid.ToString()));
			var start = DateTime.UtcNow;
			var end = DateTime.UtcNow.AddMinutes(59.5);
			var sig = blobReference.GetSharedAccessSignature(new SharedAccessPolicy {
				Permissions = SharedAccessPermissions.Write,
				SharedAccessStartTime = DateTime.UtcNow,
				SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(59.5)
			});

			var signedUrl = blobReference.Uri.ToString() + sig;
			return new SignUploadResponse {
				ReportKey = guid,
				Url = new Uri(signedUrl)
			};
		}

		public SignUploadResponse SignUpload(SignUploadRequest request)
		{
			return SignUpload(request.ReportKey);
		}

		public void Setup()
		{
			var container = _BlobClient.GetContainerReference("photos");
			container.CreateIfNotExist();
		}
	}
}
