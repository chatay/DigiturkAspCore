using System;
using System.Linq;
using Digiturk.business.Abstract;
using Digiturk.core.Abstract;
using Digiturk.data.Dto;
using Digiturk.data.Model;

namespace Digiturk.business.Concrete
{
    public class CategoriesService : ICategoriesService
    {
        private IRepository<Categories> _categoriesrepository;

        public CategoriesService(IRepository<Categories> categoriesrepository)
        {
            _categoriesrepository = categoriesrepository;
        }

        public ServiceResponse<CategoriesDto> Delete(int categoriesId)
        {
            var categorie = new Categories { CategoriesId = categoriesId };

            var response = new ServiceResponse<CategoriesDto>(null);
            try
            {
                _categoriesrepository.Delete(categorie);
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<CategoriesDto> Get(int categoriesId)
        {
            var response = new ServiceResponse<CategoriesDto>(null);
            try
            {
                var responseEntity = _categoriesrepository.GetById(categoriesId);

                response.Entity = new CategoriesDto();

                response.Entity.CategoriesId = responseEntity.CategoriesId;
                response.Entity.LangId = responseEntity.LangId;
                response.Entity.Name = responseEntity.Name;
                response.Entity.Slug = responseEntity.Slug;
                response.Entity.Description = responseEntity.Description;
                response.Entity.Keywords = responseEntity.Keywords;
                response.Entity.ParentId = responseEntity.ParentId;
                response.Entity.CategoryOrder = responseEntity.CategoryOrder;
                response.Entity.ShowOnMenu = responseEntity.ShowOnMenu;
                response.Entity.CreatedAt = responseEntity.CreatedAt;

                response.Count = (response.Entity != null) ? 1 : 0;
                response.IsSuccessful = true;

            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<CategoriesDto> GetList()
        {
            var response = new ServiceResponse<CategoriesDto>(null);

            try
            {
                var responseList = _categoriesrepository.Table.ToList();


                foreach (var categorie in responseList)
                    response.List.Add(new CategoriesDto
                    {
                        CategoriesId = categorie.CategoriesId,
                        LangId = categorie.LangId,
                        Name = categorie.Name,
                        Slug = categorie.Slug,
                        Description = categorie.Description,
                        Keywords = categorie.Keywords,
                        ParentId = categorie.ParentId,
                        CategoryOrder = categorie.CategoryOrder,
                        ShowOnMenu = categorie.ShowOnMenu,
                        CreatedAt = categorie.CreatedAt
                    });


                response.Count = response.List.Count;
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
            }

            return response;
        }

        public ServiceResponse<CategoriesDto> Insert(CategoriesDto postCategorieDto)
        {
            var categorie = new Categories
            {
                CategoriesId = postCategorieDto.CategoriesId,
                LangId = postCategorieDto.LangId,
                Name = postCategorieDto.Name,
                Slug = postCategorieDto.Slug,
                Description = postCategorieDto.Description,
                Keywords = postCategorieDto.Keywords,
                ParentId = postCategorieDto.ParentId,
                CategoryOrder = postCategorieDto.CategoryOrder,
                ShowOnMenu = postCategorieDto.ShowOnMenu,
                CreatedAt = DateTime.Now
            };


            var response = new ServiceResponse<CategoriesDto>(null);

            try
            {
                _categoriesrepository.Insert(categorie);

                response.IsSuccessful = true;

            }
            catch (Exception e)
            {
                response.HasExceptionError = false;
                response.ExceptionMessage = e.Message + " " + e.InnerException;
            }
            return response;
        }

        public ServiceResponse<CategoriesDto> Update(CategoriesDto putCategorieDto)
        {
            var categorie = new Categories
            {
                CategoriesId = putCategorieDto.CategoriesId,
                LangId = putCategorieDto.LangId,
                Name = putCategorieDto.Name,
                Slug = putCategorieDto.Slug,
                Description = putCategorieDto.Description,
                Keywords = putCategorieDto.Keywords,
                ParentId = putCategorieDto.ParentId,
                CategoryOrder = putCategorieDto.CategoryOrder,
                ShowOnMenu = putCategorieDto.ShowOnMenu
            };


            var response = new ServiceResponse<CategoriesDto>(null);
            try
            {
                _categoriesrepository.Update(categorie);
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }
    }
}
