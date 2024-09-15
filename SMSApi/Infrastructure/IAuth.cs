using SMSApi.Dto;
using SMSApi.Models;

namespace SMSApi.Infrastructure
{
    public interface IAuth
    {
        UserDto Auth(LoginDto loginDto);
    }
}
