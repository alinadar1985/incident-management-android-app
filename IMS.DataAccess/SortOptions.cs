using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.DataAccess
{
	public class SortOptions
	{
		public SortOptions() { }
		public SortOptions(string criterium) : this(criterium, SortDirection.Ascending) { }
		public SortOptions(string criterium, SortDirection direction)
		{
			this.Criterium = criterium;
			this.Direction = direction;
		}
		public string Criterium { get; set; }
		public SortDirection Direction { get; set; }
	}

	public class ReportSortOptions : SortOptions
	{
		public ReportSortOptions(string criterium, SortDirection direction)
			: base(criterium, direction)
		{
			var allowedCriteria = new string[] { "Operator.Name", "CreateDate" };
			if (!allowedCriteria.Contains(criterium))
				throw new ArgumentException("criterium");
		}

		public ReportSortOptions(string criterium) : this(criterium, SortDirection.Ascending) { }
		public ReportSortOptions() { }
	}
}
