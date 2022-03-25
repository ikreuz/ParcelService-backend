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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersApplication _customersApplication;

        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region Synchronous Methods

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null) return BadRequest();

            var response = _customersApplication.Insert(customersDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null) return BadRequest();

            var response = _customersApplication.Update(customersDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("delete/{customersId}")]
        public IActionResult Delete(string customersId)
        {
            if (string.IsNullOrEmpty(customersId)) return BadRequest();

            var response = _customersApplication.Delete(customersId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get/{customersId}")]
        public IActionResult Get(string customersId)
        {
            if (string.IsNullOrEmpty(customersId)) return BadRequest();

            var response = _customersApplication.Get(customersId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _customersApplication.GetAll();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region Asynchronous Methods

        [HttpPost("insertAsync{customersDto}")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null) return BadRequest();

            var response = await _customersApplication.InsertAsync(customersDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("updateAsync/{customersDto}")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null) return BadRequest();

            var response = await _customersApplication.UpdateAsync(customersDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("deleteAsync/{customersId}")]
        public async Task<IActionResult> DeleteAsync(string customersId)
        {
            if (string.IsNullOrEmpty(customersId)) return BadRequest();

            var response = await _customersApplication.DeleteAsync(customersId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getAsync/{customersId}")]
        public async Task<IActionResult> GetAsync(string customersId)
        {
            if (string.IsNullOrEmpty(customersId)) return BadRequest();

            var response = await _customersApplication.GetAsync(customersId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getallAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customersApplication.GetAllAsync();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
