using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AnimeReviewAPI.Data;
using AnimeReviewAPI.Interfaces;
using AnimeReviewAPI.Models;

namespace AnimeReviewAPI.Repository
{
    public class StudioRepository : IStudioRepository
    {
        private readonly DataContext _context;

        public StudioRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateStudio(Studio owner)
        {
            _context.Add(owner);
            return Save();
        }

        public bool DeleteStudio(Studio studio)
        {
            _context.Remove(studio);
            return Save();
        }

        public Studio GetStudio(int studioId)
        {
            return _context.Studios.Where(o => o.Id == studioId).FirstOrDefault();
        }

        public ICollection<Studio> GetStudios()
        {
            return _context.Studios.ToList();
        }

        public ICollection<Anime> GetAnimeByStudio(int studioId)
        {
            return _context.Animes.Where(a => a.StudioId == studioId).ToList();
        }

        public bool StudioExists(int studioId)
        {
            return _context.Studios.Any(o => o.Id == studioId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateStudio(Studio studio)
        {
            _context.Update(studio);
            return Save();
        }
    }
}
