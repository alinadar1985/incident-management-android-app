package mobile.IMS;

import java.io.File;
import java.util.Arrays;

import mobile.IMS.util.FileByModifiedComparator;
import mobile.IMS.util.FileBySuffixFilter;

import org.simpleframework.xml.core.Persister;

import android.os.Environment;

public class ReportPersistence {
	public static File SaveReportData(ReportData data) throws Exception {
		Persister persister = new Persister();
		File reportDir = new File(Environment.getExternalStorageDirectory(),
				"report-data");
		if (!reportDir.exists())
			reportDir.mkdir();
		File reportFile = new File(reportDir, data.getUuid().toString()
				+ ".xml");
		persister.write(data, reportFile);
		return reportFile;
	}

	public static File TopReportDataFile() {
		File reportDir = new File(Environment.getExternalStorageDirectory(),
				"report-data");
		File[] reportFiles = reportDir.listFiles(FileBySuffixFilter
				.getInstance(".xml"));
		Arrays.sort(reportFiles, FileByModifiedComparator.getInstance());
		return reportFiles.length > 0 ? reportFiles[1] : null;
	}
}
