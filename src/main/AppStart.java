package main;

import sheared.Const;
import sheared.Utils;

public class AppStart {

	public static void main(String[] args) {
		
		System.out.println("-- // SOFTWARE Metrics \\\\ --");
		System.out.println("----------------------------");
		System.out.println();
		
		Const.ALL_OUTPUT.add(Const.HEADER);
		
		int iteration = Const.PROJECTS.size(); 
		
		for(int i = 0; i < iteration; i++) {
			Utils.processInfo(Const.PROJECTS.get(i), Const.PROJECT_AUTHOR.get(i));
			System.out.println();
			System.out.println();
		}
		
		Const.FILE_READWRITER.writeOutput(Const.ALL_OUTPUT, Const.OUTPUT_CSV_FILE);
		
	}
	
	
}
