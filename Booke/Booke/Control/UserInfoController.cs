using BookStore.BL.Interfaces;
using BookStore.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booke.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;

        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpPost("AddUserInfo")]
        public async Task<IActionResult>
            AddUserInfo(string email, string password)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                return BadRequest("Empty email or password!");
            }

            await _userInfoService.Add(email, password);
            return Ok();
        }

        [HttpGet("GetUserInfo")]
        public async Task<IActionResult>
            GetUserInfo(string email, string password)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                return BadRequest("Empty email or password!");
            }

            var result = await _userInfoService.GetUserInfo(email, password);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
