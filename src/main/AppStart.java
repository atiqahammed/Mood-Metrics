package main;

import java.util.ArrayList;

import sheared.Const;
import sheared.Utils;
import template.ClassTemplate;

public class AppStart {

	public static void main(String[] args) {
		System.out.println("Mood Metrics");
	
		Const.FILE_READWRITER.getAllFileNameInDirectory(Const.PROJECT_1);
		ArrayList<String> filteredPath = Const.UTILS.filterCsFiles(Const.ALL_FILE_PATH);
		
		
//		System.out.println(Const.ALL_FILE_PATH.size());
		
		
		for(String path: filteredPath) 
			Const.UTILS.processClass(path);
		
		for(ClassTemplate template: Const.ALL_CLASSES)
			template.processInfo();
//		Const.UTILS.processClass(filteredPath.get(0));
		
//		System.out.println(Const.ALL_CLASSES.size());
		int totalHiddenAttribute = 0;
		int totalAttribute = 0;
		int totalHiddenMethod = 0;
		int totalMethod = 0;
		int totalPLMRC = 0;
		int totalPMD = 0;
		int totalMethodCount = 0;
		int totalDefinedMethodCount = 0;
		int totalAttributeCount = 0;
		int totalDefinedAttributeCount = 0;
		int totalCall = 0;
		
		for(ClassTemplate template: Const.ALL_CLASSES) {
			
			totalAttribute += template.getAttributesSize();
			totalHiddenAttribute += template.getHiddenAttributeSize();
			totalHiddenMethod += template.getHiddenMethodSize();
			totalMethod += template.getMethodSize();
			totalPLMRC += template.getPolyMorphucMethodCount();
			totalPMD += template.getNewMethodMultiplyedByDescendants();
			totalMethodCount += template.getTotalMethod();
			totalDefinedMethodCount += template.getDefinedMethod();
			totalAttributeCount += template.getTotalAttribute();
			totalDefinedAttributeCount += template.getDefinedAttribute();
			totalCall += template.getTotalCall();
		}
		
		System.out.println(totalAttribute);
		System.out.println(totalHiddenAttribute);
		
		int TC = Const.ALL_CLASSES.size();
		
		System.out.println("Methods Hiding Factor : MHF = " + (double) totalHiddenMethod / totalMethod);
		System.out.println("Attributes Hiding Factors : AHF = " + (double) totalHiddenAttribute / totalAttribute);
		System.out.println("total number of classes: Ci = " + Const.ALL_CLASSES.size());
		System.out.println("POF :" +(double) totalPLMRC / totalPMD);
		System.out.println("MIF: " + (double) totalDefinedMethodCount / totalMethodCount);
		System.out.println("AIF : " + (double) totalDefinedAttributeCount / totalAttributeCount);
		System.out.println("COF : " + (double) totalCall / (TC * TC - TC));
//		System.out.println(filteredPath.get(0));
//		System.out.println(filteredPath.size());
		
	}
	
	
}
