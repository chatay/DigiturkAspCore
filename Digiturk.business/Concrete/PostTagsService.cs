using System;
using System.Linq;
using Digiturk.business.Abstract;
using Digiturk.core.Abstract;
using Digiturk.data.Dto;
using Digiturk.data.Model;

namespace Digiturk.business.Concrete
{
    public class PostTagsService : IPostTagsService
    {
        private IRepository<PostTags> _postTagsrepository;
        public PostTagsService(IRepository<PostTags> postTagsrepository)
        {
            _postTagsrepository = postTagsrepository;
        }
        public ServiceResponse<PostTagsDto> Delete(int postId)
        {
            var response = new ServiceResponse<PostTagsDto>(null);
            try
            {
                _postTagsrepository.Delete(new PostTags { PostId = postId });
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<PostTagsDto> Get(int postId)
        {
            var response = new ServiceResponse<PostTagsDto>(null);
            try
            {
                var responseEntity = _postTagsrepository.GetById(postId);

                response.Entity = new PostTagsDto
                {
                    PostId = responseEntity.PostId,
                    Tag = responseEntity.Tag,
                    TagSlug = responseEntity.TagSlug
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

        public ServiceResponse<PostTagsDto> GetList()
        {
            var response = new ServiceResponse<PostTagsDto>(null);

            try
            {
                var responseList = _postTagsrepository.Table.ToList();


                foreach (var file in responseList)
                    response.List.Add(new PostTagsDto
                    {
                        PostId = file.PostId,
                        Tag = file.Tag,
                        TagSlug = file.TagSlug
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

        public ServiceResponse<PostTagsDto> Insert(PostTagsDto postTagDto)
        {
            var response = new ServiceResponse<PostTagsDto>(null);

            try
            {
                _postTagsrepository.Insert(new PostTags
                {
                    PostId = postTagDto.PostId,
                    Tag = postTagDto.Tag,
                    TagSlug = postTagDto.TagSlug
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

        public ServiceResponse<PostTagsDto> Update(PostTagsDto postTagDto)
        {
            var response = new ServiceResponse<PostTagsDto>(null);
            try
            {
                _postTagsrepository.Update(new PostTags
                {
                    PostId = postTagDto.PostId,
                    Tag = postTagDto.Tag,
                    TagSlug = postTagDto.TagSlug
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
