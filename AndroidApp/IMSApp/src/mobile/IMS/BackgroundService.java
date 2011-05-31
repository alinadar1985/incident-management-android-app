package mobile.IMS;

import java.io.File;

import mobile.IMS.api.PhotoUploader;
import mobile.IMS.api.ReportUploader;
import mobile.IMS.api.UploadManager;
import android.app.Service;
import android.content.Intent;
import android.os.IBinder;

public class BackgroundService extends Service {

	
	private Runnable photoUploadTask = new Runnable() {

		public void run() {
			UploadManager upload = UploadManager.getInstance();
			do {
				File photoFile = upload.topPhotoFile(); // blocking
				if (photoFile == null) continue;
				try {
					new PhotoUploader().upload(photoFile);
					photoFile.delete();
				} catch (Exception e) {
					upload.AddPhoto(photoFile);
				}
			} while (true);
		}
	};

	private Runnable reportUploadTask = new Runnable() {

		public void run() {
			UploadManager upload = UploadManager.getInstance();
			do {
				File reportDataFile = upload.topReportFile(); // blocking
				if (reportDataFile==null)continue;
				try {
					new ReportUploader().upload(reportDataFile);
					reportDataFile.delete();
				} catch (Exception e) {
					upload.AddReport(reportDataFile);
				}
			} while (true);
		}
	};

	@Override
	public IBinder onBind(Intent arg0) {
		return null;
	}

	@Override
	public int onStartCommand(Intent intent, int flags, int startId) {
		new Thread(reportUploadTask, "Report upload").start();
		new Thread(photoUploadTask, "Photo upload").start();
		return super.onStartCommand(intent, flags, startId);
	}
}
