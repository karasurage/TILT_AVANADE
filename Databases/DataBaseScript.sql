CREATE DATABASE tvplus; 

USE tvplus; 

CREATE TABLE [user] 
  ( 
     id                 INT IDENTITY(1, 1) PRIMARY KEY NOT NULL, 
     email              VARCHAR(50) NOT NULL, 
     firstname          VARCHAR(20) NOT NULL, 
     lasname            VARCHAR(50) NOT NULL, 
     cellphone          VARCHAR(20) NOT NULL, 
     datecreatedaccount DATETIME NOT NULL, 
     fk_reservation     INT 
  ); 

CREATE TABLE [reservation] 
  ( 
     id              INT IDENTITY(1, 1) PRIMARY KEY NOT NULL, 
     totalvalue      FLOAT NOT NULL, 
     datereservation DATETIME NOT NULL 
  ); 

CREATE TABLE [actor] 
  ( 
     actinggenre VARCHAR(20) NOT NULL, 
     cpf         VARCHAR(20) NOT NULL, 
     hourvalue   FLOAT NOT NULL, 
     fk_user     INT NOT NULL, 
     FOREIGN KEY(fk_user) REFERENCES [user] (id) 
  ); 

CREATE TABLE [producer] 
  ( 
     fantasyname VARCHAR(30) NOT NULL, 
     cnpj        VARCHAR(20) NOT NULL, 
     fk_user     INT NOT NULL, 
     FOREIGN KEY(fk_user) REFERENCES [user] (id) 
  ); 

CREATE TABLE [logs] 
  ( 
     id             INT IDENTITY(1, 1) PRIMARY KEY, 
     errorslogs     VARCHAR(500) NOT NULL, 
     trackingslogs  VARCHAR(500) NOT NULL, 
     securitieslogs VARCHAR(500) NOT NULL 
  ); 

CREATE TABLE [reservation_generate] 
  ( 
     fk_reservation INT NOT NULL, 
     fk_logs        INT NOT NULL, 
     FOREIGN KEY(fk_reservation) REFERENCES reservation (id), 
     FOREIGN KEY(fk_logs) REFERENCES logs (id) 
  ); 

CREATE TABLE [user_generate] 
  ( 
     fk_user INT, 
     fk_logs INT, 
     FOREIGN KEY(fk_user) REFERENCES [user] (id), 
     FOREIGN KEY(fk_logs) REFERENCES logs (id) 
  ); 

ALTER TABLE [user] 
  ADD FOREIGN KEY(fk_reservation) REFERENCES reservation (id); 