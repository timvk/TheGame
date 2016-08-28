using System;
using System.Collections.Generic;

namespace TheGame.DbModels.Items
{
    public class Weapon
    {
        private ICollection<SpecialtyValues> specialties;

        public Weapon()
        {
            this.specialties = new HashSet<SpecialtyValues>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Attack { get; set; }

        public int SpellAttack { get; set; }

        public string Text { get; set; }

        public int WeaponTypeId { get; set; }

        public virtual WeaponType WeaponType { get; set; }

        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }

        public virtual ICollection<SpecialtyValues> Specialties
        {
            get { return this.specialties; }
            set { this.specialties = value; }
        }
    }
}
