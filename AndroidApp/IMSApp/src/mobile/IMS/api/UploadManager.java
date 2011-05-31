package mobile.IMS.api;

import static android.os.Environment.getExternalStorageDirectory;

import java.io.File;
import java.io.FilenameFilter;
import java.util.Arrays;
import java.util.concurrent.PriorityBlockingQueue;

import mobile.IMS.ReportData;
import mobile.IMS.ReportPersistence;
import mobile.IMS.util.FileByModifiedComparator;


public class UploadManager {
	
	/*
	 * Threadsafe singleton Implementation
	 */
	private static UploadManager instance = null;
	private static Object sync = new Object();
	
	public static UploadManager getInstance() {
		if (instance==null) {
			synchronized (sync) {
				if (instance == null)
					instance = new UploadManager();
			}
		}
		return instance;
	}
	
	
	
	
	private final PriorityBlockingQueue<File> reportDataQueue;
	private final PriorityBlockingQueue<File> photoQueue;
	private final File photoFileDirectory = new File(getExternalStorageDirectory(),
			"incidents");
	private final File reportDataFileDirectory = new File(getExternalStorageDirectory(),
			"report-data");

	private UploadManager() {
		reportDataQueue = new PriorityBlockingQueue<File>(50, FileByModifiedComparator.getInstance());
		photoQueue = new PriorityBlockingQueue<File>(50, FileByModifiedComparator.getInstance());
		initQueues();
	}
	
	private void initQueues() {
		File[] reportDataFiles = reportDataFileDirectory.listFiles(new FilenameFilter() {
			public boolean accept(File dir, String filename) {
				return filename.endsWith(".xml");
			}
		});
		File[] photoFiles = photoFileDirectory.listFiles(new FilenameFilter() {	
			public boolean accept(File dir, String filename) {
				return filename.endsWith(".jpg");
			}
		});
		for (File reportDataFile : reportDataFiles)
			reportDataQueue.add(reportDataFile);
		for (File photoFile : photoFiles)
			photoQueue.add(photoFile);
	}
	
	public void AddReport(ReportData report) throws Exception {
		File reportFile = ReportPersistence.SaveReportData(report);
		reportDataQueue.add(reportFile);
	}
	
	public void AddPhoto(File photo) {
		reportDataQueue.add(photo);
	}
	
	public File topReportFile() {
		return reportDataQueue.peek();
	}
	
	public void removeReportFile(File reportFile) {
		reportDataQueue.remove(reportFile);
		reportFile.delete();
	}
	
	public void removePhotoFile(File photoFile) {
		photoQueue.remove(photoFile);
		photoFile.delete();
	}
	
	public File[] listReportFiles() {
		File[] inQueue = (File[]) reportDataQueue.toArray();
		Arrays.sort(inQueue, FileByModifiedComparator.getInstance());
		return inQueue;
	}
	
	public File[] listPhotoFiles() {
		File[] inQueue = (File[]) photoQueue.toArray();
		Arrays.sort(inQueue, FileByModifiedComparator.getInstance());
		return inQueue;
	}
}
