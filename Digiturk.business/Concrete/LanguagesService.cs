using System;
using System.Linq;
using Digiturk.business.Abstract;
using Digiturk.core.Abstract;
using Digiturk.data.Dto;
using Digiturk.data.Model;

namespace Digiturk.business.Concrete
{
    public class LanguagesService : ILanguagesService
    {
        private IRepository<Languages> _languagesrepository;
        public LanguagesService(IRepository<Languages> languagesrepository)
        {
            _languagesrepository = languagesrepository;
        }
        public ServiceResponse<LanguagesDto> Delete(byte languagesId)
        {
            var language = new Languages { LanguagesId = languagesId };

            var response = new ServiceResponse<LanguagesDto>(null);
            try
            {
                _languagesrepository.Delete(language);
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<LanguagesDto> Get(byte languagesId)
        {
            var response = new ServiceResponse<LanguagesDto>(null);
            try
            {
                var responseEntity = _languagesrepository.GetById(languagesId);

                response.Entity = new LanguagesDto();

                response.Entity.LanguagesId = responseEntity.LanguagesId;
                response.Entity.Name = responseEntity.Name;
                response.Entity.ShortForm = responseEntity.ShortForm;
                response.Entity.LanguageCode = responseEntity.LanguageCode;
                response.Entity.FolderName = responseEntity.FolderName;
                response.Entity.TextDirection = responseEntity.TextDirection;
                response.Entity.Status = responseEntity.Status;
                response.Entity.LanguageOrder = responseEntity.LanguageOrder;

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

        public ServiceResponse<LanguagesDto> GetList()
        {
            var response = new ServiceResponse<LanguagesDto>(null);

            try
            {
                var responseList = _languagesrepository.Table.ToList();


                foreach (var file in responseList)
                    response.List.Add(new LanguagesDto
                    {
                        LanguagesId = file.LanguagesId,
                        Name = file.Name,
                        ShortForm = file.ShortForm,
                        LanguageCode = file.LanguageCode,
                        FolderName = file.FolderName,
                        TextDirection = file.TextDirection,
                        Status = file.Status,
                        LanguageOrder = file.LanguageOrder
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

        public ServiceResponse<LanguagesDto> Insert(LanguagesDto languageDto)
        {
            var language = new Languages
            {
                LanguagesId = languageDto.LanguagesId,
                Name = languageDto.Name,
                ShortForm = languageDto.ShortForm,
                LanguageCode = languageDto.LanguageCode,
                FolderName = languageDto.FolderName,
                TextDirection = languageDto.TextDirection,
                Status = languageDto.Status,
                LanguageOrder = languageDto.LanguageOrder
            };


            var response = new ServiceResponse<LanguagesDto>(null);

            try
            {
                _languagesrepository.Insert(language);

                response.IsSuccessful = true;

            }
            catch (Exception e)
            {
                response.HasExceptionError = false;
                response.ExceptionMessage = e.Message + " " + e.InnerException;
            }
            return response;
        }

        public ServiceResponse<LanguagesDto> Update(LanguagesDto languageDto)
        {
            var language = new Languages
            {
                LanguagesId = languageDto.LanguagesId,
                Name = languageDto.Name,
                ShortForm = languageDto.ShortForm,
                LanguageCode = languageDto.LanguageCode,
                FolderName = languageDto.FolderName,
                TextDirection = languageDto.TextDirection,
                Status = languageDto.Status,
                LanguageOrder = languageDto.LanguageOrder
            };


            var response = new ServiceResponse<LanguagesDto>(null);
            try
            {
                _languagesrepository.Update(language);
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
