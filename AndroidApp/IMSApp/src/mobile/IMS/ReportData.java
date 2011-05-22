package mobile.IMS;

import java.io.Serializable;
import java.util.Date;

import org.simpleframework.xml.Element;
import org.simpleframework.xml.Namespace;
import org.simpleframework.xml.Order;
import org.simpleframework.xml.Path;
import org.simpleframework.xml.Root;

@Root(name = "report")
@Namespace(reference="http://schemas.datacontract.org/2004/07/IMS.Api")
@Order(elements={"id","operator-id", "description", "priority", "location", "datetime"})
public class ReportData implements Serializable {
	private static final long serialVersionUID = 134836923434623428L;
	@Element(name = "id", required = true)
	private String uuid;

	@Element(name = "operator-id", required = true)
	private String operatorID;

	@Element(name = "description", required = false)
	private String textDescription;

	@Element(name = "priority", required = true)
	private String priority;

	@Element(name = "location", required = false)
	private String location;

	@Element(name = "datetime", required = true)
	private String dateTime;

	public ReportData() {
	}

	public String getUuid() {
		return uuid;
	}

	public void setUuid(String uuid) {
		this.uuid = uuid;
	}

	public String getOperatorID() {
		return operatorID;
	}

	public void setOperatorID(String operatorID) {
		this.operatorID = operatorID;
	}

	public String getTextDescription() {
		return textDescription;
	}

	public void setTextDescription(String textDescription) {
		this.textDescription = textDescription;
	}

	public String getPriority() {
		return priority;
	}

	public void setPriority(String priority) {
		this.priority = priority;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

	public String getLocation() {
		return this.location;
	}

	public void setLocation(String location) {
		this.location = location;
	}

	public void setDateTime(String dateTime) {
		this.dateTime = dateTime;
	}

	public void setDateTime(Date date) {
		this.dateTime = date.toGMTString();
	}
	
	public String getDateTimm() {
		return this.dateTime;
	}

}
