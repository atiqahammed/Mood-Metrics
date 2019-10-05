package sheared;

import java.util.ArrayList;

public class Utils {
	
	public ArrayList<String> filterCsFiles(ArrayList<String> filePaths) {
		
		ArrayList<String> filteredPath = new ArrayList<String>();
		
		for(String path: filePaths) 
			if(path.endsWith(".cs")) 
				filteredPath.add(path);
			
		return filteredPath;
	}

}
