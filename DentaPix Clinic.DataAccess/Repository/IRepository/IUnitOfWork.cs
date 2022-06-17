namespace DentaPix_Clinic.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        void Save();
    }
}
