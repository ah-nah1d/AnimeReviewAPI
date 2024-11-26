using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeReviewAPI.Data;
using AnimeReviewAPI.Interfaces;
using AnimeReviewAPI.Models;

namespace AnimeReviewAPI.Repository
{
    public class AnimeRepository : IAnimeRepository
    {
        public readonly DataContext _context;
        public AnimeRepository(DataContext context)
        {
            _context=context;
        }
        public ICollection<Anime> GetAnimes(){
            var animes= _context.Animes.OrderBy(a=>a.Id).ToList();
            return animes;
        }

    }
}