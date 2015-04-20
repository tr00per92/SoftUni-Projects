namespace BugTracker.RestServices.Models
{
    public class FilterInputModel
    {
        public string Keyword { get; set; }

        public string Statuses { get; set; }

        public string Author { get; set; }
    }
}