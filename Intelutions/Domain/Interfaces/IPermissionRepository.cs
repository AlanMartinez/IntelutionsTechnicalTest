using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPermissionRepository
    {
        Task<Permission> Create(Permission permission);
        Task<bool> Delete(int id);
        Task<IEnumerable<Permission>> GetAll();
        Task<bool> Update(Permission permission);
        Task<Permission> Get(int id);
    }
}
