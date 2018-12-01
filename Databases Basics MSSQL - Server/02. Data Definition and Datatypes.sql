--1
CREATE DATABASE Minions

--2
CREATE TABLE Minions (
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50),
	Age INT
	)

CREATE TABLE Towns (
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50)
	)

--3
ALTER TABLE Minions ADD TownId INT

ALTER TABLE Minions ADD FOREIGN KEY (TownId) REFERENCES Towns (Id)

--4
INSERT INTO Towns (
	Id,
	[Name]
	)
VALUES 
(1, 'Sofia'), 
(2, 'Plovdiv'), 
(3, 'Varna')


INSERT INTO Minions (
	Id,
	[Name],
	Age,
	TownId
	)
VALUES 
(1, 'Kevin', 22, 1), 
(2, 'Bob', 15, 3), 
(3, 'Steward', DEFAULT, 2)


--5
TRUNCATE TABLE Minions

--6
DROP TABLE Minions

DROP TABLE Towns

--7
CREATE TABLE People (
	Id INT PRIMARY KEY identity,
	[Name] NVARCHAR(200) NOT NULL,
	Pciture VARBINARY(MAX),
	Height FLOAT(2),
	Wight FLOAT(2),
	Gender CHAR(1) CHECK (Gender = 'm' OR Gender = 'f') NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
	)

INSERT INTO People (
	Name,
	Height,
	Pciture,
	Wight,
	Gender,
	Birthdate,
	Biography
	)
VALUES 
('Iko', 195.88, NULL, 85, 'm', '1800-12-01', 'LifePro'), 
('Tiko', 195.88, NULL, 85, 'm', '1800-12-01', 'LifePro'), 
('Piko', 195.88, NULL, 85, 'm', '1800-12-01', 'LifePro'), 
('Miko', 195.88, NULL, 85, 'm', '1800-12-01', 'LifePro'), 
('Riko', 195.88, NULL, 85, 'm', '1800-12-01', 'LifePro')


--8
CREATE TABLE Users (
	Id INT UNIQUE identity,
	Username VARCHAR(50) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT CONSTRAINT PK_Users PRIMARY KEY (Id)
	)

INSERT INTO Users (
	Username,
	Password,
	ProfilePicture,
	LastLoginTime,
	IsDeleted
	)
VALUES 
('Ziko', '12345', NULL, NULL, 0), 
('Viko', '12345', NULL, NULL, 1), 
('Miko', '12345', NULL, NULL, 0), 
('Kiko', '12345', NULL, NULL, 0), 
('Biko', '12345', NULL, NULL, 1)


--9
ALTER TABLE Users

DROP CONSTRAINT PK_Users

ALTER TABLE Users ADD CONSTRAINT PK_Users PRIMARY KEY (
	Id,
	Username
	)

--10
ALTER TABLE Users ADD CONSTRAINT PasswordLength CHECK (LEN(Password) >= 5)

--11
ALTER TABLE Users ADD DEFAULT GETDATE ()
FOR LastLoginTime

--12
ALTER TABLE Users

DROP CONSTRAINT PK_Users

ALTER TABLE Users ADD CONSTRAINT PK_Usrs PRIMARY KEY (Id)

ALTER TABLE Users ADD CONSTRAINT UsernameLength CHECK (LEN(Username) >= 3)

--13
CREATE DATABASE Movies

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(100) UNIQUE NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(80) UNIQUE NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(MAX) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear SMALLINT NOT NULL,
	[Length] TIME NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating FLOAT(2),
	Notes NVARCHAR(MAX)
	)

INSERT INTO Directors VALUES
('Ivan Ivanov', 'Golden boot Winner'),
('Stan Petrov', 'Multiple international awards'),
('James Cameron', 'FC Liverpool legend'),
('Sam Mayor', 'MK3 World Champion'),
('Dany De La Hoya', 'Very talented')

INSERT INTO Genres VALUES
('Comedy', 'Very funny...'),
('Action', 'Weapons mepons'),
('Horror', 'Not for children'),
('SciFi', 'Space and aliens'),
('Drama', 'OMG')

INSERT INTO Categories VALUES
('1', NULL),
('2', NULL),
('3', NULL),
('4', NULL),
('5', NULL)

INSERT INTO Movies VALUES
('Captain America', 1, 1988, '1:22:00', 1, 5, 9.5, 'Superhero'),
('Mean Machine', 1, 1998, '1:40:00', 2, 4, 8.0, 'Prison'),
('Little Cow', 2, 2007, '1:35:55', 3, 3, 2.3, 'Agro'),
('Smoked Almonds', 5, 2013, '2:22:25', 4, 2, 7.8, 'Whiskey in the Jar'),
('I''m very mad!', 4, 2018, '1:30:02', 5, 1, 9.9, 'Rating 10 not supported')

--14
CREATE DATABASE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL(15, 2) NOT NULL,
	WeeklyRate DECIMAL(15, 2) NOT NULL,
	MonthlyRate DECIMAL(15, 2) NOT NULL,
	WeekendRate DECIMAL(15, 2) NOT NULL,
	)


CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(20) UNIQUE NOT NULL,
	Manufacturer NVARCHAR(100) NOT NULL,
	Model NVARCHAR(100) NOT NULL,
	CarYear SMALLINT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors SMALLINT DEFAULT 4,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(500) NOT NULL,
	Avaliable BIT NOT NULL,
	)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Title NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenseNumber NVARCHAR(50) UNIQUE NOT NULL,
	FullName NVARCHAR(200) NOT NULL,
	[Address] NVARCHAR(200) NOT NULL,
	City NVARCHAR(100) NOT NULL,
	ZipCode NVARCHAR(60) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage AS KilometrageEnd - KilometrageStart,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied DECIMAL NOT NULL,
	TaxRate AS RateApplied * 0.2,
	OrderStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(500)
	)

INSERT INTO Categories (
	CategoryName,
	DailyRate,
	WeeklyRate,
	MonthlyRate,
	WeekendRate
	)
VALUES

('Luxory', 59.99, 350, 1200, 150),
('SUV', 50, 200, 900, 100),
('Van', 59.99, 350, 1200, 150)

INSERT INTO Cars (
	PlateNumber,
	Manufacturer,
	Model,
	CarYear,
	CategoryId,
	Doors,
	Picture,
	Condition,
	Avaliable
	)

VALUES
('PB0001', 'Opel', 'Insignia',2015, 1, 4, NULL, 'Old', 1),
('PB0002', 'Mercedes', 'V-class', 2018, 1, 4, NULL, 'New', 1),
('PB0003', 'BMW', '7', 2005, 1, 4, NULL, 'Old', 1)

INSERT INTO EMPLOYEES(FirstName, LastName, Title, Notes)
VALUES
('Tiko', 'Pkiov', 'Mechanic', 'Experienced worker'),
('Tiko', 'Pkiov', 'Mechanic', 'QA'),
('Tiko', 'Pkiov', 'Mechanic', NULL)

INSERT INTO Customers (
	DriverLicenseNumber,
	FullName,
	[Address],
	City,
	ZipCode,
	Notes
	)
VALUES

('AZ18555PO', 'Bat Pesho', 'This str. 25', 'Chikago', '4000', NULL),
('AZ1855PO', 'Bat Gosho', 'That str. 25', 'Chikago', '4000', NULL),
('AZ18555P', 'Bat Tosho', 'Those str. 25', 'Chikago', '4000', NULL)

INSERT INTO RentalOrders (
	EmployeeId,
	CustomerId,
	CarId,
	TankLevel,
	KilometrageStart,
	KilometrageEnd,
	StartDate,
	EndDate,
	RateApplied,
	OrderStatus
	)
VALUES

(1, 1, 3, 80, 150000, 155000, '2018-05-01', '2018-05-11', 59.99, 1),
(2, 2, 2, 80, 156000, 157000, '2018-05-01', '2018-05-11', 59.99, 1),
(3, 3, 1, 80, 157000, 159000, '2018-05-01', '2018-05-11', 59.99, 1)

--15
CREATE DATABASE Hotel

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(500)
	)

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(50),
	EmergencyName NVARCHAR(100),
	EmergencyNumber NVARCHAR(50),
	Notes NVARCHAR(500)
	)

CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(500)
	)

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(500)
	)

CREATE TABLE BedTypes (
	BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(500)
	)

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(15, 2) NOT NULL,
	RoomStatus NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(500)
	)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATETIME2 DEFAULT GETDATE(),
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccupied DATETIME2 NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(15, 2) NOT NULL,
	TaxRate DECIMAL(15, 2),
	TaxAmount AS AmountCharged * TaxRate,
	PaymentTotal AS AmountCharged + AmountCharged * TaxRate,
	Notes NVARCHAR(500)
	)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATETIME2 DEFAULT GETDATE(),
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied DECIMAL(15, 2) NOT NULL,
	PhoneCharge DECIMAL(15, 2) NOT NULL,
	Notes NVARCHAR(500)
	)

INSERT INTO Employees(FirstName, LastNAme) 
VALUES
('Galin', 'Zhelev'),
('Stoyan', 'Ivanov'),
('Petar', 'Ikonomov')

INSERT INTO Customers(FirstName, LastName, PhoneNumber) 
VALUES
('Monio', 'Ushev', '+359888666555'),
('Gancho', 'Stoykov', '+359866444222'),
('Genadi', 'Dimchov', '+35977555333')

INSERT INTO RoomStatus(RoomStatus) 
VALUES
('occupied'),
('non occupied'),
('repairs')

INSERT INTO RoomTypes(RoomType) 
VALUES
('single'),
('double'),
('appartment')

INSERT INTO BedTypes(BedType) 
VALUES
('single'),
('double'),
('couch')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus) 
VALUES
(201, 'single', 'single', 40.0, 'occupied'),
(205, 'double', 'double', 70.0, 'occupied'),
(208, 'appartment', 'double', 110.0, 'repairs')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate) 
VALUES
(1, '2011-11-25', 2, '2017-11-30', '2017-12-04', 250.0, 0.2),
(3, '2014-06-03', 3, '2014-06-06', '2014-06-09', 340.0, 0.2),
(3, '2016-02-25', 2, '2016-02-27', '2016-03-04', 500.0, 0.2)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge) 
VALUES
(2, '2011-02-04', 3, 205, 70.0, 12.54),
(2, '2015-04-09', 1, 201, 40.0, 11.22),
(3, '2012-06-08', 2, 208, 110.0, 10.05)
