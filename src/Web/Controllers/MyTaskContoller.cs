using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MyTaskController : ControllerBase
{
    private readonly IMyTaskRepository _taskRepository;

    public MyTaskController(IMyTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskRepository.GetAllAsync();
        return Ok(tasks);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] MyTask task)
    {
        await _taskRepository.AddAsync(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(Guid id, [FromBody] MyTask task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        await _taskRepository.UpdateAsync(task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        await _taskRepository.DeleteAsync(id);
        return NoContent();
    }

}

