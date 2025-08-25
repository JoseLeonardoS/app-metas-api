using AppMetasApi.Data;
using AppMetasApi.Interfaces;
using AppMetasApi.Models;
using AppMetasApi.Models.Base;
using AppMetasApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AppMetasApi.Services
{
    public class GoalService : IGoalInterface
    {
        private readonly AppDbContext _context;

        public GoalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Goal>> CheckGoal(CheckGoalDto dto)
        {
            var response = new ResponseModel<Goal>();

            try
            {
                var goal = await _context.Goals.FirstOrDefaultAsync(g => g.Id == dto.Id);

                if(goal == null)
                {
                    response.Message = "Meta não encontrada";
                    return response;
                }

                goal.IsCompleted = dto.IsCompleted;

                _context.Update(goal);
                await _context.SaveChangesAsync();

                response.Data = goal;
                response.Message = "Status de progresso atualizado";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<Goal>> CreateGoal(CreateGoalDto dto)
        {
            var response = new ResponseModel<Goal>();

            try
            {
                var goal = new Goal
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = dto.DueDate
                };

                _context.Goals.Add(goal);
                await _context.SaveChangesAsync();

                response.Data = goal;
                response.Message = "Tarefa criada com sucesso.";
                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<Goal>> DeleteGoal(int id)
        {
            var response = new ResponseModel<Goal>();

            try
            {
                var goal = await _context.Goals.FirstOrDefaultAsync(g => g.Id == id);

                if(goal == null)
                {
                    response.Message = "Tarefa não encontrada.";
                    return response;
                }

                _context.Goals.Remove(goal);
                await _context.SaveChangesAsync();

                response.Data = goal;
                response.Message = "Tarefa deletada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<Goal>> Goal(int id)
        {
            var response = new ResponseModel<Goal>();

            try
            {
                var goal = await _context.Goals.Include(g => g.Tasks).FirstOrDefaultAsync(g => g.Id == id);

                if (goal == null)
                {
                    response.Message = "Tarefa não encontrada.";
                    return response;
                }

                response.Data = goal;
                response.Message = "Tarefa retornada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<Goal>>> Goals()
        {
            var response = new ResponseModel<List<Goal>>();

            try
            {
                var goals = await _context.Goals.Include(g => g.Tasks).ToListAsync();

                if (goals == null || !goals.Any())
                {
                    response.Message = "Nenhuma meta encontrada.";
                    return response;
                }

                response.Data = goals;
                response.Message = "Metas retornadas com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<Goal>> UpdateGoal(UpdateGoalDto dto)
        {
            var response = new ResponseModel<Goal>();

            try
            {
                var goal = await _context.Goals.FirstOrDefaultAsync(g => g.Id == dto.Id);

                if (goal == null)
                {
                    response.Message = "Tarefa não encontrada.";
                    return response;
                }

                goal.Title = dto.Title;
                goal.Description = dto.Description;
                goal.UpdatedAt = DateTime.UtcNow;
                goal.DueDate = dto.DueDate;

                _context.Goals.Update(goal);
                await _context.SaveChangesAsync();

                response.Data = goal;
                response.Message = "Tarefa atualizada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
