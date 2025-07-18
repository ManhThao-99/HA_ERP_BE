using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using HA_ERP.Staffs;
using Volo.Abp.EntityFrameworkCore.Modeling;
namespace HA_ERP.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class HA_ERPDbContext :
    AbpDbContext<HA_ERPDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    public DbSet<IdentityUserRole> UserRoles { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    //app dbsets
    public DbSet<Staff> Staffs { get; set; }

    #endregion







    public HA_ERPDbContext(DbContextOptions<HA_ERPDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(HA_ERPConsts.DbTablePrefix + "YourEntities", HA_ERPConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Staff>(b =>
        {
            b.ToTable(HA_ERPConsts.DbTablePrefix + "Staffs", HA_ERPConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Code).IsRequired().HasMaxLength(12); //temp (EMP*********)
            b.Property(x => x.Name).IsRequired(false).HasMaxLength(36);
            b.Property(x => x.Mobile).IsRequired(false).HasMaxLength(12);
            b.Property(x => x.Email).IsRequired(false).HasMaxLength(100);
            b.Property(x => x.ManagerId).IsRequired(false);
            b.Property(x => x.Address).HasMaxLength(150);
            b.Property(x => x.BankAccountName).HasMaxLength(36);
            b.Property(x => x.BankAccountNo).HasMaxLength(36);
            b.Property(x => x.BankName).HasMaxLength(100);
            b.Property(x => x.BankAddress).HasMaxLength(150);
            b.HasIndex(x => x.Code).IsUnique();
            b.HasIndex(x => x.Email).IsUnique();
            b.HasIndex(x => x.Mobile).IsUnique();
            b.Property(x => x.OrganizationUnitId).IsRequired(false);
            b.HasOne<OrganizationUnit>()
                .WithMany()
                .HasForeignKey(x => x.OrganizationUnitId)
                .IsRequired(false);
            b.HasOne<Staff>()
                .WithMany()
                .HasForeignKey(x => x.ManagerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict); //optional, can be null
            b.HasOne<IdentityUser>()
                 .WithOne()
                 .HasForeignKey<Staff>(x => x.UserId)
                 .IsRequired(false);

        });

       

    }
}
