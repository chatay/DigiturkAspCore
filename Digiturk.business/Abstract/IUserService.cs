using Digiturk.data.Dto;
using Digiturk.data.Model;

namespace Digiturk.business.Abstract
{
    public interface IUserService
    {
        ServiceResponse<UsersDto> GetList();
        ServiceResponse<UsersDto> Get(int usersId);
        ServiceResponse<UsersDto> Insert(UsersDto userDto);
        ServiceResponse<UsersDto> Update(UsersDto userDto);
        ServiceResponse<UsersDto> Delete(int usersId);
        ServiceResponse<Users> Authenticate(string user,string pass);
    }
}