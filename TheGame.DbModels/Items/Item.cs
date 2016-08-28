using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheGame.DbModels.Items
{
    public class Item
    {
        private ICollection<SpecialtyValues> specialties;

        public Item()
        {
            this.specialties = new HashSet<SpecialtyValues>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Power { get; set; }

        public int Armor { get; set; }

        public int SpellPower { get; set; }

        public string Text { get; set; }

        public virtual ICollection<SpecialtyValues> Specialties
        {
            get { return this.specialties; }
            set { this.specialties = value; }
        }

        public int SlotId { get; set; }

        public virtual Slot Slot { get; set; }

        public int ItemTypeId { get; set; }

        public virtual ItemType ItemType { get; set; }

        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
