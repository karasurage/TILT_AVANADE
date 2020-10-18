using Microsoft.Extensions.Configuration;
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
                    var query = $"SELECT *FROM Usuario";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.CommandType = CommandType.Text;

                        con.Open();
                        var retorno =  cmd.ExecuteReader();

                        while (retorno.Read())
                        {

                            var usuario =
                                new User(int.Parse(retorno["Id"].ToString())
                                , retorno["FirsName"].ToString(),
                                retorno["LastName"].ToString(),
                                retorno["Email"].ToString(),
                                retorno["Phone"].ToString(),
                                DateTime.Parse(retorno["Date"].ToString()));

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

                    var query = $"SELECT *FROM Usuario WHERE Id = {id}";

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
                                 retorno["LastName"].ToString(),
                                retorno["Email"].ToString(),
                                retorno["Phone"].ToString(),
                                DateTime.Parse(retorno["Date"].ToString()));
                            
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


    

        public int Insert(User usuario)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))

                {

                    var query = @"INSERT INTO Usuario (Name, Email, Phone, CPF, Date)
                                            VALUES (@name, @email, @phone, @cpf, @date); SELECT scope_identity();";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("name", usuario.FirstName);
                        cmd.Parameters.AddWithValue("email", usuario.Email);
                        cmd.Parameters.AddWithValue("phone", usuario.Phone);
                        cmd.Parameters.AddWithValue("date", usuario.Date);

                        con.Open();
                        return int.Parse(cmd.ExecuteScalar().ToString());
                        
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
