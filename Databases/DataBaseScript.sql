CREATE DATABASE TvPlus; 

	USE TvPlus; 



	CREATE TABLE [User] (
		Id				   INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
		FirstName		   VARCHAR(20) NOT NULL,
		LasName			   VARCHAR(50) NOT NULL,
		Email		       VARCHAR(100) NOT NULL,
		Cellphone		   VARCHAR(14) NOT NULL,
		DateCreatedAccount DATETIME NOT NULL
	);

	CREATE TABLE [Producer] (
	FantasyName			VARCHAR(50) NOT NULL,
	Cnpj				VARCHAR(30) NOT NULL,
	FK_IdUser			INT  NOT NULL,

	FOREIGN KEY(FK_IdUser) REFERENCES [USER] (Id) ON DELETE CASCADE
	);



	CREATE TABLE [Actor] (
	ActingGenre		VARCHAR(20) NOT NULL,
	Cpf				VARCHAR(15) NOT NULL,
	HourValue		FLOAT NOT NULL,
	FK_IdUser		INT  NOT NULL
	);

	ALTER TABLE ACTOR ADD FOREIGN KEY(FK_IdUser) REFERENCES [USER] (Id) ON DELETE CASCADE;


CREATE TABLE [Reservation] (
Id					int IDENTITY(1, 1) PRIMARY KEY NOT NULL,
TotalValue			FLOAT NOT NULL,
DateReservation		DATETIME NOT NULL,
FK_IdUser			INT 
);

ALTER TABLE [Reservation] ADD FOREIGN KEY(FK_IdUser) REFERENCES [User] (Id) ON DELETE SET NULL;


CREATE TABLE Logs (
Id				INT IDENTITY(1, 1) PRIMARY KEY  NOT NULL,
ErrorsLogs		VARCHAR(500) NOT NULL,
TrackingsLogs	VARCHAR(500) NOT NULL,
SecuritiesLogs  VARCHAR(500) NOT NULL
);

CREATE TABLE Reservation_Generate  (
FK_IdReservation INT ,
FK_IdLogs		 INT ,

FOREIGN KEY(FK_IdReservation) REFERENCES [Reservation] (Id) ON DELETE SET NULL,
FOREIGN KEY(FK_IdLogs) REFERENCES LOGS (Id) ON DELETE SET NULL
);

CREATE TABLE User_Generate  (
FK_IdUser INT ,
FK_IdLogs INT,


FOREIGN KEY(FK_IdUser) REFERENCES [User] (Id) ON DELETE SET NULL,
FOREIGN KEY(FK_IdLogs) REFERENCES [Logs] (Id) ON DELETE SET NULL
);

