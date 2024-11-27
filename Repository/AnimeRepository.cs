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

        public bool AnimeExists(int id)
        {
            return _context.Animes.Any(a=>a.Id==id);
        }

        public Anime GetAnime(int id)
        {
            return _context.Animes.Where(a=>a.Id==id).FirstOrDefault();
        }

        public Anime GetAnime(string title)
        {
            return _context.Animes.Where(a=>a.Title==title).FirstOrDefault();
        }
        public decimal GetAnimeRating(int id)
        {
            var reviews=_context.Reviews.Where(a=>a.Anime.Id==id);
            if (reviews.Count()<=0)
                return 0;
            
            return ((decimal)reviews.Sum(r=>r.Rating)/reviews.Count());
        }
        public ICollection<Anime> GetAnimes(){
            var animes= _context.Animes.OrderBy(a=>a.Id).ToList();
            return animes;
        }

    }
}