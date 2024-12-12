using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AnimeReviewAPI.Models;

namespace AnimeReviewAPI.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Anime> GetAnimeByCategory(int categoryId);
        bool CategoryExists(int id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}