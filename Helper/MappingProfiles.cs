using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeReviewAPI.Dto;
using AnimeReviewAPI.Models;
using AutoMapper;

namespace AnimeReviewAPI.Helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Anime,AnimeDto>();
        }
    }
}