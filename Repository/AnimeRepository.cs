using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeReviewAPI.Data;
using AnimeReviewAPI.Dto;
using AnimeReviewAPI.Interfaces;
using AnimeReviewAPI.Models;
using Microsoft.EntityFrameworkCore; 

namespace AnimeReviewAPI.Repository
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly DataContext _context;

        public AnimeRepository(DataContext context)
        {
            _context = context;
        }
        public bool DeletePokemon(Anime anime)
        {
            _context.Remove(anime);
            return Save();
        }

        public Anime GetAnimeById(int id)
        {
            return _context.Animes.Where(p => p.Id == id).FirstOrDefault();
        }
        public decimal GetAnimeRating(int id)
        {
            var review = _context.Reviews.Where(p => p.Anime.Id == id);

            if (review.Count() <= 0)
                return 0;
                
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Anime> GetAnimes()
        {
            return _context.Animes.OrderBy(p => p.Id).ToList();
        }

        public bool AnimeExists(int id)
        {
            return _context.Animes.Any(p => p.Id == id);
        }

        public bool AnimeExists(string title)
        {
            return _context.Animes.Any(p => p.Title == title);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}