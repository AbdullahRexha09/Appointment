using Appointment.Dto;

namespace Appointment.Services
{
    public interface IAppointmentService
    {
        List<Response> GetAppointment(BookedAppoinmentsDTO dTO);
    }
}
