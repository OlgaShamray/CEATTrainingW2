
// Part 1 - Filling the friends collection:

var names = new List<string>();

void AddToNames()                                   // Method 1
{
    string friend = Console.ReadLine();
    if (friend != "")   //string
    {
        names.Add(friend);
    }
    else
    {
        Console.WriteLine("Oops! Enter a name");
        AddToNames();
    }
}

Console.WriteLine("Hello! My name is Olya.");
names.Add("Olya");

Console.WriteLine("What is your name?");
AddToNames();                                       // The use of the method 1

Console.WriteLine("\nI and my friends Ira and Sergey are having a party!");
names.AddRange( new string[]  {"Ira", "Sergiy"});

Console.WriteLine("Come to the party and invite your friends!");
Console.WriteLine("What is your frend name?");      // The use of the method 1
AddToNames();

Console.WriteLine("\nWho else can you invite?");    // To do: add more friends using some loop?
AddToNames();                                     

Console.WriteLine($"\nWe are {names.Count}:");
Console.WriteLine(string.Join(", ", names));


// Part 2 - Organizing a party:

Console.WriteLine("\nWe need to organize everything.");

List<string> Party()                                   // Method 2
{
    int min = names.Select(name => name.Length).Min(); // way 1 to determine min/max
    int max = names.Max(name => name.Length);          // way 2 to determine min/max
    Console.WriteLine($"Enter a number from {min} to {max}");

    // Trying to think of some other choice of numbers:
    /* var letters = new List<int>();
       letters = names.Select(name => name.Length).ToList();
       Console.WriteLine($"Enter any of the numbers {string.Join(",", letters)}"); */

    string anumber = Console.ReadLine();

    if (anumber == "")  //string
    {
        Console.WriteLine("Oops! Enter a number");
        return Party();
    }

    // int number = int.ToUInt32(anumber); // returned an error if not a number
    // int number = int.Parse(anumber);    // returned an error if not a number
    // int number = int.TryParse(anumber, out int outnumber) ? outnumber : 0; // returned 0 if not parsed
    if (!int.TryParse(anumber, out int number))   //bool
    {
        Console.WriteLine("Oops! Enter a number");
        return Party();
    }

    var result = names.Where(name => name.Length == number).ToList();

    if (!result.Any()) // if the list is empty    //bool
    {
        Console.WriteLine("Oops!Enter another number");
        return Party();
    }
    return result;
}

Console.WriteLine("\nWho will take care of food and drinks?");
List<string> food = Party();                         // The use of the method 2
Console.WriteLine(string.Join(", ", food));

Console.WriteLine("\nWho is our DJ?");
List<string> music = Party();                        // The use of the method 2
Console.WriteLine(string.Join(", ", music));

Console.WriteLine("\nWho will create cool decorations?");
List<string> decor = Party();                        // The use of the method 2
Console.WriteLine(string.Join(", ", decor));


Console.WriteLine($"\nThanks for everything! See you at the party!");