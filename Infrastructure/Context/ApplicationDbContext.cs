using Domain;
using Domain.Vote;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "clone_app";
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public ApplicationDbContext()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Friendship> Friendships { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbSet<CommentVote> CommentVotes { get; set; }
        public DbSet<PostVote> PostVotes { get; set; }

        public DbSet<StoryVote> StoryVotes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=instagram_clone_db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {

            var addedEntites = ChangeTracker.Entries()
                                    .Where(i => i.State == EntityState.Added)
                                    .Select(i => (BaseEntity)i.Entity);
            var updatedEntites = ChangeTracker.Entries()
                .Where(i=>i.State ==EntityState.Modified)
                .Select(i => (BaseEntity)i.Entity);

            PrepareAddedEntities(addedEntites);
            PrepareUpdatedEntities(updatedEntites);
        }

        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.CreatedAt == DateTime.MinValue)
                    entity.CreatedAt = DateTime.Now;
            }
        }
        private void PrepareUpdatedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var item in entities)
            {
                if (item.UpdatedAt == DateTime.MinValue)
                    item.UpdatedAt = DateTime.Now;
            }
        }


    }
}
