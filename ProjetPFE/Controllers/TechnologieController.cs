using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetPFE.Contracts;
using ProjetPFE.Dto;

namespace ProjetPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologieController : ControllerBase
    {

        private readonly ITechnologieRepository _TechnologieRepo;
        public TechnologieController(ITechnologieRepository TechnologieRepo)
        {
            _TechnologieRepo = TechnologieRepo;
        }




        [HttpGet]
        public async Task<IActionResult> GetTechnologies()
        {
            try
            {
                var techno = await _TechnologieRepo.GetTechnologies();
                return Ok(techno);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("{techno_id}", Name = "technologiebyid")]
        public async Task<IActionResult> GetTechnologie(int techno_id)

        {
            try
            {
                var technologie = await _TechnologieRepo.GetTechnologie(techno_id);
                if (technologie == null)
                    return NotFound();

                return Ok(technologie);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }







        [HttpPost]
        public async Task<IActionResult> CreateTechnologie(TechnologieForCreationDto technologie)
        {
            try
            {
                var createdtechno = await _TechnologieRepo.CreateTechnologie(technologie);
                //return CreatedAtRoute("technoById", new { techno_id = createdtechno.techno_id }, createdtechno);
                return Ok();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }





        [HttpPut("{techno_id}")]
        public async Task<IActionResult> UpdateTechnologie(int techno_id, TechnologieForUpdateDto technologie)
        {
            try
            {
                var dbcertif = await _TechnologieRepo.GetTechnologie(techno_id);
                if (dbcertif == null)
                    return NotFound();

                await _TechnologieRepo.UpdateTechnologie(techno_id, technologie);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }





        [HttpDelete("{techno_id}")]
        public async Task<IActionResult> DeleteTechnologie(int techno_id)
        {
            try
            {
                var dbtechno = await _TechnologieRepo.GetTechnologie(techno_id);
                if (dbtechno == null)
                    return NotFound();

                await _TechnologieRepo.GetTechnologie(techno_id);
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
