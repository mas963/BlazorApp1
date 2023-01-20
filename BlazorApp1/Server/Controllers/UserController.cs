using BlazorApp1.Server.Services.Infrastruce;
using BlazorApp1.Server.Services.Services;
using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ServiceResponse<UserLoginResponseDto>> Login(UserLoginRequestDto userRequest)
        {
            return new ServiceResponse<UserLoginResponseDto>()
            {
                Value = await _userService.Login(userRequest.Email, userRequest.Password)
            };
        }

        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDto>>> GetUsers()
        {
            return new ServiceResponse<List<UserDto>>()
            {
                Value = await _userService.GetUsers()
            };
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDto>> CreateUser([FromBody] UserDto user)
        {
            return new ServiceResponse<UserDto>()
            {
                Value = await _userService.CreateUser(user)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDto>> UpdateUser([FromBody] UserDto user)
        {
            return new ServiceResponse<UserDto>()
            {
                Value = await _userService.UpdateUser(user)
            };
        }

        [HttpGet("UserById/{Id}")]
        public async Task<ServiceResponse<UserDto>> GetUserById(Guid Id)
        {
            return new ServiceResponse<UserDto>()
            {
                Value = await _userService.GetUserById(Id)
            };
        }


        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteUser([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await _userService.DeleteUserById(id)
            };
        }
    }
}
