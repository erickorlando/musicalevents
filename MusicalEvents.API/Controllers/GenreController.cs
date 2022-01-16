using Microsoft.AspNetCore.Mvc;
using MusicalEvents.Dto.Request;
using MusicalEvents.Dto.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicalEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        // GET: api/<GenreController>
        [HttpGet]
        public BaseCollectionResponse<GenreDto> Get()
        {
            var response = new BaseCollectionResponse<GenreDto>();

            return response;
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public BaseResponse<GenreDto> Get(int id)
        {
            var response = new BaseResponse<GenreDto>();
            response.Result = new GenreDto();
            return response;
        }

        // POST api/<GenreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
