using AppMetasApi.Models;
using AppMetasApi.Models.Dtos;

namespace AppMetasApi.Interfaces
{
    public interface ITaskInterface
    {
        public Task<ResponseModel<List<TaskModel>>> Tasks();
        public Task<ResponseModel<List<TaskModel>>> TasksByGoalId(int goalId);
        public Task<ResponseModel<TaskModel>> Task(int id);
        public Task<ResponseModel<TaskModel>> CreateTask(CreateTaskDto dto);
        public Task<ResponseModel<TaskModel>> UpdateTask(UpdateTaskDto tsk);
        public Task<ResponseModel<TaskModel>> DeleteTask(int id);
        public Task<ResponseModel<TaskModel>> CheckTask(CheckTaskDto dto);
    }
}
