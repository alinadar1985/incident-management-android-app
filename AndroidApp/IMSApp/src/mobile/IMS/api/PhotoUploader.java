package mobile.IMS.api;

import java.io.File;

public class PhotoUploader extends Uploader {
	@Override
	protected String getUrl(File upload) {
		String pattern = "http://c88dafde179944689e633062115d4a2b.cloudapp.net/PhotoService.svc/photos?reportID={REPORTID}";
		String fileName = upload.getName();
		String url = pattern.replace("{REPORTID}", fileName.substring(0, fileName.indexOf(".")));
		return url;
	}
	
	@Override
	public void upload(File file) throws Exception {
		super.upload(file, "put", "image/jpeg");
	}
}