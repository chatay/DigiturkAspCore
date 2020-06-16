using System;
using System.Linq;
using Digiturk.business.Abstract;
using Digiturk.core.Abstract;
using Digiturk.data.Dto;
using Digiturk.data.Model;

namespace Digiturk.business.Concrete
{
    public class PostFilesService : IPostFilesService
    {
        private IRepository<PostFiles> _postFilesrepository;

        public PostFilesService(IRepository<PostFiles> postFilesrepository)
        {
            _postFilesrepository = postFilesrepository;
        }

        public ServiceResponse<PostFilesDto> Delete(int postId)
        {
            var response = new ServiceResponse<PostFilesDto>(null);
            try
            {
                _postFilesrepository.Delete(new PostFiles {PostId = postId});
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<PostFilesDto> Get(int postId)
        {
            var response = new ServiceResponse<PostFilesDto>(null);
            try
            {
                var responseEntity = _postFilesrepository.GetById(postId);

                response.Entity = new PostFilesDto
                {
                    PostId = responseEntity.PostId,
                    FileId = responseEntity.FileId
                };


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

        public ServiceResponse<PostFilesDto> GetList()
        {
            var response = new ServiceResponse<PostFilesDto>(null);

            try
            {
                var responseList = _postFilesrepository.Table.ToList();


                foreach (var file in responseList)
                    response.List.Add(new PostFilesDto
                    {
                        PostId = file.PostId,
                        FileId = file.FileId
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

        public ServiceResponse<PostFilesDto> Insert(PostFilesDto postFilesDto)
        {
            var response = new ServiceResponse<PostFilesDto>(null);

            try
            {
                _postFilesrepository.Insert(new PostFiles
                {
                    PostId = postFilesDto.PostId,
                    FileId = postFilesDto.FileId
                });

                response.IsSuccessful = true;

            }
            catch (Exception e)
            {
                response.HasExceptionError = false;
                response.ExceptionMessage = e.Message + " " + e.InnerException;
            }

            return response;
        }

        public ServiceResponse<PostFilesDto> Update(PostFilesDto postFilesDto)
        {
            var response = new ServiceResponse<PostFilesDto>(null);
            try
            {
                _postFilesrepository.Update(new PostFiles
                {
                    PostId = postFilesDto.PostId,
                    FileId = postFilesDto.FileId
                });
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
