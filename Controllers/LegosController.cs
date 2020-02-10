using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using legos.Models;
using legos.Services;

namespace legos.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LegosController : ControllerBase
  {
    private readonly LegosService _ls;
    private readonly SetsService _ss;
    public LegosController(LegosService ls, SetsService ss)
    {
      _ss = ss;
      _ls = ls;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Lego>> Get()
    {
      try
      {
        return Ok(_ss.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Lego> Get(int id)
    {
      try
      {
        return Ok(_ss.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/sets")]
    public ActionResult<IEnumerable<Set>> GetSets(int id)
    {
      try
      {
        return Ok(_ss.GetByLegoId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Lego> Create([FromBody] Lego newData)
    {
      try
      {
        return Ok(_ss.Create(newData));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Lego> Edit([FromBody] Lego update, int id)
    {
      try
      {
        update.Id = id;
        return Ok(_ss.Edit(update));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_ss.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}