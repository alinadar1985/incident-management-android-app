package mobile.IMS;

import static android.os.Environment.getExternalStorageDirectory;

import java.io.File;
import java.util.Arrays;
import java.util.TimerTask;
import java.util.UUID;

import mobile.IMS.util.FileByModifiedComparator;
import mobile.IMS.util.FileBySuffixFilter;

import android.os.Environment;
import android.util.Log;

import static mobile.IMS.api.ReportUploader.uploadReport;

public class ReportUploadTask extends TimerTask {
	private final static File filePath = new File(
			getExternalStorageDirectory(), "report-data");

	@Override
	public void run() {
		File reportFile = getFirstFile();
		if (reportFile != null) {
			try {
				uploadReport(reportFile);
				reportFile.delete();
			} catch (Exception e) {
				Log.w("IMSUPL", e);
			}
		}

	}

	private File getFirstFile() {
		File[] reportFiles = filePath.listFiles(FileBySuffixFilter
				.getInstance(".xml"));
		Arrays.sort(reportFiles, FileByModifiedComparator.getInstance());
		return reportFiles.length > 0 ? reportFiles[0] : null;
	}

	private static UUID getFileUUID(File file) {
		String fileName = file.getName();
		String uuidString = fileName.substring(0, fileName.indexOf('.') - 1);
		return UUID.fromString(uuidString);
	}
}
