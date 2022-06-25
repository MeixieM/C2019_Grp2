using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;

namespace DentaPix_Clinic.DataAccess.Repository
{
    public class AppointmentCartRepository : Repository<AppointmentCart>, IAppointmentCartRepository
    {
        private AppDbContext _db;
        public AppointmentCartRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }
}
