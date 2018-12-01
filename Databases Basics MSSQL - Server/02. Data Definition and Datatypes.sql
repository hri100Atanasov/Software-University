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
VALUES (
	1,
	'Sofia'
	),
	(
	2,
	'Plovdiv'
	),
	(
	3,
	'Varna'
	)

INSERT INTO Minions (
	Id,
	[Name],
	Age,
	TownId
	)
VALUES (
	1,
	'Kevin',
	22,
	1
	),
	(
	2,
	'Bob',
	15,
	3
	),
	(
	3,
	'Steward',
	DEFAULT,
	2
	)

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
VALUES (
	'Iko',
	195.88,
	NULL,
	85,
	'm',
	'1800-12-01',
	'LifePro'
	),
	(
	'Tiko',
	195.88,
	NULL,
	85,
	'm',
	'1800-12-01',
	'LifePro'
	),
	(
	'Piko',
	195.88,
	NULL,
	85,
	'm',
	'1800-12-01',
	'LifePro'
	),
	(
	'Miko',
	195.88,
	NULL,
	85,
	'm',
	'1800-12-01',
	'LifePro'
	),
	(
	'Riko',
	195.88,
	NULL,
	85,
	'm',
	'1800-12-01',
	'LifePro'
	)

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
VALUES (
	'Ziko',
	'12345',
	NULL,
	NULL,
	0
	),
	(
	'Viko',
	'12345',
	NULL,
	NULL,
	1
	),
	(
	'Miko',
	'12345',
	NULL,
	NULL,
	0
	),
	(
	'Kiko',
	'12345',
	NULL,
	NULL,
	0
	),
	(
	'Biko',
	'12345',
	NULL,
	NULL,
	1
	)

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
