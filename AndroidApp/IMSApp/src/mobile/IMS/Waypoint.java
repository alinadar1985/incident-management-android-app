package mobile.IMS;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;

public class Waypoint extends Activity {
	private static final int SCAN_BARCODE = 0xD00DE;
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(this);
		dialogBuilder.setPositiveButton("Scan barcode", new DialogInterface.OnClickListener() {
			public void onClick(DialogInterface dialog, int which) {
				Intent intent = new Intent("com.google.zxing.client.android.SCAN");
		        intent.setPackage("com.google.zxing.client.android");
		        startActivityForResult(intent, SCAN_BARCODE);
			}
		}).setNeutralButton("Shoot Photo", new DialogInterface.OnClickListener() {
			
			public void onClick(DialogInterface dialog, int which) {
				
			}
		}).setNeutralButton("Cancel",new DialogInterface.OnClickListener() {
			
			public void onClick(DialogInterface dialog, int which) {
				
			}
		}).setCancelable(true).setTitle("Barcode or Photo?").create();		
	}
	 
	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		// TODO Auto-generated method stub
		super.onActivityResult(requestCode, resultCode, data);
	}
}
