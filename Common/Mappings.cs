using Appointment.Dto;
using Appointment.Models;

namespace Appointment.Common
{
    public static class Mappings
    {
        public static TimeSlot DtoToEntity(TimeSlotDTO dTO) 
        {
            var entity = new TimeSlot();

            entity.Start = dTO.Start;
            entity.End = dTO.End;

            return entity;
        }

        public static IEnumerable<TimeSlot> DtosToEntities(IEnumerable<TimeSlotDTO> dtos) 
        {
            if (dtos == null) 
            {
                return Enumerable.Empty<TimeSlot>();
            }

            return dtos.Select(DtoToEntity);
        
        }
    }
}
