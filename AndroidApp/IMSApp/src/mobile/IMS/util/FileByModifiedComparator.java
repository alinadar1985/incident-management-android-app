package mobile.IMS.util;

import java.io.File;
import java.util.Comparator;

public class FileByModifiedComparator implements Comparator<File> {

	private static FileByModifiedComparator instance = null;

	private FileByModifiedComparator() {
	}

	public static FileByModifiedComparator getInstance() {
		if (instance == null) {
			synchronized (FileByModifiedComparator.class) {
				if (instance == null)
					instance = new FileByModifiedComparator();
			}
		}
		return instance;
	}

	public int compare(File a, File b) {
		Long lA = Long.valueOf(a.lastModified());
		Long lB = Long.valueOf(b.lastModified());
		return lA.compareTo(lB) * -1; // old files to the front of a queue
	}

}
