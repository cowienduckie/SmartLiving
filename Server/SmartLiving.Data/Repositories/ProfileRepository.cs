using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataContext _context;

        public ProfileRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.Profiles.Any(p => !p.IsDelete && p.Id == id);
        }

        public IEnumerable<Profile> GetAll()
        {
            return _context.Profiles.Where(p => !p.IsDelete).AsNoTracking().ToList();
        }

        public Profile GetById(int id)
        {
            return _context.Profiles.FirstOrDefault(p => !p.IsDelete && p.Id == id);
        }

        public Profile Create(Profile entity)
        {
            _context.Profiles.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(Profile entity)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Profiles.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!IsExist(id)) return false;

            var profile = _context.Profiles.First(p => !p.IsDelete && p.Id == id);

            profile.IsDelete = true;
            profile.LastModified = DateTime.Now;

            _context.Profiles.Update(profile);
            _context.SaveChanges();
            return true;
        }
    }
}