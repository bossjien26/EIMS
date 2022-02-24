using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Entities;

namespace DbEntity
{
    public class DbContextEntity : DbContext
    {
        public IDbContextTransaction _transaction;
        public DbContextEntity(DbContextOptions<DbContextEntity> options)
        : base(options) { }

        
        #region user

        public DbSet<User> Users { get; set; }

        public DbSet<UserDetail> UserDetails { get; set; }

        #endregion

        public async void BeginTransaction()
        {
            _transaction = await Database.BeginTransactionAsync();
        }

        public async void Commit()
        {
            try
            {
                await SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public async void Rollback()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
            modelBuilder.Entity<User>().Property(d => d.CreateAt).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(d => d.UpdateAt).ValueGeneratedOnAddOrUpdate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}