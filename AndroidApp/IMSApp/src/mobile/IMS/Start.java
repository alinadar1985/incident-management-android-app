package mobile.IMS;

import java.io.File;
import java.util.UUID;
import android.app.Activity;
import android.app.AlertDialog;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;
import android.content.DialogInterface;
import android.content.Intent;

public class Start extends Activity implements View.OnClickListener {
	private static final int SCAN_BARCODE = 0xD00DE;
	private static final int TAKE_IMAGE_REQUEST = 0xDEAD;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.start);
		Button reportButton = (Button) findViewById(R.id.newincidentreportbutton);
		reportButton.setOnClickListener(this);

		((Button) findViewById(R.id.new_waypoint_button)).setOnClickListener(this);
		Intent serviceIntent = new Intent(this, BackgroundService.class);
		startService(serviceIntent);
	}

	public void onClick(View view) {
		switch (view.getId()) {
		case R.id.newincidentreportbutton:
			Intent reportIntent = new Intent(this, Report.class);
			reportIntent.putExtra(Report.REPORT_UUID, UUID.randomUUID());
			startActivity(reportIntent);
		case R.id.new_waypoint_button:
			AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(this);
			dialogBuilder
					.setPositiveButton("Scan barcode",
							new DialogInterface.OnClickListener() {
								public void onClick(DialogInterface dialog, int which) {
									Intent intent = new Intent(
											"com.google.zxing.client.android.SCAN");
									intent.setPackage("com.google.zxing.client.android");
									startActivityForResult(intent, SCAN_BARCODE);
								}
							})
					.setNeutralButton("Shoot Photo",
							new DialogInterface.OnClickListener() {
								public void onClick(DialogInterface dialog, int which) {
									String photoFileName = UUID.randomUUID().toString()
											+ ".jpg";
									File photoPath = new File(Environment
											.getExternalStorageDirectory(),
											"waypoints");
									// ensure that /incidents directy exist
									if (!photoPath.exists()) {
										boolean success = photoPath.mkdirs();
										if (!success) {
											throw new RuntimeException(
													"Could not create Image path!");
										}
									}
									// save camera data in this file
									File photoFile = new File(photoPath, photoFileName);
									Uri photoUri = Uri.fromFile(photoFile);
									Intent captureImage = new Intent(
											MediaStore.ACTION_IMAGE_CAPTURE);
									captureImage.putExtra(MediaStore.EXTRA_OUTPUT,
											photoUri);
									captureImage.putExtra(MediaStore.EXTRA_SIZE_LIMIT,
											240 * 1024);
									startActivityForResult(captureImage,
											TAKE_IMAGE_REQUEST);
								}
							})
					.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog, int which) {}
					})
					.setCancelable(true)
					.setTitle("Barcode or Photo?")
					.show();
		}
	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		switch (requestCode) {
		case SCAN_BARCODE:
			if (resultCode == RESULT_OK) {
				String barcode = data.getStringExtra("SCAN_RESULT");
				Toast.makeText(this, barcode, Toast.LENGTH_LONG).show();
			}
		}

	}
}
