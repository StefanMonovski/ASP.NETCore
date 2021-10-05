namespace Taskly.Services.DataTransferObjects
{
    public class LabelDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ColorHex { get; set; }

        public string CreatorId { get; set; }
    }
}
