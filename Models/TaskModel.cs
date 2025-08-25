using AppMetasApi.Models.Base;
using System.Text.Json.Serialization;

namespace AppMetasApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public string? Title { get; set; }
        public bool IsDone { get; set; } = false;
        [JsonIgnore]
        public Goal? Goal { get; set; }
    }
}
