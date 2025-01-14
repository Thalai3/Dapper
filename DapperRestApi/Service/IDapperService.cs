using DapperRestApi.DTO.ReqDto;
using DapperRestApi.DTO.ResDto;

namespace DapperRestApi.Service
{
    public interface IDapperService
    {
        Task<ResponseDto> Create(EmployeeDto req);
        Task<ResponseDto> GetAllEmployee();
    }
}