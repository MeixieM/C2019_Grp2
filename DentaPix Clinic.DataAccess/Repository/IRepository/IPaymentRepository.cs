using DentaPix_Clinic.Models;

namespace DentaPix_Clinic.DataAccess.Repository.IRepository
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        void Update(Payment obj);
    }
}