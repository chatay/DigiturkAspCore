using System;
using System.Linq;
using Digiturk.business.Abstract;
using Digiturk.core.Abstract;
using Digiturk.data.Dto;
using Digiturk.data.Model;

namespace Digiturk.business.Concrete
{
    public class PostService : IPostService
    {
        private IRepository<Posts> _postsRepository;

        public PostService(IRepository<Posts> postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public ServiceResponse<PostsDto> GetList()
        {
            var response = new ServiceResponse<PostsDto>(null);

            try
            {
                var responseList = _postsRepository.Table.ToList();


                foreach (var file in responseList)
                    response.List.Add(new PostsDto
                    {
                        PostsId = file.PostsId,
                        LanguagesId = file.LanguagesId,
                        Title = file.Title,
                        TitleSlug = file.TitleSlug,
                        Summary = file.Summary,
                        Content = file.Content,
                        Keywords = file.Keywords,
                        UserId = file.UserId,
                        CategoryId = file.CategoryId,
                        ImageBig = file.ImageBig,
                        ImageMid = file.ImageMid,
                        ImageSmall = file.ImageSmall,
                        ImageSlider = file.ImageSlider,
                        ImageMime = file.ImageMime,
                        IsSlider = file.IsSlider,
                        IsPicked = file.IsPicked,
                        Hit = file.Hit,
                        SliderOrder = file.SliderOrder,
                        OptionalUrl = file.OptionalUrl,
                        PostType = file.PostType,
                        VideoUrl = file.VideoUrl,
                        VideoEmbedCode = file.VideoEmbedCode,
                        ImageUrl = file.ImageUrl,
                        NeedAuth = file.NeedAuth,
                        Visibility = file.Visibility,
                        Status = file.Status,
                        CreatedAt = file.CreatedAt
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

        public ServiceResponse<PostsDto> Get(int postsId)
        {
            var response = new ServiceResponse<PostsDto>(null);
            try
            {
                var file = _postsRepository.GetById(postsId);

                response.Entity = new PostsDto
                {
                    PostsId = file.PostsId,
                    LanguagesId = file.LanguagesId,
                    Title = file.Title,
                    TitleSlug = file.TitleSlug,
                    Summary = file.Summary,
                    Content = file.Content,
                    Keywords = file.Keywords,
                    UserId = file.UserId,
                    CategoryId = file.CategoryId,
                    ImageBig = file.ImageBig,
                    ImageMid = file.ImageMid,
                    ImageSmall = file.ImageSmall,
                    ImageSlider = file.ImageSlider,
                    ImageMime = file.ImageMime,
                    IsSlider = file.IsSlider,
                    IsPicked = file.IsPicked,
                    Hit = file.Hit,
                    SliderOrder = file.SliderOrder,
                    OptionalUrl = file.OptionalUrl,
                    PostType = file.PostType,
                    VideoUrl = file.VideoUrl,
                    VideoEmbedCode = file.VideoEmbedCode,
                    ImageUrl = file.ImageUrl,
                    NeedAuth = file.NeedAuth,
                    Visibility = file.Visibility,
                    Status = file.Status,
                    CreatedAt = file.CreatedAt
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

        public ServiceResponse<PostsDto> Insert(PostsDto postsDto)
        {

            var response = new ServiceResponse<PostsDto>(null);

            try
            {
                _postsRepository.Insert(new Posts
                {
                    LanguagesId = postsDto.LanguagesId,
                    Title = postsDto.Title,
                    TitleSlug = postsDto.TitleSlug,
                    Summary = postsDto.Summary,
                    Content = postsDto.Content,
                    Keywords = postsDto.Keywords,
                    UserId = postsDto.UserId,
                    CategoryId = postsDto.CategoryId,
                    ImageBig = postsDto.ImageBig,
                    ImageMid = postsDto.ImageMid,
                    ImageSmall = postsDto.ImageSmall,
                    ImageSlider = postsDto.ImageSlider,
                    ImageMime = postsDto.ImageMime,
                    IsSlider = postsDto.IsSlider,
                    IsPicked = postsDto.IsPicked,
                    Hit = postsDto.Hit,
                    SliderOrder = postsDto.SliderOrder,
                    OptionalUrl = postsDto.OptionalUrl,
                    PostType = postsDto.PostType,
                    VideoUrl = postsDto.VideoUrl,
                    VideoEmbedCode = postsDto.VideoEmbedCode,
                    ImageUrl = postsDto.ImageUrl,
                    NeedAuth = postsDto.NeedAuth,
                    Visibility = postsDto.Visibility,
                    Status = postsDto.Status,
                    CreatedAt = postsDto.CreatedAt
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

        public ServiceResponse<PostsDto> Update(PostsDto postsDto)
        {
            var response = new ServiceResponse<PostsDto>(null);
            try
            {
                _postsRepository.Update(new Posts
                {
                    PostsId = postsDto.PostsId,
                    LanguagesId = postsDto.LanguagesId,
                    Title = postsDto.Title,
                    TitleSlug = postsDto.TitleSlug,
                    Summary = postsDto.Summary,
                    Content = postsDto.Content,
                    Keywords = postsDto.Keywords,
                    UserId = postsDto.UserId,
                    CategoryId = postsDto.CategoryId,
                    ImageBig = postsDto.ImageBig,
                    ImageMid = postsDto.ImageMid,
                    ImageSmall = postsDto.ImageSmall,
                    ImageSlider = postsDto.ImageSlider,
                    ImageMime = postsDto.ImageMime,
                    IsSlider = postsDto.IsSlider,
                    IsPicked = postsDto.IsPicked,
                    Hit = postsDto.Hit,
                    SliderOrder = postsDto.SliderOrder,
                    OptionalUrl = postsDto.OptionalUrl,
                    PostType = postsDto.PostType,
                    VideoUrl = postsDto.VideoUrl,
                    VideoEmbedCode = postsDto.VideoEmbedCode,
                    ImageUrl = postsDto.ImageUrl,
                    NeedAuth = postsDto.NeedAuth,
                    Visibility = postsDto.Visibility,
                    Status = postsDto.Status,
                    CreatedAt = postsDto.CreatedAt
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

        public ServiceResponse<PostsDto> Delete(int postsId)
        {
            var response = new ServiceResponse<PostsDto>(null);
            try
            {
                _postsRepository.Delete(new Posts { PostsId = postsId });
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message;
                response.HasExceptionError = true;
            }

            return response;
        }

        public ServiceResponse<PostsDto> Search(SearchPostsDto searchPostsDto)
        {
            var response = new ServiceResponse<PostsDto>(null);
            searchPostsDto.Skip = searchPostsDto.Skip == 0 ? 1 : searchPostsDto.Skip;
            searchPostsDto.Take = searchPostsDto.Take == 0 ? 10 : searchPostsDto.Take;

            try
            {

                var query = _postsRepository.Table.Where(m => m.Title.Contains(searchPostsDto.SearchText) || m.Content.Contains(searchPostsDto.SearchText) || m.Keywords.Contains(searchPostsDto.SearchText)).Where(m => m.Visibility != 0 && m.Status != 0).OrderByDescending(x => x.CreatedAt).Skip(searchPostsDto.Skip).Take(searchPostsDto.Take);


                foreach (var file in query)
                    response.List.Add(new PostsDto
                    {
                        PostsId = file.PostsId,
                        LanguagesId = file.LanguagesId,
                        Title = file.Title,
                        TitleSlug = file.TitleSlug,
                        Summary = file.Summary,
                        Content = file.Content,
                        Keywords = file.Keywords,
                        UserId = file.UserId,
                        CategoryId = file.CategoryId,
                        ImageBig = file.ImageBig,
                        ImageMid = file.ImageMid,
                        ImageSmall = file.ImageSmall,
                        ImageSlider = file.ImageSlider,
                        ImageMime = file.ImageMime,
                        IsSlider = file.IsSlider,
                        IsPicked = file.IsPicked,
                        Hit = file.Hit,
                        SliderOrder = file.SliderOrder,
                        OptionalUrl = file.OptionalUrl,
                        PostType = file.PostType,
                        VideoUrl = file.VideoUrl,
                        VideoEmbedCode = file.VideoEmbedCode,
                        ImageUrl = file.ImageUrl,
                        NeedAuth = file.NeedAuth,
                        Visibility = file.Visibility,
                        Status = file.Status,
                        CreatedAt = file.CreatedAt
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
    }
}
