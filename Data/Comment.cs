using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;


        [Range(1, 5)]
        public int Rating { get; set; }

        public Event Event { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;
    }
}
