using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Business.Interfaces
{
    public interface IPermissionBusiness
    {
        Task<Permission> Create(Permission permission);
        Task<bool> Delete(int id);
        Task<IEnumerable<Permission>> GetAll();
        Task<bool> Update(Permission permission);
        Task<Permission> Get(int id);
    }
}
