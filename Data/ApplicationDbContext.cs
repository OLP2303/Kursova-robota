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

            // ��'���� �� EventAndUser �� Event
            builder.Entity<EventAndUser>()
                .HasOne(eu => eu.Event)
                .WithMany(e => e.EventAndUsers)
                .HasForeignKey(eu => eu.EventId)
                .OnDelete(DeleteBehavior.Cascade);  // ���������, �� ���� ��� �������� ��䳿

            // ��'���� �� EventAndUser �� ApplicationUser
            builder.Entity<EventAndUser>()
                .HasOne(eu => eu.User)
                .WithMany()  // �� ��������� ��������� ��'���� ��� User
                .HasForeignKey(eu => eu.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // ���������, �� ���� ��� �������� �����������
        }
     
    }
}