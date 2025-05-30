
///using System.Xml.Linq;

public class Store
{
    private List<Product> storeProducts = new List<Product>();

    public void AddProduct(Product newProduct)
    {
        var storeProduct = GetProduct(newProduct.Name);
        if (storeProduct == null)
        {
            storeProducts.Add(newProduct);
        }
        else
        {
            storeProduct.Quantity = storeProduct.Quantity + newProduct.Quantity;
        }
    }
    public void RemoveProduct(Product product)
    {
        var storeProduct = GetProduct(product.Name);
        if (storeProduct.Quantity > product.Quantity)
        {
            storeProduct.Quantity = storeProduct.Quantity - product.Quantity;
        }
        else
        {
            storeProducts.Remove(storeProduct);
        }
    }
    public void ShowProducts()
    {
        Console.WriteLine("|{0,10}|{1,12}|{2,12}|", "Product", "Price,UAH", "Quantity,kg");
        Console.WriteLine("---------------------------------------");
        foreach (var product in storeProducts)
        {

            Console.WriteLine("|{0,10}|{1,12}|{2,12}|", product.Name, product.Price, product.Quantity);
        }
    }
    public Product GetProduct(string productName)
    {
        foreach (var product in storeProducts)
        {
            if (product.Name.ToLower() == productName.ToLower())
            {
                return product;
            }
        }
        return null;
    }
}
