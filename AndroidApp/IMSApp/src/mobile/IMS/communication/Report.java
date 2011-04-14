package mobile.IMS.communication;
import java.util.Date;
public class Report {
	private Date createDate;
    private String id;
    private String operatorId;
    private String text;
    private OnSiteOperator onSiteOperator;
    
        
    public Report(Date createDate, String id, String operatorId, String text,
			OnSiteOperator onSiteOperator) {
		super();
		this.createDate = createDate;
		this.id = id;
		this.operatorId = operatorId;
		this.text = text;
		this.onSiteOperator = onSiteOperator;
	}

	public Report() {
		super();
	}

	public Report(String id) {
    	super();
    	this.id = id;
    }
    
	public Date getCreateDate() {
		return createDate;
	}
	public void setCreateDate(Date createDate) {
		this.createDate = createDate;
	}
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getOperatorId() {
		return operatorId;
	}
	public void setOperatorId(String operatorId) {
		this.operatorId = operatorId;
	}
	public String getText() {
		return text;
	}
	public void setText(String text) {
		this.text = text;
	}
	public OnSiteOperator getOnSiteOperator() {
		return onSiteOperator;
	}
	public void setOnSiteOperator(OnSiteOperator onSiteOperator) {
		this.onSiteOperator = onSiteOperator;
	}
    
    
}
