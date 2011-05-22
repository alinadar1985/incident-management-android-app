package mobile.IMS.api;

import java.io.File;
import java.io.FileInputStream;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;

import android.provider.Settings;

public class ReportUploader {
	//private static String UrlBase = "http://10.0.2.2:81/ReportService.svc/UploadReport";

	private static String getUrlBase() {
		return Settings.Secure.ANDROID_ID == null 
				? "http://10.0.2.2/ReportService.svc/UploadReport"
				: "http://192.168.1.4:5100/ReportService.svc/UploadReport";
	}

	public static void uploadReport(File file) throws Exception {
		OutputStream netStream = null;
		try {
			URL url = new URL(getUrlBase());
			HttpURLConnection connection = (HttpURLConnection) url
					.openConnection();
			connection.setDoInput(true);
			connection.setDoOutput(true);
			connection.setRequestMethod("POST");
			connection.setFixedLengthStreamingMode((int) file.length());
			connection.setConnectTimeout(1000);
			connection.addRequestProperty("Content-Type", "application/xml");
			netStream = connection.getOutputStream();
			FileInputStream fileStream = new FileInputStream(file);
			byte[] buffer = new byte[(int) file.length()];
			fileStream.read(buffer);
			fileStream.close();
			netStream.write(buffer);
			netStream.flush();
			int responseCode = connection.getResponseCode();
			if (responseCode / 200 != 1) {
				throw new RuntimeException("not created");
			}
		} finally {
			netStream.close();
		}
	}
}
