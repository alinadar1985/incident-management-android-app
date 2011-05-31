package mobile.IMS.api;

import java.io.File;
import java.io.InputStream;

import org.apache.http.HttpEntity;
import org.apache.http.HttpEntityEnclosingRequest;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpPut;
import org.apache.http.client.methods.HttpUriRequest;
import org.apache.http.entity.BufferedHttpEntity;
import org.apache.http.entity.FileEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;

import android.util.Log;

public abstract class Uploader {
	protected abstract String getUrl(File uload);

	public abstract void upload(File file) throws Exception;

	public void upload(File file, String method, String contentType) throws Exception {
		String url = getUrl(file);
		HttpClient http = new DefaultHttpClient();
		HttpParams params = http.getParams();
		HttpConnectionParams.setConnectionTimeout(params, 1000);
		FileEntity fileEntity = new FileEntity(file, contentType);
		BufferedHttpEntity bufferedEntity = new BufferedHttpEntity(fileEntity);
		// Build Request
		HttpEntityEnclosingRequest request;
		if (method.compareToIgnoreCase("put") == 0) {
			request = new HttpPut(url);
		} else if (method.compareToIgnoreCase("post") == 0) {
			request = new HttpPost(url);
		} else {
			throw new RuntimeException("FUCK!");
		}
		request.setEntity(bufferedEntity);
		HttpResponse response = http.execute((HttpUriRequest) request);

		int statusCode = response.getStatusLine().getStatusCode();
		if ((statusCode / 200) != 1) { // Errrrrrrror!
			HttpEntity responseEntity = response.getEntity();
			if (responseEntity != null) {

				int contentLength = (int) responseEntity.getContentLength();
				byte[] buffer = new byte[contentLength];
				InputStream stream = responseEntity.getContent();
				stream.read(buffer);
				String content = new String(buffer, "UTF8");
				Log.w("IMS-UPL", content);
			}
			throw new Exception("FUCK");
		}
	}
}
