using Digiturk.business.Abstract;
using Digiturk.data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.webapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostFilesController : ControllerBase
    {
        private IPostFilesService _service;
        public PostFilesController(IPostFilesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ServiceResponse<PostFilesDto> GetAll()
        {
            var response = _service.GetList();
            return response;
        }

        //http://localhost:57949/api/v1/PostFiles/272569
        [HttpGet("{postId}")]
        public ServiceResponse<PostFilesDto> Get(int postId)
        {
            return _service.Get(postId);
        }

        //http://localhost:57949/api/v1/PostFiles/
        [HttpPost]
        public ServiceResponse<PostFilesDto> Insert(PostFilesDto postFileDto)
        {
            return _service.Insert(postFileDto);
        }

        //http://localhost:57949/api/v1/PostFiles/
        [HttpPut]
        public ServiceResponse<PostFilesDto> Update(PostFilesDto postFileDto)
        {
            return _service.Update(postFileDto);
        }

        //http://localhost:57949/api/v1/PostFiles/
        [HttpDelete("{postId}")]
        public ServiceResponse<PostFilesDto> Delete(int postId)
        {
            return _service.Delete(postId);
        }
    }
}
