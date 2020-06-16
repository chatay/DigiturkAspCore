using Digiturk.data.Dto;

namespace Digiturk.business.Abstract
{
    public interface ICategoriesService
    {
        ServiceResponse<CategoriesDto> GetList();
        ServiceResponse<CategoriesDto> Get(int categoriesId);
        ServiceResponse<CategoriesDto> Insert(CategoriesDto categorie);
        ServiceResponse<CategoriesDto> Update(CategoriesDto categorie);
        ServiceResponse<CategoriesDto> Delete(int categoriesId);
    }
}
