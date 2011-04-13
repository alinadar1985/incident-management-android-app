using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace IMS.WWW.ControlCenter.Models
{
	public static class SortingExtensions
	{
		public static SortDirection Toggle(this SortDirection direction) {
			if (direction == SortDirection.Ascending)
				return SortDirection.Descending;
			else
				return SortDirection.Ascending;

		}
	}
}