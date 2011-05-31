package mobile.IMS;

import java.io.File;
import java.util.Date;
import java.util.UUID;

import mobile.IMS.api.UploadManager;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class Report extends Activity implements View.OnClickListener {

	private static final int TAKE_IMAGE_REQUEST = 0xdead;
	public static final int EXTRA_REPORT_UUID = 0xbeef;
	private UUID incidentUuid = null;
	public final static String REPORT_UUID = "mobile.IMS.Report.FILL_OUT";
	private final UploadManager uploadManager = UploadManager.getInstance();

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main);
		setupListeners();
		this.incidentUuid = (UUID) getIntent().getExtras().get(REPORT_UUID);
	}

	

	@Override
	public void finish() {
		String textDescription = getDescriptionTextView().getText().toString();
		String priority = getPriorityButton().getText().toString();
		String location = getLocationTextView().getText().toString();
		ReportData report = new ReportData();
		report.setDateTime(new Date());
		report.setPriority(priority);
		report.setLocation(location);
		report.setTextDescription(textDescription);
		report.setUuid(this.incidentUuid.toString());
		report.setOperatorID("00000000-0000-0000-0000-000000000000");
		try {
			uploadManager.AddReport(report);
		} catch (Exception e) {
			Log.e("IMS", "Could not write Report file", e);
		}
		super.finish();
	}

	private void setupListeners() {
		// get View references
		Button submitButton = (Button) findViewById(R.id.reportSubmitButton);
		submitButton.setOnClickListener(this);
		Button choosePriorityButton = (Button) findViewById(R.id.report_btn_priority);
		choosePriorityButton.setOnClickListener(this);
	}

	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.reportSubmitButton: // submit button was clicked
			if (this.incidentUuid == null)
				throw new NullPointerException("incidentReport was null");
			// callback for the dialog
			DialogInterface.OnClickListener takePhotoDialogListener = new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dialog, int which) {
					switch (which) {
					case DialogInterface.BUTTON_POSITIVE:
						takePhoto(); // flow continues at onActivityResult
						break;
					case DialogInterface.BUTTON_NEUTRAL:
						Report.this.setResult(RESULT_OK);
						// User doesn't want to take a photo
						Report.this.finish();
						break;
					case DialogInterface.BUTTON_NEGATIVE:
						// User canceled
						Report.this.setResult(RESULT_CANCELED);
						break;
					}
				}
			};
			// build dialog to ask for a photo
			AlertDialog.Builder takePhotoDialog = new AlertDialog.Builder(this);
			takePhotoDialog.setMessage(R.string.ask_for_photo)
					.setPositiveButton("Yes", takePhotoDialogListener)
					.setNeutralButton("No", takePhotoDialogListener)
					.setNegativeButton("Cancel", takePhotoDialogListener);
			takePhotoDialog.show();
			break;
		case R.id.report_btn_priority: // priority button clicked
			final String[] priorities = getResources().getStringArray(
					R.array.report_priorities);
			DialogInterface.OnClickListener priorityListener = new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dialog, int which) {
					String priority = priorities[which];
					Button priorityButton = (Button) findViewById(R.id.report_btn_priority);
					priorityButton.setText(priority);
					dialog.cancel();
				}
			};
			AlertDialog.Builder priorityDialog = new AlertDialog.Builder(this);
			priorityDialog.setSingleChoiceItems(priorities, -1,
					priorityListener).show();
			break;
		default:
			break;
		}
	}

	private void takePhoto() {
		String photoFileName = incidentUuid.toString() + ".jpg";
		File photoPath = new File(Environment.getExternalStorageDirectory(),
				"incidents");
		// ensure that /incidents directy exist
		if (!photoPath.exists()) {
			boolean success = photoPath.mkdirs();
			if (!success) { throw new RuntimeException("Could not create Image path!"); }
		}
		// save camera data in this file
		File photoFile = new File(photoPath, photoFileName);
		Uri photoUri = Uri.fromFile(photoFile);
		Intent captureImage = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
		captureImage.putExtra(MediaStore.EXTRA_OUTPUT, photoUri);
		captureImage.putExtra(MediaStore.EXTRA_SIZE_LIMIT, 50);
		startActivityForResult(captureImage, TAKE_IMAGE_REQUEST);
	}
	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		switch (requestCode) {
		case TAKE_IMAGE_REQUEST:
			switch (resultCode) {
			case RESULT_OK:
				uploadManager.AddPhoto(this.incidentUuid);
				Toast.makeText(this, "Image Taken", Toast.LENGTH_SHORT).show();
				this.setResult(RESULT_OK);
				this.finish();
				break;
			case RESULT_CANCELED:
				Toast.makeText(this, "No Image taken!", Toast.LENGTH_LONG);
				break;
			}
		}
	}

	private TextView getDescriptionTextView() {
		return (TextView) findViewById(R.id.editTextIncidentDescription);
	}

	private TextView getLocationTextView() {
		return (TextView) findViewById(R.id.report_edit_location);
	}

	private Button getPriorityButton() {
		return (Button) findViewById(R.id.report_btn_priority);
	}
}