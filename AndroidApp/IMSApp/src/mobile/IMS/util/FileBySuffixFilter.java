package mobile.IMS.util;

import java.io.File;
import java.io.FileFilter;
import java.util.HashMap;

public class FileBySuffixFilter implements FileFilter {
	private final static HashMap<String, FileBySuffixFilter> instances = new HashMap<String, FileBySuffixFilter>();
	private final String suffix;

	public static FileBySuffixFilter getInstance(String suffix) {
		synchronized (instances) {
			if (!instances.containsKey(suffix))
				instances.put(suffix, new FileBySuffixFilter(suffix));
		}
		return instances.get(suffix);

	}

	private FileBySuffixFilter(String suffix) {
		if (suffix != null)
			this.suffix = suffix;
		else
			throw new NullPointerException("suffix is null");
	}

	public boolean accept(File pathname) {
		return pathname.getName().endsWith(suffix);
	}

}
