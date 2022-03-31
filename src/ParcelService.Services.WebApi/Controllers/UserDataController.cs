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
    public class UserDataController : ControllerBase
    {
        private readonly IUserDataApplication _userDataApplication;
        public UserDataController(IUserDataApplication userDataApplication)
        {
            _userDataApplication = userDataApplication;
        }


        #region Synchronous Methods

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] UserDataDto userDataDto)
        {
            if (userDataDto == null) return BadRequest();

            var response = _userDataApplication.Insert(userDataDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UserDataDto userDataDto)
        {
            if (userDataDto == null) return BadRequest();

            var response = _userDataApplication.Update(userDataDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("delete/{userDataId}")]
        public IActionResult Delete(string userDataId)
        {
            if (string.IsNullOrEmpty(userDataId)) return BadRequest();

            var response = _userDataApplication.Delete(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get/{userDataId}")]
        public IActionResult Get(string userDataId)
        {
            if (string.IsNullOrEmpty(userDataId)) return BadRequest();

            var response = _userDataApplication.Get(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _userDataApplication.GetAll();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region Asynchronous Methods

        [HttpPost("insertAsync{userDataDto}")]
        public async Task<IActionResult> InsertAsync([FromBody] UserDataDto userDataDto)
        {
            if (userDataDto == null) return BadRequest();

            var response = await _userDataApplication.InsertAsync(userDataDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("updateAsync/{userDataDto}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UserDataDto userDataDto)
        {
            if (userDataDto == null) return BadRequest();

            var response = await _userDataApplication.UpdateAsync(userDataDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("deleteAsync/{userDataId}")]
        public async Task<IActionResult> DeleteAsync(string userDataId)
        {
            if (string.IsNullOrEmpty(userDataId)) return BadRequest();

            var response = await _userDataApplication.DeleteAsync(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getAsync/{userDataId}")]
        public async Task<IActionResult> GetAsync(string userDataId)
        {
            if (string.IsNullOrEmpty(userDataId)) return BadRequest();

            var response = await _userDataApplication.GetAsync(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getallAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _userDataApplication.GetAllAsync();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
