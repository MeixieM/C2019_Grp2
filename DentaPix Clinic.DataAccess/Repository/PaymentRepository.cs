using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;

namespace DentaPix_Clinic.DataAccess.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private AppDbContext _db;
        public PaymentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Payment obj)
        {
            _db.Payments.Update(obj);
        }
    }
}
