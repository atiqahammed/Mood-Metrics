package sheared;

import java.util.ArrayList;

import javax.print.attribute.standard.PDLOverrideSupported;

import template.ClassTemplate;
import template.Project;

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
		
		Const.TOTAL_LINE_OF_CODE += linesOfCode.size(); 
		
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

	public static String getProjectPath(String projectName) {
		// TODO Auto-generated method stub
		return "./" + projectName + "-master/";
	}

	public static void processInfo(String projectName, String author) {
		Const.ALL_CLASSES = new ArrayList<ClassTemplate>();
		Const.ALL_FILE_PATH = new ArrayList<String>();
		Const.TOTAL_LINE_OF_CODE = 0;
		
		String projectLink = getProjectGithubLink(projectName, author);
		String projectPath = getProjectPath(projectName);
			
		
		
		
		
		
		Const.FILE_READWRITER.getAllFileNameInDirectory(projectPath);
		ArrayList<String> filteredPath = Const.UTILS.filterCsFiles(Const.ALL_FILE_PATH);
	
		for(String path: filteredPath) 
			Const.UTILS.processClass(path);
		
		for(ClassTemplate template: Const.ALL_CLASSES)
			template.processInfo();
		
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
		int totalRFC = 0;
		int totalCall = 0;
		int totalLCOM1 = 0;
		int totalClassCall = 0;
		
		
		for(ClassTemplate template: Const.ALL_CLASSES) {
			
			totalAttribute += template.getAttributesSize();
			totalHiddenAttribute += template.getHiddenAttributeSize();
			totalHiddenMethod += template.getHiddenMethodSize();
			totalMethod += template.getMethodSize();
			totalRFC += template.getMethodRFC();
			totalPLMRC += template.getPolyMorphucMethodCount();
			totalPMD += template.getNewMethodMultiplyedByDescendants();
			totalMethodCount += template.getTotalMethod();
			totalDefinedMethodCount += template.getDefinedMethod();
			totalAttributeCount += template.getTotalAttribute();
			totalDefinedAttributeCount += template.getDefinedAttribute();
			totalCall += template.getTotalCall();
			totalLCOM1 += template.getLCOM1();
			totalClassCall += template.getTotalCallClass();
			
		}
		
		int TC = Const.ALL_CLASSES.size();
		int lineOfCode = Const.TOTAL_LINE_OF_CODE;
		double WMC = (double)totalMethod / TC;
		int NOC = TC / Const.ncFctr;
		double LCOM1 = (double) totalLCOM1 / TC;
		double COB = (double) totalClassCall / TC;
		double RFC = (double) totalRFC / TC;
		double MHF = (double) totalHiddenMethod / totalMethod;
		double AHF = (double) totalHiddenAttribute / totalAttribute;
		double POF = (double) totalPLMRC / totalPMD;
		double MIF =  (double) totalDefinedMethodCount / totalMethodCount;
		double AIF = (double) totalDefinedAttributeCount / totalAttributeCount;
		double COF = (double) totalCall / (TC * TC - TC);
		
		
		
		System.out.println("PROJECT_NAME                       ::          " + projectName);
		System.out.println("GITHUB LINT                        ::          " + projectLink);
		System.out.println("TOTAL NUMBER OF CLASS              ::          " + TC);
		System.out.println("LINE OF CODE                       ::          " + lineOfCode);
		System.out.println("Weighted Methods Per Class - WMC   ::          " + WMC);
		System.out.println("LCOM1                              ::          " + LCOM1);
		System.out.println("Coupling between Object Classes    ::          " + COB);
		System.out.println("Methods Hiding Factor - MHF        ::          " + MHF);
		System.out.println("Attributes Hiding Factors - AHF    ::          " + AHF);
		System.out.println("POF                                ::          " + POF);
		System.out.println("MIF                                ::          " + MIF);
		System.out.println("RFC                                ::          " + RFC);
		System.out.println("AIF                                ::          " + AIF);
		System.out.println("COF                                ::          " + COF);
		
		
		Project project = new Project(projectName, projectLink, TC, lineOfCode, WMC, LCOM1, COB, MHF, AHF, POF, MIF, AIF, COF, RFC);
		Const.ALL_OUTPUT.add(project.getProjectCSVInfo());
		
		System.out.println();
		
	}

}
