package mobile.IMS.api;

import java.io.File;

public class ReportUploader extends Uploader {
	@Override
	protected String getUrl(File uload) {
		return "http://c88dafde179944689e633062115d4a2b.cloudapp.net/ReportService.svc/UploadReport";
	}
	@Override
	public void upload(File file) throws Exception {
		super.upload(file, "post", "application/xml");
	}
}