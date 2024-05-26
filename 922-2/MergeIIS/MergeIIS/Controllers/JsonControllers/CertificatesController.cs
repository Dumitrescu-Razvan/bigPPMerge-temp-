using Microsoft.AspNetCore.Mvc;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;
using System;
using System.Collections.Generic;

namespace MergeIIS.Controllers.JsonControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly ICertificateRepo _certificateRepo;

        public CertificatesController(ICertificateRepo certificateRepo)
        {
            _certificateRepo = certificateRepo;
        }

        // GET: api/Certificates
        [HttpGet]
        public ActionResult<IEnumerable<Certificate>> GetCertificates()
        {
            return Ok(_certificateRepo.GetAll());
        }

        // GET: api/Certificates/5
        [HttpGet("{id}")]
        public ActionResult<Certificate> GetCertificate(int id)
        {
            var certificate = _certificateRepo.GetById(id);

            if (certificate == null)
            {
                return NotFound();
            }

            return Ok(certificate);
        }

        // PUT: api/Certificates/5
        [HttpPut("{id}")]
        public IActionResult UpdateCertificate(int id, Certificate certificate)
        {
            if (id != certificate.certificateId)
            {
                return BadRequest();
            }

            try
            {
                _certificateRepo.Update(certificate);
            }
            catch (Exception)
            {
                if (_certificateRepo.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Certificates
        [HttpPost]
        public ActionResult<Certificate> AddCertificate(Certificate certificate)
        {
            _certificateRepo.Add(certificate);

            return CreatedAtAction("GetCertificate", new { id = certificate.certificateId }, certificate);
        }

        // DELETE: api/Certificates/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCertificate(int id)
        {
            var certificate = _certificateRepo.GetById(id);
            if (certificate == null)
            {
                return NotFound();
            }

            _certificateRepo.Delete(id);

            return NoContent();
        }
    }
}