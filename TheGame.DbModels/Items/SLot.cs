using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheGame.DbModels.Items
{
    public class Slot
    {
        private ICollection<Item> items;

        public Slot()
        {
            this.items = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
    }
}
