using NuGet.Frameworks;

namespace Olha.HW9.Shop.Tests;
public class Tests
{

    Store store;
    ShopCart cart;

    [SetUp]
    //[OneTimeSetUp]
    public void Setup()
    {
        store = new Store();
        store.AddProduct(new Product("Tomato", 15.00m, 3)); // <- test data for Cart tests
        store.AddProduct(new Product("Potato", 10.00m, 3)); // <- test data for Cart tests
        store.AddProduct(new Product("Cheese", 20.00m, 3)); // <- test data for Cart tests
        cart = new ShopCart("Olha", store);
    }

    [Test]
    public void AddProductToStoreTest()
    {
        string productName = "Apple";
        var newProduct = new Product(productName, 20.00m, 30);
        store.AddProduct(newProduct);
        var storeProduct = store.GetProduct(productName);
        Assert.AreEqual(newProduct.Name, storeProduct.Name);
    }

    [TestCase(1, 3, 2)]
    [TestCase(1, 1, 0)]
    public void DeleteProductFromStoreTest(int Expected, int addQuantity, int deleteQuantity)
    {
        var productName = "Apple";
        store.AddProduct(new Product(productName, 20.00m, addQuantity));
        store.RemoveProduct(new Product(productName, 20.00m, deleteQuantity));
        var storeProduct = store.GetProduct(productName);
        Assert.AreEqual(Expected, storeProduct.Quantity);
    }

    [TestCase(3, 3)]
    [TestCase(3, 4)]
    [TestCase(0, 3)]
    [TestCase(0, 0)]
    public void DeleteAllProductsFromStoreTest(int addQuantity, int deleteQuantity)
    {
        var productName = "Apple";
        store.AddProduct(new Product(productName, 20.00m, addQuantity));
        store.RemoveProduct(new Product(productName, 20.00m, deleteQuantity));
        var storeProduct = store.GetProduct(productName);
        Assert.IsNull(storeProduct);
    }

    [Test]
    public void AddProductToCartTest()
    {
        var productName = "Tomato";
        var quantity = 3;
        cart.AddProduct(productName, quantity);
        var cartProduct = cart.FindProductInCart(productName);
        Assert.IsNotNull(cartProduct);
        Assert.AreEqual(productName, cartProduct.Name);
        Assert.AreEqual(quantity, cartProduct.Quantity);
    }

    [Test]
    public void CartAmountTest()
    {
        cart.AddProduct("Tomato", 3);
        cart.AddProduct("Potato", 2);
        cart.AddProduct("Cheese", 1);
        Assert.AreEqual(85.00m, cart.Amount);
    }

    [TestCase("Tomato", 3, 2, 1)]
    [TestCase("Potato", 3, 0, 3)]
    public void RemoveProductsFromCartTest(string productName, decimal addQuantity, decimal deleteQuantity, decimal expectedQuantity)
    {
        cart.AddProduct(productName, addQuantity);
        cart.RemoveProduct(productName, deleteQuantity);
        var cartProduct = cart.FindProductInCart(productName);
        Assert.IsNotNull(cartProduct);
        Assert.AreEqual(expectedQuantity, cartProduct.Quantity);
    }

    [TestCase("Tomato", 3, 3, 0)]
    [TestCase("Potato", 0, 0, 0)]
    public void RemoveAllProductsFromCartTest(string productName, decimal addQuantity, decimal deleteQuantity, decimal expectedQuantity)
    {
        cart.AddProduct(productName, addQuantity);
        cart.RemoveProduct(productName, deleteQuantity);
        var cartProduct = cart.FindProductInCart(productName);
        Assert.IsNull(cartProduct);
    }

    [Test]
    public void ClearCartAfterBuyTest()
    {
        cart.AddProduct("Tomato", 3);
        cart.AddProduct("Potato", 2);
        cart.Buy();
        Assert.IsNull(cart.FindProductInCart("Tomato"));
        Assert.IsNull(cart.FindProductInCart("Potato"));
    }


    [TestCase("Tomato", 3, 0)]
    [TestCase("Potato", 2, 1)]
    public void RemoveProductfromStoreAfterBuyTest(string productName, decimal addQuantity, decimal expectedQuantity)
    {
        cart.AddProduct(productName, addQuantity);
        cart.Buy();
        Assert.AreEqual(expectedQuantity, store.GetProduct(productName).Quantity);
    }

    [Test]
    public void AddNotExistngProductToCartTest()
    {
        var productName = "NonExistentProduct";
        var quantity = 1;
        var ex = Assert.Throws<ArgumentNullException>(() => cart.AddProduct(productName, quantity));
        Assert.That(ex.Message, Does.Contain("Product is not found in the store"));
    }

    [Test]
    public void AddProductsMoreThanInStoreTest()
    {
        var productName = "Potato";
        var quantity = 4;
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => cart.AddProduct(productName, quantity));
        Assert.That(ex.Message, Does.Contain("There is not enough quantity of the product in the store"));
    }

    [Test]
    public void RemoveNonExistentProductFromCartTest()
    {
        var productName = "Banana";
        var quantity = 4;
        var ex = Assert.Throws<ArgumentNullException>(() => cart.RemoveProduct(productName, quantity));
        Assert.That(ex.Message, Does.Contain("There is no such product in the cart"));
    }

    [TestCase("Potato", 3, 4)]
    [TestCase("Tomato", 0, 1)]
    public void RemoveProductsMoreThanInCartTest(string productName, decimal addQuantity, decimal deleteQuantity)
    {
        cart.AddProduct(productName, addQuantity);
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => cart.RemoveProduct(productName, deleteQuantity));
        Assert.That(ex.Message, Does.Contain("There is not enough quantity of the product in the cart"));
    }
}