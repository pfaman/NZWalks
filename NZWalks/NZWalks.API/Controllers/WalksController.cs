
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{

    // /api/controller
    [Route("api/[Controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        public readonly IMapper Mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            Mapper = mapper;
            this.walkRepository = walkRepository;
        }


        // Create Walk
        // POST : /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {

            // Map Dto to Domain Model

            var walkDomianModel = Mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomianModel);

            //Map Domain to Dto

            return Ok(Mapper.Map<WalkDto>(walkDomianModel));

        }

        // Commnetd for Filter Testing
        /*
                //Get All walks
                // Get : /api/walks
                [HttpGet]
                public async Task<IActionResult> GetAll()
                {
                    var walksDomianModel = await walkRepository.GetAllAsync();

                    // Map Domain to Dto
                    return Ok(Mapper.Map<List<WalkDto>>(walksDomianModel));
                }
                */


        //Get walks By Filter
        // Get : /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
        [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {

            var walksDomianModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            // Create an Execption for Global testing
            //  throw new Exception("This is an Execption"); // Commented
            // Map Domain to Dto
            return Ok(Mapper.Map<List<WalkDto>>(walksDomianModel));
        }


        //Get Single walk By Id
        // Get : /api/walks/{id}
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to Dto

            return Ok(Mapper.Map<WalkDto>(walkDomainModel));

        }


        // Update Walk By Id
        // PUT : /api/Walks/{id}

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            // Map Dto to Domain Model

            var walkDomainModel = Mapper.Map<Walk>(updateWalkRequestDto);


            walkDomainModel = await walkRepository.UpdateWalkAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain to Dto
            return Ok(Mapper.Map<WalkDto>(walkDomainModel));

        }

        //Delete Single walk By Id
        // Delete : /api/walks/{id}
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteWalkById([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteByIdAsync(id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to Dto

            return Ok(Mapper.Map<WalkDto>(deletedWalkDomainModel));

        }


    }
}