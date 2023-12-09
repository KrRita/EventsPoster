namespace EventsPoster.Service.Controllers.Entities
{
    public class UpdateEventRequest
    {
        public int TypeEventId;
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public int AgeViewer { get; set; }

    }
}
