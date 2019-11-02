USE [SmartOffice]
GO

DROP TABLE MthSalesReport
DROP TABLE LogReport
DROP TABLE ContractApproval
DROP TABLE BorrowItemsApproval
DROP TABLE ReimburseApproval
DROP TABLE OvertimeApproval
DROP TABLE LeavingApproval
DROP TABLE Employee
DROP TABLE Department
DROP TABLE BorrowItemList
DROP TABLE typeOfLeaves

GO

CREATE TABLE typeOfLeaves(
	LeaveId              INT                NOT NULL      IDENTITY(1,1),
	LeaveType            NVARCHAR(30)       NOT NULL      UNIQUE,
	PRIMARY KEY(LeaveId)
)
GO

CREATE TABLE BorrowItemList(
	ItemId              INT                NOT NULL      IDENTITY(1,1),
	ItemName            NVARCHAR(30)       NOT NULL      UNIQUE,
	PRIMARY KEY(ItemId)
)
GO

CREATE TABLE Department(
	DpmtId              INT                NOT NULL      IDENTITY(1,1),
	DpmtName            NVARCHAR(30)       NOT NULL      UNIQUE,
	DpmtCity			NVARCHAR(20)	   NOT NULL,
	DpmtState           NVARCHAR(10)       NOT NULL,
	DpmtCountry			NVARCHAR(20)       NOT NULL,
	PRIMARY KEY(DpmtId)
)
GO

CREATE TABLE Employee(
	EmpyId              INT                NOT NULL      IDENTITY(1,1),
	EmpyName            NVARCHAR(30)       NOT NULL      UNIQUE,
	EmpyPwHash			BINARY(24),
	EmpyPwSalt			BINARY(24),
	EmpyAge				INT				   NOT NULL,
	EmpyGender          NVARCHAR(10)       NOT NULL,
	EmpyDOB				DATE               NOT NULL,
	EmpyHmPhnNo         NUMERIC							 UNIQUE,
	EmpyMbPhnNo         NUMERIC		       NOT NULL		 UNIQUE,
	EmpyEmail			NVARCHAR(30)       NOT NULL,
	EmpyMailAdd         NVARCHAR(100)      NOT NULL,
	DpmtId				INT                NOT NULL,
	DpmtName			NVARCHAR(30)       NOT NULL,
	EmpyJobTitle		NVARCHAR(50)       NOT NULL,
	EmpyDrctMgId		INT,
	EmpyDrctMgName		NVARCHAR(30),
	PRIMARY KEY(EmpyId),
	FOREIGN KEY(DpmtId) REFERENCES Department(DpmtId),
	FOREIGN KEY(EmpyDrctMgId) REFERENCES Employee(EmpyId)
)
GO

CREATE TABLE LeavingApproval(
	LAppId              INT                NOT NULL      IDENTITY(1,1),
	LAppTime            DATETIME,
	DpmtId				INT,
	DpmtName            NVARCHAR(30),
	LAppType			NVARCHAR(30),
	LDestination        NVARCHAR(50),
	LAppStartTime       DATETIME,
	LAppEndTime			DATETIME,
	LAppDuration        DATETIME,
	LReason				NVARCHAR(500),
	RequesterEpId		INT,
	RequesterEpNm		NVARCHAR(30),
	ApproverEpId		INT,
	ApproverEpNm		NVARCHAR(30),
	DecisionStatus		BIT,
	PRIMARY KEY(LAppId),
	FOREIGN KEY(DpmtId) REFERENCES Department(DpmtId),
	FOREIGN KEY(RequesterEpId) REFERENCES Employee(EmpyId),
	FOREIGN KEY(ApproverEpId) REFERENCES Employee(EmpyId)
)
GO

CREATE TABLE OvertimeApproval(
	OAppId              INT                NOT NULL      IDENTITY(1,1),
	OAppTime            DATETIME,
	DpmtId				INT,
	DpmtName            NVARCHAR(30),
	PublicHolidayYN		BIT,
	CompMethod			NVARCHAR(50),
	OAppStartTime       DATETIME,
	OAppEndTime			DATETIME,
	OAppDuration        DATETIME,
	OReason				NVARCHAR(500),
	RequesterEpId		INT,
	RequesterEpNm		NVARCHAR(30),
	ApproverEpId		INT,
	ApproverEpNm		NVARCHAR(30),
	DecisionStatus		BIT,
	PRIMARY KEY(OAppId),
	FOREIGN KEY(DpmtId) REFERENCES Department(DpmtId),
	FOREIGN KEY(RequesterEpId) REFERENCES Employee(EmpyId),
	FOREIGN KEY(ApproverEpId) REFERENCES Employee(EmpyId)
)
GO

CREATE TABLE ReimburseApproval(
	RAppId              INT                NOT NULL      IDENTITY(1,1),
	RAppTime            DATETIME,
	DpmtId				INT,
	DpmtName            NVARCHAR(30),
	RAppAmount			INT,
	RAppType			NVARCHAR(50),
	RExpDetails         NVARCHAR(500),
	RequesterEpId		INT,
	RequesterEpNm		NVARCHAR(30),
	ApproverEpId		INT,
	ApproverEpNm		NVARCHAR(30),
	DecisionStatus		BIT,
	PRIMARY KEY(RAppId),
	FOREIGN KEY(DpmtId) REFERENCES Department(DpmtId),
	FOREIGN KEY(RequesterEpId) REFERENCES Employee(EmpyId),
	FOREIGN KEY(ApproverEpId) REFERENCES Employee(EmpyId)
)
GO

CREATE TABLE BorrowItemsApproval(
	BAppId              INT                NOT NULL      IDENTITY(1,1),
	BAppTime            DATETIME,
	DpmtId				INT,
	DpmtName            NVARCHAR(30),
	BAppItemUse			NVARCHAR(50),
	BAppItemId          INT,
	BAppItem			NVARCHAR(30),
	BAppQuantity        INT,
	BAppStartDate		DATETIME,
	BAppEndDate			DATETIME,
	BDetails			NVARCHAR(500),
	RequesterEpId		INT,
	RequesterEpNm		NVARCHAR(30),
	ApproverEpId		INT,
	ApproverEpNm		NVARCHAR(30),
	DecisionStatus		BIT,
	PRIMARY KEY(BAppId),
	FOREIGN KEY(DpmtId) REFERENCES Department(DpmtId),
	FOREIGN KEY(RequesterEpId) REFERENCES Employee(EmpyId),
	FOREIGN KEY(ApproverEpId) REFERENCES Employee(EmpyId),
	FOREIGN KEY(BAppItemId) REFERENCES BorrowItemList(ItemId)
)
GO

CREATE TABLE ContractApproval(
	CAppId              INT                NOT NULL      IDENTITY(1,1),
	CAppTime            DATETIME,
	DpmtId				INT,
	DpmtName            NVARCHAR(30),
	CAppNo				NVARCHAR(30),
	CAppSignDate		DATETIME,
	MyPartyName         NVARCHAR(30),
	MyPartyEpId			INT,
	MyPartyEpNm         NVARCHAR(30),
	OppPartyName        NVARCHAR(30),
	OppPartyEpNm        NVARCHAR(30),
	CAppContent			NVARCHAR(500),
	RequesterEpId		INT,
	RequesterEpNm		NVARCHAR(30),
	ApproverEpId		INT,
	ApproverEpNm		NVARCHAR(30),
	DecisionStatus		BIT,
	PRIMARY KEY(CAppId),
	FOREIGN KEY(DpmtId) REFERENCES Department(DpmtId),
	FOREIGN KEY(RequesterEpId) REFERENCES Employee(EmpyId),
	FOREIGN KEY(ApproverEpId) REFERENCES Employee(EmpyId),
	FOREIGN KEY(MyPartyEpId) REFERENCES Employee(EmpyId)
)
GO

CREATE TABLE LogReport(
	LogId              INT                NOT NULL      IDENTITY(1,1),
	LogTime            DATETIME,
	LogType			   NVARCHAR(30),
	Complete           NVARCHAR(1000),
	Incomplete         NVARCHAR(1000),
	Pending		       NVARCHAR(1000),
	NextPlan		   NVARCHAR(1000),
	Note			   NVARCHAR(30),
	ReporterEpId	   INT,
	ReporterEpNm	   NVARCHAR(30),
	RecipientEpId	   INT,
	RecipientEpNm	   NVARCHAR(30),
	Comments		   NVARCHAR(1000),
	ReadStatus		   BIT,
	PRIMARY KEY(LogId),
	FOREIGN KEY(ReporterEpId) REFERENCES Employee(EmpyId),
	FOREIGN KEY(RecipientEpId) REFERENCES Employee(EmpyId)
)
GO

CREATE TABLE MthSalesReport(
	SalesRpId              INT                NOT NULL      IDENTITY(1,1),
	SalesRpTime            DATETIME,
	Sales			       NVARCHAR(30),
	Clients                NVARCHAR(30),
	ItemName               NVARCHAR(100),
	Quantity		       INT,
	Revenue		           FLOAT,
	SalesTarget			   FLOAT,
	Feedback			   NVARCHAR(1000),
	ReporterEpId	       INT,
	ReporterEpNm	       NVARCHAR(30),
	RecipientEpId	       INT,
	RecipientEpNm	       NVARCHAR(30),
	Comments		       NVARCHAR(1000),
	ReadStatus		       BIT,
	PRIMARY KEY(SalesRpId),
	FOREIGN KEY(ReporterEpId) REFERENCES Employee(EmpyId),
	FOREIGN KEY(RecipientEpId) REFERENCES Employee(EmpyId)
)
GO