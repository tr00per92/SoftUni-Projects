SELECT * FROM Departments


SELECT Name FROM Departments


SELECT FirstName, LastName, Salary FROM Employees


SELECT FirstName + ' ' + LastName AS [Full Name] FROM Employees


SELECT FirstName + '.' + LastName + '@softuni.bg' AS Email FROM Employees


SELECT DISTINCT Salary FROM Employees


SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'


SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'


SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'


SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary BETWEEN 20000 AND 30000


SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)


SELECT * FROM Employees
WHERE ManagerID IS NULL


SELECT * FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC


SELECT TOP 5 * FROM Employees
ORDER BY Salary DESC


SELECT e.FirstName, e.LastName, a.AddressText
FROM Employees e JOIN Addresses a
ON e.AddressID = a.AddressID


SELECT e.FirstName, e.LastName, a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID


SELECT e.FirstName, e.LastName, m.FirstName + m.LastName as [Manager Name]
FROM Employees e LEFT OUTER JOIN Employees m ON e.ManagerID = m.EmployeeID


SELECT e.FirstName, e.LastName, a.AddressText, m.FirstName + m.LastName as [Manager Name]
FROM Employees e 
	LEFT OUTER JOIN Employees m ON e.ManagerID = m.EmployeeID
	JOIN Addresses a ON e.AddressID = a.AddressID


SELECT Name FROM Departments 
UNION SELECT Name FROM Towns


SELECT e.FirstName, e.LastName, m.FirstName + m.LastName as [Manager Name]
FROM Employees m RIGHT OUTER JOIN Employees e ON e.ManagerID = m.EmployeeID


SELECT e.FirstName, e.LastName, d.Name as DepartmentName, e.HireDate
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance')
	AND Year(e.HireDate) BETWEEN 1995 AND 2005
