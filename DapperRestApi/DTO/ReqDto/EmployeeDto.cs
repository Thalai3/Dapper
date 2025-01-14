namespace DapperRestApi.DTO.ReqDto
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        public string? EmployeeName { get; set; }
        public int Age { get; set; }
        public IFormFile? file { get; set; }
    }
}
