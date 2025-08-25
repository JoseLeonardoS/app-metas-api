using AppMetasApi.Interfaces;
using AppMetasApi.Models;
using AppMetasApi.Models.Base;
using AppMetasApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppMetasApi.Controllers
{
    [Route("api/metas")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalInterface _goalService;

        public GoalController(IGoalInterface goalService)
        {
            _goalService = goalService;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<ResponseModel<List<Goal>>>> Goals()
        {
            var goals = await _goalService.Goals();
            return Ok(goals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<List<Goal>>>> Goals(int id)
        {
            var goal = await _goalService.Goal(id);
            return Ok(goal);
        }

        [HttpPost("criar")]
        public async Task<ActionResult<ResponseModel<Goal>>> CreateGoal(CreateGoalDto dto)
        {
            var goal = await _goalService.CreateGoal(dto);
            return Ok(goal);
        }

        [HttpPut("check")]
        public async Task<ActionResult<ResponseModel<Goal>>> CheckGoal(CheckGoalDto dto)
        {
            var goal = await _goalService.CheckGoal(dto);
            return Ok(goal);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<ResponseModel<Goal>>> UpdateGoal(UpdateGoalDto dto)
        {
            var goal = await _goalService.UpdateGoal(dto);
            return Ok(goal);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<ResponseModel<Goal>>> DeleteGoal(int id)
        {
            var goal = await _goalService.DeleteGoal(id);
            return Ok(goal);
        }
    }
}
