using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public IEnumerable<PostDto> GetAllPosts()
        {
            var posts = _postRepository.GetAll();
            //return posts.Select(post => new PostDto {Id=post.Id,Title=post.Title,Content=post.Content });
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);
            /// bez autoMapper
            //return new PostDto()
            //{
            //    Id = post.Id,
            //    Title = post.Title,
            //    Content = post.Content
            //};
            /// z
            return _mapper.Map<PostDto>(post);
        }
        public PostDto AddNewPost(CreatePostDto newpost)
        {
            if (string.IsNullOrEmpty(newpost.Title))
            {
                throw new Exception("Post can not have an empty title");
            }
            var post = _mapper.Map<Post>(newpost);
            _postRepository.Add(post);
            return _mapper.Map<PostDto>(post);
        }

    }
}
