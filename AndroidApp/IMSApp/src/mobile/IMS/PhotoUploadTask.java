package mobile.IMS;

import static android.os.Environment.getExternalStorageDirectory;

import java.io.File;
import java.util.Arrays;
import java.util.TimerTask;

import mobile.IMS.api.PhotoUploader;
import mobile.IMS.util.FileByModifiedComparator;
import mobile.IMS.util.FileBySuffixFilter;
import android.util.Log;

public class PhotoUploadTask extends TimerTask {

	private final static File filePath = new File(
			getExternalStorageDirectory(), "incidents");

	@Override
	public void run() {
		File uploadFile = firstFile();
		if (uploadFile != null) {
			try {
				new PhotoUploader().upload(uploadFile);
				uploadFile.delete();
			} catch (Exception e) {
				Log.w("IMSUPL", "Upload failed", e);
			}
		}
	}

	private File firstFile() {
		// only jpgs
		File[] photoFiles = filePath.listFiles(FileBySuffixFilter
				.getInstance(".jpg"));
		// sort by date
		Arrays.sort(photoFiles, FileByModifiedComparator.getInstance());
		return photoFiles.length > 0 ? photoFiles[0] : null;
	}
}