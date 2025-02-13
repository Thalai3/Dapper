using DapperRestApi.DTO.ReqDto;
using DapperRestApi.DTO.ResDto;

namespace DapperRestApi.Service
{
    public interface IJwtservice
    {
        AuthendicationResponse CreateJwtToken(UserDto userDto);  
    }
}
