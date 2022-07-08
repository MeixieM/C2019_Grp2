using DentaPix_Clinic.Models;

namespace DentaPix_Clinic.DataAccess.Repository.IRepository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient obj);
    }
}