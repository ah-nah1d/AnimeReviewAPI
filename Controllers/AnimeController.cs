using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeReviewAPI.Interfaces;
using AnimeReviewAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimeReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeRepository _animeRepository;
        public AnimeController(IAnimeRepository animeRepository)
        {
            _animeRepository=animeRepository;
        }

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Anime>))]
        public IActionResult GetAnimes(){
            var animes =_animeRepository.GetAnimes();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(animes);
        }
    }
}