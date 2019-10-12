package sheared;

import java.util.ArrayList;
import java.util.Arrays;

import fileManager.FileReadWriter;
import template.ClassTemplate;

public class Const {
	
	public static final FileReadWriter FILE_READWRITER = new FileReadWriter();
	public static final Utils UTILS = new Utils();
	
	public static ArrayList<ClassTemplate> ALL_CLASSES;// = new ArrayList<ClassTemplate>();
	public static final ArrayList<String> ACCESS_MODIFIER = new ArrayList<String>(Arrays.asList("public", "private", "protected")); 
    public static int TOTAL_LINE_OF_CODE;    
	
	public static ArrayList<String> ALL_FILE_PATH;// = new ArrayList<String>();
	
	public static final String PROJECT_1 = "./Reddnet/";
	public static final String PROJECT_2 = "./BlogCoreEngine/";

	
	public static final ArrayList<String> PROJECTS = 
			new ArrayList<String>(
					Arrays.asList(
									"BlogCoreEngine",
									"Location-Scout",
									"NetLogSystem",
									"Online-Auction",
									"Reddnet",
									"SiGCT",
									"SmartOffice-WebApp",
									"staff-review",
									"UofT-Timetable-Generator",
									"volley-management"
							));
	
	
	public static final ArrayList<String> PROJECT_AUTHOR = 
			new ArrayList<String>(
					Arrays.asList(
									"moritz-mm",
									"girishpatni",
									"Vladimir-Novick",
									"whd18",
									"moritz-mm",
									"fabianohkd",
									"Evelynfeifei",
									"ms853",
									"EKarton",
									"VolleyManagement"
							));
	
	
	public static String HEADER = 		"\"PROJECT NAME\"" + "," +
									 	"\"GITHUB LINK\"" + "," +
									 	"\"TOTAL NUMBER OF CLASSES\"" + "," +
									 	"\"LINE OF CODE\"" + "," +
									 	"\"WMC\"" + "," +
									 	"\"LCOM1\"" + "," +
									 	"\"COB\"" + "," +
									 	"\"RFC\"" + "," +
									 	"\"MHF\"" + "," +
									 	"\"AHF\"" + "," +
									 	"\"POF\"" + "," +
									 	"\"MIF\"" + "," +
									 	"\"AIF\"" + "," +
									 	"\"COF\"" ; 
	
	
	
	
	
	public static String OUTPUT_CSV_FILE = "result.csv";
	public static ArrayList<String> ALL_OUTPUT = new ArrayList<String>();
	public static int ncFctr = 10;
	public static int rfFctr = 3;
	
}
