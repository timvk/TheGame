namespace TheGame.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DbModels.Items;
    using System.IO;

    internal sealed class Configuration : DbMigrationsConfiguration<TheGameContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TheGameContext context)
        {
            if (!context.ItemTypes.Any())
            {
                this.SeedCategories(context);
            }

            if (!context.Items.Any())
            {
                this.SeedItems(context);
            }

            if (!context.Weapons.Any())
            {
                this.SeedWeapons(context);
            }
        }

        private void SeedItems(TheGameContext ctx)
        {
            var itemInfoFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "ItemInfo.txt");
            var itemInfoCollection = File.ReadAllText(itemInfoFilePath).Split(new[] { '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < itemInfoCollection.Length; i += 2)
            {
                var itemDescription = itemInfoCollection[i].Split(',').Select(x => x.Trim()).ToArray();
                var itemSpecialties = itemInfoCollection[i + 1];

                var typeName = itemDescription[5];
                var slotName = itemDescription[6];
                var ratingName = itemDescription[7];
                var item = new Item
                {
                    Name = itemDescription[0],
                    Power = int.Parse(itemDescription[1]),
                    Armor = int.Parse(itemDescription[2]),
                    SpellPower = int.Parse(itemDescription[3]),
                    Text = itemDescription[4],
                    ItemType = ctx.ItemTypes.First(type => type.Name == typeName),
                    Slot = ctx.Slots.First(slot => slot.Name == slotName),
                    Rating = ctx.Ratings.First(rating => rating.Name == ratingName)
                };

                ctx.Items.Add(item);

                this.AddSpecialtyValues(itemSpecialties, item, null, ctx);
            }

            ctx.SaveChanges();
        }

        private void SeedWeapons(TheGameContext ctx)
        {
            var weaponInfoFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "WeaponInfo.txt");
            var weaponInfoCollection = File.ReadAllText(weaponInfoFilePath).Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < weaponInfoCollection.Length; i += 2)
            {
                var weaponDescription = weaponInfoCollection[i].Split(',').Select(x => x.Trim()).ToArray();
                var weaponSpecialties = weaponInfoCollection[i + 1];

                var typeName = weaponDescription[4];
                var ratingName = weaponDescription[5];

                var weapon = new Weapon
                {
                    Name = weaponDescription[0],
                    Attack = int.Parse(weaponDescription[1]),
                    SpellAttack = int.Parse(weaponDescription[2]),
                    Text = weaponDescription[3],
                    WeaponType = ctx.WeaponTypes.First(type => type.Name == typeName),
                    Rating = ctx.Ratings.First(rating => rating.Name == ratingName)
                };

                ctx.Weapons.Add(weapon);

                this.AddSpecialtyValues(weaponSpecialties, null, weapon, ctx);
            }

            ctx.SaveChanges();
        }

        private void SeedCategories(TheGameContext ctx)
        {
            var itemTypes = new[] { "Cloth", "Leather", "Mail" };
            var ratings = new[] { "Basic", "Fine", "Rare", "Excellent", "Legendary" };
            var slots = new[] { "Chest", "Feet", "Legs", "Head", "Arms" };
            var weaponTypes = new[] { "Sword", "Hammer", "Dagger", "Staff", "Axe" };
            var specialties = new[] { "Leech", "Critical", "Multihit", "Stun", "Move Distance", "Spell Resistance", "Block" };

            foreach (var itemTypeName in itemTypes)
            {
                var type = new ItemType { Name = itemTypeName };
                ctx.ItemTypes.Add(type);
            }

            foreach (var ratingName in ratings)
            {
                var rating = new Rating { Name = ratingName };
                ctx.Ratings.Add(rating);
            }

            foreach (var slotName in slots)
            {
                var slot = new Slot { Name = slotName };
                ctx.Slots.Add(slot);
            }

            foreach (var weaponTypeName in weaponTypes)
            {
                var weaponType = new WeaponType { Name = weaponTypeName };
                ctx.WeaponTypes.Add(weaponType);
            }

            foreach (var specialtyName in specialties)
            {
                var specialty = new Specialty { Name = specialtyName };
                ctx.Specialties.Add(specialty);
            }

            ctx.SaveChanges();
        }

        private void AddSpecialtyValues(string specInfo, Item item, Weapon weapon, TheGameContext ctx)
        {
            var specialties = specInfo.Replace("Specialties:", string.Empty).Trim().Split(',');
            foreach (var specialtyInfo in specialties)
            {
                if (string.IsNullOrWhiteSpace(specialtyInfo))
                    continue;

                var specialtyInfoTokens = specialtyInfo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToArray();

                var specialtyName = specialtyInfoTokens[0].Trim();

                if (specialtyInfoTokens.Length == 3)
                    specialtyName += " " + specialtyInfoTokens[1].Trim();

                var specialtyValue = int.Parse(specialtyInfoTokens[specialtyInfoTokens.Length - 1].Trim());

                var itemSpecialtyValue = new SpecialtyValues
                {
                    Value = specialtyValue,
                    Specialty = ctx.Specialties.First(s => s.Name.Equals(specialtyName, StringComparison.InvariantCultureIgnoreCase)),
                    Item = item,
                    Weapon = weapon
                };

                ctx.SpecialtyValues.Add(itemSpecialtyValue);
            }
        }
    }
}
