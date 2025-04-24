using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETAP.Application.DTOs.Activities;
using ETAP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _activityService.GetAllAsync();
            return Ok(activities);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var activity = await _activityService.GetByIdAsync(id);
            return activity is null ? NotFound() : Ok(activity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateActivityRequest request)
        {
            await _activityService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.OrganizerId }, request); // örnek CreatedAt
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _activityService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateActivityRequest request)
        {
            if (id != request.Id)
                return BadRequest("URL'deki ID ile body'deki ID uyuşmuyor.");

            await _activityService.UpdateAsync(request);
            return NoContent();
        }
    }
}