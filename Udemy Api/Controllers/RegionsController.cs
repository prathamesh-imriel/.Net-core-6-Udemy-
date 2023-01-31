using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Udemy_Api.Model;
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

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            //var regions = new List<Region>()
            //{
            //    new Region() {Id=Guid.NewGuid(),Name="Wellington",Code="WEL"},
            //    new Region() {Id=Guid.NewGuid(),Name="Pune",Code = "PUN"},
            //    new Region() {Id=Guid.NewGuid(),Name="Mumbai",Code = "MUM"}
            //};



            var allRegions = await regionRepository.GetRegionsAsync();


            //var regionsDTO = new List<DTO.Region>();

            //allRegions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new DTO.Region()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long= region.Long,
            //        Population = region.Population
            //    };

            //    regionsDTO.Add(regionDTO);
            //});

            var regionsDTO =  mapper.Map<List<Model.DTO.Region>>(allRegions);
            return Ok(regionsDTO);
        }
    }
}
