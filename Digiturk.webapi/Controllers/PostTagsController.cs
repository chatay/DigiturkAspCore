using Digiturk.business.Abstract;
using Digiturk.data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.webapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostTagsController : ControllerBase
    {
        private IPostTagsService _service;

        public PostTagsController(IPostTagsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ServiceResponse<PostTagsDto> GetAll()
        {
            var response = _service.GetList();
            return response;
        }

        //http://localhost:57949/api/v1/PostTags/272569
        [HttpGet("{postId}")]
        public ServiceResponse<PostTagsDto> Get(int postId)
        {
            return _service.Get(postId);
        }

        //http://localhost:57949/api/v1/PostTags/
        [HttpPost]
        public ServiceResponse<PostTagsDto> Insert(PostTagsDto postTagDto)
        {
            return _service.Insert(postTagDto);
        }

        //http://localhost:57949/api/v1/PostTags/
        [HttpPut]
        public ServiceResponse<PostTagsDto> Update(PostTagsDto postTagDto)
        {
            return _service.Update(postTagDto);
        }

        //http://localhost:57949/api/v1/PostTags/
        [HttpDelete("{postId}")]
        public ServiceResponse<PostTagsDto> Delete(int postId)
        {
            return _service.Delete(postId);
        }
    }
}
