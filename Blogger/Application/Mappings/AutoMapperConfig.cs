using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{

    //CONFIGURACJA MAPOWANIA
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<Post, PostDto>();
                ctg.CreateMap<CreatePostDto, Post>();
            })
            .CreateMapper();
    }
}
