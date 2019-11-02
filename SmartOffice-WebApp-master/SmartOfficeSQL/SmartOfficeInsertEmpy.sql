USE [SmartOffice]
GO

INSERT INTO [dbo].[Employee]
           ([EmpyName]
		   ,[EmpyPwHash]
		   ,[EmpyPwSalt]
           ,[EmpyAge]
           ,[EmpyGender]
           ,[EmpyDOB]
           ,[EmpyHmPhnNo]
           ,[EmpyMbPhnNo]
           ,[EmpyEmail]
           ,[EmpyMailAdd]
           ,[DpmtId]
           ,[DpmtName]
           ,[EmpyJobTitle]
           ,[EmpyDrctMgId]
           ,[EmpyDrctMgName])
     VALUES
           ('Tom Frank',null,null,36,'Male','19830210',2032128877,2032127688,'tomfrank@gmail.com','NO.12 APT Apple St. Fairfield CT 06824',1,'Admin Office','CEO',null,null),
		   ('Lucy Lee',null,null,28,'Female','19910315',2032128856,2032127656,'lucylee@gmail.com','NO.16 APT Sunny St. Fairfield CT 06825',2,'Human Resource Department','Manager',1,'Tom Frank'),
		   ('Judy Crowley',null,null,33,'Female','19860820',6463458794,6463458797,'judycrowley@gmail.com','NO.22 APT Green St. NYC NY 10001',3,'Financial Department','Manager',1,'Tom Frank'),
		   ('Jack Carter',null,null,35,'Male','19840217',7046678888,7043221556,'jackcarter@gmail.com','NO.12 APT Juddy St. Charlotte NC 28105',4,'Manufacture Department','Manager',1,'Tom Frank'),
		   ('James He',null,null,27,'Male','19921115',7042123345,7043136678,'jameshe@gmail.com','NO.52 APT Watt St. Charlotte NC 28205',5,'Logistic Department','Manager',1,'Tom Frank'),
		   ('Lily Ang',null,null,29,'Female','19901211',2142128877,2142127688,'lilyang@gmail.com','NO.25 APT Hayyet St. Dallas TX 75001',6,'Sales Department','Manager',1,'Tom Frank'),
		   ('Amy Ye',null,null,34,'Female','19850610',2032146554,2033237887,'amyye@gmail.com','378 Jenny Rd. Fairfield CT 06826',2,'Human Resource Department','Supervisor',2,'Lucy Lee'),
		   ('Sam Hawk',null,null,36,'Male','19831112',6465678899,6465887689,'samhawk@gmail.com','33 East St. NYC NY 10001',3,'Financial Department','Supervisor',3,'Judy Crowley'),
		   ('John Samberry',null,null,30,'Male','19890723',7046667548,7043337667,'johnsamberry@gmail.com','277 APT Juice Rd. Charlotte CT 28105',4,'Manufacture Department','Supervisor',4,'Jack Carter'),
		   ('Alex July',null,null,32,'Male','19870324',7048182234,7043334478,'alexjuly@gmail.com','577 Hank Rd. Charlotte CT 28205',5,'Logistic Department','Supervisor',5,'James He'),
		   ('Yiwei Sun',null,null,33,'Male','19860522',2145567688,2143136578,'yiweisun@gmail.com','778 Sammya St. Dallas TX 75001',6,'Sales Department','Supervisor',6,'Lily Ang'),
		   ('Modi Clay',null,null,26,'Male','19930202',20325567445,2032334456,'modiclay@gmail.com','56 Mill Plain Rd. Fairfield CT 06824',2,'Human Resource Department','Staff',7,'Amy Ye'),
		   ('Vanna Chun',null,null,27,'Female','19920716',6463546789,6462345678,'vannachun@gmail.com','789 Sandy Rd. NYC NY 10001',3,'Financial Department','Staff',8,'Sam Hawk'),
		   ('April Cruz',null,null,25,'Female','19940810',7046667211,7043335544,'aprilcruz@gmail.com','56 Juwee St. Charlotte CT 28105',4,'Manufacture Department','Staff',9,'John Samberry'),
		   ('Julia Luora',null,null,24,'Female','19950428',7043164990,7048789933,'julialuora@gmail.com','NO.59 APT Honey St. Charlotte CT 28205',5,'Logistic Department','Staff',10,'Alex July'),
		   ('Jessie Li',null,null,25,'Female','19940918',2145576875,2143453349,'jessieli@gmail.com','239 July Rd. Dallas TX 75001',6,'Sales Department','Staff',11,'Yiwei Sun'),
		   ('Coco Penny',null,null,26,'Female','19930622',7042225678,7045156644,'cocopenny@gmail.com','1232 APT Jonny St. Charlotte CT 28105',4,'Manufacture Department','Staff',9,'John Samberry'),
		   ('Katy Taylor',null,null,26,'Female','19930219',7045167790,7046178654,'katytaylor@gmail.com','NO.33 APT Woody St. Charlotte CT 28205',5,'Logistic Department','Staff',10,'Alex July'),
		   ('Will Foss',null,null,25,'Male','19941228',2148895665,21433445665,'willfoss@gmail.com','36 Junsoo Rd. Dallas TX 75001',6,'Sales Department','Staff',11,'Yiwei Sun')

GO

select * from Employee

