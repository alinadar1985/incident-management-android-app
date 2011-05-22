using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace IMS.Api
{
	//    @Element(name = "id")
	//private String uuid;

	//@Element(name = "operator-name")
	//private String operatorName;
	
	//@Element(name="operator-id")
	//private String operatorID;

	//@Element(name = "description")
	//private String textDescription;

	//@Element(name = "has-photo")
	//private boolean hasPhoto;



	[DataContract(Name = "report")]
	public class ReportData
	{
		[DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false, Order = 0)]
		public Guid ReportID { get; set; }

		[DataMember(Name = "operator-id", IsRequired = true, Order = 1)]
		public Guid OperatorID { get; set; }

		[DataMember(Name = "description", Order = 2)]
		public string Description { get; set; }

		[DataMember(Name = "priority", Order = 3)]
		public string Priority { get; set; }

		[DataMember(Name = "location", Order = 4)]
		public string Location { get; set; }

		[DataMember(Name = "datetime", Order = 5)]
		public String DateTime { get; set; }

	}
}
