USE [SmartOffice]
GO

DROP PROCEDURE wca_sel_GetCredentials
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Yifei Li
-- Create date: 4/19/2019
-- Description:	Get the employee's credentials. Will return this full row from Employee table
-- =============================================
CREATE PROCEDURE [dbo].[wca_sel_GetCredentials] 
	@EmpyEmail		NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
	   [EmpyId]
      ,[EmpyName]
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
	  ,[EmpyDrctMgName]
  FROM [dbo].[Employee] u
  WHERE
	u.EmpyEmail = @EmpyEmail

END
GO
