package main;

import java.util.ArrayList;

import fileManager.FileReadWriter;
import sheared.Const;

public class AppStart {

	public static void main(String[] args) {
		System.out.println("hello dear");
	
		Const.FILE_READWRITER.getAllFileNameInDirectory(Const.PROJECT_1);
		ArrayList<String> filteredPath = Const.UTILS.filterCsFiles(Const.ALL_FILE_PATH);
		
		
		System.out.println(Const.ALL_FILE_PATH.size());
		System.out.println(filteredPath.size());
		
	}
	
	
}
