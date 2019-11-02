package template;

public class Project {

	private String projectName;
	private int numberOfClasses;
	private String gitLink;
	private int lineOfCode;
	private double WMC;
	private double LCOM1;
	private double COB;
	private double MHF;
	private double AHF;
	private double POF;
	private double MIF;
	private double AIF;
	private double COF;
	private double RFC;
	private int	totalHiddenAttribyute;
	private int totalAttribute;
	private int totalPublicAttribute;
	private int totalHiddenMethod;
	private int totalMethod;
	private int totalPublicMethod;
	
	public Project(	String projectName, 
					String gitLink, 
					int numberOfClasses, 
					int lineOfCode, 
					double WMC, 
					double LCOM1, 
					double COB, 
					double MHF, 
					double AHF, 
					double POF,
					double MIF, 
					double AIF, 
					double COF, 
					double RFC, 
					int	totalHiddenAttribyute,
					int totalAttribute,
					int totalPublicAttribute,
					int totalHiddenMethod,
					int totalMethod,
					int totalPublicMethod) {
		
		
		this.projectName = projectName;
		this.gitLink = gitLink;
		this.numberOfClasses = numberOfClasses;
		this.lineOfCode = lineOfCode;
		this.WMC = WMC;
		this.LCOM1 = LCOM1;
		this.COB = COB;
		this.MHF = MHF;
		this.AHF = AHF;
		this.POF = POF;
		this.MIF = MIF;
		this.AIF = AIF;
		this.COF = COF;
		this.RFC = RFC;
		this.totalHiddenAttribyute = totalHiddenAttribyute;
		this.totalAttribute = totalAttribute;
		this.totalPublicAttribute = totalPublicAttribute;
		this.totalHiddenMethod = totalHiddenMethod;
		this.totalMethod = totalMethod;
		this.totalPublicMethod = totalPublicMethod;
		
	}

	public String getProjectName() {
		return projectName;
	}
	
	public String getProjectCSVInfo() {
		return 	projectName + "," +
				gitLink + "," +
				numberOfClasses + "," +
				lineOfCode + "," +
				WMC + "," +
				LCOM1 + "," +
				COB + "," +
				RFC + "," +
				MHF + "," +
				AHF + "," +
				POF + "," +
				MIF + "," +
				AIF + "," +
				COF + "," +
				totalHiddenAttribyute + "," +
				totalAttribute + "," +
				totalPublicAttribute + "," +
				totalHiddenMethod + "," +
				totalMethod + "," +
				totalPublicMethod;
	}
	
	
	
	
}
