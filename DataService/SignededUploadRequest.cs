using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataService
{
	[DataContract(Name="upload-response")]
	class SignededUploadRequest
	{
		[DataMember(IsRequired=true,EmitDefaultValue=false)]
		public Guid ReportGuid { get; set; }
	}
}
