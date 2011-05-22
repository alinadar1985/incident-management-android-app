using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataService
{
	[DataContract(Name="upload-request")]
	public class SignedUploadResponse
	{
		[DataMember]
		public Uri Url { get; set; }
	}
}
