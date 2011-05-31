package mobile.IMS.api;

import java.io.File;

public class PhotoUploader extends Uploader {
	@Override
	protected String getUrl(File upload) {
		String pattern = "http://618b201c46744a079130d7bc9dce0969.cloudapp.net/PhotoService.svc/photos?reportID={REPORTID}";
		String fileName = upload.getName();
		String url = pattern.replace("{REPORTID}", fileName.substring(0, fileName.indexOf(".")));
		return url;
	}
	
	@Override
	public void upload(File file) throws Exception {
		super.upload(file, "put", "image/jpeg");
	}
}
//
// import java.io.File;
// import java.io.FileInputStream;
// import java.io.IOException;
// import java.io.InputStream;
// import java.io.OutputStream;
// import java.net.HttpURLConnection;
// import java.net.ProtocolException;
// import java.net.URL;
// import java.util.UUID;
//
// import org.apache.http.HttpEntity;
// import org.apache.http.HttpResponse;
// import org.apache.http.client.HttpClient;
// import org.apache.http.client.methods.HttpPut;
// import org.apache.http.entity.BufferedHttpEntity;
// import org.apache.http.entity.FileEntity;
// import org.apache.http.entity.StringEntity;
// import org.apache.http.impl.client.DefaultHttpClient;
// import org.apache.http.params.HttpConnectionParams;
// import org.apache.http.params.HttpParams;
//
// import android.provider.Settings;
// import android.util.Log;
//
// public class PhotoUploader {
// // private static String UrlBase =
// // "http://10.0.2.2:81/PhotoService.svc?report-id=";
//
// private static String getUrlBase() {
// // return
// // "http://192.168.1.4:5100/PhotoService.svc/photos?reportID={REPORTID}";
// return
// "http://618b201c46744a079130d7bc9dce0969.cloudapp.net/PhotoService.svc/photos?reportID={REPORTID}";
// // "http://65.52.154.255/PhotoService.svc/photos?reportID={REPORTID}";
// // return
// // "http://10.0.2.2:81/PhotoService.svc/photos?reportID={REPORTID}";
// }
//
// public static void Upload(File file, String reportUUID) throws Exception {
// HttpClient http = new DefaultHttpClient();
// HttpParams params = http.getParams();
// HttpConnectionParams.setConnectionTimeout(params, 20000);
// FileEntity fileEntity = new FileEntity(file, "image/jpeg");
// BufferedHttpEntity buffered = new BufferedHttpEntity(fileEntity);
// // fileEntity.setChunked(true);
// HttpPut put = new HttpPut(getUrlBase().replace("{REPORTID}",
// reportUUID));
// put.setEntity(buffered);
// HttpResponse response = http.execute(put);
// int statusCode = response.getStatusLine().getStatusCode();
// if ((statusCode / 200) != 1) {
// HttpEntity responseEntity = response.getEntity();
// if (responseEntity != null) {
//
// int contentLength = (int) responseEntity.getContentLength();
// byte[] buffer = new byte[contentLength];
// InputStream stream = responseEntity.getContent();
// stream.read(buffer);
// String content = new String(buffer, "UTF8");
// Log.w("IMS-UPL", content);
// }
// throw new Exception("FUCK");
// }
// }
// }
