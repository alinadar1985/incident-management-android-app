using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace DataService
{
	[ServiceContract]
	public interface IAuthorizationService
	{
		[OperationContract]
		[WebGet(UriTemplate="{reportUri}/upload-url")]
		SignedUploadResponse SignUpload(string reportUri);
		
	}
}
