using Digiturk.data.Dto;

namespace Digiturk.business.Abstract
{
    public interface IPostImagesService
    {
        ServiceResponse<PostImagesDto> GetList();
        ServiceResponse<PostImagesDto> Get(int postId);
        ServiceResponse<PostImagesDto> Insert(PostImagesDto postImagesDto);
        ServiceResponse<PostImagesDto> Update(PostImagesDto postImagesDto);
        ServiceResponse<PostImagesDto> Delete(int postId);
    }
}
