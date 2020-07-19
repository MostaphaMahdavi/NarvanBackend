using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Narvan.Domains.Commons;
using Narvan.Domains.ProductCategories.Entities;
using Narvan.Domains.ProductGalleries.Entities;
using Narvan.Domains.Products.Entities;
using Narvan.Domains.ProductSelectedCategories.Entities;
using Narvan.Domains.ProductVisits.Entities;
using Narvan.Domains.Roles.Entities;
using Narvan.Domains.Sliders.Entities;
using Narvan.Domains.UserRoles.Entities;
using Narvan.Domains.Users.Entities;

namespace Narvan.DataAccessCommands.Context
{
    public class NarvanContext : DbContext
    {

        public NarvanContext(DbContextOptions<NarvanContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
       // public DbSet<UserRole> UserRoles { get; set; }
       // public DbSet<Slider> Sliders { get; set; }
        //public DbSet<ProductCategory> ProductCategories { get; set; }
        //public DbSet<ProductGallery> ProductGalleries { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<ProductSelectedCategory> ProductSelectedCategories { get; set; }
        //public DbSet<ProductVisit> ProductVisits { get; set; }



        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

             


            #region Disable CascadeDelete In DataBase

            var cascade = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var item in cascade)
            {
                item.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #endregion


        }

        #endregion

        #region Save

        #region SaveChanges
        public override int SaveChanges()
        {
            CustomSaveChange();

            return base.SaveChanges();
        }

        #endregion

        #region SaveChanges

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            CustomSaveChange();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        #endregion

        #region SaveChangesAsync
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            CustomSaveChange();


            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region SaveChangesAsync

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            CustomSaveChange();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion


        #region CustomSaveChangeMethod

        private void CustomSaveChange()
        {

            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                                e.State == EntityState.Added
                                || e.State == EntityState.Modified));



            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }


        }

        #endregion

        #endregion




    }
}