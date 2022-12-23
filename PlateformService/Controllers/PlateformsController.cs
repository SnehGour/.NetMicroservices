using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlateformService.Data;
using PlateformService.DTOs;
using PlateformService.Models;
using PlateformService.SyncDataService.Http;

namespace PlateformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateformsController : ControllerBase
    {
        private readonly IPlateformRepo _repo;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _client;

        public PlateformsController(IPlateformRepo repo, IMapper mapper,ICommandDataClient client)
        {
            _repo = repo;
            _mapper = mapper;
            _client = client;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlateformReadDTO>> GetAllPlateforms()
        {
            Console.WriteLine("-->Getting All Plateforms...");
            var plateformItems = _repo.GetAllPlateforms();
            return Ok(_mapper.Map<IEnumerable<PlateformReadDTO>>(plateformItems));
        }

        [HttpGet("{id}", Name = "GetPlateformById")]
        public ActionResult<PlateformReadDTO> GetPlateformById(int id)
        {
            var plateformItem = _repo.GetPlateformById(id);
            if (plateformItem != null)
            {
                return Ok(_mapper.Map<PlateformReadDTO>(plateformItem));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlateformReadDTO>> CreatePlateform(PlateformCreateDTO plateformCreateDTO)
        {
            Console.WriteLine("--->Creating Plateform...");
            var plateformModel = _mapper.Map<Plateform>(plateformCreateDTO);
            _repo.CreatePlateform(plateformModel);
            _repo.SaveChanges();

            var plateformItem = _mapper.Map<PlateformReadDTO>(plateformModel);

            try
            {
                await _client.SendPlateformToCommand(plateformItem);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"---> Error: {ex.Message}");
            }
            return CreatedAtRoute(nameof(GetPlateformById), new { Id = plateformItem.Id }, plateformItem);
        }
    }
}