USE MASTER
GO
CREATE DATABASE PerformanceTest
GO
USE PerformanceTest
GO

CREATE TABLE TestTable
	(Id int PRIMARY KEY IDENTITY,
	Date datetime,
	Text nvarchar(100))
GO

INSERT INTO TestTable(Text, Date) Values('Text Number 1', GETDATE())
INSERT INTO TestTable(Text, Date) Values('Text Number 2', DATEADD(DAY, 20, GETDATE()))
INSERT INTO TestTable(Text, Date) Values('Text Number 3', DATEADD(DAY, 40, GETDATE()))
INSERT INTO TestTable(Text, Date) Values('Text Number 4', DATEADD(DAY, 80, GETDATE()))
INSERT INTO TestTable(Text, Date) Values('Text Number 5', DATEADD(DAY, 160, GETDATE()))
INSERT INTO TestTable(Text, Date) Values('Text Number 6', DATEADD(DAY, 150, GETDATE()))
INSERT INTO TestTable(Text, Date) Values('Text Number 7', DATEADD(DAY, 55, GETDATE()))

--This may take a while. Feel free to reduce the number of entries.
DECLARE @counter int = 0
WHILE (SELECT COUNT(*) FROM TestTable) < 10000000
BEGIN
  INSERT INTO TestTable(Date, Text)
  SELECT DATEADD(DAY, @counter * 20, Date), Text + CONVERT(nvarchar, @counter) FROM TestTable
  SET @counter += 1
END
GO

SELECT COUNT(*) FROM TestTable

CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT Date FROM TestTable
WHERE Date BETWEEN GETDATE() AND DATEADD(YEAR, 3, GETDATE())

CREATE INDEX IDX_TestTable_Date
ON TestTable(Date)

CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT Date FROM TestTable
WHERE Date BETWEEN GETDATE() AND DATEADD(YEAR, 3, GETDATE())
