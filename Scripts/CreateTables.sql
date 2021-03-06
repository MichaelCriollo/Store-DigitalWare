--CREATE DATABASE STORE
USE STORE

CREATE TABLE [TypeProduct] (
	IdTypeProduct	INT NOT NULL IDENTITY(1,1),	
	[Name]			VARCHAR(30),
)

CREATE TABLE Gender(
	IdGender		INT NOT NULL IDENTITY(1,1),	
	[Name]			VARCHAR(30),
) 

CREATE TABLE [State](
	IdState			INT NOT NULL IDENTITY(1,1),
	[Name]			VARCHAR(30),
)  

CREATE TABLE Size(
	IdSize			INT NOT NULL IDENTITY(1,1),
	[Name]			VARCHAR(10),
)

CREATE TABLE Color(
	IdColor			INT NOT NULL IDENTITY(1,1),
	[Name]			VARCHAR(20),
)


CREATE TABLE SizeTypeProduct(
	IdSizeTypeProduct		INT NOT NULL IDENTITY(1,1),
	IdSize					INT NOT NULL,
	IdTypeProduct			INT NOT NULL,
)

CREATE TABLE Product(
	IdProduct				INT NOT NULL IDENTITY(1,1),
	IdTypeProduct			INT NOT NULL,
	IdState					INT NOT NULL,
	IdColor					INT NOT NULL,
	IdGender				INT NOT NULL,
	Reference				VARCHAR(200) NOT NULL,
	[Name]					VARCHAR(100) NOT NULL,
	PriceUnit				NUMERIC(18,0) NOT NULL,
	Quantity				INT NOT NULL,
	DateCreate				DATETIME NOT NULL,
	DateEdit				DATETIME
)

CREATE TABLE ProductSize(
	IdProductSize	INT NOT NULL IDENTITY(1,1),
	IdProduct		INT NOT NULL,
	IdSize			INT NOT NULL,
	DateCreate		DATETIME NOT NULL,
	DateEdit		DATETIME
)


CREATE TABLE Client(
	IdClient		INT NOT NULL IDENTITY(1,1),
	FirstName		VARCHAR(50) NOT NULL,
	LastName		VARCHAR(50) NOT NULL,
	MobilePhone		VARCHAR(15) NOT NULL,
	Email			VARCHAR(200) NOT NULL,
	BirthdayDate	DATETIME NOT NULL,
	DateCreate		DATETIME NOT NULL,
	DateEdit		DATETIME
)

CREATE TABLE Bill(
	IdBill			INT NOT NULL IDENTITY(1,1),
	IdClient		INT NOT NULL,
	TotalPrice		NUMERIC(18,0) NOT NULL,
	DateCreate		DATETIME NOT NULL,
	DateEdit		DATETIME
)

CREATE TABLE DetailBill(
	IdDetailBill	INT NOT NULL IDENTITY(1,1),
	IdBill			INT NOT NULL,
	IdProduct		INT NOT NULL,
	Quantity		INT NOT NULL,
	Price			NUMERIC(18,0) NOT NULL,
	DateCreate		DATETIME NOT NULL,
	DateEdit		DATETIME
)
