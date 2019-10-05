package sheared;

import java.util.ArrayList;
import java.util.Arrays;

import fileManager.FileReadWriter;
import template.ClassTemplate;

public class Const {
	
	public static final FileReadWriter FILE_READWRITER = new FileReadWriter();
	public static final Utils UTILS = new Utils();
	
	
	public static ArrayList<ClassTemplate> ALL_CLASSES = new ArrayList<ClassTemplate>();
	public static final ArrayList<String> ACCESS_MODIFIER = new ArrayList<String>(Arrays.asList("public", "private", "protected")); 
        
    
	
	public static ArrayList<String> ALL_FILE_PATH = new ArrayList<String>();
	
	public static final String PROJECT_1 = "./Reddnet/";
	public static final String PROJECT_2 = "./BlogCoreEngine/";

}
