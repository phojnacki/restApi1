﻿using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static readonly ISet<Post> _posts = new HashSet<Post>()
        {
            new Post(1, "Dzien 1","Dzisiaj na swojej drodze spotkałem Łosia! Jest on ogromyn zwierzęciem"),
            new Post(2, "Dzien 2","Po wczorajszej walce z Łosiem, ide w strone szpitala"),
            new Post(3, "Dzien 3","Wróciłem ze szpitala, i poszedłem się zaopatrzyć w broń")
        };

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public Post GetById(int id)
        {
            return _posts.SingleOrDefault(x => x.Id == id);
        }
        public Post Add(Post post)
        {
            post.Id = _posts.Count() + 1;
            post.Created = DateTime.UtcNow;
            _posts.Add(post);
            return post;
        }
        public void Update(Post post)
        {
            post.LastModified = DateTime.UtcNow;
        }

        public void Delete(Post post)
        {
            _posts.Remove(post);
        }


    }
}