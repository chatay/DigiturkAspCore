using Digiturk.data.Dto;

namespace Digiturk.business.Abstract
{
    public interface ILanguagesService
    {
        ServiceResponse<LanguagesDto> GetList();
        ServiceResponse<LanguagesDto> Get(byte languagesId);
        ServiceResponse<LanguagesDto> Insert(LanguagesDto languageDto);
        ServiceResponse<LanguagesDto> Update(LanguagesDto languageDto);
        ServiceResponse<LanguagesDto> Delete(byte languagesId);
    }
}
