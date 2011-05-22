package mobile.IMS;

import java.util.Timer;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;

public class BackgroundService extends Service {

	private final Timer timer = new Timer(true);

	@Override
	public IBinder onBind(Intent arg0) {
		// TODO Auto-generated method stub

		return null;
	}

	@Override
	public int onStartCommand(Intent intent, int flags, int startId) {
		timer.schedule(new PhotoUploadTask(), 1000, 1000);
		timer.schedule(new ReportUploadTask(), 2000, 2000);
		return START_STICKY;
	}
}
