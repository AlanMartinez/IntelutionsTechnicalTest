using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Business.Interfaces;
using Domain.Entities;
using Xunit;

namespace UnitTests
{
    public class PermissionBusinessFake : IPermissionBusiness
    {
        private readonly List<Permission> _permissions;
        public PermissionBusinessFake()
        {
            _permissions = new List<Permission>()
            {
                new Permission() { Id = 1,
                    EmployeeLastName = "Parada", EmployeeName="Juan", PermissionTypeId = 1, PermissionDate=new DateTime()},
                new Permission() { Id = 2,
                    EmployeeLastName = "Marmol", EmployeeName="Pedro", PermissionTypeId = 2, PermissionDate=new DateTime()},
                new Permission() { Id = 3,
                    EmployeeLastName = "Ramirez", EmployeeName="Antonio", PermissionTypeId = 3, PermissionDate=new DateTime()},
            };
        }

        public Task<Permission> Create(Permission permission)
        {
            Random rnd = new Random();
            permission.Id = rnd.Next(10,10000);
            _permissions.Add(permission);

            return Task.FromResult<Permission>(permission);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> Get(int id)
        {
            var permissions = _permissions.Where(a => a.Id == id)
            .FirstOrDefault();

            return Task.FromResult<Permission>(permissions);
        }

        public Task<IEnumerable<Permission>> GetAll()
        {
            return Task.FromResult<IEnumerable<Permission>>(_permissions);
        }

        public Task<bool> Update(Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}
