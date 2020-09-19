using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPermissionTypeRepository
    {
        Task<IEnumerable<PermissionType>> GetAll();
    }
}
