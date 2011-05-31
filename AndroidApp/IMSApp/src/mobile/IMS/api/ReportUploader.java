package mobile.IMS.api;

import java.io.File;

public class ReportUploader extends Uploader {
	@Override
	protected String getUrl(File uload) {
		return "http://618b201c46744a079130d7bc9dce0969.cloudapp.net/ReportService.svc/UploadReport";
	}
	@Override
	public void upload(File file) throws Exception {
		super.upload(file, "post", "application/xml");
	}
}