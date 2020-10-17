-- Geração de Modelo físico 
-- Sql ANSI 2003 - brModelo. 
CREATE TABLE USER 
  ( 
     id                 INT PRIMARY KEY, 
     email              VARCHAR(50), 
     firstname          VARCHAR(20), 
     lasname            VARCHAR(50), 
     cellphone          VARCHAR(20), 
     datecreatedaccount DATETIME, 
     fk_reservation     INT 
  ) 

CREATE TABLE reservation 
  ( 
     id              INT PRIMARY KEY, 
     totalvalue      FLOAT, 
     datereservation DATETIME 
  ) 

CREATE TABLE actor 
  ( 
     actinggenre VARCHAR(20), 
     cpf         VARCHAR(20), 
     hourvalue   FLOAT, 
     fk_user     INT, 
     FOREIGN KEY(fk_user) REFERENCES USER (id) 
  ) 

CREATE TABLE producer 
  ( 
     fantasyname VARCHAR(30), 
     cnpj        VARCHAR(20), 
     fk_user     INT, 
     FOREIGN KEY(fk_user) REFERENCES USER (id) 
  ) 

CREATE TABLE logs 
  ( 
     id             INT PRIMARY KEY, 
     errorslogs     VARCHAR(500), 
     trackingslogs  VARCHAR(500), 
     securitieslogs VARCHAR(500) 
  ) 

CREATE TABLE reservation_generate 
  ( 
     fk_reservation INT, 
     fk_logs        INT, 
     FOREIGN KEY(fk_reservation) REFERENCES reservation (id), 
     FOREIGN KEY(fk_logs) REFERENCES logs (id) 
  ) 

CREATE TABLE user_generate 
  ( 
     fk_user INT, 
     fk_logs INT, 
     FOREIGN KEY(fk_user) REFERENCES USER (id), 
     FOREIGN KEY(fk_logs) REFERENCES logs (id) 
  ) 

ALTER TABLE USER 
  ADD FOREIGN KEY(fk_reservation) REFERENCES reservation (id) 