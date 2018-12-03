--1 Problem
USE SoftUni

SELECT [FirstName],
	[LastName]
FROM Employees
WHERE SUBSTRING(FirstName, 1, 2) = 'SA'

--2 Problem
SELECT [FirstName],
	[LastName]
FROM Employees
WHERE LastName LIKE '%ei%'

--3 Problem
SELECT [FirstName]
FROM Employees
WHERE DepartmentID IN (3,10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--4 Problem
SELECT [FirstName], [LastName]
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--5 Problem
SELECT [Name]
FROM Towns
WHERE DATALENGTH([Name]) IN (5,6)
ORDER BY [Name]

--6 Problem
SELECT [TownID],
	[Name]
FROM Towns

WHERE SUBSTRING([Name],1,1) IN('M','B','K','E')
ORDER BY [Name]

--7 Problem
SELECT [TownID],
	[Name]
FROM Towns

WHERE SUBSTRING([Name],1,1) NOT IN ('B','R','D')
ORDER BY [Name]
GO
--8 Problem
CREATE VIEW V_EmployeesHiredAfter2000
AS
SELECT [FirstName],
	[LastName]
FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000
GO

--9 Problem
SELECT [FirstName],
	[LastName]
FROM Employees
WHERE DATALENGTH([LastName]) = 5

--10 Problem
USE [Geography]

SELECT [CountryName],
[IsoCode]
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--11 Problem
SELECT p.PeakName, r.RiverName, LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName)-1)) AS Mix
FROM Peaks AS p
JOIN Rivers AS r
ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix