using System;
using System.Linq;
using Digiturk.business.Abstract;
using Digiturk.core.Abstract;

namespace Digiturk.business.Helper
{
    public class CrudHelper<T> : ICrudHelper<T>
    {
        private readonly IRepository<T> _repository;

        public CrudHelper(IRepository<T> repository)
        {
            _repository = repository;
        }
        public ServiceResponse<T> Delete(T categorie)
        {
            var response = new ServiceResponse<T>(null);
            try
            {
                _repository.Delete(categorie);

                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<T> Get(int id)
        {
            var response = new ServiceResponse<T>(null);
            try
            {
                response.Entity = _repository.GetById(id);
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

        public ServiceResponse<T> GetList()
        {
            var response = new ServiceResponse<T>(null);

            try
            {
                response.List = _repository.Table.ToList();
                response.Count = response.List.Count;
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
            }

            return response;
        }

        public ServiceResponse<T> Insert(T categorie)
        {
            var response = new ServiceResponse<T>(null);
            try
            {
                _repository.Insert(categorie);

                response.IsSuccessful = true;

            }
            catch (Exception e)
            {
                response.HasExceptionError = false;
                response.ExceptionMessage = e.Message + " " + e.InnerException;
            }
            return response;
        }

        public ServiceResponse<T> Update(T categorie)
        {
            var response = new ServiceResponse<T>(null);
            try
            {
                _repository.Update(categorie);
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
