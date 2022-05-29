using Appointment.Dto;

namespace Appointment.Services
{
    public interface IAppointmentService
    {
        object GetAppointment(BookedAppoinmentsDTO dTO);
    }
}
