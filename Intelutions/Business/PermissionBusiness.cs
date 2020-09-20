using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Business
{
    public class PermissionBusiness : IPermissionBusiness
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public PermissionBusiness(IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionRepository = permissionRepository;
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task<Permission> Create(Permission permission)
        {
            var permissionType = await _permissionTypeRepository.Get((int)permission.PermissionTypeId);
            if (permissionType == null)
                throw new Exception("El tipo de permiso no existe");

            return await _permissionRepository.Create(permission);
        }

        public async Task<bool> Delete(int id)
        {
            return await _permissionRepository.Delete(id);
        }

        public async Task<Permission> Get(int id)
        {
            return await _permissionRepository.Get(id);
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            return await _permissionRepository.GetAll();
        }

        public async Task<bool> Update(Permission permission)
        {
            return await _permissionRepository.Update(permission);
        }
    }
}
