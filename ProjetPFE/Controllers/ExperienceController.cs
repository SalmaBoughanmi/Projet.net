using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetPFE.Contracts;
using ProjetPFE.Dto;

namespace ProjetPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {

        private readonly IExperienceRepository _ExperienceRepo;
        public ExperienceController(IExperienceRepository ExperienceRepo)
        {
            _ExperienceRepo = ExperienceRepo;
        }




        [HttpGet]
        public async Task<IActionResult> GetExperiences()
        {
            try
            {
                var exp = await _ExperienceRepo.GetExperiences();
                return Ok(exp);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("{experience_id}", Name = "experiencebyid")]
        public async Task<IActionResult> GetExperience(int experience_id)

        {
            try
            {
                var experience = await _ExperienceRepo.GetExperience(experience_id);
                if (experience == null)
                    return NotFound();

                return Ok(experience);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }







        [HttpPost]
        public async Task<IActionResult> CreateExperience(ExperienceForCreationDto experience)
        {
            try
            {
                var createdexp = await _ExperienceRepo.CreateExperience(experience);
                //return CreatedAtRoute("experienceById", new { experience_id = createdexp.experience_id }, createdexp);
                return Ok();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }





        [HttpPut("{experience_id}")]
        public async Task<IActionResult> UpdateExperience(int experience_id, ExperienceForUpdateDto experience)
        {
            try
            {
                var dbexp = await _ExperienceRepo.GetExperience(experience_id);
                if (dbexp == null)
                    return NotFound();

                await _ExperienceRepo.UpdateExperience(experience_id, experience);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }





        [HttpDelete("{experience_id}")]
        public async Task<IActionResult> DeleteExperience(int experience_id)
        {
            try
            {
                var dbexp = await _ExperienceRepo.GetExperience(experience_id);
                if (dbexp == null)
                    return NotFound();

                await _ExperienceRepo.GetExperience(experience_id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }














    }
}
