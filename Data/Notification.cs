namespace BlazorApp2.Data
{
    public class Notification
    {

        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Date {  get; set; }= DateTime.Now;
        public Event Event { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;
    }
}
