using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetPFE.Contracts;
using ProjetPFE.Dto;

namespace ProjetPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationController : ControllerBase
    {

        private readonly ICertificationRepository _CertificationRepo;
        public CertificationController(ICertificationRepository CertificationRepo)
        {
            _CertificationRepo = CertificationRepo;
        }




        [HttpGet]
        public async Task<IActionResult> GetCertifications()
        {
            try
            {
                var certif = await _CertificationRepo.GetCertifications();
                return Ok(certif);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("{certif_id}", Name = "certificationbyid")]
        public async Task<IActionResult> GetCertification(int certif_id)

        {
            try
            {
                var certification = await _CertificationRepo.GetCertification(certif_id);
                if (certification == null)
                    return NotFound();

                return Ok(certification);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }







        [HttpPost]
        public async Task<IActionResult> CreateCertification(CertificationForCreationDto certification)
        {
            try
            {
                var createdcertif = await _CertificationRepo.CreateCertification(certification);
                //return CreatedAtRoute("certifById", new { certif_id = createdcertif.certif_id }, createdcertif);
                return Ok();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }





        [HttpPut("{certif_id}")]
        public async Task<IActionResult> UpdateCertification(int certif_id, CertificationForUpdateDto certification)
        {
            try
            {
                var dbcertif = await _CertificationRepo.GetCertification(certif_id);
                if (dbcertif == null)
                    return NotFound();

                await _CertificationRepo.UpdateCertification(certif_id, certification);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }





        [HttpDelete("{certif_id}")]
        public async Task<IActionResult> DeleteCertification(int certif_id)
        {
            try
            {
                var dbcertif = await _CertificationRepo.GetCertification(certif_id);
                if (dbcertif == null)
                    return NotFound();

                await _CertificationRepo.GetCertification(certif_id);
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
