using WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IServiceManager _serviceManager;

        public AppointmentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> Get()
        {
            return Ok(await _serviceManager.AppointmentService.GetAllAsync<Appointment>());
        }

        // GET api/Appointment/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> Get(int id)
        {
            try
            {
                return Ok(await _serviceManager.AppointmentService.GetByIdAsync<Appointment>(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/Appointment
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AppointmentDTO appointmentDto)
        {
            try
            {
                return Ok(await _serviceManager.AppointmentService.CreateAppointmentAsync(appointmentDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/Appointment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AppointmentDTO appointmentDto)
        {
            try
            {
                await _serviceManager.AppointmentService.UpdateAppointmentByIdAsync(id, appointmentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _serviceManager.AppointmentService.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
