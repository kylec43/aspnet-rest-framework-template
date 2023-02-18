    using Microsoft.EntityFrameworkCore;
    using ChatApp.Database.Models;
      
    namespace ChatApp.DataAccess  
    {  
        public class ChatAppDbContext : DbContext
        {  
            public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)  
            {  
            }  
      
            protected override void OnModelCreating(ModelBuilder builder)  
            {  
                base.OnModelCreating(builder);
                builder.Entity<Profile>().ToTable("profile");
            }  
      
            public override int SaveChanges()  
            {  
                ChangeTracker.DetectChanges();  
                return base.SaveChanges();  
            }  
        }  
    }  
