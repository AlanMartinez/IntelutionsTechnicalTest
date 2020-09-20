using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Business.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionBusiness _permissionBusiness;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionBusiness permissionBusiness, IMapper mapper)
        {
            _permissionBusiness = permissionBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissions = await _permissionBusiness.GetAll();
            var permissionsDTO = _mapper.Map<IEnumerable<PermissionDTO>>(permissions);

            return Ok(permissionsDTO);
        }

        [HttpPost]
        public IActionResult PostPermission(PermissionDTO permissionDTO)
        {
            var permission = _mapper.Map<Permission>(permissionDTO);
            _permissionBusiness.Create(permission);

            return Ok(permission);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePermission(PermissionDTO permissionDTO)
        {
            var permission = _mapper.Map<Permission>(permissionDTO);

            await _permissionBusiness.Update(permission);
            return Ok(permission);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var result = await _permissionBusiness.Delete(id);
            return Ok(result);
        }
    }
}
