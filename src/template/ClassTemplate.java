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
	
	
	public void processInfo() {
		ArrayList<String> allLineOfCode = Const.FILE_READWRITER.readStringsFromFile(path);
		ArrayList<String> tempLine = new ArrayList<String>();
		for(String line: allLineOfCode)
			tempLine.add(line.trim());
		allLineOfCode = tempLine;
		
		
		findAttributes(allLineOfCode);
		
		
		
//		for(String line: allLineOfCode)
//			System.out.println(line);
		
		
	}
	
	
	
	


	private void findAttributes(ArrayList<String> tempLine) {
		
		for(String line: tempLine) {
			String [] words = line.split(" ");
			if(Const.ACCESS_MODIFIER.contains(words[0]) && line.endsWith(";") && !line.endsWith(");")) {
				System.out.println(line);
			}
		}
		
		System.out.println("==================");
		
	}


	public String getClassName() {
		return className;
	}

}
