using System;
using System.Linq;
using Digiturk.business.Abstract;
using Digiturk.core.Abstract;
using Digiturk.data.Dto;
using Digiturk.data.Model;

namespace Digiturk.business.Concrete
{
    public class PostImagesService : IPostImagesService
    {

        private IRepository<PostImages> _postImagesrepository;

        public PostImagesService(IRepository<PostImages> postImagesrepository)
        {
            _postImagesrepository = postImagesrepository;
        }

        public ServiceResponse<PostImagesDto> Delete(int postId)
        {
            var response = new ServiceResponse<PostImagesDto>(null);
            try
            {
                _postImagesrepository.Delete(new PostImages {PostId = postId});
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<PostImagesDto> Get(int postId)
        {
            var response = new ServiceResponse<PostImagesDto>(null);
            try
            {
                var responseEntity = _postImagesrepository.GetById(postId);

                response.Entity = new PostImagesDto
                {
                    PostId = responseEntity.PostId,
                    ImagePath = responseEntity.ImagePath
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

        public ServiceResponse<PostImagesDto> GetList()
        {
            var response = new ServiceResponse<PostImagesDto>(null);

            try
            {
                var responseList = _postImagesrepository.Table.ToList();


                foreach (var file in responseList)
                    response.List.Add(new PostImagesDto
                    {
                        PostId = file.PostId,
                        ImagePath = file.ImagePath
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

        public ServiceResponse<PostImagesDto> Insert(PostImagesDto postImagesDto)
        {

            var response = new ServiceResponse<PostImagesDto>(null);

            try
            {
                _postImagesrepository.Insert(new PostImages
                {
                    PostId = postImagesDto.PostId,
                    ImagePath = postImagesDto.ImagePath
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

        public ServiceResponse<PostImagesDto> Update(PostImagesDto postImageDto)
        {
            var response = new ServiceResponse<PostImagesDto>(null);
            try
            {
                _postImagesrepository.Update(new PostImages
                {
                    PostId = postImageDto.PostId,
                    ImagePath = postImageDto.ImagePath
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
