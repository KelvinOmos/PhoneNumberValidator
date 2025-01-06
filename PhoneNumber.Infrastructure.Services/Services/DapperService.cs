using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;


namespace SI.Engine.Infrastructure.Services
{
    public class DapperService : PhoneNumber.Application.Interfaces.IDapper
    {
        private readonly ILogger<DapperService> _logger;

        public DapperService(ILogger<DapperService> logger)
        {
            _logger = logger;
        }

        public async Task<List<T>> GetListAsync<T>(string connectionString, string sql, CommandType commandType = CommandType.Text, DynamicParameters parameters = null)
        {
            List<T> result = new List<T>();

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var records = await connection.QueryAsync<T>(sql: sql, param: parameters, commandType: commandType);
                    if (records != null && records.Any())
                    {
                        result = records.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
            }
            return result;
        }

        public async Task<T> GetSingleAsync<T>(string connectionString, string sql, CommandType commandType = CommandType.Text, DynamicParameters parameters = null)
        {
            T result = default(T);

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var records = await connection.QueryAsync<T>(sql: sql, param: parameters, commandType: commandType);
                    if (records != null && records.Any())
                    {
                        result = records.ToList()[0];
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
            }

            return result;
        }

        public async Task<bool> ExecuteQueryAsync(string connectionString, string sql, CommandType commandType = CommandType.Text, DynamicParameters parameters = null)
        {
            bool result = false;

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var records = await connection.ExecuteScalarAsync(sql: sql, param: parameters, commandType: commandType);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
            }
            return result;
        }
    }
}
