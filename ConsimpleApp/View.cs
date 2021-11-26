using System;

namespace ConsimpleApp
{
    class View
    {
        public void ShowData(Catalog catalog)
        {
            Console.WriteLine("Product name\t\tCategory name\n");
            foreach (var product in catalog.Products)
            {
                Console.Write(product.Name);
                for (int i = 0; i < catalog.Categories.Length; i++)
                    if (catalog.Categories[i].Id == product.CategoryId)
                    {
                        if (product.Name.Length > 15)
                            Console.WriteLine($"\t{catalog.Categories[i].Name}");
                        if (product.Name.Length >= 8 && product.Name.Length <= 15)
                            Console.WriteLine($"\t\t{catalog.Categories[i].Name}");
                        if (product.Name.Length < 8)
                            Console.WriteLine($"\t\t\t{catalog.Categories[i].Name}");
                    }
            }
        }
        public bool RetryMessage()
        {
            bool check;
            Console.WriteLine("\nIf you want to repeat, enter «Y» or «y».");
            string answer = Console.ReadLine();
            if (String.Equals(answer, "y", StringComparison.OrdinalIgnoreCase))
                check = true;
            else
                check = false;
            return check;
        }
    }
}
