using System;
using System.Linq;
using Digiturk.business.Abstract;
using Digiturk.core.Abstract;
using Digiturk.data.Dto;
using Digiturk.data.Model;

namespace Digiturk.business.Concrete
{
    public class FilesService : IFilesService
    {
        private IRepository<Files> _filesrepository;
        public FilesService(IRepository<Files> filesrepository)
        {
            _filesrepository = filesrepository;
        }

        public ServiceResponse<FilesDto> Delete(int filesId)
        {
            var file = new Files { FilesId = filesId };

            var response = new ServiceResponse<FilesDto>(null);
            try
            {
                _filesrepository.Delete(file);
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<FilesDto> Get(int filesId)
        {
            var response = new ServiceResponse<FilesDto>(null);
            try
            {
                var responseEntity = _filesrepository.GetById(filesId);

                response.Entity = new FilesDto();

                response.Entity.FilesId = responseEntity.FilesId;
                response.Entity.FileName = responseEntity.FileName;

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

        public ServiceResponse<FilesDto> GetList()
        {
            var response = new ServiceResponse<FilesDto>(null);

            try
            {
                var responseList = _filesrepository.Table.ToList();


                foreach (var file in responseList)
                    response.List.Add(new FilesDto
                    {
                        FilesId = file.FilesId,
                        FileName = file.FileName
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

        public ServiceResponse<FilesDto> Insert(FilesDto fileDto)
        {
            var file = new Files
            {
                FilesId = fileDto.FilesId,
                FileName = fileDto.FileName
            };


            var response = new ServiceResponse<FilesDto>(null);

            try
            {
                _filesrepository.Insert(file);

                response.IsSuccessful = true;

            }
            catch (Exception e)
            {
                response.HasExceptionError = false;
                response.ExceptionMessage = e.Message + " " + e.InnerException;
            }
            return response;
        }

        public ServiceResponse<FilesDto> Update(FilesDto fileDto)
        {
            var file = new Files
            {
                FilesId = fileDto.FilesId,
                FileName = fileDto.FileName
            };


            var response = new ServiceResponse<FilesDto>(null);
            try
            {
                _filesrepository.Update(file);
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
