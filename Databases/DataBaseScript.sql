CREATE DATABASE TvPlus;

	use TvPlus;

	CREATE TABLE [USER]
  ( 
     id INT  IDENTITY(1,1) PRIMARY KEY NOT NULL, 
     email  VARCHAR(50) NOT NULL, 
     firstname VARCHAR(20)	NOT NULL, 
     lasname  VARCHAR(50) NOT NULL, 
     cellphone  VARCHAR(20) NOT NULL, 
     datecreatedaccount DATETIME NOT NULL, 
     fk_reservation INT 
  ) ;

CREATE TABLE [RESERVATION]
  ( 
     id              INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
     totalvalue      FLOAT NOT NULL, 
     datereservation DATETIME NOT NULL
  ) ;

CREATE TABLE [ACTOR]
  ( 
     actinggenre VARCHAR(20) NOT NULL, 
     cpf         VARCHAR(20) NOT NULL, 
     hourvalue   FLOAT NOT NULL, 
     fk_user     INT NOT NULL, 
     FOREIGN KEY(fk_user) REFERENCES [USER] (id) 
  ) ;

CREATE TABLE [PRODUCER] 
  ( 
     fantasyname VARCHAR(30) NOT NULL, 
     cnpj        VARCHAR(20) NOT NULL, 
     fk_user     INT NOT NULL, 
     FOREIGN KEY(fk_user) REFERENCES [USER] (id) 
  ) ;

CREATE TABLE [LOGS]
  ( 
     id             INT	IDENTITY(1,1) PRIMARY KEY, 
     errorslogs     VARCHAR(500) NOT NULL, 
     trackingslogs  VARCHAR(500) NOT NULL, 
     securitieslogs VARCHAR(500) NOT NULL
  ) ;

CREATE TABLE [RESERVATION_GENERATE]
  ( 
     fk_reservation INT  NOT NULL, 
     fk_logs        INT  NOT NULL, 
     FOREIGN KEY(fk_reservation) REFERENCES reservation (id), 
     FOREIGN KEY(fk_logs) REFERENCES logs (id) 
  ) ;

CREATE TABLE [USER_GENERATE]
  ( 
     fk_user INT, 
     fk_logs INT, 
     FOREIGN KEY(fk_user) REFERENCES [USER] (id), 
     FOREIGN KEY(fk_logs) REFERENCES logs (id) 
  ) ;

ALTER TABLE [USER] 
  ADD FOREIGN KEY(fk_reservation) REFERENCES reservation (id) ;


  