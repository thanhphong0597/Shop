using System.ComponentModel.DataAnnotations;

namespace DoAn.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<GenericShoes> GenericShoes { get; set; }


    }
}
