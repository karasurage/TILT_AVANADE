using Microsoft.Extensions.Configuration;
using TvPlus.Domain.Entities;
using TvPlus.Domain.Interfaces.Repositories;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AutoMapper;

namespace TvPlus.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IConfiguration _configuration;
        public ProfileRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Profile> GetByIdAsync(int id)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))
                {
                    var sqlCmd = $@"SELECT *
                                        FROM PROFILE 
                                    WHERE Id={id}";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        var reader = await cmd
                                            .ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                        while (reader.Read())
                        {
                            var profile = new Profile(int.Parse(reader["id"].ToString()),
                                                reader["Description"].ToString());

                            return profile;
                        }

                        return default;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
