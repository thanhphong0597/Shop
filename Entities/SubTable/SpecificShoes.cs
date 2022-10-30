using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Entities.SubTable
{
    public class SpecificShoes
    {

        public int Stock { get; set; }

        public float Price { get; set; }

        public int ColorID { get; set; }
        public int ShoesID { get; set; }
        public int SizeID { get; set; }

        public Color Color { get; set; }
        public GenericShoes GenericShoes { get; set; }
        public Size Size { get; set; }
    }

    public class ShoesConfig : IEntityTypeConfiguration<SpecificShoes>
    {
        public void Configure(EntityTypeBuilder<SpecificShoes> b)
        {
            b.ToTable("SpecificShoes");
            b.HasKey(t=>new {t.ShoesID, t.ColorID, t.SizeID});

            b.HasOne(t => t.GenericShoes)
            .WithMany(x => x.SpecificShoeses)
            .HasForeignKey(t => t.ShoesID)
            .HasPrincipalKey(x => x.GenericShoesID)
            .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(t => t.Color)
            .WithMany(x => x.SpecificShoeses)
            .HasForeignKey(t => t.ColorID)
            .HasPrincipalKey(x => x.ColorID)
            .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(t => t.Size)
           .WithMany(x => x.SpecificShoeses)
           .HasForeignKey(t => t.SizeID)
           .HasPrincipalKey(x => x.SizeID)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
