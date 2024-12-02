using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeReviewAPI.Dto;
using AnimeReviewAPI.Models;

namespace AnimeReviewAPI.Interfaces
{
    public interface IAnimeRepository
    {
        ICollection<Anime> GetAnimes();
        Anime GetAnimeById(int id);
        decimal GetAnimeRating(int id);
        bool AnimeExists(int id);
        bool AnimeExists(string title);
        bool DeletePokemon(Anime anime);
        bool Save();
    }
}