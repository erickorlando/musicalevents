using System.Net;
using Microsoft.AspNetCore.Mvc;
using MusicalEvents.Dto.Request;
using MusicalEvents.Dto.Response;
using MusicalEvents.Entities;

namespace MusicalEvents.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    [HttpGet]
    // filter = ""
    // page = 1 || 2
    // rows = 10 || 10
    public ActionResult<BaseResponseGeneric<ICollection<Concert>>> Get(string? filter = ""
        , int page = 1,
        int rows = 10)
    {
        var response = new BaseResponseGeneric<ICollection<Concert>>();

        try
        {
            response.Success = true;

        }
        catch (Exception ex)
        {
            response.Errors.Add(ex.Message);
        }

        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public ActionResult<BaseResponseGeneric<Concert>> Get(int id)
    {
        return Ok(new Concert());
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public ActionResult<BaseResponseGeneric<int>> Post([FromBody] DtoEvent request)
    {
        var obj = new Concert();
        return Created($"Get/{obj.Id}", obj);
    }

    [HttpPut("{id:int}")]
    public ActionResult<BaseResponseGeneric<int>> Put(int id, [FromBody]DtoEvent request)
    {
        return Ok(id);
    }



    [HttpDelete("{id:int}")]
    public ActionResult<BaseResponseGeneric<int>> Delete(int id)
    {
        return Ok(id);
    }
}