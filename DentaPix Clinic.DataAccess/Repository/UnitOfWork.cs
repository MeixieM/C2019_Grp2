﻿using DentaPix_Clinic.DataAccess.Repository.IRepository;

namespace DentaPix_Clinic.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Doctor = new DoctorRepository(_db);
        }
        public IDoctorRepository Doctor { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}