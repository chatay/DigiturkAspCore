using Digiturk.business.Abstract;
using Digiturk.data.Dto;
using Digiturk.data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.webapi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = Role.Admin)]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private ILanguagesService _service;
        public LanguagesController(ILanguagesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ServiceResponse<LanguagesDto> GetAll()
        {
            var response = _service.GetList();
            return response;
        }

        //http://localhost:57949/api/v1/Languages/272569
        [HttpGet("{languagesId}")]
        public ServiceResponse<LanguagesDto> Get(byte languagesId)
        {
            return _service.Get(languagesId);
        }

        //http://localhost:57949/api/v1/Languages/
        [HttpPost]
        public ServiceResponse<LanguagesDto> Insert(LanguagesDto language)
        {
            return _service.Insert(language);
        }

        //http://localhost:57949/api/v1/Languages/
        [HttpPut]
        public ServiceResponse<LanguagesDto> Update(LanguagesDto language)
        {
            return _service.Update(language);
        }

        //http://localhost:57949/api/v1/Languages/
        [HttpDelete("{languagesId}")]
        public ServiceResponse<LanguagesDto> Delete(byte languagesId)
        {
            return _service.Delete(languagesId);
        }
    }
}
