namespace EFCore_MVC_Workshop.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeOnly ActivityTime { get; set; }

    }
}
