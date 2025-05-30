
public class ShopCart
{
    //Properties
    public string CartID { get; }
    public string Owner { get; set; }
    public decimal Amount
    {
        get
        {
            return cartProducts.Sum(x => x.Price * x.Quantity);
        }
    }
    /*public decimal Amount2
    {
        get
        {
            decimal amount = 0;
            foreach (var item in cartProducts)
            {
                amount += item.Price * item.Quantity;
            }
            return amount;
        }
    }*/
    private static int cartIdSeed = 1234567890;
    private List<Product> cartProducts = new List<Product>();
    private Store store;

    //Constructor
    public ShopCart(string name, Store store)
    {
        this.Owner = name;
        this.CartID = cartIdSeed.ToString();
        cartIdSeed++;
        this.store = store;
    }

    //Methods.Functions
    public void AddProduct(string productName, decimal quantity)
    {
        var storeProduct = store.GetProduct(productName);
        var cartProduct = FindProductInCart(productName);
        if (storeProduct == null)
        {
            //throw new ArgumentNullException("Product is not found in the store");
            Console.WriteLine("There is no such product in the store");
            return;
        }
        else if (storeProduct.Quantity < quantity)
        {
            //throw new ArgumentOutOfRangeException("There is not enough quantity of the product in the store");
            Console.WriteLine("There is not enough quantity of the product in the store");
            return;
        }

        if (cartProduct == null)
        {
            var newCartProduct = new Product(storeProduct.Name, storeProduct.Price, quantity);
            cartProducts.Add(newCartProduct);
        }
        else
        {
            cartProduct.Quantity = cartProduct.Quantity + quantity;
        }
    }
    public void RemoveProduct(string productName, decimal quantity)
    {
        var cartProduct = FindProductInCart(productName);
        if (cartProduct == null)
        {
            //throw new ArgumentNullException("Product is not found in the cart");
            Console.WriteLine("There is no such product in the cart");
            return;
        }
        else if (cartProduct.Quantity < quantity)
        {
            //throw new ArgumentOutOfRangeException("There is not enough quantity of the product in the cart");
            Console.WriteLine("There is not enough quantity of the product in the cart");
            return;
        }
        else
        {
            cartProduct.Quantity = cartProduct.Quantity - quantity;
            if (cartProduct.Quantity == 0)
            {
                cartProducts.Remove(cartProduct);
            }
        }
    }
    public Product FindProductInCart(string productName)
    {
        foreach (var product in cartProducts)
        {
            if (product.Name.ToLower() == productName.ToLower())
            {
                return product;
            }
        }
        return null;
    }
    public void ShowProducts()
    {
        Console.WriteLine("|{0,10}|{1,12}|{2,12}|", "Product", "Price,UAH", "Quantity,kg");
        Console.WriteLine("---------------------------------------");
        foreach (var product in cartProducts)
        {

            Console.WriteLine("|{0,10}|{1,12}|{2,12}|", product.Name, product.Price, product.Quantity);
        }
    }
    private void ShowCheck()                                        // encapsulation
    {
        Console.WriteLine($"Seller: STORE");
        Console.WriteLine($"Customer: {Owner}");
        Console.WriteLine($"CartID: {CartID}");
        var now = DateTime.Now;
        Console.WriteLine($"Date: {now.ToString("U")}");
        Console.WriteLine(".......................................");
        foreach (var product in cartProducts)
        {
            Console.WriteLine("{0,24}{1,15}", $"{product.Quantity} x {product.Price} {product.Name}", $"{(product.Quantity * product.Price).ToString("F")} UAH");
        }
        Console.WriteLine(".......................................");
        Console.WriteLine("{0,24}{1,15}", "Total amount:", $"{Amount.ToString("F")} UAH");
        Console.WriteLine(".......................................");
        Console.WriteLine("Thank you for your purchase!");
    }
    public void Buy()
    {
        foreach (var product in cartProducts)
        {
            var storeProduct = store.GetProduct(product.Name);
            storeProduct.Quantity = storeProduct.Quantity - product.Quantity;
        }
        ShowCheck();
        cartProducts.Clear();
    }
}

