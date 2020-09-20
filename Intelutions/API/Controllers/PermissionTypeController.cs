using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeBusiness _permissionTypeBusiness;
        private readonly IMapper _mapper;

        public PermissionTypeController(IPermissionTypeBusiness permissionTypeBusiness, IMapper mapper)
        {
            _permissionTypeBusiness = permissionTypeBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissionsTypes = await _permissionTypeBusiness.GetAll();
            var selectedValuesDTO = _mapper.Map<IEnumerable<SelectedValuesDTO>>(permissionsTypes);

            return Ok(selectedValuesDTO);
        }
    }
}
