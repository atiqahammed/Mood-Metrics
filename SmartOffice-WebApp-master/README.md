# SmartOffice-WebApp
<h3>Introduction</h3>
This is a final project of my graduate course named ASP.NET Web Development II.<br>
This web application is developed on Visual Studio 2017. ASP.NET and C# were used.<br>
*Files are not the whole project. Only the main code for the web pages, front end and back end.

<h3>Features</h3>
1.A smart web workplace which gives one-stop solution on which employees can apply for approvals, report to managers, and managers can review and provide a decision or make comments.<br>
2.The modules include “Paid Off Time Approval”, “Overtime Approval”, “Reimbursements Approval”, “Borrow Items Approval”, “Contract Approval”, and "Reports".<br>
3.The system reduce the paperwork burden for the office management and provide a clear picture to management about employees’ availability and their routine progress.<br>

<h3>Software Environment & Design Method</h3>
1.Build database management system using MS SQL Server.<br>
2..Net Framework 4.6.1<br>
3.OOD is used throughout the project development.<br>

<h3>Technical Points</h3>
1.Password Hash&Salt<br>
2.Session State<br>
3.Repeater<br>
  a.Load Data from Datasource(session is used here)<br>
  b.Create hyperlink with ID as suffix(http://localhost:58556/Views/Outputs/OvertimeRead?OAppId=1.aspx)<br>
4.Read/Unread pages<br>
  a.Get url with ID suffix from current page<br>
  b.Use ID to get data from Database using SQL (SELECT, UPDATE)
