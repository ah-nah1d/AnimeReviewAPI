using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeReviewAPI.Models
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; } 
        public Country? Country { get; set; } 
        public List<Anime> Animes { get; set; }=[];
    }
}