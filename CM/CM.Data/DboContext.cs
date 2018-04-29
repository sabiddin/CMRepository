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
            var db = new DboContext("CM");

            db.Database.Log = Console.WriteLine;

            return db;
        }
    }

    public interface IDboContext
    {
        //DbSet<Document> DocumentMetaData { get; set; }
        //DbSet<ExceptionLog> ExceptionLogs { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Representative> Representatives { get; set; }
        DbSet<Client> Clients { get; set; }


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

        //public DbSet<Document> DocumentMetaData { get; set; }
        //public DbSet<ExceptionLog> ExceptionLogs { get; set; }			// wasn't sure if this data is also meta data? qualifying name can be changed
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("tbl_User")
                .HasKey(u => u.UserID)
                .HasOptional(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleID);
                                
            modelBuilder.Entity<Role>()
                .ToTable("tbl_Role")
                .HasKey(u => u.RoleID);

            modelBuilder.Entity<Representative>()
                 .ToTable("tbl_Representative")
                 .HasKey(u => u.RepresentativeID)
                 .HasOptional(u => u.User)
                 .WithMany()
                 .HasForeignKey(u => u.UserID);
            modelBuilder.Entity<Client>()
               .ToTable("tbl_Client")
               .HasKey(u => u.ClientID)
               .HasOptional(u => u.Representative)
               .WithMany()
               .HasForeignKey(u => u.RepresentativeID);
            //modelBuilder.Entity<Document>()
            //    .ToTable("tbl_DocumentLibrary")
            //    .HasKey(dl => dl.DocumentID);

            //modelBuilder.Entity<Document>()
            //    .HasOptional(dl => dl.LastUpdatedUser)
            //    .WithMany()
            //    .HasForeignKey(dl => dl.LastUpdatedBy);

            //modelBuilder.Entity<Visit>()
            //    .ToTable("tbl_Visit")
            //    .HasOptional(v => v.VisitType)
            //    .WithMany()
            //    .HasForeignKey(v => v.VisitTypeID);

            //modelBuilder.Entity<Visit>()
            //    .HasKey(v => v.VisitID);

            //modelBuilder.Entity<VisitType>()
            //    .ToTable("tbl_CODE_VisitType")
            //    .HasKey(v => v.Code);

            //modelBuilder.Entity<User>()
            //    .ToTable("tbl_Users")
            //    .HasKey(v => v.UserId);

            //modelBuilder.Entity<Facility>()
            //    .ToTable("tbl_facility")
            //    .HasKey(dl => dl.FacilityID);

            //modelBuilder.Entity<ExceptionLog>()
            //    .ToTable("tbl_Exceptions")
            //    .HasKey(e => e.ExceptionID);

            //modelBuilder.Entity<ExceptionLog>()
            //    .HasRequired(e => e.ExceptionUser)
            //    .WithMany()
            //    .HasForeignKey(e => e.UserID);

            //modelBuilder.Entity<ExceptionLog>()
            //    .HasRequired(e => e.ExceptionFacility)
            //    .WithMany()
            //    .HasForeignKey(e => e.FacilityID);

        }
    }

}
