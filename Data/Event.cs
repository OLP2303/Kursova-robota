namespace BlazorApp2.Data
{
    public class Event
    {
        public int Id { get; set; } // Ідентифікатор події
        public string Name { get; set; } = string.Empty; // Назва події
        public string Description { get; set; } = string.Empty; // Опис події
        public DateTime Date { get; set; } = DateTime.Today;// Дата події
        public string Location { get; set; } = string.Empty; // Місце проведення
        public string IDOrganiser { get; set; } = string.Empty;
        public byte[]? EventPicture { get; set; }
        public ICollection<EventAndUser> EventAndUsers { get; set; } = new List<EventAndUser>();
       
    }
}
