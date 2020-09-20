using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Permission> Create(Permission permission)
        {
            var p = _context.Permissions.Add(permission).Entity;
            await _context.SaveChangesAsync();

            return p;
        }

        public async Task<bool> Delete(int id)
        {
            var p = await Get(id);

            if (p != null)
                _context.Permissions.Remove(p);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Permission> Get(int id)
        {
            var permission = await _context.Permissions.Include(x => x.PermissionType).FirstOrDefaultAsync(x => x.Id == id);
            return permission;
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            var permissions = await _context.Permissions.Include(x => x.PermissionType).ToListAsync();
            return permissions;
        }

        public async Task<bool> Update(Permission permission)
        {
            var currentPermission = await Get(permission.Id);
            if (currentPermission == null)
                return false;
            
            currentPermission.EmployeeName = permission.EmployeeName;
            currentPermission.EmployeeLastName = permission.EmployeeLastName;
            currentPermission.PermissionDate = permission.PermissionDate;
            currentPermission.PermissionTypeId = permission.PermissionTypeId;

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
