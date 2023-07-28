using Microsoft.EntityFrameworkCore;

namespace UmbracoFood.Data
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {
        }
        #region DbSet
        public DbSet<Reservation>? Reservations { get; set; }
        public DbSet<ContactUs>? ContactUss { get; set; }
        public DbSet<CommentStories>? CommentStoriess { get; set; }
        public DbSet<Stories>? Storiess { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
