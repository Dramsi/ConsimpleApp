namespace ConsimpleApp
{
    public class Catalog
    {
        public ProductsList[] Products { get; set; }
        public CategoriesList[] Categories { get; set; }
    }

    public class ProductsList
    {
        private int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }

    public class CategoriesList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
