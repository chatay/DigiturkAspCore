using Digiturk.data.Dto;

namespace Digiturk.business.Abstract
{
    public interface IPostService
    {
        ServiceResponse<PostsDto> GetList();
        ServiceResponse<PostsDto> Get(int postsId);
        ServiceResponse<PostsDto> Insert(PostsDto postDto);
        ServiceResponse<PostsDto> Update(PostsDto postDto);
        ServiceResponse<PostsDto> Delete(int postsId);
        ServiceResponse<PostsDto> Search(SearchPostsDto searchPostsDto);
    }
}
