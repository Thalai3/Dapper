namespace DapperRestApi.DTO.ReqDto
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        public string? EmployeeName { get; set; }
        public int Age { get; set; }
        public IFormFile? file { get; set; }
    }

    public class UserDto
    {
        public int userId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
