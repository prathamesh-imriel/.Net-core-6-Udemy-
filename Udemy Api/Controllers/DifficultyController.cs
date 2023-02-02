using Microsoft.AspNetCore.Mvc;
using Udemy_Api.Repositories;

namespace Udemy_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DifficultyController : Controller
    {
        private readonly IDifficultyRepository difficultyRepository;
        public DifficultyController(IDifficultyRepository difficultyRepository)
        {
            this.difficultyRepository = difficultyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDifficulties()
        {
            var allDifficulties = await difficultyRepository.GetAllDifficulties();

            if (allDifficulties == null) return BadRequest();

            return Ok(allDifficulties);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDifficultyById(Guid id)
        {
            var difficultyLevel = await difficultyRepository.GetDificultyLevelById(id);

            if (difficultyLevel == null) return BadRequest();

            return Ok(difficultyLevel);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDifficultyLevel(Model.DTO.AddDifficultyRequest request)
        {
           var newDifficulty = await difficultyRepository.AddNewDifficultyAsync(request);

            if (newDifficulty == null) return BadRequest();

            return Ok(newDifficulty);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDifficultyInfo(Guid id, Model.DTO.AddDifficultyRequest request)
        {
            var updatedDifficultyInfo = await difficultyRepository.UpdateDifficultyAsync(id, request);

            if (updatedDifficultyInfo == null) return BadRequest();

            return Ok(updatedDifficultyInfo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDifficultyLevel(Guid id)
        {
            var deletedDifficultyLevel = await difficultyRepository.DeleteDifficultyLevel(id);


            if (deletedDifficultyLevel == null) return BadRequest();

            return Ok(deletedDifficultyLevel);
        }
    }
}
