using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel;
using System.Transactions;
using Udemy_Api.Repositories;

namespace Udemy_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;
        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles ="reader")]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var result = await walkRepository.GetWalkAsync();


            if (result == null)
                return BadRequest();


            var resultDTO = mapper.Map<IEnumerable<Model.DTO.Walk>>(result);

            return Ok(resultDTO);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetWalkByIdAsync(Guid Id)
        {
            var result = await walkRepository.GetWalkByIdAsync(Id);

            if (result == null)
                return BadRequest();


            var resultDTO = mapper.Map<Model.DTO.Walk>(result);
            
            return Ok(resultDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> AddNewWalkAsync(Model.DTO.AddWalkRequest walkRequest)
        {
            var res = await walkRepository.AddWalkAsync(walkRequest);

            if(res==null)
                return BadRequest();

            return Ok(res);
        }

        [HttpPut]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> UpdateWalkInfoAsync(Guid id , Model.DTO.AddWalkRequest request)
        {
            var res = await walkRepository.UpdateWalkAsync(id, request);
            if(res==null)return BadRequest();

            return Ok(res);
        }

        [HttpDelete]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var res = await walkRepository.DeleteWalk(id);

            if(res==null)return NotFound();

            var resultDTO = mapper.Map<Model.DTO.Walk>(res);
            return Ok(resultDTO);
            
        }
        
    }
}
