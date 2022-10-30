using DoAn.Entities.SubTable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Entities
{
    public class GenericShoes
    {
        [Key]
        public int GenericShoesID { get; set; } 

        public string Name { get; set; }

        public string Detail { get; set; }

        public string Images { get; set; }
        public string Slug { get; set; }



        //foreign key
        [ForeignKey("Category")]
        public int Category_ID { get; set; }    

        public Category Category { get; set; }

        //specificshoes
        public virtual ICollection<SpecificShoes> SpecificShoeses { get; set; }


    }
}
