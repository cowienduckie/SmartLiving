﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _context;

        public DeviceRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.Devices.Any(d => !d.IsDelete && d.Id == id);
        }

        public IEnumerable<Device> GetAll()
        {
            return _context.Devices.Where(d => !d.IsDelete).AsNoTracking().ToList();
        }

        public Device GetById(int id)
        {
            return _context.Devices.FirstOrDefault(d => !d.IsDelete && d.Id == id);
        }

        public Device Create(Device entity)
        {
            _context.Devices.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(Device entity)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Devices.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!IsExist(id)) return false;

            var device = _context.Devices.First(d => !d.IsDelete && d.Id == id);

            device.IsDelete = true;
            device.LastModified = DateTime.Now;

            _context.Devices.Update(device);
            _context.SaveChanges();
            return true;
        }
    }
}