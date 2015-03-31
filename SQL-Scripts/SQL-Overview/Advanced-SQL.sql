SELECT FirstName, LastName, Salary 
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)


SELECT FirstName, LastName, Salary 
FROM Employees
WHERE Salary < (SELECT MIN(Salary) * 1.1 FROM Employees)


SELECT e.FirstName, e.LastName, e.Salary, d.Name as DepartmentName
FROM Employees e, Departments d
WHERE Salary = (SELECT MIN(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID)
	AND d.DepartmentID = e.DepartmentID


SELECT AVG(Salary) as [Average Salary for Department 1]
FROM Employees
WHERE DepartmentID = 1


SELECT AVG(Salary) as [Average Salary for Sales Department]
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'


SELECT COUNT(*) as [Sales Employees Count]
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'


SELECT COUNT(ManagerID) as [Employees With Manager]
FROM Employees


SELECT COUNT(*) - COUNT(ManagerID) as [Employees With Manager]
FROM Employees


SELECT d.Name as [Department], AVG(e.Salary) as [Average Salary]
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name


SELECT t.Name as [Town], d.Name as [Department], COUNT(*) as [Employees count]
FROM Employees e 
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
GROUP BY d.Name, t.Name


SELECT m.FirstName, m.LastName, COUNT(*) as [Employees Count]
FROM Employees e JOIN Employees m ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5


SELECT e.FirstName, e.LastName, ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') as [Manager]
FROM Employees e LEFT OUTER JOIN Employees m ON e.ManagerID = m.EmployeeID


SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5


SELECT CONVERT(NVARCHAR(10), GETDATE(), 104) + ' ' + CONVERT(NVARCHAR(12), GETDATE(), 114) as DateTime


CREATE TABLE Users
	(UserId int IDENTITY PRIMARY KEY,
	Username nvarchar(30) NOT NULL UNIQUE,
	Password nvarchar(30) CHECK (LEN(Password) >= 5),
	FullName nvarchar(50),
	LastLoginTime datetime)

GO

CREATE VIEW [Users Logged Today] AS 
SELECT * FROM Users
WHERE CONVERT(DATE, LastLoginTime) = CONVERT(DATE, GETDATE())

GO

CREATE TABLE Groups
	(GroupId int IDENTITY PRIMARY KEY,
	Name nvarchar(30) NOT NULL UNIQUE)

GO

ALTER TABLE Users
ADD GroupId int

GO

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
FOREIGN KEY (GroupId) REFERENCES Groups(GroupId)

GO

INSERT INTO Groups VALUES('Purva Grupa')
INSERT INTO Groups VALUES('Alkoholicite')
INSERT INTO Groups VALUES('Be Grupa')
INSERT INTO Users VALUES('Peco', 'pesho123', 'Pesho Peshev', GETDATE(), 6)
INSERT INTO Users (Username, Password) VALUES ('gogo12', 'qwerty')
INSERT INTO Users (Username, Password) VALUES ('naki4a', 'bira123')


UPDATE Groups SET Name = 'Peshovcite' WHERE Name = 'Be Grupa'
UPDATE Users SET GroupId = 6 WHERE Username = 'naki4a'
UPDATE Users SET GroupId = 7, FullName = 'Just Pesho' WHERE Username = 'Peco'


DELETE FROM Groups WHERE Name = 'Purva Grupa'
DELETE FROM Users WHERE Username = 'gogo12'


INSERT INTO Users (Username, Password, FullName)
	SELECT LOWER(LEFT(FirstName, 3) + LastName),
		   LOWER(LEFT(FirstName, 3) + LastName),
		   FirstName + ' ' + LastName
	FROM Employees


UPDATE Users SET Password = NULL
WHERE LastLoginTime <= CONVERT(DATETIME, '2010-10-03', 120)
	OR LastLoginTime IS NULL


DELETE FROM Users WHERE Password IS NULL


SELECT d.Name as Department, e.JobTitle, AVG(e.Salary) as AverageSalary
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle


SELECT d.Name as Department, e.JobTitle, e.FirstName, e.LastName, MIN(e.Salary) as MinSalary
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName


SELECT TOP 1 t.Name as [Town name], COUNT(*) as [Number of employees]
FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC


SELECT t.Name as [Town name], COUNT(DISTINCT e.ManagerID) as [Number of managers]
FROM Employees e
	JOIN Employees m ON e.ManagerID = m.EmployeeID
	JOIN Addresses a ON m.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name


CREATE TABLE WorkHours
	(Id int PRIMARY KEY IDENTITY,
	EmployeeId int NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeID),
	Hours int NOT NULL,	
	Task nvarchar(50) NOT NULL,
	Comments nvarchar(150),
	Date datetime)

GO

INSERT INTO WorkHours (EmployeeId, Hours, Task) VALUES(4, 7.5, 'Developing')
INSERT INTO WorkHours (EmployeeId, Hours, Task) VALUES(43, 8, 'Testing')
INSERT INTO WorkHours (EmployeeId, Hours, Task) VALUES(11, 2, 'Bug Fixing')
INSERT INTO WorkHours VALUES (55, 5, 'Controllers', 'Work in progress', GETDATE())
INSERT INTO WorkHours VALUES (56, 6, 'View', 'Creting home page view, almost done', GETDATE())
UPDATE WorkHours SET Task = 'More Developing' WHERE EmployeeId = 4
DELETE FROM WorkHours WHERE EmployeeId = 4


CREATE TABLE WorkHoursLogs
	(Id int IDENTITY PRIMARY KEY,
	Command nvarchar(10) NOT NULL,
	OldEmployeeId int,
	NewEmployeeId int,
	OldHours int,
	NewHours int,
	OldTask nvarchar(50),
	NewTask nvarchar(50),
	OldComments nvarchar(150),
	NewComments nvarchar(150),
	OldDate datetime,
	NewDate datetime)

GO


CREATE TRIGGER tr_WorkHoursChange ON WorkHours FOR INSERT, UPDATE, DELETE AS
DECLARE @action nchar(6) = 'INSERT';
IF EXISTS(SELECT * FROM DELETED) SET @action =
	CASE
		WHEN EXISTS(SELECT * FROM INSERTED) THEN 'UPDATE'
		ELSE 'DELETE'
	END
IF @action = 'INSERT' 
	INSERT INTO WorkHoursLogs 
		SELECT @action, NULL, EmployeeId, NULL, Hours, NULL, Task, NULL, Comments, NULL, Date
		FROM INSERTED
ELSE IF @action = 'UPDATE' 
	INSERT INTO WorkHoursLogs
		SELECT @action, d.EmployeeId, i.EmployeeId, d.Hours, i.Hours, d.Task, i.Task, d.Comments, i.Comments, d.Date, i.Date
		FROM INSERTED i, DELETED d
ELSE
	INSERT INTO WorkHoursLogs
		SELECT @action, EmployeeId, NULL, Hours, NULL, Task, NULL, Comments, NULL, Date, NULL
		FROM DELETED


BEGIN TRAN

ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees
ALTER TABLE Departments
	ADD CONSTRAINT FK_Departments_Employees
	FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
DELETE Employees
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

ROLLBACK TRAN


BEGIN TRAN

DROP TABLE EmployeesProjects

ROLLBACK TRAN


SELECT * INTO #EmployeesProjectsCopy FROM EmployeesProjects
DROP TABLE EmployeesProjects
CREATE TABLE EmployeesProjects
	(EmployeeID int FOREIGN KEY REFERENCES Employees(EmployeeID) NOT NULL,
	ProjectID int FOREIGN KEY REFERENCES Projects(ProjectID) NOT NULL)
INSERT INTO EmployeesProjects
	SELECT * FROM #EmployeesProjectsCopy
DROP TABLE #EmployeesProjectsCopy
