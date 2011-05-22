package mobile.IMS.api;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.ProtocolException;
import java.net.URL;
import java.util.UUID;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPut;
import org.apache.http.entity.FileEntity;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;

import android.provider.Settings;
import android.util.Log;

public class PhotoUploader {
	// private static String UrlBase =
	// "http://10.0.2.2:81/PhotoService.svc?report-id=";

	private static String getUrlBase() {
		// runs in emulator
		if (android.provider.Settings.Secure.ANDROID_ID.equals("android_id"))
			return "http://10.0.2.2/PhotoService.svc/photos?reportID={REPORTID}";
		// is running on device
		else
			return "http://192.168.1.4:5100/PhotoService.svc/photos?reportID={REPORTID}";
	}

	public static void Upload(File file, UUID reportUUID) throws Exception {
		HttpClient client = new DefaultHttpClient();
		FileEntity fileEntity = new FileEntity(file, "image/jpeg");
		
		HttpPut put = new HttpPut(getUrlBase().replace("{REPORTID}",
				reportUUID.toString()));
		put.setEntity(fileEntity);
		HttpResponse response = client.execute(put);
		int statusCode = response.getStatusLine().getStatusCode();
		HttpEntity entity = response.getEntity();
		byte[] responseContent = new byte[(int) entity.getContentLength()];
	}
}
