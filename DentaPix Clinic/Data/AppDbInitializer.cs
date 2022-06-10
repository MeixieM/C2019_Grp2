using DentaPix_Clinic.Models;

namespace DentaPix_Clinic.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Treatment
                if (!context.Treatments.Any())
                {
                    context.Treatments.AddRange(new List<Treatment>()
                    {
                        new Treatment()
                        {
                            ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRYMbo_4jzmaX1ErMcuWzqkYeyqM_FmcUHrdbOcI1tXfRL1LUmVLjBekQgRiOW18l6aZ4&usqp=CAU",
                            Name = "Teet Whitening",
                            Description = "This is a description of the first treatment"
                        },
                        new Treatment()
                        {
                            ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRYMbo_4jzmaX1ErMcuWzqkYeyqM_FmcUHrdbOcI1tXfRL1LUmVLjBekQgRiOW18l6aZ4&usqp=CAU",
                            Name = "Teet Whitening 1",
                            Description = "This is a description of the second treatment"
                        }
                    });
                    context.SaveChanges();

                }
                //Appointment
                if (!context.Appointments.Any())
                {

                }
                //Doctor
                if (!context.Doctors.Any())
                {
                    context.Doctors.AddRange(new List<Doctor>()
                    {
                        new Doctor()
                        {
                            ProfilePictureURL = "https://stpaulsdental.com/assets/images/general/james.jpg",
                            FullName = "Joe Mama",
                            Career = "first best",
                            Interest = "Walking"

                        },
                        new Doctor()
                        {
                            ProfilePictureURL = "https://stpaulsdental.com/assets/images/general/james.jpg",
                            FullName = "Joe Mama",
                            Career = "Best Dentist in the World",
                            Interest = "Walking"
                        }
                    });
                    context.SaveChanges();
                }
                //Patient
                if (!context.Patients.Any())
                {

                }
                //Patient & Appointment
                if (!context.Patients_Appointments.Any())
                {

                }
                //Payment
                if (!context.Payments.Any())
                {

                }

            }
        }
    }
}
