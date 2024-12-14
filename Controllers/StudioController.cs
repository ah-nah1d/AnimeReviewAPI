using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AnimeReviewAPI.Dto;
using AnimeReviewAPI.Interfaces;
using AnimeReviewAPI.Models;

namespace AnimeReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioController : Controller
    {
        private readonly IStudioRepository _studioRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public StudioController(IStudioRepository studioRepository, 
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            _studioRepository = studioRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Studio>))]
        public IActionResult GetStudio()
        {
            var studios = _mapper.Map<List<StudioDto>>(_studioRepository.GetStudios());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(studios);
        }

        [HttpGet("{studioId}")]
        [ProducesResponseType(200, Type = typeof(Studio))]
        [ProducesResponseType(400)]
        public IActionResult GetStudio(int studioId)
        {
            if (!_studioRepository.StudioExists(studioId))
                return NotFound();

            var studio = _mapper.Map<StudioDto>(_studioRepository.GetStudio(studioId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(studio);
        }

        [HttpGet("{studioId}/anime")]
        [ProducesResponseType(200, Type = typeof(Studio))]
        [ProducesResponseType(400)]
        public IActionResult GetAnimeByStudio(int studioId)
        {
            if (!_studioRepository.StudioExists(studioId))
            {
                return NotFound();
            }

            var studio = _mapper.Map<List<AnimeDto>>(
                _studioRepository.GetAnimeByStudio(studioId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(studio);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateStudio([FromQuery] int countryId, [FromBody] StudioDto studioCreate)
        {
            if (studioCreate == null)
                return BadRequest(ModelState);

            var studios = _studioRepository.GetStudios()
                .Where(c => c.Name.Trim().ToUpper() == studioCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (studios != null)
            {
                ModelState.AddModelError("", "Studio already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studioMap = _mapper.Map<Studio>(studioCreate);

            studioMap.Country = _countryRepository.GetCountry(countryId);

            if (!_studioRepository.CreateStudio(studioMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{studioId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateStudio(int studioId, [FromBody] StudioDto updatedStudio)
        {
            if (updatedStudio == null)
                return BadRequest(ModelState);

            if (studioId != updatedStudio.Id)
                return BadRequest(ModelState);

            if (!_studioRepository.StudioExists(studioId))
                return NotFound();
            
            if (!_countryRepository.CountryExists(updatedStudio.CountryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var studioMap = _mapper.Map<Studio>(updatedStudio);

            if (!_studioRepository.UpdateStudio(studioMap))
            {
                ModelState.AddModelError("", "Something went wrong updating studio");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{studioId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStudio(int studioId)
        {
            if (!_studioRepository.StudioExists(studioId))
            {
                return NotFound();
            }

            var studioToDelete = _studioRepository.GetStudio(studioId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_studioRepository.DeleteStudio(studioToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting studio");
            }

            return NoContent();
        }
    }
}
