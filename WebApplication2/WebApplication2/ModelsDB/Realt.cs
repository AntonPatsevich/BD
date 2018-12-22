namespace WebApplication2.ModelsDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Realt : DbContext
    {
        public Realt()
            : base("name=RealtO")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<district> district { get; set; }
        public virtual DbSet<employer> employer { get; set; }
        public virtual DbSet<lot> lot { get; set; }
        public virtual DbSet<lots_type> lots_type { get; set; }
        public virtual DbSet<orderus> orderus { get; set; }
        public virtual DbSet<positions> positions { get; set; }
        public virtual DbSet<street> street { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.orderus)
                .WithOptional(e => e.customer)
                .HasForeignKey(e => e.customer_id);

            modelBuilder.Entity<employer>()
                .HasMany(e => e.orderus)
                .WithOptional(e => e.employer)
                .HasForeignKey(e => e.employer_id);

            modelBuilder.Entity<lot>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<lot>()
                .Property(e => e.area)
                .HasPrecision(18, 0);

            modelBuilder.Entity<lot>()
                .HasMany(e => e.orderus)
                .WithOptional(e => e.lot)
                .HasForeignKey(e => e.lot_id);

            modelBuilder.Entity<lots_type>()
                .HasMany(e => e.lot)
                .WithOptional(e => e.lots_type)
                .HasForeignKey(e => e.typeid);

            modelBuilder.Entity<positions>()
                .HasMany(e => e.employer)
                .WithRequired(e => e.positions)
                .HasForeignKey(e => e.position_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<street>()
                .HasMany(e => e.lot)
                .WithOptional(e => e.street)
                .HasForeignKey(e => e.street_id);
        }
    }
}
