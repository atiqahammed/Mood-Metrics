package template;

import java.util.ArrayList;

import sheared.Const;
import sheared.Utils;

public class ClassTemplate {

	private String className;
	private String path;

	private ArrayList<Attribute> attributes;
	private ArrayList<Method> methods;
	private ArrayList<String> polyMorphicMethods;
	private ArrayList<String> descendants;
	
	
	public String getPath() {
		return path;
	}
	
	
	public ClassTemplate(String className, String path) {
		this.className = className;
		this.path = path;
		attributes = new ArrayList<Attribute>();
		methods = new ArrayList<Method>();
		polyMorphicMethods = new ArrayList<String>();
		descendants = new ArrayList<String>();
		
		
	}
	
	private void processDescendants() {
		
		descendants.add(className);
		for(ClassTemplate classTemplate: Const.ALL_CLASSES) {
			ArrayList<String> linesOfCode = Const.FILE_READWRITER.readStringsFromFile(classTemplate.getPath());
			
			
			for (String line : linesOfCode) {
				String trimedLine = line.trim();

				if (!trimedLine.startsWith("#")) {
					String keywords[] = trimedLine.split(" ");
					if (Utils.classKeyWordFound(keywords)) {
//						System.out.println("-------------------");
						boolean implemented = false;
						boolean thisClass = false;
						for(int i = 0; i < keywords.length; i++) {
							if(keywords[i].equals(":"))
								implemented = true;
							if(keywords[i].equals(className))
								thisClass = true;
						}
//							System.out.println(keywords[i]);
						if(thisClass && implemented)
							descendants.add(classTemplate.getClassName());
					}
				}
			}
				
		}
		
	}
	
	

	private void processPolyMorphicMethod() {
		ArrayList<String> uniqueMethods = new ArrayList<String>();
		for(Method method: methods) {
			String methodName = method.getName();
			if(!uniqueMethods.contains(methodName)) {
				uniqueMethods.add(methodName);
				polyMorphicMethods.add(methodName);
			}
		}
	}
	
	public int getPolyMorphucMethodCount() {
		return polyMorphicMethods.size();
	}
	
	public int getNewMethodMultiplyedByDescendants() {
		return descendants.size() * methods.size();
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
		
		processPolyMorphicMethod();
		processDescendants();

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
