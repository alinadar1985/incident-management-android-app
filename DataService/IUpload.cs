using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataService
{
	[ServiceContract]
	public interface IUpload
	{
		[OperationContract]
		SignUploadResponse SignUpload(SignUploadRequest request);

		[OperationContract]
		void Setup();
	}
}
