package sheared;

import java.util.ArrayList;

import template.ClassTemplate;

public class Utils {

	public ArrayList<String> filterCsFiles(ArrayList<String> filePaths) {

		ArrayList<String> filteredPath = new ArrayList<String>();

		for (String path : filePaths)
			if (path.endsWith(".cs"))
				filteredPath.add(path);

		return filteredPath;
	}

	public ClassTemplate processClass(String path) {

		ArrayList<String> linesOfCode = Const.FILE_READWRITER.readStringsFromFile(path);

		if (isClass(linesOfCode)) {
			System.out.println("this is a class");
		}

		return null;
	}

	private boolean isClass(ArrayList<String> linesOfCode) {

		for (String line : linesOfCode) {
			String trimedLine = line.trim();

			if (!trimedLine.startsWith("#")) {
				String keywords[] = trimedLine.split(" ");
				if (classKeyWordFound(keywords)) {
					return true;
				}
//				System.out.println(line);
			}
//			System.out.println(line);
		}

		return false;
	}

	private boolean classKeyWordFound(String[] keywords) {

		if (keywords.length >= 2 && keywords[1].equals("class") && keywords[0].equals("public"))
			return true;
		return false;
	}

}
