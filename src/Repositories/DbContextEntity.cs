using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Entities;
using System;

namespace DbEntity
{
    public class DbContextEntity : DbContext
    {
        public IDbContextTransaction _transaction;
        public DbContextEntity(DbContextOptions<DbContextEntity> options) : base(options) { }

        #region user

        public DbSet<User> Users { get; set; }

        public DbSet<UserDetail> UserDetails { get; set; }

        #endregion

        #region Order

        public DbSet<OrderInfo> OrderInfos { get; set; }

        public DbSet<OrderItem> OrderItemDetails { get; set; }

        #endregion

        #region Item  

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Item> Items { get; set; }

        #endregion

        #region Company

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientContact> ClientContacts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<SupplierContact> SupplierContacts { get; set; }

        #endregion

        #region  Other

        public DbSet<Currency> Currencies { get; set; }

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

            modelBuilder.Entity<User>().Property(d => d.CreateAt).HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(d => d.UpdateAt).HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<OrderInfo>().Property(d => d.CreateAt).HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderInfo>().Property(d => d.UpdateAt).HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<OrderItem>().Property(d => d.CreateAt).HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderItem>().Property(d => d.UpdateAt).HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<Item>().Property(d => d.CreateAt).HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Item>().Property(d => d.UpdateAt).HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<Supplier>().Property(d => d.CreateAt).HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Supplier>().Property(d => d.UpdateAt).HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<SupplierContact>().Property(d => d.CreateAt).HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SupplierContact>().Property(d => d.UpdateAt).HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<Client>().Property(d => d.CreateAt).HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Client>().Property(d => d.UpdateAt).HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<ClientContact>().Property(d => d.CreateAt).HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ClientContact>().Property(d => d.UpdateAt).HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}