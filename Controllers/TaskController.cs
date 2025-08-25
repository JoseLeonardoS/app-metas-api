using AppMetasApi.Interfaces;
using AppMetasApi.Models;
using AppMetasApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppMetasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskInterface _taskService;

        public TaskController(ITaskInterface taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> Tasks()
        {
            var tasks = await _taskService.Tasks();
            return Ok(tasks);
        }

        [HttpGet("listar-meta-Id/{goalId}")]
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> TasksByGoalId(int goalId)
        {
            var tasks = await _taskService.TasksByGoalId(goalId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> Task(int id)
        {
            var task = await _taskService.Task(id);
            return Ok(task);
        }

        [HttpPost("criar")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> CreateTask(CreateTaskDto dto)
        {
            var task = await _taskService.CreateTask(dto);
            return Ok(task);
        }

        [HttpPut("check")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> CheckTask(CheckTaskDto dto)
        {
            var task = await _taskService.CheckTask(dto);
            return Ok(task);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> UpdateTask(UpdateTaskDto dto)
        {
            var task = await _taskService.UpdateTask(dto);
            return Ok(task);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> DeleteTask(int id)
        {
            var task = await _taskService.DeleteTask(id);
            return Ok(task);
        }
    }
}
