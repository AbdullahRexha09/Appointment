using Appointment.Models;

namespace Appointment.Extensions
{
    public static class ScheduleListValidator
    {
        public static List<TimeSlot> Validator(this List<TimeSlot> list) 
        {
            // ordering schedule

            return list.OrderBy(t => DateTime.Parse(t.Start)).ToList();

        }

    }
}
