using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelService.Application.DTO;
using ParcelService.Application.Interface;
using System.Threading.Tasks;

namespace ParcelService.Services.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesApplication _rolesApplication;

        public RolesController(IRolesApplication rolesApplication)
        {
            _rolesApplication = rolesApplication;
        }

        #region Synchronous Methods

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] RolesDto rolesDto)
        {
            if (rolesDto == null) return BadRequest();

            var response = _rolesApplication.Insert(rolesDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] RolesDto rolesDto)
        {
            if (rolesDto == null) return BadRequest();

            var response = _rolesApplication.Update(rolesDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("delete/{rolesId}")]
        public IActionResult Delete(string rolesId)
        {
            if (string.IsNullOrEmpty(rolesId)) return BadRequest();

            var response = _rolesApplication.Delete(rolesId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get/{rolesId}")]
        public IActionResult Get(string rolesId)
        {
            if (string.IsNullOrEmpty(rolesId)) return BadRequest();

            var response = _rolesApplication.Get(rolesId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _rolesApplication.GetAll();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region Asynchronous Methods

        [HttpPost("insertAsync{rolesDto}")]
        public async Task<IActionResult> InsertAsync([FromBody] RolesDto rolesDto)
        {
            if (rolesDto == null) return BadRequest();

            var response = await _rolesApplication.InsertAsync(rolesDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("updateAsync/{rolesDto}")]
        public async Task<IActionResult> UpdateAsync([FromBody] RolesDto rolesDto)
        {
            if (rolesDto == null) return BadRequest();

            var response = await _rolesApplication.UpdateAsync(rolesDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("deleteAsync/{rolesId}")]
        public async Task<IActionResult> DeleteAsync(string rolesId)
        {
            if (string.IsNullOrEmpty(rolesId)) return BadRequest();

            var response = await _rolesApplication.DeleteAsync(rolesId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getAsync/{rolesId}")]
        public async Task<IActionResult> GetAsync(string rolesId)
        {
            if (string.IsNullOrEmpty(rolesId)) return BadRequest();

            var response = await _rolesApplication.GetAsync(rolesId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getallAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _rolesApplication.GetAllAsync();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
