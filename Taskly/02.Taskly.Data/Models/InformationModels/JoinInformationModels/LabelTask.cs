namespace Taskly.Data.Models
{
    public class LabelTask : BaseModel
    {
        public int LabelId { get; set; }
        public Label Label { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
