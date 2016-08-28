using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheGame.DbModels.Items
{
    public class WeaponType
    {
        private ICollection<Weapon> weapons;

        public WeaponType()
        {
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

    }
}
