namespace Appointment.Extensions
{
    public static class DateTimeExt
    {
        public static bool Contains(this DateTime moment, DateTime start, DateTime end)
        {
            return moment >= start && moment <= end;
        }
    }
}
