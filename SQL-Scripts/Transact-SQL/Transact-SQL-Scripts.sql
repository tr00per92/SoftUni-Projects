CREATE DATABASE BankAccounts
GO

USE BankAccounts
GO

CREATE TABLE Persons
	(PersonId int PRIMARY KEY IDENTITY,
	FirstName nvarchar(30) NOT NULL,
	LastName nvarchar(30) NOT NULL,
	SSN nvarchar(10))
GO

CREATE TABLE Accounts
	(AccountId int PRIMARY KEY IDENTITY,
	PersonId int FOREIGN KEY REFERENCES Persons(PersonId) NOT NULL,
	Balance money NOT NULL)
GO

INSERT INTO Persons VALUES('Ivan', 'Ivanov', '123213')
INSERT INTO Persons VALUES('Pesho', 'Peshev', '6876867')
INSERT INTO Persons VALUES('Kiril', 'Georgiev', '4365346')
INSERT INTO Persons VALUES('Tosho', 'Goshev', '68786876')
INSERT INTO Persons VALUES('Pencho', 'Petkov', '345345345')
INSERT INTO Persons VALUES('Petko', 'Ignatov', '364653634')
INSERT INTO Persons VALUES('Dragan', 'Stoyanov', '63463643')
GO

INSERT INTO Accounts VALUES(2, 2000)
INSERT INTO Accounts VALUES(2, 100)
INSERT INTO Accounts VALUES(3, 50.55)
INSERT INTO Accounts VALUES(7, 15000)
INSERT INTO Accounts VALUES(6, 2000)
INSERT INTO Accounts VALUES(6, 22500)
INSERT INTO Accounts VALUES(1, 1050.60)
INSERT INTO Accounts VALUES(5, 200.22)
GO

CREATE PROC usp_SelectPersonFullNames AS
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Persons
GO

EXEC usp_SelectPersonFullNames
GO

CREATE PROC usp_SelectPersonsByMinMoney(@minMoney int) AS
SELECT p.FirstName, p.LastName, a.Balance
FROM Persons p JOIN Accounts a ON p.PersonId = a.PersonId
WHERE a.Balance >= @minMoney
GO

EXEC usp_SelectPersonsByMinMoney 1000
GO

CREATE FUNCTION ufn_CalcInterest(@balance money, @interest numeric(6, 4), @months int) 
RETURNS money AS
BEGIN
	RETURN @balance + @balance * @interest / 12 * @months
END
GO

SELECT dbo.ufn_CalcInterest(10000, 0.078, 6)
GO

CREATE PROC usp_CalcInterest(@accountId int, @interest numeric(6, 4)) AS
SELECT p.FirstName, p.LastName, a.Balance, dbo.ufn_CalcInterest(a.Balance, @interest, 1) as [Balance After One Month]
FROM Persons p JOIN Accounts a ON p.PersonId = a.PersonId
WHERE a.AccountId = @accountId
GO

EXEC usp_CalcInterest 6, 0.06
GO

CREATE PROC usp_WithrawMoney(@accountId int, @amount money) AS
BEGIN TRAN
	UPDATE Accounts 
	SET Balance = Balance - @amount
	WHERE AccountId = @accountId
COMMIT TRAN
GO

CREATE PROC usp_DepositMoney(@accountId int, @amount money) AS
BEGIN TRAN
	UPDATE Accounts 
	SET Balance = Balance + @amount
	WHERE AccountId = @accountId
COMMIT TRAN
GO

EXEC usp_DepositMoney 6, 1000
EXEC usp_WithrawMoney 6, 2200
GO

CREATE TABLE Logs
	(LogId int PRIMARY KEY IDENTITY,
	AccountId int FOREIGN KEY REFERENCES Accounts(AccountId) NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL)
GO

CREATE TRIGGER tr_AccountsUpdateSum ON Accounts FOR UPDATE AS
INSERT INTO Logs
	SELECT i.AccountId, d.Balance, i.Balance
	FROM INSERTED i, DELETED d
GO


USE SoftUni
GO

CREATE FUNCTION CheckForLetters(@word nvarchar(50), @letters nvarchar(50)) 
RETURNS BIT AS 
BEGIN
IF(@word IS NULL) 
	RETURN 0 
DECLARE @wordLen int = LEN(@word), @containsAll bit = 1, @currentChar nvarchar(1) 
WHILE(@wordLen > 0) 
	BEGIN
		SET @currentChar = SUBSTRING(@word, @wordLen, 1) 
		IF(CHARINDEX(@currentChar, @letters) = 0) 
			BEGIN 
				SET @containsAll = 0 
				BREAK 
			END 
		SET @wordLen = @wordLen - 1
	END 
RETURN @containsAll 
END 
GO

CREATE FUNCTION FindNamesAndTowns(@letters nvarchar(50))
RETURNS @result TABLE (Name nvarchar(50) NOT NULL) AS
BEGIN
INSERT INTO @result
	SELECT LastName FROM Employees	
INSERT INTO @result
	SELECT FirstName FROM Employees
INSERT INTO @result
	SELECT Name FROM Towns
DELETE FROM @result
	WHERE dbo.CheckForLetters(Name, @letters) = 0
RETURN
END
GO

SELECT * FROM dbo.FindNamesAndTowns('oistmiahf')
GO

DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT e.FirstName + ' ' + e.LastName as Employee, t.Name
	FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID = t.TownID
OPEN empCursor
DECLARE @employee nvarchar(100), @town nvarchar(50), @employeeTemp nvarchar(100), @townTemp nvarchar(50)
FETCH NEXT FROM empCursor INTO @employeeTemp, @townTemp
FETCH NEXT FROM empCursor INTO @employee, @town
WHILE @@FETCH_STATUS = 0
	BEGIN		
		IF @townTemp = @town
			PRINT @town + ' - ' + @employee + ', ' + @employeeTemp
		SET @employeeTemp = @employee
		SET @townTemp = @town
		FETCH NEXT FROM empCursor INTO @employee, @town
	END
CLOSE empCursor
DEALLOCATE empCursor
GO


CREATE ASSEMBLY concatAssembly
   AUTHORIZATION dbo   
   FROM 'C:\Temp\StrConcat.dll' -- the location of the dll
   WITH PERMISSION_SET = SAFE; 
GO 

SP_CONFIGURE 'clr enabled', 1
GO
RECONFIGURE
GO

CREATE AGGREGATE StrConcat (@value nvarchar(MAX)) 
RETURNS nvarchar(MAX) 
EXTERNAL Name concatAssembly.StrConcat; 
GO

SELECT dbo.StrConcat(FirstName + ' ' + LastName) as [All Employees]
FROM Employees
GO

DECLARE townCursor CURSOR READ_ONLY FOR
	SELECT t.Name as Town, dbo.StrConcat(e.FirstName + ' ' + e.LastName) as Employeess
	FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID = t.TownID
	GROUP BY t.Name
OPEN townCursor
DECLARE @town nvarchar(50), @employees nvarchar(MAX)
FETCH NEXT FROM townCursor INTO @town, @employees
WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @town + ' -> ' + @employees
		FETCH NEXT FROM townCursor INTO @town, @employees
	END
CLOSE townCursor
DEALLOCATE townCursor
GO
