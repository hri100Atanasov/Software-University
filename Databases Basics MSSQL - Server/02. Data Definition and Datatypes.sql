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
