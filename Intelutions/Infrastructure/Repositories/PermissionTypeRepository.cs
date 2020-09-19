using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly AppDbContext _context;

        public PermissionTypeRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PermissionType>> GetAll()
        {
            var permissionsTypes = await _context.PermissionTypes.ToListAsync();
            return permissionsTypes;
        }
    }
}
