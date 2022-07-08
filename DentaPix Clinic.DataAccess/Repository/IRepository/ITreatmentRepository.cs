using DentaPix_Clinic.Models;

namespace DentaPix_Clinic.DataAccess.Repository.IRepository
{
    public interface ITreatmentRepository : IRepository<Treatment>
    {
        void Update(Treatment obj);
    }
}