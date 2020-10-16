using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using TvPlus.Domain.Entities;
using TvPlus.Domain.Interfaces.Repositories;

namespace TvPlus.Infrastrutucture.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private List<Usuario> usuarios;

        private readonly IConfiguration _configuration;

    

        public UsuarioRepository(IConfiguration configuration)
        {
            usuarios = new List<Usuario>();
            _configuration = configuration;


        }
        public IEnumerable<Usuario> Get()
        {
            return usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return usuarios.Where
                (filter => filter.Id == id).FirstOrDefault();


        }

        public void Insert(Usuario usuario)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))

                {

                    var query = @"INSERT INTO Usuario (Name, Email, Phone, CPF, Date)
                                            VALUES (@name, @email, @phone, @cpf, @date)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("name", usuario.Name);
                        cmd.Parameters.AddWithValue("email", usuario.Email);
                        cmd.Parameters.AddWithValue("phone", usuario.Phone);
                        cmd.Parameters.AddWithValue("cpf", usuario.CPF);
                        cmd.Parameters.AddWithValue("date", usuario.Date);

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
