package main;

import java.util.ArrayList;

import sheared.Const;
import template.ClassTemplate;

public class AppStart {

	public static void main(String[] args) {
		System.out.println("Mood Metrics");
	
		Const.FILE_READWRITER.getAllFileNameInDirectory(Const.PROJECT_1);
		ArrayList<String> filteredPath = Const.UTILS.filterCsFiles(Const.ALL_FILE_PATH);
		
		
//		System.out.println(Const.ALL_FILE_PATH.size());
		
		
		for(String path: filteredPath) 
			Const.UTILS.processClass(path);
//		Const.UTILS.processClass(filteredPath.get(0));
		
//		System.out.println(Const.ALL_CLASSES.size());
		int totalHiddenAttribute = 0;
		int totalAttribute = 0;
		for(ClassTemplate template: Const.ALL_CLASSES) {
			
			totalAttribute += template.getAttributesSize();
			totalHiddenAttribute += template.getHiddenAttributeSize();
		}
		
		System.out.println(totalAttribute);
		System.out.println(totalHiddenAttribute);
		
		
		System.out.println("Attributes Hiding Factors : AHF = " + (double) totalHiddenAttribute / totalAttribute);
		System.out.println("total number of classes: Ci = " + Const.ALL_CLASSES.size());
		
		
		
//		System.out.println(filteredPath.get(0));
//		System.out.println(filteredPath.size());
		
	}
	
	
}
