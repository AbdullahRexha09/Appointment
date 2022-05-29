using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.Models
{
    public class Employee
    {

        public Guid Id { get; set; }

        public string? Name { get; set; }    

        public string? Email { get; set; }

        public Guid? WorkingScheduleId { get; set; }


        [ForeignKey("WorkingScheduleId")]
        public virtual TimeSlot? WorkingSchedule { get; set; }

        public Guid? BreakId { get; set; }

        [ForeignKey("BreakId")]

        public virtual TimeSlot? Break { get; set; }
    }
}
