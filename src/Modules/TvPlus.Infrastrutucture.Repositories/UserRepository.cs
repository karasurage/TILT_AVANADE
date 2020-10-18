﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvPlus.Domain.Entities;
using TvPlus.Domain.Interfaces.Repositories;

namespace TvPlus.Infrastrutucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        

        private readonly IConfiguration _configuration;

    

        public UserRepository(IConfiguration configuration)
        {
            
            _configuration = configuration;


        }
        public IEnumerable<User> Get()
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))

                {
                    var usuarioList = new List<User>();
                    var query = $@"  select u.Id, u.FirstName, u.LasName, u.Email, u.Cellphone
                                    , u.DateCreatedAccount, a.ActingGenre, a.Cpf, a.HourValue
		                            , a.FK_IdUser from[User] u
                                     JOIN[Actor] a ON u.Id = a.FK_IdUser";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.CommandType = CommandType.Text;

                        con.Open();
                        var retorno =  cmd.ExecuteReader();

                        while (retorno.Read())
                        {

                            var usuario =
                                new User(int.Parse(retorno["Id"].ToString())
                                , retorno["FirstName"].ToString(),
                                retorno["LasName"].ToString(),
                                retorno["Email"].ToString(),
                                

                                new Actor(int.Parse(retorno["FK_IdUser"].ToString()),
                                retorno["ActingGenre"].ToString(), retorno["Cpf"].ToString()
                                , float.Parse(retorno["HourValue"].ToString())),

                                retorno["Cellphone"].ToString(),

                                DateTime.Parse(retorno["DateCreatedAccount"].ToString()));

                           usuarioList.Add(usuario);
                        }

                        return usuarioList;
                    }


                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))

                {

                    var query = @$" select u.Id, u.FirstName, u.LasName, u.Email, u.Cellphone
		                            , u.DateCreatedAccount, a.ActingGenre,a.Cpf, a.HourValue
		                            , a.FK_IdUser from [User] u
		                              JOIN [Actor] a ON u.Id = {id}";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.CommandType = CommandType.Text;

                        con.Open();
                        var retorno = await cmd.ExecuteReaderAsync()
                                                .ConfigureAwait(false);

                        while (retorno.Read())
                        {
                            
                            var usuario =  
                                new User(int.Parse(retorno["Id"].ToString())
                                , retorno["FirstName"].ToString(),
                                 retorno["LasName"].ToString(),
                                retorno["Email"].ToString(),
                               
                                /*Create Actor*/

                                new Actor(int.Parse(retorno["FK_IdUser"].ToString()),
                                 retorno["ActingGenre"].ToString(), retorno["Cpf"].ToString()
                                , float.Parse(retorno["HourValue"].ToString())), 

                                retorno["Cellphone"].ToString(),
                                DateTime.Parse(retorno["DateCreatedAccount"].ToString()));
                            
                            return usuario;
                        }

                        return default;
                    }


                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }

        }


    

        public void Insert(User usuario)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))

                {

                    var query = @"BEGIN;
			                            INSERT INTO
			                              [user] (FirstName, LasName, Email, Cellphone, DateCreatedAccount)
			                            VALUES (@firstName, @lastName, @email, @cellPhone, @date);

			                            DECLARE @Local INT;
			                            SELECT
			                             @Local = scope_identity();
			                            INSERT INTO
			                              [Actor] (ActingGenre, Cpf, HourValue,FK_IdUser) 
			                            VALUES
			                              (
				                            @actionGenere, @cpf, @hourValue, @Local 
			                              );
			
		                            END;"; 

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("firstName", usuario.FirstName);
                        cmd.Parameters.AddWithValue("lastName", usuario.LastName);
                        cmd.Parameters.AddWithValue("email", usuario.Email);
                        cmd.Parameters.AddWithValue("cellPhone", usuario.Phone);
                        cmd.Parameters.AddWithValue("date", usuario.Date);
                        cmd.Parameters.AddWithValue("actionGenere", usuario.Actor.ActorGenre);
                        cmd.Parameters.AddWithValue("cpf", usuario.Actor.CPF);
                        cmd.Parameters.AddWithValue("hourValue", usuario.Actor.HourValue);
                        

                        con.Open();
                        cmd.ExecuteNonQuery();
                        
                    }


                }
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
          
        }
    }
}
