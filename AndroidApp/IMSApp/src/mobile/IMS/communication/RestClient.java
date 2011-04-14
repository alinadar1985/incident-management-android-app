package mobile.IMS.communication;
import org.restlet.ext.odata.Query;

public class RestClient extends org.restlet.ext.odata.Service{

	public RestClient() {
		super("http://10.0.2.2:9501/IMSData.svc/");
	}

	public void addOnSiteOperator(OnSiteOperator operator) throws Exception  {
		addEntity("/OnSiteOperators", operator);
	}

	public void addReport(Report report) throws Exception  {
		addEntity("/Reports", report);
	}

	public Query<OnSiteOperator> createOnSiteOperatorQuery(String subPath) throws Exception {
		return createQuery(subPath, OnSiteOperator.class);
	}
	
	public Query<Report> createReportQuery(String subPath)throws Exception {
		return createQuery(subPath, Report.class);
	}
	
}
