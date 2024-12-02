using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeReviewAPI.Dto
{
    public class AnimeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
    }
}