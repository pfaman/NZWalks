using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Repositories;


namespace NZWalks.API.Controllers
{
    // https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;

        }
        // GET All Region
        // GEt https://localhost:portNumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            /*
            var regionsDomain = await dbContext.Regions.ToListAsync();
            */

            var regionsDomain = await regionRepository.GetAllAsync();

            // Convert Dmain regions to DTO regions
            var regionsDTO = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDTO.Add(new RegionDto
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }
            return Ok(regionsDTO);
        }


        // GET Single Region
        // GEt https://localhost:portNumber/api/regions/{id}

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            /*
            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            */

            var regionDomain = await regionRepository.GetByIdAsync(id);



            // if region not found
            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map Dmain region to DTO region

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(regionDto);
        }


        // POST Creat Region
        // POST https://localhost:portNumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Convert DTO to Domain
            var regionDomain = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            // Pass details to DBContext to save to database 

            /*
            await dbContext.Regions.AddAsync(regionDomain);
            await dbContext.SaveChangesAsync();
            */

            regionDomain =  await regionRepository.CreateAsync(regionDomain);

             
            // Convert Domain to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDomain.Id }, regionDto);
        }

        // Update Region
        // PUT https://localhost:portNumber/api/regions/{id}

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            //Map Dto to Domain Model
            var regionDomain = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl,
            };

            /*
            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x=> x.Id == id);

            */

            regionDomain = await regionRepository.UpdateAsync(id, regionDomain);

            if(regionDomain == null)
            {
                return NotFound();
            }

            // Convert DTO to Domain

            regionDomain.Code = updateRegionRequestDto.Code;
            regionDomain.Name = updateRegionRequestDto.Name;
            regionDomain.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;


            await dbContext.SaveChangesAsync();

            // Convert Domain to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDto);
        }


        // Delete Region
        // DELETE https://localhost:portNumber/api/regions/{id}

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            /*
            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            
            */

            var regionDomain = await regionRepository.DeleteAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            /*
            dbContext.Regions.Remove(regionDomain);
            await dbContext.SaveChangesAsync();
            */

            // return deleted region

            // Convert Domain to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };


            return Ok(regionDto);
        }
    }
}
