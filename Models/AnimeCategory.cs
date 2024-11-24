using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeReviewAPI.Models
{
    public class AnimeCategory
    {
        public int AnimeId { get; set; }
        public int CategoryId { get; set; }
        public Anime Anime { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}