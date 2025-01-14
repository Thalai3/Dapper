namespace DapperRestApi.DTO.ResDto
{
    public class ResponseDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public ResponseDto(bool success,string message)
        {
            Success = success;
            Message = message;
        }
        public ResponseDto(bool success,string message,object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
      
    }
}
