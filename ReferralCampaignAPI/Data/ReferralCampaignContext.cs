using Microsoft.EntityFrameworkCore;

namespace ReferralCampaignAPI.Models
{
    public class ReferralCampaignContext : DbContext
    {
        public ReferralCampaignContext(DbContextOptions<ReferralCampaignContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id); 
                entity.Property(e => e.ReferralCode).IsRequired(); 
                entity.Property(e => e.Name).IsRequired(); 
                entity.Property(e => e.ReferralCount).HasDefaultValue(0); 
                entity.Property(e => e.TotalRevenue).HasColumnType("decimal(18,2)"); 
            });

            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id); 
                entity.Property(u => u.FirstName).IsRequired();
                entity.Property(u => u.LastName).IsRequired();
                entity.Property(u => u.UserId).IsRequired();
                entity.Property(u => u.MoneySpent).HasColumnType("decimal(18,2)");

              
                entity.HasOne(u => u.Employee)
                      .WithMany() 
                      .HasForeignKey(u => u.EmployeeId) 
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
