using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DataService
{
	[DataContract]
	public class SignUploadRequest
	{
		[DataMember]
		public Guid ReportKey { get; set; }
		[DataMember]
		public Guid PhotoMd5 { get; set; }
	}

	[DataContract]
	public class SignUploadResponse
	{
		[DataMember]
		public Guid ReportKey { get; set; }
		[DataMember]
		public Guid PhotoMd5 { get; set; }
		[DataMember]
		public Uri Url { get; set; }
	}
}