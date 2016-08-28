using System.ComponentModel.DataAnnotations;

namespace TheGame.DbModels.Items
{
    public class SpecialtyValues
    {
        [Key]
        public int Id { get; set; }

        public int Value { get; set; }

        public int? ItemId { get; set; }

        public virtual Item Item { get; set; }

        public int? WeaponId { get; set; }

        public virtual Weapon Weapon { get; set; }

        public int SpecialtyId { get; set; }

        public virtual Specialty Specialty { get; set; }
    }
}
