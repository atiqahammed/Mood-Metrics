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

			String className = getClassName(linesOfCode);
			ClassTemplate template = new ClassTemplate(className, path);

//			template.processInfo();

			Const.ALL_CLASSES.add(template);
		}

		return null;
	}

	private String getClassName(ArrayList<String> linesOfCode) {
		for (String line : linesOfCode) {
			String trimedLine = line.trim();
			String keywords[] = trimedLine.split(" ");
			if (keywords.length >= 3 && keywords[1].equals("class") && keywords[0].equals("public"))
				return keywords[2];

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
			}
		}

		return false;
	}

	public static boolean classKeyWordFound(String[] keywords) {

		if (keywords.length >= 2 && keywords[1].equals("class") && keywords[0].equals("public"))
			return true;
		return false;
	}

	public static String getProjectGithubLink(String projectName, String author) {
		return "https://github.com/" + author + "/" + projectName;
	}

}
