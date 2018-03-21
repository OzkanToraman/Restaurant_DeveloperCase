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
                #region TableSettings
                context.Tables.Add(new Table() { Id = 1, TableName = "1" });
                context.Tables.Add(new Table() { Id = 2, TableName = "2" });
                context.Tables.Add(new Table() { Id = 3, TableName = "3" });
                context.Tables.Add(new Table() { Id = 4, TableName = "4" });
                #endregion
                #region AllTableSettings
                context.AllTables.Add(new AllTable() { Id = 1, ModId = 1, TableId = 1 });
                context.AllTables.Add(new AllTable() { Id = 2, ModId = 1, TableId = 2 });
                context.AllTables.Add(new AllTable() { Id = 3, ModId = 1, TableId = 3 });
                context.AllTables.Add(new AllTable() { Id = 4, ModId = 1, TableId = 4 });
                context.AllTables.Add(new AllTable() { Id = 5, ModId = 2, TableId = 1 });
                context.AllTables.Add(new AllTable() { Id = 6, ModId = 2, TableId = 2 });
                context.AllTables.Add(new AllTable() { Id = 7, ModId = 2, TableId = 3 });
                context.AllTables.Add(new AllTable() { Id = 8, ModId = 2, TableId = 4 });
                context.AllTables.Add(new AllTable() { Id = 9, ModId = 3, TableId = 1 });
                context.AllTables.Add(new AllTable() { Id = 10, ModId = 3, TableId = 2 });
                context.AllTables.Add(new AllTable() { Id = 11, ModId = 3, TableId = 3 });
                context.AllTables.Add(new AllTable() { Id = 12, ModId = 3, TableId = 4 });
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
