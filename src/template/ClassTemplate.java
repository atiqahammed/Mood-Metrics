package template;

import java.util.ArrayList;

import sheared.Const;

public class ClassTemplate {

	private String className;
	private String path;

	private ArrayList<Attribute> attributes;
	private ArrayList<Method> methods;

	public ClassTemplate(String className, String path) {
		this.className = className;
		this.path = path;
		attributes = new ArrayList<Attribute>();
		methods = new ArrayList<Method>();
	}
	
	public int getAttributesSize() {
		return attributes.size();
	}
	
	public int getMethodSize() {
		return methods.size();
	}
	
	public int getHiddenMethodSize() {
		int count = 0; 
		for(Method method: methods)
			if(method.getType().equals(Const.ACCESS_MODIFIER.get(1)))
				count++;
		return count;
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
		findMethods(allLineOfCode);

	}

	private void findMethods(ArrayList<String> allLineOfCode) {
		// TODO Auto-generated method stub
		
	}

	private void findAttributes(ArrayList<String> tempLine) {

		for (String line : tempLine) {
			String[] words = line.split(" ");
			if (Const.ACCESS_MODIFIER.contains(words[0]) && line.endsWith(";") && !line.endsWith(");")) {
				
				String type = words[0];
				String name = extractAttributeName(words[words.length - 1]);

				attributes.add(new Attribute(name, type));
			}
			
			if(Const.ACCESS_MODIFIER.contains(words[0]) && (line.endsWith(")") || line.endsWith(");"))) {
//				System.out.println(line);
				for(int i = 0; i < words.length; i++) {
//					System.out.println(words[i]);
//					System.out.println();
					String []tempWords = words[i].split("\\(");
					if(tempWords.length > 1) {
						String name = tempWords[0];
						String type = words[0];
//						System.out.println(name +" " + type);
						methods.add(new Method(name, type));
					}
				}
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
