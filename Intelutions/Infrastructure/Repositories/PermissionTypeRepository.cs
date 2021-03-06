﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly AppDbContext _context;

        public PermissionTypeRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PermissionType> Get(int id)
        {
            var permissionType = await _context.PermissionTypes.FirstOrDefaultAsync(x => x.Id == id);
            return permissionType;
        }

        public async Task<IEnumerable<PermissionType>> GetAll()
        {
            var permissionsTypes = await _context.PermissionTypes.ToListAsync();
            return permissionsTypes;
        }
    }
}
