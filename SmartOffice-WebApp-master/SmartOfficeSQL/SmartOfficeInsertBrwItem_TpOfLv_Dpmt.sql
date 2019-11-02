USE [SmartOffice]
GO

INSERT INTO [dbo].[BorrowItemList]
           ([ItemName])
     VALUES
           ('Mouse'),
		   ('Keyboard'),
		   ('Speaker'),
		   ('Printer'),
		   ('Headphone'),
		   ('MousePad'),
		   ('Pendrive')

GO

select * from BorrowItemList

INSERT INTO [dbo].[TypeOfLeaves]
           ([LeaveType])
     VALUES
           ('Sick Leave'),
		   ('Bussiness Trip')
GO

select * from TypeOfLeaves

INSERT INTO [dbo].[Department]
           ([DpmtName]
           ,[DpmtCity]
           ,[DpmtState]
           ,[DpmtCountry])
     VALUES
		   ('Admin Office','Fairfield','CT','US'),
		   ('Human Resource Department','Fairfield','CT','US'),
		   ('Financial Department','New York City','NY','US'),
		   ('Manufacture Department','Charlotte','NC','US'),	   
		   ('Logistic Department','Charlotte','NC','US'),
		   ('Sales Department','Dallas','TX','US')
GO

select * from Department