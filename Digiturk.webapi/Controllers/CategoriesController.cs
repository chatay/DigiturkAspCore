using Digiturk.business.Abstract;
using Digiturk.data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Digiturk.webapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoriesService _service;
        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ServiceResponse<CategoriesDto> GetAll()
        {
            return _service.GetList();
        }

        //http://localhost:57949/api/v1/Categories/272569
        [HttpGet("{categoriesId}")]
        public ServiceResponse<CategoriesDto> Get(int categoriesId)
        {
            return _service.Get(categoriesId);
        }

        //http://localhost:57949/api/v1/Categories/
        [HttpPost]
        public ServiceResponse<CategoriesDto> Insert(CategoriesDto categorie)
        {
            return _service.Insert(categorie);
        }

        //http://localhost:57949/api/v1/Categories/
        [HttpPut]
        public ServiceResponse<CategoriesDto> Update(CategoriesDto categorie)
        {
            return _service.Update(categorie);
        }

        //http://localhost:57949/api/v1/Categories/
        [HttpDelete("{categoriesId}")]
        public ServiceResponse<CategoriesDto> Delete(int categoriesId)
        {
            return _service.Delete(categoriesId);
        }
    }
}
