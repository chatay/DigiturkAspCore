using Digiturk.business.Abstract;
using Digiturk.data.Dto;
using Digiturk.data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.webapi.Controllers
{
    [Authorize]
    [Route("api/v1/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ServiceResponse<Users> Authenticate([FromBody] Users userParam)
        {
            return _userService.Authenticate(userParam.Email, userParam.Password);
        }

        //http://localhost:57949/api/v1/Users/
        [HttpGet]
        public ServiceResponse<UsersDto> GetAll()
        {
            var response = _userService.GetList();
            return response;
        }

        //http://localhost:57949/api/v1/Users/272569
        [HttpGet("{usersId}")]
        public ServiceResponse<UsersDto> Get(int usersId)
        {
            return _userService.Get(usersId);
        }

        //http://localhost:57949/api/v1/Users/
        [AllowAnonymous]
        [HttpPost]
        public ServiceResponse<UsersDto> Insert(UsersDto user)
        {
            return _userService.Insert(user);
        }

        //http://localhost:57949/api/v1/Users/
        [HttpPut]
        public ServiceResponse<UsersDto> Update(UsersDto user)
        {
            return _userService.Update(user);
        }

        //http://localhost:57949/api/v1/Users/
        [HttpDelete("{usersId}")]
        public ServiceResponse<UsersDto> Delete(int usersId)
        {
            return _userService.Delete(usersId);
        }
    }
}
