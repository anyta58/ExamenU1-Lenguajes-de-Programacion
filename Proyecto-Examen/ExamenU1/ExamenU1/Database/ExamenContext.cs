//using ExamenU1.Database.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace ExamenU1.Database;

//public class ExamenContext : IdentityDbContext<UserEntity>
//{

//    public ExamenContext(
//        DbContextOptions options
//        ) : base( options )
//    {

//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {

//        modelBuilder.HasDefaultSchema("security");

//        modelBuilder.Entity<UserEntity>().ToTable("users");
//        modelBuilder.Entity<IdentityRole>().ToTable("roles");
//        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("users_roles");
//        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("users_claims");
//        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("roles_claims");
//        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("users_logins");
//        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("users_tokens");

//        modelBuilder.Entity<IdentityUserLogin<string>>()
//            .ToTable("users_logins")
//            .HasKey(l => new { l.LoginProvider, l.ProviderKey });

//        modelBuilder.Entity<IdentityUserRole<string>>()
//            .ToTable("users_roles")
//            .HasKey(ur => new { ur.UserId, ur.RoleId });

//        modelBuilder.Entity<IdentityUserToken<string>>()
//        .ToTable("users_tokens")
//        .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

//        var eTypes = modelBuilder.Model.GetEntityTypes();
//        foreach ( var type in eTypes )
//        {
//            var foreignKeys = type.GetForeignKeys();

//            foreach(var foreignKey in foreignKeys)
//            {
//                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
//            }
//        }
//    }

//    public DbSet<UserEntity> Users {  get; set; }
//    public DbSet<PermissionStatusEntity> PermissionStatuses { get; set; }
//    public DbSet<RequestPermissionEntity> RequestPermissions { get; set; }
//    public DbSet<TypePermitEntity> TypesPermit { get; set; }
//}

using ExamenU1.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamenU1.Database;

public class ExamenContext : IdentityDbContext<UserEntity>
{
    public ExamenContext(
        DbContextOptions options        //se quito <ExamenContext>
        ) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Security");

        builder.Entity<UserEntity>().ToTable("users");
        builder.Entity<IdentityRole>().ToTable("roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("users_roles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("users_claims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("users_logins");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("roles_claims");
        builder.Entity<IdentityUserToken<string>>().ToTable("users_tokens");

        //comentar por si acaso
        //var eTypes = builder.Model.GetEntityTypes();
        //foreach (var type in eTypes)
        //{
        //    var foreignKeys = type.GetForeignKeys();

        //    foreach (var foreignKey in foreignKeys)
        //    {
        //        foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        //    }
        //}
;
    }


}