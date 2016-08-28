using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheGame.DbModels.Items
{
    public class Specialty
    {
        private ICollection<SpecialtyValues> specialtyValues;

        public Specialty()
        {
            this.specialtyValues = new HashSet<SpecialtyValues>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SpecialtyValues> SpecialtyValues
        {
            get { return this.specialtyValues; }
            set { this.specialtyValues = value; }
        }
    }
}
