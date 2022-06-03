using Microsoft.EntityFrameworkCore;

namespace Appointment.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<TimeSlot> TimeSlot { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot[]
            {
                new TimeSlot
                {
                    Id = Guid.Parse("7a44de32-c577-40e8-b638-8059d4d821d4"),
                    Name = "Working Schedule",
                    Start =  "09:00:00 AM",
                    End = "06:00:00 PM"
                },

                new TimeSlot
                {
                    Id = Guid.Parse("7a44de32-c577-40e8-b638-8059d4d821d5"),
                    Name = "Break Schedule",
                    Start = "12:00:00 PM",
                    End = "01:00:00 PM"
                },

            });



            modelBuilder.Entity<Employee>().HasData(new Employee[]
            {
                new Employee{ Id = Guid.Parse("EC450A2D-1675-4199-B742-FEE1BECBBDFB"),
                    Name = "Abdullah",
                    Email = "abdullahrexha09@gmail.com",
                    WorkingScheduleId = Guid.Parse("7a44de32-c577-40e8-b638-8059d4d821d4"),
                    BreakId = Guid.Parse("7a44de32-c577-40e8-b638-8059d4d821d5"),
                }

            });




        }
    }
}
