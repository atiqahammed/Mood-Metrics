package template;

import java.util.ArrayList;

import sheared.Const;

public class ClassTemplate {

	private String className;
	private String path;

	private ArrayList<Attribute> attributes;

	public ClassTemplate(String className, String path) {
		this.className = className;
		this.path = path;
		attributes = new ArrayList<Attribute>();
	}
	
	public int getAttributesSize() {
		return attributes.size();
	}
	
	public int getHiddenAttributeSize() {
		int count = 0; 
		for(Attribute attribute: attributes)
			if(attribute.getType().equals(Const.ACCESS_MODIFIER.get(1)))
				count++;
		return count;
	}

	public void processInfo() {
		ArrayList<String> allLineOfCode = Const.FILE_READWRITER.readStringsFromFile(path);
		ArrayList<String> tempLine = new ArrayList<String>();
		for (String line : allLineOfCode)
			tempLine.add(line.trim());
		allLineOfCode = tempLine;

		findAttributes(allLineOfCode);

	}

	private void findAttributes(ArrayList<String> tempLine) {

		for (String line : tempLine) {
			String[] words = line.split(" ");
			if (Const.ACCESS_MODIFIER.contains(words[0]) && line.endsWith(";") && !line.endsWith(");")) {
				
				String type = words[0];
				String name = extractAttributeName(words[words.length - 1]);

				attributes.add(new Attribute(name, type));
			}
		}

	}

	private String extractAttributeName(String str) {
		if (str.charAt(str.length() - 1) == ';') {
			str = str.replace(str.substring(str.length() - 1), "");
			return str;
		} else {
			return str;
		}
	}

	public String getClassName() {
		return className;
	}

}
