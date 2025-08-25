using AppMetasApi.Data;
using AppMetasApi.Interfaces;
using AppMetasApi.Models;
using AppMetasApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AppMetasApi.Services
{
    public class TaskService : ITaskInterface
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;            
        }

        public async Task<ResponseModel<TaskModel>> CheckTask(CheckTaskDto dto)
        {
            var response = new ResponseModel<TaskModel>();

            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == dto.Id);

                if (task == null)
                {
                    response.Message = "Tarefa não encontrada";
                    return response;
                }

                task.IsDone = dto.IsDone;

                _context.Update(task);
                await _context.SaveChangesAsync();
                response.Data = task;
                response.Message = "Status de tarefa atualizado";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskModel>> CreateTask(CreateTaskDto dto)
        {
            var response = new ResponseModel<TaskModel>();

            try
            {
                var goal = await _context.Goals.FirstOrDefaultAsync(t => t.Id == dto.GoalId);

                if(goal == null)
                {
                    response.Message = "Não foi possível criar a tarefa";
                    return response;
                }

                var task = new TaskModel
                {
                    GoalId = dto.GoalId,
                    Title = dto.Title
                };

                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();

                response.Data = task;
                response.Message = "Tarefa criada com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskModel>> DeleteTask(int id)
        {
            var response = new ResponseModel<TaskModel>();

            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

                if (task == null)
                {
                    response.Message = "Tarefa não encontrada";
                    return response;
                }

                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                
                response.Data = task;
                response.Message = "Tarefa deletada com sucesso";
                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskModel>> Task(int id)
        {
            var response = new ResponseModel<TaskModel>();

            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
                
                if (task == null)
                {
                    response.Message = "Tarefa não encontrada";
                    return response;
                }

                response.Data = task;
                response.Message = "Tarefa encontrada";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> Tasks()
        {
            var response = new ResponseModel<List<TaskModel>>();

            try
            {
                var tasks = await _context.Tasks.ToListAsync();

                if (tasks == null || !tasks.Any())
                {
                    response.Message = "Nenhuma tarefa encontrada";
                    return response;
                }

                response.Data = tasks;
                response.Message = "Tarefas retornadas com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> TasksByGoalId(int goalId)
        {
            var response = new ResponseModel<List<TaskModel>>();

            try
            {
                var tasks = await _context.Tasks.Where(t=>t.GoalId == goalId).ToListAsync();

                if(tasks == null || !tasks.Any())
                {
                    response.Message = "Tarefas não encontradas";
                    return response;
                }

                response.Data = tasks;
                response.Message = "Tarefas listadas com sucesso";
                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskModel>> UpdateTask(UpdateTaskDto tsk)
        {
            var response = new ResponseModel<TaskModel>();
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == tsk.Id);

                if (task == null)
                {
                    response.Message = "Tarefa não encontrada";
                    return response;
                }

                task.Title = tsk.Title;

                _context.Update(task);
                await _context.SaveChangesAsync();

                response.Data = task;
                response.Message = "Tarefa atualizada com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
