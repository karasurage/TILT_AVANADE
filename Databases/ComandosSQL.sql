
use TvPlus;

 /* Querys para projeto */

		

/* Inserir Dados em user-actor OBS: Colocar em uma query única*/
		
		BEGIN;
			INSERT INTO
			  [user] (FirstName, LasName, Email, Cellphone, DateCreatedAccount)
			VALUES ('Tarcisio', 'Dantas', 'tarcisiodantas@deAndrade.com',
			'(81)98656-5214', '2020-15-10');

			DECLARE @Local INT;
			SELECT
			 @Local = scope_identity();
			INSERT INTO
			  [Actor] (ActingGenre, Cpf, HourValue,FK_IdUser) 
			VALUES
			  (
				'Ação',	'108.390.324-12', 350.65, @Local 
			  );
			
		END;

		/* Inserir Dados em user-actor OBS: Colocar em uma query única*/

		BEGIN;
			INSERT INTO
			  [user] (FirstName, LasName, Email, Cellphone, DateCreatedAccount)
			VALUES ('Joel', 'Medeiros', 'joel@hotmail.com',
			'(81)985658987', '2019-31-12');

			DECLARE @Local2 INT;
			SELECT
			 @Local2 = scope_identity();
			INSERT INTO
			  [Producer] (Cnpj, FantasyName, FK_IdUser) 
			VALUES
			  (
				'28.100.477/0001-68',	'Globo',@Local2 
			  );
			
		END;
  
  select * from [Producer];



  /* select para voltar cpf e nome de user*/

  select  u.FirstName as PrimeiroNome, a.Cpf as CPF from [User] u
		  JOIN [Actor] a ON  u.Id = a.FK_IdUser;
		
	