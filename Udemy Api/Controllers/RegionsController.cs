using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Udemy_Api.Model.DTO;
using Udemy_Api.Repositories;
using Microsoft.AspNetCore.Authorization;

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
        //[Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllRegions()
        {

            var allRegions = await regionRepository.GetRegionsAsync();

            var regionsDTO = mapper.Map<List<Region>>(allRegions);
            return Ok(regionsDTO);
        }


        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "writer")]
        public async Task<IActionResult> GetRegionByIdAsync(Guid id)
        {
            var result = await regionRepository.GetRegionByIdAsync(id);

            if (result == null)
                return NotFound();

            var resultDTO = mapper.Map<Region>(result);
            return Ok(resultDTO);

        }

        [HttpPost]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> AddNewRegionAsync(Model.DTO.AddRegionRequest region)
        {

            //var isValid = ValidateAddRegionRequest(region);

            //if (!isValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var result = await regionRepository.AddNewRegionAsync(region);

            var resultDTO = mapper.Map<Region>(result);


            if (resultDTO != null)
                return Ok(resultDTO);
            return BadRequest();
        }


        [HttpDelete]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var res = await regionRepository.DeleteRegionAsync(id);
            var resultDTO = mapper.Map<Region>(res);
            if (res != null)
                return Ok(resultDTO);

            return NotFound();
        }

        [HttpPut]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateRegionAsync(Guid id, Model.DTO.AddRegionRequest request)
        {
            var regionFound = await regionRepository.UpdateRegionAsync(id, request);

            if (regionFound != null)
                return Ok(regionFound);

            return BadRequest();
        }


        #region Private Methods
        private bool ValidateAddRegionRequest(Model.DTO.AddRegionRequest region)
        {
            {

                if (region == null)
                {
                    ModelState.AddModelError(nameof(region), "Enter Data");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(region.Code))
                {
                    ModelState.AddModelError(nameof(region.Code), $"{nameof(region.Code)} can't be empty");

                }

                if (string.IsNullOrWhiteSpace(region.Name))
                {
                    ModelState.AddModelError(nameof(region.Name), $"{nameof(region.Name)} can't be empty");

                }

                if (region.Area <= 0)
                {
                    ModelState.AddModelError(nameof(region.Area), $"Enter valid value for {nameof(region.Area)}");

                }

                if (region.Lat <= 0)
                {
                    ModelState.AddModelError(nameof(region.Lat), $"Enter valid value for {nameof(region.Lat)}");

                }

                if (region.Long <= 0)
                {
                    ModelState.AddModelError(nameof(region.Long), $"Enter valid value for {nameof(region.Long)}");

                }

                if (region.Population <= 0)
                {
                    ModelState.AddModelError(nameof(region.Population), $"Enter valid value for {nameof(region.Population)}");

                }

                if (ModelState.ErrorCount > 0)
                {
                    return false;
                }

                return true;
            }


        }



        #endregion
    }

}


