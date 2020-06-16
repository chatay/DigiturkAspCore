using Digiturk.business.Abstract;
using Digiturk.data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.webapi.Controllers
{
    [Route("api/v1/Posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public ServiceResponse<PostsDto> GetAll()
        {
            return _postService.GetList();
        }

        //http://localhost:57949/api/v1/Posts/272569
        [HttpGet("{postsId}")]
        public ServiceResponse<PostsDto> Get(int postsId)
        {
            return _postService.Get(postsId);
        }

        //http://localhost:57949/api/v1/Posts/
        [HttpPost]
        public ServiceResponse<PostsDto> Insert(PostsDto postsDto)
        {
            return _postService.Insert(postsDto);
        }

        //http://localhost:57949/api/v1/Posts/
        [HttpPut]
        public ServiceResponse<PostsDto> Update(PostsDto postsDto)
        {
            return _postService.Update(postsDto);
        }

        //http://localhost:57949/api/v1/Posts/
        [HttpDelete("{postsId}")]
        public ServiceResponse<PostsDto> Delete(int postsId)
        {
            return _postService.Delete(postsId);
        }

        //http://localhost:57949/api/v1/Posts/
        [HttpPost]
        [Route("Search")]
        public ServiceResponse<PostsDto> Search(SearchPostsDto searchPostsDto)
        {
            return _postService.Search(searchPostsDto);
        }
    }
}
