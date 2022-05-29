using Appointment.Common;
using Appointment.Dto;
using Appointment.Extensions;
using Appointment.Models;
using System.Collections.Generic;

namespace Appointment.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;


        public AppointmentService(AppDbContext context) 
        {
            _context = context;
        }

        public object GetAppointment(BookedAppoinmentsDTO bookedDto)
        {
            var employee = _context.Employee.FirstOrDefault(emp => emp.Id == bookedDto.EmployeeId);

            var timeSlots = Mappings.DtosToEntities(bookedDto.TimeSlot).ToList();

            var todayDate = DateTime.Parse(timeSlots[0].Start).ToString("yyyy-MM-dd");

            var testString = CreateTimes(employee.WorkingSchedule.Start, employee.WorkingSchedule.End, employee.Break, timeSlots, todayDate);

            var availableTimeSlot = new List<Response>();
            
            if(testString.Count() % 2 != 0) 
            {
                return null; //an error in the code 
            }

            for (int i = 0; i < testString.Count(); i += 2) 
            {
                if (testString[i] != testString[i + 1]
                    && DateTime.Parse(testString[i]) != DateTime.Parse(todayDate + " " + employee.Break.Start)
                    && DateTime.Parse(testString[i + 1]) != DateTime.Parse(todayDate + " " + employee.Break.End)) { 

                availableTimeSlot.Add(new Appointment.Dto.Response { Start = testString[i], End = testString[i + 1] });
                
                }
            }

            return availableTimeSlot; 

        }
        public List<string> CreateTimes(string start, string end, TimeSlot breakT, List<TimeSlot> scheduleTs, string todayDate)
        {

            List<DateTime> times = new List<DateTime>();


            // Start of the day
            var startT = DateTime.Parse(todayDate + " " + start);

            // ENd of the day
            var endT = DateTime.Parse(todayDate + " " + end);

            times.Add(startT);


            foreach (var timeSlot in scheduleTs.Validator()) 
            {
                var lastElement = scheduleTs.LastOrDefault();


                var timeSlotDT = DateTime.Parse(timeSlot.Start);

                
                if (timeSlotDT.Contains(startT, endT) 
                    && DateTime.Parse(timeSlot.Start).Hour >= startT.Hour
                    && DateTime.Parse(timeSlot.End).Hour <= endT.Hour
                    ) 
                {
                    if ((startT - timeSlotDT) == TimeSpan.Zero)
                    {
                        if (times.Any()) 
                        {
                            times = new List<DateTime>();
                        }

                        times.Add(DateTime.Parse(timeSlot.End));
                    }

                    else
                    {
                        times.Add(DateTime.Parse(timeSlot.Start));
                        times.Add(DateTime.Parse(timeSlot.End));

                    }
                }

                else 
                {
                    throw new Exception("Outside the working schedule!!");
                }

                if (timeSlot == lastElement) 
                {
                    times.Add(endT);
                }
            }

            var updatedString = new List<string>();


            times.Add(breakT.Start.AddDay(todayDate));
            times.Add(breakT.End.AddDay(todayDate));

            times.OrderBy(t => t.Hour).ToList().ForEach(a => updatedString.Add(a.ToString()));

            return updatedString;        


        }



    }
}
