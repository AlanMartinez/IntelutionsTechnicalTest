using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Business.Interfaces
{
    public interface IPermissionTypeBusiness
    {
        Task<IEnumerable<PermissionType>> GetAll();
    }
}
