namespace prakt7_Leshukov.Models
{
    public class EventPatch
    {
        public string? Title { get; set; }
        public string? Location { get; set; }
        public DateTime? EventDate { get; set; }
        public decimal? TicketPrice { get; set; }
        public bool? IsActive { get; set; }
    }
}
