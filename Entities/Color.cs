using DoAn.Entities.SubTable;
using System.ComponentModel.DataAnnotations;

namespace DoAn.Entities
{
    public class Color
    {
        [Key]
        public int ColorID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SpecificShoes> SpecificShoeses { get; set; }


    }
}
