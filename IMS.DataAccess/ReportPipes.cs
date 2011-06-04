using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace IMS.DataAccess
{
	public static class ReportPipes
	{
		public static IOrderedQueryable<Report> OrderByOperator(this IQueryable<Report> reports, SortDirection direction = SortDirection.Ascending)
		{
			Expression<Func<Report, String>> selector = report => report.OnSiteOperator.Name;
			return
				direction == SortDirection.Ascending
				? reports.OrderBy(selector)
				: reports.OrderByDescending(selector);
		}
		public static IOrderedQueryable<Report> OrderByDate(this IQueryable<Report> reports, SortDirection direction = SortDirection.Descending)
		{
			Expression<Func<Report, DateTime>> selector = report => report.CreateDate;
			return
				direction == SortDirection.Ascending
				? reports.OrderBy(selector)
				: reports.OrderByDescending(selector);
		}

		public static IQueryable<Report> CreatedAfter(this IQueryable<Report> reports, DateTime date)
		{
			return reports.Where(report => report.ReceivedDate > date);
		}
	}
}
