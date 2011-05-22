package mobile.IMS.util;

import java.io.File;
import java.util.Comparator;

public class FileByModifiedComparator implements Comparator<File> {

	private static FileByModifiedComparator instance = null;
	private FileByModifiedComparator() {}
	public static FileByModifiedComparator getInstance() {
		synchronized (FileByModifiedComparator.class) {
			if (instance == null) instance = new FileByModifiedComparator();
		}
		return instance;
	}
	
	public int compare(File a, File b) {
		return (int) (a.lastModified() - b.lastModified());
	}

}
