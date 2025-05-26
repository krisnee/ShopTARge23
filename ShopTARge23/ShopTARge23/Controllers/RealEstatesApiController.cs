using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;

namespace ShopTARge23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstatesApiController : ControllerBase
    {
        private readonly IRealEstateServices _realEstateServices;

        public RealEstatesApiController(IRealEstateServices realEstateServices)
        {
            _realEstateServices = realEstateServices;
        }

        // GET: api/RealEstatesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RealEstateDto>>> GetRealEstates()
        {
            var realEstates = await _realEstateServices.GetAllAsync();
            var result = realEstates.Select(x => new RealEstateDto
            {
                Id = x.Id,
                Size = x.Size,
                Location = x.Location,
                RoomNumber = x.RoomNumber,
                BuildingType = x.BuildingType,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt
            });

            return Ok(result);
        }

        // GET: api/RealEstatesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RealEstateDto>> GetRealEstate(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var result = new RealEstateDto
            {
                Id = realEstate.Id,
                Size = realEstate.Size,
                Location = realEstate.Location,
                RoomNumber = realEstate.RoomNumber,
                BuildingType = realEstate.BuildingType,
                CreatedAt = realEstate.CreatedAt,
                ModifiedAt = realEstate.ModifiedAt
            };

            return Ok(result);
        }

        // POST: api/RealEstatesApi
        [HttpPost]
        public async Task<ActionResult<RealEstateDto>> CreateRealEstate(RealEstateDto dto)
        {
            var result = await _realEstateServices.Create(dto);

            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetRealEstate), new { id = result.Id }, dto);
        }

        // PUT: api/RealEstatesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRealEstate(Guid id, RealEstateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var result = await _realEstateServices.Update(dto);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/RealEstatesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealEstate(Guid id)
        {
            var result = await _realEstateServices.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}