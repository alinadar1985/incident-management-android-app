using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMS.DataAccess;
namespace IMS.WWW.ControlCenter.Models
{
	public class SortOptions
	{
		public ReportSortCriterium Criterium { get; set; }
		public SortDirection Direction { get; set; }

		public SortOptions(ReportSortCriterium criterium, SortDirection direction = SortDirection.Ascending)
		{
			this.Criterium = criterium;
			this.Direction = direction;
		}


		public SortOptions(string criterium, SortDirection direction = SortDirection.Ascending)
			: this(
				criterium: (ReportSortCriterium)Enum.Parse(typeof(ReportSortCriterium), criterium, true),
				direction: direction
			) { }

		public SortOptions ToggleIfSameCriterium(ReportSortCriterium criterium)
		{
			if (this.Criterium == criterium) {
				if (this.Direction == SortDirection.Ascending)
					return new SortOptions(criterium, SortDirection.Descending);
				else
					return new SortOptions(criterium, SortDirection.Ascending);
			} else return this;
		}
	}
}