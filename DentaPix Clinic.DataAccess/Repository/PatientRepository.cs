using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;

namespace DentaPix_Clinic.DataAccess.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private AppDbContext _db;
        public PatientRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Patient obj)
        {
            var objFromDb = _db.Patients.FirstOrDefault(u => u.PatientId == obj.PatientId);
            if (objFromDb != null)
            {
                objFromDb.FirstName = obj.FirstName;
                objFromDb.LastName = obj.LastName;
                objFromDb.MiddleInitial = obj.MiddleInitial;
                objFromDb.Birthday = obj.Birthday;
                objFromDb.Address = obj.Address;
                objFromDb.PhoneNo = obj.PhoneNo;
                objFromDb.Email = obj.Email;
                objFromDb.Gender = obj.Gender;
                objFromDb.Parent = obj.Parent;
                if (obj.ImageURL != null)
                {
                    objFromDb.ImageURL = obj.ImageURL;
                }
            }

        }

    }
}
