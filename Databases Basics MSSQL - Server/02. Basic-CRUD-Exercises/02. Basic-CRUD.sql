--1 Problem - Get familiar

--2 Problem
SELECT *
FROM Departments

--3 Problem
SELECT [Name]
FROM Departments

--4 Problem
SELECT [FirstName],
	[LastName],
	[Salary]
FROM Employees

--5 Problem
SELECT [FirstName],
	[MiddleName],
	[LastName]
FROM Employees


--6 Problem
SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' AS [Full Email Address]
FROM Employees

--7 Problem
SELECT DISTINCT [Salary] 
FROM Employees

--8 Problem
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

--9 Problem
SELECT [FirstName],
	[LastName],
	[JobTitle]
FROM Employees
WHERE Salary BETWEEN 20000
		AND 30000

--10 Problem
SELECT [FirstName] + ' ' + [MiddleName] + ' ' + [LastName] AS 'Full Name'
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--11 Problem
SELECT [FirstName],
	[LastName]
FROM Employees
WHERE ManagerID IS NULL

--12 Problem
SELECT [FirstName],
	[LastName],
	[Salary]
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--13 Problem
SELECT TOP (5) [FirstName],
	[LastName]
FROM Employees
ORDER BY Salary DESC

--14 Problem
SELECT [FirstName],
	[LastName]
FROM Employees
WHERE DepartmentID != 4

--15 Problem
SELECT *
FROM Employees
ORDER BY Salary DESC,
	FirstName,
	LastName DESC,
	MiddleName
GO

--16 Problem
CREATE VIEW [V_EmployeesSalaries]
AS
SELECT [FirstName],
	[LastName],
	[Salary]
FROM Employees
GO

--17 Problem
CREATE VIEW [V_EmployeeNameJobTitle ]
AS
SELECT [FirstName] + ' ' + ISNULL([MiddleName], '') + ' ' + [LastName] AS [Full Name],
	[JobTitle] AS [Job Title]
FROM Employees
GO

--18 Problem
SELECT DISTINCT [JobTitle]
FROM Employees

--19 Problem
SELECT TOP(10) * FROM Projects
ORDER BY StartDate, [Name]

--20 Problem
SELECT TOP(7) [FirstName],[LastName],[HireDate] FROM Employees
ORDER BY [HireDate] DESC

--21 Problem
UPDATE Employees
SET [Salary] = Salary * 1.12
WHERE DepartmentID IN (
		SELECT [DepartmentID]
		FROM Departments
		WHERE [Name] IN (
				'Engineering',
				'Tool Design',
				'Marketing',
				'Information Services'
				)
		)

SELECT [Salary]
FROM Employees

--22 Problem
SELECT [PeakName] FROM Peaks
ORDER BY [PeakName]

--23 Problem
SELECT TOP (30) [CountryName],
	[Population]
FROM Countries
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC,
	CountryName

--24 Problem
SELECT [CountryName],
	[CountryCode],
	CASE 
		WHEN [CurrencyCode] = 'EUR'
			THEN 'Euro'
		ELSE 'Not Euro'
	END 
AS [Currency]
FROM Countries
ORDER BY [CountryName]

--25 Problem
USE Diablo

SELECT [Name]
FROM Characters
ORDER BY [Name]



