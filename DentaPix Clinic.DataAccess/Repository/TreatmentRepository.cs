using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;

namespace DentaPix_Clinic.DataAccess.Repository
{
    public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
    {
        private AppDbContext _db;
        public TreatmentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Treatment obj)
        {
            var objFromDb = _db.Treatments.FirstOrDefault(u => u.TreatmentId == obj.TreatmentId);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.TreatmentPrice = obj.TreatmentPrice;

                if (obj.Image != null)
                {
                    objFromDb.Image = obj.Image;
                }
            }

        }

    }
}
