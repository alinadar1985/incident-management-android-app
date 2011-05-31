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

//package mobile.IMS.api;
//
//import java.io.File;
//import java.io.FileInputStream;
//import java.io.InputStream;
//import java.io.OutputStream;
//import java.net.HttpURLConnection;
//import java.net.URL;
//
//import mobile.IMS.R;
//
//import org.apache.http.HttpEntity;
//import org.apache.http.HttpResponse;
//import org.apache.http.client.HttpClient;
//import org.apache.http.client.methods.HttpOptions;
//import org.apache.http.client.methods.HttpPost;
//import org.apache.http.entity.BufferedHttpEntity;
//import org.apache.http.entity.FileEntity;
//import org.apache.http.entity.StringEntity;
//import org.apache.http.impl.client.DefaultHttpClient;
//import org.apache.http.params.HttpConnectionParams;
//import org.apache.http.params.HttpParams;
//
//import android.R.integer;
//import android.provider.Settings;
//import android.text.AndroidCharacter;
//import android.util.Log;
//import android.view.View;
//
//public class ReportUploader {
//	// private static String UrlBase =
//	// "http://10.0.2.2:81/ReportService.svc/UploadReport";
//
//	private static String getUrlBase() {
//		return
//		// "http://10.0.2.2:81/ReportService.svc/UploadReport"
//		"http://618b201c46744a079130d7bc9dce0969.cloudapp.net/ReportService.svc/UploadReport";
//	}
//
//	public static void uploadReport(File file) throws Exception {
//		HttpClient http = new DefaultHttpClient();
//		HttpParams params = http.getParams();
//		HttpConnectionParams.setConnectionTimeout(params, 1000);
//		FileEntity fileEntity = new FileEntity(file, "application/xml");
//		HttpPost postRequest = new HttpPost(getUrlBase());
//		postRequest.setEntity(fileEntity);
//		HttpResponse response = http.execute(postRequest);
//		int statusCode = response.getStatusLine().getStatusCode();
//		if ((statusCode / 200) != 1) {
//			
//			HttpEntity responseEntity = response.getEntity();
//			if (responseEntity != null) {
//
//				int contentLength = (int) responseEntity.getContentLength();
//				byte[] buffer = new byte[contentLength];
//				InputStream stream = responseEntity.getContent();
//				stream.read(buffer);
//				String content = new String(buffer, "UTF8");
//				Log.w("IMS-REP", content);
//			}
//			throw new Exception("FUCK");
//		}
//
//	}
//	// public static void uploadReport(File file) throws Exception {
//	// OutputStream netStream = null;
//	// try {
//	// URL url = new URL(getUrlBase());
//	// HttpURLConnection connection = (HttpURLConnection) url
//	// .openConnection();
//	// connection.setDoInput(true);
//	// connection.setDoOutput(true);
//	// connection.setRequestMethod("POST");
//	// connection.setFixedLengthStreamingMode((int) file.length());
//	// connection.setConnectTimeout(1000);
//	// connection.addRequestProperty("Content-Type", "application/xml");
//	// netStream = connection.getOutputStream();
//	// FileInputStream fileStream = new FileInputStream(file);
//	// byte[] buffer = new byte[(int) file.length()];
//	// fileStream.read(buffer);
//	// fileStream.close();
//	// netStream.write(buffer);
//	// netStream.flush();
//	// int responseCode = connection.getResponseCode();
//	// if (responseCode / 200 != 1) {
//	// throw new RuntimeException("not created");
//	// }
//	// } finally {
//	// netStream.close();
//	// }
//	// }
//}
