using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Udemy_Api.Model;
using System.Net;
using Udemy_Api.Model.DTO;
using Udemy_Api.Repositories;

namespace Udemy_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        public readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {


            /*
             
             var regions = new List<Region>(){
                new Region() {Id=Guid.NewGuid(),Name="Wellington",Code="WEL"},
                new Region() {Id=Guid.NewGuid(),Name="Pune",Code = "PUN"},
                new Region() {Id=Guid.NewGuid(),Name="Mumbai",Code = "MUM"}
            };

             */



            var allRegions = await regionRepository.GetRegionsAsync();


            /*

                var regionsDTO = new List<DTO.Region>();

                allRegions.ToList().ForEach(region =>
                {
                    var regionDTO = new DTO.Region()
                    {
                        Id = region.Id,
                        Name = region.Name,
                        Code = region.Code,
                        Area = region.Area,
                        Lat = region.Lat,
                        Long= region.Long,
                        Population = region.Population
                    };

                    regionsDTO.Add(regionDTO);
                });

             */

            var regionsDTO = mapper.Map<List<Region>>(allRegions);
            return Ok(regionsDTO);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionByIdAsync(Guid id)
        {
            var result = await regionRepository.GetRegionByIdAsync(id);

            var resultDTO = mapper.Map<Region>(result);
            if (result == null)
                return NotFound();
            
            return Ok(resultDTO);

        }

        [HttpPost]
        public async Task<IActionResult> AddNewRegionAsync(Model.DTO.AddRegionRequest region)
        {
            var result = await regionRepository.AddNewRegionAsync(region);

            var resultDTO = mapper.Map<Region>(result);
            

            if(resultDTO!=null)
                return Ok(resultDTO);
            return BadRequest();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var res = await regionRepository.DeleteRegionAsync(id);
            var resultDTO = mapper.Map<Region>(res);    
            if (res != null)
                return Ok(resultDTO);

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegionAsync(Guid id,Model.DTO.AddRegionRequest request)
        {
            var regionFound = await regionRepository.UpdateRegionAsync(id,request);

            if(regionFound!=null) 
                return Ok(regionFound);
            
            return BadRequest();
        }
    }
}


//0bb799de - 2831 - 475e-959f - 08db041e1a63