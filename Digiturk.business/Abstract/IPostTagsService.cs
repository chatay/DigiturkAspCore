using Digiturk.data.Dto;

namespace Digiturk.business.Abstract
{
    public interface IPostTagsService
    {
        ServiceResponse<PostTagsDto> GetList();
        ServiceResponse<PostTagsDto> Get(int postId);
        ServiceResponse<PostTagsDto> Insert(PostTagsDto postTagDto);
        ServiceResponse<PostTagsDto> Update(PostTagsDto postTagDto);
        ServiceResponse<PostTagsDto> Delete(int postId);
    }
}
