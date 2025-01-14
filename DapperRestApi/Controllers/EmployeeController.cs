using DapperRestApi.DTO.ReqDto;
using DapperRestApi.DTO.ResDto;
using DapperRestApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace DapperRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDapperService service; 
        public EmployeeController(IDapperService dapper)
        {
                service = dapper;
        }
        [HttpPost][Route("AddEmployee")]
        public Task<ResponseDto> AddEmployee(EmployeeDto req)
        {
            return service.Create(req);
        }
        //[HttpPost][Route("Add")]
        //public Task<IActionResult> AddData([FromForm] EmployeeDto req)
        //{
        //    return service.Create(req);
        //}
        [HttpGet][Route("GetAll")]
        public Task<ResponseDto> GetAll()
        {
            return service.GetAllEmployee();
        }
    }
}
