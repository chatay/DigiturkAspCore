using Digiturk.business.Abstract;
using Digiturk.business.Middleware;
using Digiturk.core.Abstract;
using Digiturk.data.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Digiturk.data.Dto;

namespace Digiturk.business.Concrete
{
    public class UserService:IUserService
    {
        private IRepository<Users> _userRepository;

        public UserService(IRepository<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        public ServiceResponse<Users> Authenticate(string user,string pass)
        {
            var response = new ServiceResponse<Users>(null);
          try
          {
              var userget = _userRepository.Table.FirstOrDefault(x => x.Email == user && x.Password == Cipher.Encrypt("EncryptionKey", pass));

            // return null if user not found
            if (userget == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("jwt secret key. change please ");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userget.UsersId.ToString()),
                    new Claim(ClaimTypes.Role, userget.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userget.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            userget.Password = null;
            response.Entity= userget;
            response.IsSuccessful=true;
            return response;
          }
          catch (Exception ex)
          {
              response.ExceptionMessage=ex.Message;
              response.HasExceptionError=true;
              return response;
            
          }
            
        }

        public ServiceResponse<UsersDto> Delete(int usersId)
        {
            var response = new ServiceResponse<UsersDto>(null);
            try
            {
                _userRepository.Delete(new Users { UsersId = usersId });
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<UsersDto> Get(int usersId)
        {
            var response = new ServiceResponse<UsersDto>(null);
            try
            {
                var responseEntity = _userRepository.GetById(usersId);

                response.Entity = new UsersDto
                {
                    UsersId = responseEntity.UsersId,
                    Username = responseEntity.Username,
                    Name = responseEntity.Name,
                    Surname = responseEntity.Surname,
                    Slug = responseEntity.Slug,
                    Email = responseEntity.Email,
                    Password = responseEntity.Password,
                    Role = responseEntity.Role,
                    UserType = responseEntity.UserType,
                    GoogleId = responseEntity.GoogleId,
                    FacebookId = responseEntity.FacebookId,
                    Avatar = responseEntity.Avatar,
                    Status = responseEntity.Status,
                    AboutMe = responseEntity.AboutMe,
                    LastSeen = responseEntity.LastSeen,
                    FacebookUrl = responseEntity.FacebookUrl,
                    TwitterUrl = responseEntity.TwitterUrl,
                    InstagramUrl = responseEntity.InstagramUrl,
                    PinterestUrl = responseEntity.PinterestUrl,
                    LinkedinUrl = responseEntity.LinkedinUrl,
                    VkUrl = responseEntity.VkUrl,
                    YoutubeUrl = responseEntity.YoutubeUrl,
                    ShowEmailOnProfile = responseEntity.ShowEmailOnProfile
                };


                response.Count = (response.Entity != null) ? 1 : 0;
                response.IsSuccessful = true;

            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<UsersDto> GetList()
        {
            var response = new ServiceResponse<UsersDto>(null);

            try
            {
                var responseList = _userRepository.Table.ToList();


                foreach (var file in responseList)
                    response.List.Add(new UsersDto
                    {
                        UsersId = file.UsersId,
                        Username = file.Username,
                        Name = file.Name,
                        Surname = file.Surname,
                        Slug = file.Slug,
                        Email = file.Email,
                        Password = file.Password,
                        Role = file.Role,
                        UserType = file.UserType,
                        GoogleId = file.GoogleId,
                        FacebookId = file.FacebookId,
                        Avatar = file.Avatar,
                        Status = file.Status,
                        AboutMe = file.AboutMe,
                        LastSeen = file.LastSeen,
                        FacebookUrl = file.FacebookUrl,
                        TwitterUrl = file.TwitterUrl,
                        InstagramUrl = file.InstagramUrl,
                        PinterestUrl = file.PinterestUrl,
                        LinkedinUrl = file.LinkedinUrl,
                        VkUrl = file.VkUrl,
                        YoutubeUrl = file.YoutubeUrl,
                        ShowEmailOnProfile = file.ShowEmailOnProfile
                    });


                response.Count = response.List.Count;
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
            }

            return response;
        }

        public ServiceResponse<UsersDto> Insert(UsersDto userDto)
        {

            var response = new ServiceResponse<UsersDto>(null);

            try
            {
                _userRepository.Insert(new Users
                {
                    UsersId = userDto.UsersId,
                    Username = userDto.Username,
                    Name = userDto.Name,
                    Surname = userDto.Surname,
                    Slug = userDto.Slug,
                    Email = userDto.Email,
                    Password = Cipher.Encrypt("EncryptionKey", userDto.Password),
                    Role = userDto.Role,
                    UserType = userDto.UserType,
                    GoogleId = userDto.GoogleId,
                    FacebookId = userDto.FacebookId,
                    Avatar = userDto.Avatar,
                    Status = userDto.Status,
                    AboutMe = userDto.AboutMe,
                    LastSeen = userDto.LastSeen,
                    FacebookUrl = userDto.FacebookUrl,
                    TwitterUrl = userDto.TwitterUrl,
                    InstagramUrl = userDto.InstagramUrl,
                    PinterestUrl = userDto.PinterestUrl,
                    LinkedinUrl = userDto.LinkedinUrl,
                    VkUrl = userDto.VkUrl,
                    YoutubeUrl = userDto.YoutubeUrl,
                    ShowEmailOnProfile = userDto.ShowEmailOnProfile
                });

                response.IsSuccessful = true;

            }
            catch (Exception e)
            {
                response.HasExceptionError = false;
                response.ExceptionMessage = e.Message + " " + e.InnerException;
            }

            return response;
        }

        public ServiceResponse<UsersDto> Update(UsersDto userDto)
        {
            var response = new ServiceResponse<UsersDto>(null);
            try
            {
                _userRepository.Update(new Users
                {
                    UsersId = userDto.UsersId,
                    Username = userDto.Username,
                    Name = userDto.Name,
                    Surname = userDto.Surname,
                    Slug = userDto.Slug,
                    Email = userDto.Email,
                    Password = Cipher.Encrypt("EncryptionKey", userDto.Password),
                    Role = userDto.Role,
                    UserType = userDto.UserType,
                    GoogleId = userDto.GoogleId,
                    FacebookId = userDto.FacebookId,
                    Avatar = userDto.Avatar,
                    Status = userDto.Status,
                    AboutMe = userDto.AboutMe,
                    LastSeen = userDto.LastSeen,
                    FacebookUrl = userDto.FacebookUrl,
                    TwitterUrl = userDto.TwitterUrl,
                    InstagramUrl = userDto.InstagramUrl,
                    PinterestUrl = userDto.PinterestUrl,
                    LinkedinUrl = userDto.LinkedinUrl,
                    VkUrl = userDto.VkUrl,
                    YoutubeUrl = userDto.YoutubeUrl,
                    ShowEmailOnProfile = userDto.ShowEmailOnProfile
                });
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }
    }
}