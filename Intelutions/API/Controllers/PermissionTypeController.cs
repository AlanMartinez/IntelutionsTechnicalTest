using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeBusiness _permissionTypeBusiness;

        public PermissionTypeController(IPermissionTypeBusiness permissionTypeBusiness)
        {
            _permissionTypeBusiness = permissionTypeBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissionsTypes = await _permissionTypeBusiness.GetAll();

            return Ok(permissionsTypes);
        }
    }
}
