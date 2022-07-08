using DentaPix_Clinic.Models;

namespace DentaPix_Clinic.DataAccess.Repository.IRepository
{
    public interface IOverviewRepository : IRepository<Overview>
    {
        void Update(Overview obj);
    }
}