using WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IServiceManager _serviceManager;

        public PatientController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Get()
        {
            return Ok(await _serviceManager.PatientService.GetAllAsync<Patient>());
        }

        // GET api/Patient/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            try
            {
                return Ok(await _serviceManager.PatientService.GetByIdAsync<Patient>(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/Patient
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] PatientDTO patientDto)
        {
            try
            {
                return Ok(await _serviceManager.PatientService.CreateAsync<PatientDTO>(patientDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/Patient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PatientDTO patientDto)
        {
            try
            {
                await _serviceManager.PatientService.UpdateByIdAsync<PatientDTO>(id, patientDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/Patient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _serviceManager.PatientService.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
