using Digiturk.business.Abstract;
using Digiturk.data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.webapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostImagesController : ControllerBase
    {
        private IPostImagesService _service;
        public PostImagesController(IPostImagesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ServiceResponse<PostImagesDto> GetAll()
        {
            var response = _service.GetList();
            return response;
        }

        //http://localhost:57949/api/v1/PostImages/272569
        [HttpGet("{postId}")]
        public ServiceResponse<PostImagesDto> Get(int postId)
        {
            return _service.Get(postId);
        }

        //http://localhost:57949/api/v1/PostImages/
        [HttpPost]
        public ServiceResponse<PostImagesDto> Insert(PostImagesDto postImageDto)
        {
            return _service.Insert(postImageDto);
        }

        //http://localhost:57949/api/v1/PostImages/
        [HttpPut]
        public ServiceResponse<PostImagesDto> Update(PostImagesDto postImageDto)
        {
            return _service.Update(postImageDto);
        }

        //http://localhost:57949/api/v1/PostImages/
        [HttpDelete("{postId}")]
        public ServiceResponse<PostImagesDto> Delete(int postId)
        {
            return _service.Delete(postId);
        }
    }
}
