using Digiturk.business.Abstract;

namespace Digiturk.business.Helper
{
    public interface ICrudHelper<T>
    {
        ServiceResponse<T> GetList();
        ServiceResponse<T> Get(int id);
        ServiceResponse<T> Insert(T categorie);
        ServiceResponse<T> Update(T categorie);
        ServiceResponse<T> Delete(T categorie);
    }
}
