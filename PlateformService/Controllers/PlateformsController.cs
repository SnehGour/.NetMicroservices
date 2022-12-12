using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlateformService.Data;
using PlateformService.DTOs;
using PlateformService.Models;

namespace PlateformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateformsController : ControllerBase
    {
        private readonly IPlateformRepo _repo;
        private readonly IMapper _mapper;

        public PlateformsController(IPlateformRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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
        public ActionResult<PlateformReadDTO> CreatePlateform(PlateformCreateDTO plateformCreateDTO)
        {
            var plateformModel = _mapper.Map<Plateform>(plateformCreateDTO);
            _repo.CreatePlateform(plateformModel);
            _repo.SaveChanges();

            var plateformItem = _mapper.Map<PlateformReadDTO>(plateformModel);
            return CreatedAtRoute(nameof(GetPlateformById), new { Id = plateformItem.Id }, plateformItem);
        }
    }
}