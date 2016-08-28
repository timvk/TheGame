namespace TheGame.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using DbModels;
    using System.Data.Entity;
    using Migrations;
    using DbModels.Items;

    public class TheGameContext : IdentityDbContext<User>
    {
        public TheGameContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer
                (new MigrateDatabaseToLatestVersion<TheGameContext, Configuration>());
        }

        public virtual IDbSet<Item> Items { get; set; }

        public virtual IDbSet<ItemType> ItemTypes { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Slot> Slots { get; set; }

        public virtual IDbSet<Specialty> Specialties { get; set; }

        public virtual IDbSet<SpecialtyValues> SpecialtyValues { get; set; }

        public virtual IDbSet<Weapon> Weapons { get; set; }

        public virtual IDbSet<WeaponType> WeaponTypes { get; set; }
    }
}
