using DentaPix_Clinic.DataAccess.Repository.IRepository;

namespace DentaPix_Clinic.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Doctor = new DoctorRepository(_db);
            Patient = new PatientRepository(_db);
            Appointment = new AppointmentRepository(_db);
            Treatment = new TreatmentRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            AppointmentCart = new AppointmentCartRepository(_db);
        }
        public IDoctorRepository Doctor { get; private set; }
        public IPatientRepository Patient { get; private set; }
        public IAppointmentRepository Appointment { get; private set; }
        public ITreatmentRepository Treatment { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IAppointmentCartRepository AppointmentCart { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
