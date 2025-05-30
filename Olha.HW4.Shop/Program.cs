
Console.WriteLine("\n === STORE ===\n");

Console.WriteLine("Hello! This store sells the following products:\n");
var store = new Store();
store.AddProduct(new Product("Apple", 20.00m, 30));
store.AddProduct(new Product("Banana", 10.00m, 40));
store.AddProduct(new Product("Orange", 15.00m, 50));
store.AddProduct(new Product("Pineapple", 25.00m, 60));
store.AddProduct(new Product("Kiwi", 30.00m, 70));
store.AddProduct(new Product("Mango", 35.00m, 80));
store.AddProduct(new Product("Peach", 40.00m, 90));
store.AddProduct(new Product("Plum", 45.00m, 100));
store.AddProduct(new Product("Pear", 50.00m, 110));
store.AddProduct(new Product("Cherry", 55.00m, 120));
store.ShowProducts();


string wantBuy;
do
{
    Console.WriteLine("\nDo you want to buy something? (y/n)");
    wantBuy = Console.ReadLine();
    if (wantBuy != "y" & wantBuy != "Y")
    {
        Console.WriteLine("Goodbye!");
        return;
    }


    Console.WriteLine("\n === USER'S CART CREATION ===\n");

    Console.WriteLine("Enter your name");
    string name = Console.ReadLine();
    var cart = new ShopCart(name, store);
    Console.WriteLine($"New Cart {cart.CartID} was created for {cart.Owner}");


    Console.WriteLine("\n === ADD PRODUCTS TO CART ===\n");

    string y;
    do
    {
        Console.WriteLine($"Enter the product name that you want to buy?");
        string productName = Console.ReadLine();
        Console.WriteLine($"Enter the quantity");
        string productQuantity = Console.ReadLine();
        cart.AddProduct(productName, decimal.TryParse(productQuantity.Replace(".", ","), out decimal outQuantity) ? outQuantity : 1);

        Console.WriteLine("Do you want to buy something else? (y/n)");
        y = Console.ReadLine();

    } while (y == "y" || y == "Y");

    Console.WriteLine("\nProducts in your cart:");
    cart.ShowProducts();
    Console.WriteLine($"Total amount: {cart.Amount.ToString("F")} UAH");


    Console.WriteLine("\n === BUY OR DELETE PRODUCTS FROM THE CART ===\n");

    string action;
    do
    {
        Console.WriteLine("\nIf you want to buy enter \"buy\". If you want to delete a product enter its name");
        action = Console.ReadLine();
        if (action != "buy")
        {
            string productName = action;
            Console.WriteLine($"Enter the quantity");
            string productQuantity = Console.ReadLine();
            cart.RemoveProduct(productName, decimal.TryParse(productQuantity.Replace(".", ","), out decimal outQuantity) ? outQuantity : 1);
        }
    } while (action != "buy");


    Console.WriteLine($"\n=== YOUR CHECK: ===\n");
    cart.Buy();


    Console.WriteLine("\n === UPDATED STORE ===\n");
    store.ShowProducts();

} while (wantBuy == "y" || wantBuy == "Y");
