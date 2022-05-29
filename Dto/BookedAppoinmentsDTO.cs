
using FluentValidation;

namespace Appointment.Dto
{
    public class BookedAppoinmentsDTO
    {
        public Guid EmployeeId { get; set; }

        public TimeSlotDTO[] TimeSlot { get; set; }

    }

    public class TimeSlotDTO
    {
        public string Start { get; set; }
        public string End { get; set; }
    }

    public class BookedAppoinmentsDTOValidator : AbstractValidator<BookedAppoinmentsDTO>
    {

        public BookedAppoinmentsDTOValidator()
        {
            RuleFor(d => d.EmployeeId)
                .NotNull()
                .NotEmpty().WithMessage("Please provide a correct UUID");

            RuleFor
                (d => d.TimeSlot).NotNull();

        }
    }

    public class TimeSlotDTOValidator : AbstractValidator<TimeSlotDTO>
    {
        public TimeSlotDTOValidator()
        {
            RuleFor(d => d.Start).NotNull().NotEmpty().WithMessage("Start time is not correct");
            RuleFor(d => d.End).NotNull().NotEmpty().WithMessage("End time is not correct");
        }

    }



}
