using Restaurant_DeveloperCase.DAL.Data;
using Restaurant_DeveloperCase.DAL.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Context
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() : base("name=RestaurantContext")
        {
            Database.SetInitializer(new RestaurantInitializer());
        }

        public DbSet<AllTable> AllTables { get; set; }
        public DbSet<Mod> Mods { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<UserArea> Users { get; set; }

        public class RestaurantInitializer :DropCreateDatabaseIfModelChanges<RestaurantContext>
        {
            protected override void Seed(RestaurantContext context)
            {
                #region RoleTableSettings
                context.Roles.Add(new Role() { Id = 1, Name = "Admin" });
                context.Roles.Add(new Role() { Id = 2, Name = "User" }); 
                #endregion
                #region ModTableSettings
                context.Mods.Add(new Mod() { Id = 1, ModName = "Today" });
                context.Mods.Add(new Mod() { Id = 2, ModName = "Tomorrow" });
                context.Mods.Add(new Mod() { Id = 3, ModName = "AfterTomorrow" });
                #endregion


                base.Seed(context);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReservationMapping());
            modelBuilder.Configurations.Add(new UserAreaMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
            modelBuilder.Configurations.Add(new AllTableMapping());
            modelBuilder.Configurations.Add(new TableMapping());
            modelBuilder.Configurations.Add(new ModMapping());
        }
    }
}
