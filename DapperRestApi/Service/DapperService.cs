using Dapper;
using DapperRestApi.DTO.ReqDto;
using DapperRestApi.DTO.ResDto;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperRestApi.Service
{
    public class DapperService : IDapperService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;
        private readonly ILogger _logger;
        public DapperService(IConfiguration configuration,ILogger<DapperService> logger)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("falut");
            _logger = logger;
        }
        //IDbConnection connection => new SqlConnection();

        private IDbConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionstring))
            {
                throw new InvalidOperationException("Connection string is not initialized.");
            }
            return new SqlConnection(_connectionstring);
        }

        public async Task<ResponseDto> Create(EmployeeDto req)
        {
            string Errormessage = string.Empty;
            try
            {
                using (var dbCon = GetConnection())
                {
                    dbCon.Open();
                    string Query = "Insert Into tbl_Employee Values(@Name,@Age);";
                    _logger.LogInformation("Query", Query);
                    dbCon.ExecuteScalar(Query);
                }
                return new ResponseDto(true, "Record Add Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in Create {0}", ex);
                return new ResponseDto(false, ex.Message);
            }
        }
        public async Task<ResponseDto> GetAllEmployee()
        {
            string Erromessage = string.Empty;
            try
            {
                dynamic data;
                using (var dbCons = GetConnection()) 
                {
                    dbCons.Open();
                    string Query = "SELECT * FROM tbl_Employee;";
                    data = await dbCons.QueryAsync<EmployeeDto>(Query);
                }
                return new ResponseDto(true,"Record Retrive Successfully",data);
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
        }
    }
}
