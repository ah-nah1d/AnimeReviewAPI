using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeReviewAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }

        public int AnimeId { get; set; }
        public Anime? Anime { get; set; }

        public int ReviewerId { get; set; }
        public Reviewer? Reviewer { get; set; } 
    }
}