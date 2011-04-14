package mobile.IMS;

import java.util.Date;
import java.util.UUID;

import mobile.IMS.communication.*;
import android.app.Activity;
import android.os.Bundle;
import android.view.*;
import android.view.View.OnClickListener;
import android.widget.*;

public class Start extends Activity {

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main);
		setupListeners();
	}

	private View.OnClickListener buttonClickEventHandler = new OnClickListener() {
		public void onClick(View v) {
			TextView textView = (TextView) findViewById(R.id.editTextIncidentDescription);
			// textView.setText(R.string.hello);
			RestClient client = new RestClient();
			Report report = new Report(
					new Date(),
					UUID.randomUUID().toString(),
					"27ac3e4e-a17e-419a-a2e6-68eaa55f1d4f",
					textView.getText().toString(), 
					null);
			// OMG, hatte schon ganz vergessen was an Java so richtig scheiﬂe
			// ist....
			try {
				client.addReport(report);
			} catch (Exception e) {

			}
		}
	};

	private void setupListeners() {
		Button button = (Button) findViewById(R.id.reportSubmitButton);
		button.setOnClickListener(buttonClickEventHandler);
	}

}