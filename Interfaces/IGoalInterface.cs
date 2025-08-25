using AppMetasApi.Models;
using AppMetasApi.Models.Base;
using AppMetasApi.Models.Dtos;

namespace AppMetasApi.Interfaces
{
    public interface IGoalInterface
    {
        public Task<ResponseModel<List<Goal>>> Goals();
        public Task<ResponseModel<Goal>> Goal(int id);
        public Task<ResponseModel<Goal>> CheckGoal(CheckGoalDto dto);
        public Task<ResponseModel<Goal>> CreateGoal(CreateGoalDto dto);
        public Task<ResponseModel<Goal>> UpdateGoal(UpdateGoalDto dto);
        public Task<ResponseModel<Goal>> DeleteGoal(int id);
    }
}
