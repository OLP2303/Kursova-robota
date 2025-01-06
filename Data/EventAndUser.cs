namespace BlazorApp2.Data
{
    public class EventAndUser
    {
        public int Id { get; set; }

        // Зовнішній ключ для події
        public int EventId { get; set; }
        public Event Event { get; set; } = default!;  // Навігаційна властивість

        // Зовнішній ключ для користувача
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = default!;  // Навігаційна властивість
    }
}