using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.Models
{
    public class TimeSlot
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Start { get; set; }
        
        public string End { get; set; }


    }
}
