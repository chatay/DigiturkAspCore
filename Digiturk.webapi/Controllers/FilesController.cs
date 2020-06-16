using Digiturk.business.Abstract;
using Digiturk.data.Dto;
using Digiturk.data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.webapi.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize(Roles = Role.Admin)]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private IFilesService _service;
        public FilesController(IFilesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ServiceResponse<FilesDto> GetAll()
        {
            var response = _service.GetList();
            return response;
        }

        //http://localhost:57949/api/v1/Files/272569
        [HttpGet("{filesId}")]
        public ServiceResponse<FilesDto> Get(int filesId)
        {
            return _service.Get(filesId);
        }

        //http://localhost:57949/api/v1/Files/
        [HttpPost]
        public ServiceResponse<FilesDto> Insert(FilesDto file)
        {
            return _service.Insert(file);
        }

        //http://localhost:57949/api/v1/Files/
        [HttpPut]
        public ServiceResponse<FilesDto> Update(FilesDto file)
        {
            return _service.Update(file);
        }

        //http://localhost:57949/api/v1/Files/
        [HttpDelete("{filesId}")]
        public ServiceResponse<FilesDto> Delete(int filesId)
        {
            return _service.Delete(filesId);
        }
    }
}
