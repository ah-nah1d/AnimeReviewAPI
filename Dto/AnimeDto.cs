using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeReviewAPI.Dto
{
    public class AnimeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTimeOffset ReleaseDate { get; set; } = DateTimeOffset.UtcNow;
        public string Genre { get; set; } = string.Empty;
    }
}