namespace Taskly.Data.Models
{
    public class LabelNote : BaseModel
    {
        public int LabelId { get; set; }
        public Label Label { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}
