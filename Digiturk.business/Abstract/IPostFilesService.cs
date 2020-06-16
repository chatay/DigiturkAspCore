using Digiturk.data.Dto;

namespace Digiturk.business.Abstract
{
    public interface IPostFilesService
    {
        ServiceResponse<PostFilesDto> GetList();
        ServiceResponse<PostFilesDto> Get(int postId);
        ServiceResponse<PostFilesDto> Insert(PostFilesDto postFileDto);
        ServiceResponse<PostFilesDto> Update(PostFilesDto postFileDto);
        ServiceResponse<PostFilesDto> Delete(int postId);
    }
}
