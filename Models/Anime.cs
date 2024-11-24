using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeReviewAPI.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;

        public int StudioId { get; set; } 
        public Studio? Studio { get; set; } 

        public List<Review> Reviews { get; set; }=[];
        public List<AnimeCategory> AnimeCategories { get; set; } =[];
        
    }
}