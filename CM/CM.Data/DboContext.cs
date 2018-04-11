using CM.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace CM.Data
{
    public interface IDboContextFactory
    {
        IDboContext GetContext();
    }

    public class DboContextFactory : IDboContextFactory
    {
        public IDboContext GetContext()
        {
            var db = new DboContext("WoundExpert");

            db.Database.Log = Console.WriteLine;

            return db;
        }
    }

    public interface IDboContext
    {
        DbSet<Document> DocumentMetaData { get; set; }
        DbSet<ExceptionLog> ExceptionLogs { get; set; }

        void Dispose();
        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }

    public class DboContext : DbContext, IDboContext
    {
        public DboContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        public DbSet<Document> DocumentMetaData { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }			// wasn't sure if this data is also meta data? qualifying name can be changed

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .ToTable("tbl_DocumentLibrary")
                .HasKey(dl => dl.DocumentID);

            modelBuilder.Entity<Document>()
                .HasOptional(dl => dl.LastUpdatedUser)
                .WithMany()
                .HasForeignKey(dl => dl.LastUpdatedBy);

            modelBuilder.Entity<Visit>()
                .ToTable("tbl_Visit")
                .HasOptional(v => v.VisitType)
                .WithMany()
                .HasForeignKey(v => v.VisitTypeID);

            modelBuilder.Entity<Visit>()
                .HasKey(v => v.VisitID);

            modelBuilder.Entity<VisitType>()
                .ToTable("tbl_CODE_VisitType")
                .HasKey(v => v.Code);

            modelBuilder.Entity<User>()
                .ToTable("tbl_Users")
                .HasKey(v => v.UserId);

            modelBuilder.Entity<Facility>()
                .ToTable("tbl_facility")
                .HasKey(dl => dl.FacilityID);

            modelBuilder.Entity<ExceptionLog>()
                .ToTable("tbl_Exceptions")
                .HasKey(e => e.ExceptionID);

            modelBuilder.Entity<ExceptionLog>()
                .HasRequired(e => e.ExceptionUser)
                .WithMany()
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<ExceptionLog>()
                .HasRequired(e => e.ExceptionFacility)
                .WithMany()
                .HasForeignKey(e => e.FacilityID);

        }
    }

}
