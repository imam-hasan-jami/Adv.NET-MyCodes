using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UndergroundFootballStadium_UFSAPI.Data;
using UndergroundFootballStadium_UFSAPI.Models.DTOs;

namespace UndergroundFootballStadium_UFSAPI.Controllers
{
    [Route("api/UFSAPI")]
    [ApiController]
    public class UFSAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UFSAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UFSDTO>> GetAllUFS()
        {
            return Ok(_db.UFSs.ToList());
        }

        [HttpGet]
        [Route("{id}", Name = "GetUFS")]
        public ActionResult<UFSDTO> GetUFS(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var ufs = _db.UFSs.FirstOrDefault(u => u.Id == id);
            if (ufs == null)
            {
                return NotFound();
            }
            return Ok(ufs);
        }
    }
}
