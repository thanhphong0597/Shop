using DoAn.Entities;
using DoAn.Entities.SubTable;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Services
{
    public class Context : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<GenericShoes> GenericShoes { get; set; }
        public virtual DbSet<SpecificShoes> SpecificShoes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating (ModelBuilder b)
        {
            b.ApplyConfiguration(new ShoesConfig());
        
            b.Initial();
        }
        
    }
    public static class DuLieuMau
    {
        public static void Initial(this ModelBuilder b)
        {
            b.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Giay", Slug="giay" },
                new Category { CategoryID = 2, Name = "Ao",Slug="ao" },
                new Category { CategoryID = 3, Name = "Quan",Slug="quan" }
                );
            b.Entity<GenericShoes>().HasData(
                new GenericShoes { GenericShoesID=1,Name="Giay Nike",Slug="giay_nike", Category_ID=1,Detail="...",Images="..."},
                new GenericShoes { GenericShoesID=2,Name="Giay Jordan", Slug = "giay_jordan", Category_ID =1, Detail = "...", Images = "..." },
                new GenericShoes { GenericShoesID=3,Name="Ao Nike lon", Slug = "ao_nike", Category_ID =2, Detail = "...", Images = "..." },
                new GenericShoes { GenericShoesID=4,Name="Quan Nike", Slug = "quan_nike", Category_ID =3, Detail = "...", Images = "..." }
                );
            b.Entity<Color>().HasData(
                new Color { ColorID = 1, Name = "do" },
                new Color { ColorID = 2, Name = "vang" },
                new Color { ColorID = 3, Name = "cam" }
                );
            b.Entity<Size>().HasData(
                new Size { SizeID=1,Name="38"},
                new Size { SizeID=2,Name="39"},
                new Size { SizeID=3,Name="40"},
                new Size { SizeID=4,Name="41"}
                );

            b.Entity<SpecificShoes>().HasData(
                new SpecificShoes {ColorID=1,SizeID=1,ShoesID=1,Price=20000,Stock=3 },
                new SpecificShoes {ColorID=1,SizeID=2,ShoesID=1,Price=20000,Stock=2 },
                new SpecificShoes {ColorID=2,SizeID=3,ShoesID=1,Price=20000,Stock=5 },
                new SpecificShoes {ColorID=1,SizeID=2,ShoesID=2,Price=20000,Stock=1 },
                new SpecificShoes {ColorID=3,SizeID=1,ShoesID=2,Price=20000,Stock=6 }
                );
        }
    }
    
}
