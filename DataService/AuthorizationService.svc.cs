using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.ServiceModel.Activation;
namespace DataService
{
	[AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
	public class AuthorizationSerice : IAuthorizationService
	{
		private CloudBlobClient _BlobClient { get; set; }
		public AuthorizationSerice()
		{
			var connectionString = 
				RoleEnvironment.GetConfigurationSettingValue("DataConnectionString");
			this._BlobClient = 
				CloudStorageAccount.Parse(connectionString).CreateCloudBlobClient();
		}
			
		public SignedUploadResponse SignUpload(string reportUri)
		{
			var container = this._BlobClient.GetContainerReference("photos");
			var blob = container.GetBlobReference(new Guid(reportUri).ToString());
			var sig = blob.GetSharedAccessSignature(new SharedAccessPolicy {
				Permissions = SharedAccessPermissions.Write,
				SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(20.0),
				SharedAccessStartTime = DateTime.UtcNow
			});
			return new SignedUploadResponse {
				Url = new Uri(blob.Uri.ToString() + "?" + sig)
			};
		}
	}
}
