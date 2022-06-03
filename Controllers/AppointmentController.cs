using Appointment.Dto;
using Appointment.Extensions;
using Appointment.Models;
using Appointment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Appointment.Controllers
{
    [ApiController]
    [Route("appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(IAppointmentService appointmentService, ILogger<AppointmentController> logger) 
        {
            _appointmentService = appointmentService;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into AppointmentController");
        }

        [HttpPost("available")]
        public object Post([FromBody] BookedAppoinmentsDTO modelBokkeed) 
        {
            //TODO create a generic method for logging
            _logger.LogInformation(new 
            {
                Name = "Dto Object",
                Object = modelBokkeed.SerializeObject()
            }.ToString());

            try
            {

                var appointment = _appointmentService.GetAppointment(modelBokkeed);

                _logger.LogInformation(new
                {
                    Name = "Response Object",
                    Object = appointment.SerializeObject()
                }.ToString());


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
