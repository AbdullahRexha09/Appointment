using Appointment.Dto;
using Appointment.Models;
using Appointment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Appointment.Controllers
{
    [ApiController]
    [Route("appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService) 
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("available")]
        public IActionResult Get([FromBody] BookedAppoinmentsDTO modelBokkeed) 
        {
            try {

                var appointment = _appointmentService.GetAppointment(modelBokkeed);
                return Ok(appointment);

            }
            catch (Exception ex)
            {
                return BadRequest(new 
                {
                    Error = ex.Message
                });            
            }

        }

    }
}
