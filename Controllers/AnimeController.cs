using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeReviewAPI.Dto;
using AnimeReviewAPI.Interfaces;
using AnimeReviewAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimeReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : Controller
    {
        private readonly IAnimeRepository _animeRepository;
        
        private readonly IMapper _mapper;

        public AnimeController(IAnimeRepository animeRepository,IMapper mapper)
        {
            _animeRepository = animeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Anime>))]
        public IActionResult GetAnimes()
        {
            var animes = _mapper.Map<List<AnimeDto>>(_animeRepository.GetAnimes());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(animes);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Anime))]
        [ProducesResponseType(400)]
        public IActionResult GetAnime(int id)
        {
            if (!_animeRepository.AnimeExists(id))
                return NotFound();

            var anime = _mapper.Map<AnimeDto>(_animeRepository.GetAnimeById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(anime);
        }

        [HttpGet("{id}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int id)
        {
            if (!_animeRepository.AnimeExists(id))
                return NotFound();

            var rating = _animeRepository.GetAnimeRating(id);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePokemon(int id)
        {
            if (!_animeRepository.AnimeExists(id))
            {
                return NotFound();
            }

            
            var pokemonToDelete = _animeRepository.GetAnimeById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_animeRepository.DeletePokemon(pokemonToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}