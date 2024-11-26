using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeReviewAPI.Models;

namespace AnimeReviewAPI.Interfaces
{
    public interface IAnimeRepository
    {
        ICollection<Anime> GetAnimes();
    }
}