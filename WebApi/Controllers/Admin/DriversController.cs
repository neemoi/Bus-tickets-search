﻿using Application.Services.DtoModels.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repository.Admin;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class DriversController : ControllerBase
    {
        private readonly DriverRepository _controller;

        public DriversController(DriverRepository repository)
        {
            _controller = repository;
        }

        [HttpGet("api/Driver")]
        public async Task<IActionResult> GetAllDriverAsync()
        {
            return Ok(await _controller.GetAllDriverAsync());
        }

        [HttpGet("api/Driver/{id}")]
        public async Task<IActionResult> GetByIdDriverAsync(uint id)
        {
            return Ok(await _controller.GetByIdDriverAsync(id));
        }

        [HttpPost("api/Driver")]
        public async Task<IActionResult> CreatNewDriverAsync([FromQuery]DriverDto model)
        {
            return Ok(await _controller.CreateDriverAsync(model));
        }

        [HttpPut("api/Driver/{id}")]
        public async Task<IActionResult> EditDriverAsync(uint id, DriverDto model)
        {
            return Ok(await _controller.EditDriverAsync(id, model));
        }

        [HttpDelete("api/Driver/{id}")]
        public async Task<IActionResult> DeleteDriverByIdAsync(uint id)
        {
            return Ok(await _controller.DeleteDriverByIdAsync(id));
        }
    }
}