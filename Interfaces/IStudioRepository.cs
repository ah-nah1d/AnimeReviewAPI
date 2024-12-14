using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AnimeReviewAPI.Models;

namespace AnimeReviewAPI.Interfaces
{
    public interface IStudioRepository
    {
        ICollection<Studio> GetStudios();
        Studio GetStudio(int studioId);
        ICollection<Anime> GetAnimeByStudio(int StudioId);
        bool StudioExists(int studioId);
        bool CreateStudio(Studio Studio);
        bool UpdateStudio(Studio Studio);
        bool DeleteStudio(Studio Studio);
        bool Save();
    }
}
