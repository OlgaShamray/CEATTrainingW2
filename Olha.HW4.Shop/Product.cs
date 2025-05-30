
public class Product
{
    //Properties
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }

    //Constructor
    public Product(string name, decimal price, decimal quantity)
    {
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
    }

}
