namespace Appointment.Extensions
{
    public static class TodayBreak
    {
        public static DateTime AddDay(this string tdbreak, string today) 
        {
            return DateTime.Parse(today + " " + tdbreak);
        }
    }
}
