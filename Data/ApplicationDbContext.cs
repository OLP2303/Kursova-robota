using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<EventAndUser> EventsAndUsers { get; set; } = default!;
        public DbSet<Comment>Comments { get; set; } = default!;
        public DbSet<Notification> Notifications { get; set; }=default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Зв'язок між EventAndUser та Event
            builder.Entity<EventAndUser>()
                .HasOne(eu => eu.Event)
                .WithMany(e => e.EventAndUsers)
                .HasForeignKey(eu => eu.EventId)
                .OnDelete(DeleteBehavior.Cascade);  // Визначаємо, що буде при видаленні події

            // Зв'язок між EventAndUser та ApplicationUser
            builder.Entity<EventAndUser>()
                .HasOne(eu => eu.User)
                .WithMany()  // Не визначаємо зворотний зв'язок для User
                .HasForeignKey(eu => eu.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // Визначаємо, що буде при видаленні користувача
        }
     
    }
}