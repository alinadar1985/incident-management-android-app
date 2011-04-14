package mobile.IMS.communication;

import java.util.List;

public class OnSiteOperator {
	private String id;
	private String name;
	private List<Report> reports;
	
	
	public OnSiteOperator(String id, String name, List<Report> reports) {
		super();
		this.id = id;
		this.name = name;
		this.reports = reports;
	}
	
	public OnSiteOperator() {
		super();
	}

	public OnSiteOperator(String id) {
		super();
		this.id = id;
	}
	

	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public List<Report> getReports() {
		return reports;
	}
	public void setReports(List<Report> reports) {
		this.reports = reports;
	}
	
	
}
