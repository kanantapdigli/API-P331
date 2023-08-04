using Business.DTOs.Common;
using Business.DTOs.Role.Request;
using Business.DTOs.Role.Response;
using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #region Documentation
        /// <summary>
        /// Rolların siyahısı
        /// </summary>
        #endregion
        [HttpGet]
        public async Task<Response<List<RoleDTO>>> GetAllAsync()
        {
            return await _roleService.GetAllAsync();
        }

        #region Documentation
        /// <summary>
        ///  Rol yaratmaq üçün
        /// </summary>
        /// <param name="model"></param>
        #endregion
        [HttpPost]
        public async Task<Response> CreateAsync(RoleCreateDTO model)
        {
            return await _roleService.CreateAsync(model); 
        }
    }
}
