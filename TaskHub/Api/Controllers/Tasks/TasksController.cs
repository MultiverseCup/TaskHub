using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;
using Api.UseCases.Tasks.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tasks;

/// <summary>
/// Контроллер работы с задачами
/// </summary>
[ApiController]
[Route("tasks")]
public sealed class TasksController : ControllerBase
{
    private readonly ICreateTaskUseCase _createTaskUseCase;
    private readonly IGetTasksUseCase _getTasksUseCase;
    private readonly IGetTaskUseCase _getTaskUseCase;
    private readonly ISetTaskTitleUseCase _setTaskTitleUseCase;
    private readonly IDeleteTaskUseCase _deleteTaskUseCase;
    private readonly IDeleteTasksUseCase _deleteTasksUseCase;

    public TasksController(
        ICreateTaskUseCase createTaskUseCase,
        IGetTasksUseCase getTasksUseCase,
        IGetTaskUseCase getTaskUseCase,
        ISetTaskTitleUseCase setTaskTitleUseCase,
        IDeleteTaskUseCase deleteTaskUseCase,
        IDeleteTasksUseCase deleteTasksUseCase)
    {
        _createTaskUseCase = createTaskUseCase;
        _getTasksUseCase = getTasksUseCase;
        _getTaskUseCase = getTaskUseCase;
        _setTaskTitleUseCase = setTaskTitleUseCase;
        _deleteTaskUseCase = deleteTaskUseCase;
        _deleteTasksUseCase = deleteTasksUseCase;
    }

    /// <summary>
    /// Создать задачу
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TaskResponse>> CreateTaskAsync(
    [FromBody] CreateTaskRequest request,
    CancellationToken cancellationToken)
    {
        var task = await _createTaskUseCase.ExecuteAsync(request.Title, request.CreatedByUserId, cancellationToken);
        return CreatedAtRoute("GetTaskById", new { id = task.Id }, task);
    }

    /// <summary>
    /// Получить все задачи
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<TaskResponse>>> GetAllTasksAsync(CancellationToken cancellationToken)
    {
        var tasks = await _getTasksUseCase.ExecuteAsync(cancellationToken);
        return Ok(tasks);
    }

    /// <summary>
    /// Получить задачу по id
    /// </summary>
    [HttpGet("{id:guid}", Name = "GetTaskById")]
    public async Task<ActionResult<TaskResponse>> GetTaskByIdAsync(
    [FromRoute] Guid id,
    CancellationToken cancellationToken)
    {
        var task = await _getTaskUseCase.ExecuteAsync(id, cancellationToken);
        if (task is null)
            return NotFound();

        return Ok(task);
    }

    /// <summary>
    /// Изменить название задачи
    /// </summary>
    [HttpPut("{id:guid}/title")]
    public async Task<IActionResult> SetTaskTitleAsync(
        [FromRoute] Guid id,
        [FromBody] SetTaskTitleRequest request,
        CancellationToken cancellationToken)
    {
        var updated = await _setTaskTitleUseCase.ExecuteAsync(id, request.Title, cancellationToken);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Удалить задачу по id
    /// </summary>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTaskByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var deleted = await _deleteTaskUseCase.ExecuteAsync(id, cancellationToken);
        if (!deleted)
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Удалить все задачи
    /// </summary>
    [HttpDelete]
    public async Task<IActionResult> DeleteAllTasksAsync(CancellationToken cancellationToken)
    {
        await _deleteTasksUseCase.ExecuteAsync(cancellationToken);
        return NoContent();
    }
}