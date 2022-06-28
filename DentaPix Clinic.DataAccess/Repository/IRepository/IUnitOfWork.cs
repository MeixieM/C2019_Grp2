namespace DentaPix_Clinic.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        IAppointmentRepository Appointment { get; }
        ITreatmentRepository Treatment { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IAppointmentCartRepository AppointmentCart { get; }
        IOverviewRepository Overview { get; }
        IPaymentRepository Payment { get; }
        void Save();
    }
}
