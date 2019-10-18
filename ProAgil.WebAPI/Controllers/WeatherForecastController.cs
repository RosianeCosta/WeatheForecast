using AutoMapper;
using Weather.Domain;
using Weather.Repository;
using Weather.WebApi.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherRepository _repo;
        private readonly IMapper _mapper;

        public WeatherForecastController(IWeatherRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cities = await _repo.GetAllCitiesAsync();
                var result = _mapper.Map<IEnumerable<CitiesDto>>(cities);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "db falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CitiesDto model)
        {
            try
            {
                _repo.Add(_mapper.Map<IEnumerable<Cities>>(model));

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.CityId}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "db falhou");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int cityId)
        {
            try
            {
                var evento = await _repo.GetCityAsync(cityId);
                if (evento == null) return NotFound();

                _repo.Delete(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "db falhou");
            }

            return BadRequest();
        }
    }
}