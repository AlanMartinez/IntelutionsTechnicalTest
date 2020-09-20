using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Business
{
    public class PermissionTypeBusiness : IPermissionTypeBusiness
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public PermissionTypeBusiness(IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }
        public async Task<IEnumerable<PermissionType>> GetAll()
        {
            return await _permissionTypeRepository.GetAll();
        }
    }
}
