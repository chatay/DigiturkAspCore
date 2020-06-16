using Digiturk.data.Dto;

namespace Digiturk.business.Abstract
{
    public interface IFilesService
    {
        ServiceResponse<FilesDto> GetList();
        ServiceResponse<FilesDto> Get(int filesId);
        ServiceResponse<FilesDto> Insert(FilesDto fileDto);
        ServiceResponse<FilesDto> Update(FilesDto fileDto);
        ServiceResponse<FilesDto> Delete(int filesId);
    }
}
