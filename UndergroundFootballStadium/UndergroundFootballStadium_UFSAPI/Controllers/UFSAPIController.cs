using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UndergroundFootballStadium_UFSAPI.Data;
using UndergroundFootballStadium_UFSAPI.Models;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpPost]
        [Route("CreateUFS")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UFSDTO> CreateUFS([FromBody] UFSDTO ufsDTO)
        {
            if (_db.UFSs.FirstOrDefault(u => u.Name.ToLower() == ufsDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "UFS already exists");
                return BadRequest(ModelState);
            }

            if (ufsDTO == null)
            {
                return BadRequest();
            }
            if (ufsDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            UFS model = new()
            {
                Amenity = ufsDTO.Amenity,
                Details = ufsDTO.Details,
                Id = ufsDTO.Id,
                ImageUrl = ufsDTO.ImageUrl,
                Name = ufsDTO.Name,
                Occupancy = ufsDTO.Occupancy,
                Rate = ufsDTO.Rate,
                Sqft = ufsDTO.Sqft,
                CreatedDate = DateTime.Now
            };
            _db.UFSs.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetUFS", new { id = ufsDTO.Id }, ufsDTO);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUFS(int id)
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
            _db.UFSs.Remove(ufs);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}", Name = "UpdateUFS")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUFS(int id, [FromBody] UFSDTO ufsDTO)
        {
            if (ufsDTO == null || id != ufsDTO.Id)
            {
                return BadRequest();
            }

            var ufs = _db.UFSs.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (ufs == null)
            {
                return NotFound();
            }

            UFS model = new()
            {
                Amenity = ufsDTO.Amenity,
                Details = ufsDTO.Details,
                Id = ufsDTO.Id,
                ImageUrl = ufsDTO.ImageUrl,
                Name = ufsDTO.Name,
                Occupancy = ufsDTO.Occupancy,
                Rate = ufsDTO.Rate,
                Sqft = ufsDTO.Sqft,
                CreatedDate = ufs.CreatedDate,
                UpdatedDate = DateTime.Now
            };
            _db.UFSs.Update(model);
            //_db.Entry(model).Property(u => u.CreatedDate).IsModified = false;   // Ensure CreatedDate is not modified
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPatch]
        [Route("{id:int}", Name = "UpdatePartialUFS")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePPartialVilla(int id, JsonPatchDocument<UFSDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var ufs = _db.UFSs.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (ufs == null)
            {
                return NotFound();
            }

            UFSDTO ufsDTO = new()
            {
                Amenity = ufs.Amenity,
                Details = ufs.Details,
                Id = ufs.Id,
                ImageUrl = ufs.ImageUrl,
                Name = ufs.Name,
                Occupancy = ufs.Occupancy,
                Rate = ufs.Rate,
                Sqft = ufs.Sqft
            };

            if (ufs == null)
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(ufsDTO, ModelState);
            UFS model = new UFS()
            {
                Amenity = ufsDTO.Amenity,
                Details = ufsDTO.Details,
                Id = ufsDTO.Id,
                ImageUrl = ufsDTO.ImageUrl,
                Name = ufsDTO.Name,
                Occupancy = ufsDTO.Occupancy,
                Rate = ufsDTO.Rate,
                Sqft = ufsDTO.Sqft,
                CreatedDate = ufs.CreatedDate,
                UpdatedDate = DateTime.Now
            };

            _db.UFSs.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
