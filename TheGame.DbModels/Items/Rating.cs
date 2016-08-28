using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheGame.DbModels.Items
{
    public class Rating
    {
        private ICollection<Weapon> weapons;
        private ICollection<Item> items;

        public Rating()
        {
            this.items = new HashSet<Item>();
            this.weapons = new HashSet<Weapon>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<Weapon> Weapons
        {
            get { return this.weapons; }
            set { this.weapons = value; }
        }

        public virtual ICollection<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
    }
}
