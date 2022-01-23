using Microsoft.AspNetCore.Mvc;
using MusicalEvents.Dto.Request;
using MusicalEvents.Dto.Response;
using MusicalEvents.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicalEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        // GET: api/<GenreController>
        [HttpGet]
        public async Task<ActionResult<BaseResponseGeneric<ICollection<Genre>>>> Get()
        {
            var response = new BaseResponseGeneric<ICollection<Genre>>();

            return response;
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public BaseResponseGeneric<DtoGenre> Get(int id)
        {
            var response = new BaseResponseGeneric<DtoGenre>();
            response.Result = new DtoGenre();
            return response;
        }

        // POST api/<GenreController>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseGeneric<int>), StatusCodes.Status201Created)]
        public ActionResult<BaseResponseGeneric<int>> Post([FromBody] DtoGenre request)
        {
            var response = new BaseResponseGeneric<int>();
            var id = 3;

            return Created($"Get/{id}", response);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public BaseResponseGeneric<int> Put(int id, [FromBody] DtoGenre request)
        {
            return new BaseResponseGeneric<int>();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public BaseResponseGeneric<int> Delete(int id)
        {
            return new BaseResponseGeneric<int>();
        }
    }
}
