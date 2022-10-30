namespace DoAn.Models.ViewModels
{
    public class CategoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public List<GenericItem> GenericShoeses { get; set; }

    }

    public class GenericItem
    {
        public int GenericID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
