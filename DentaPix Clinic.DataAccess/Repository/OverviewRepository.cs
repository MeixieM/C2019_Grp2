﻿using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;

namespace DentaPix_Clinic.DataAccess.Repository
{
    public class OverviewRepository : Repository<Overview>, IOverviewRepository
    {
        private AppDbContext _db;

        public OverviewRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Overview obj)
        {
            _db.Overviews.Update(obj);
        }
    }
}