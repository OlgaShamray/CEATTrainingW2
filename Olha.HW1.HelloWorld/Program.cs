// See https://aka.ms/new-console-template for more information


Console.WriteLine("\n\n ------- Question 1 -------\n");

//var name = "Olga";
Console.WriteLine("Hello! What is your name?");
var name = Console.ReadLine();
Console.WriteLine("\nHello " + name + "! Sring Combaining is used here. ");
Console.WriteLine($"Hello {name}! String Interpolation is used here.");
Console.WriteLine("The line below uses only the variable:");
Console.WriteLine(name);
Console.WriteLine($"Your name written all UPPERCASE looks like {name?.ToUpper()}.");
Console.WriteLine($"Your name written all lowercase looks like {name?.ToLower()}.");

Console.WriteLine("\nPress any key to continue");
Console.ReadKey();

Console.WriteLine("\n\n ------- Question 2. .Length property -------\n");

Console.WriteLine("What is your frend name?");
string? frend = Console.ReadLine();
Console.WriteLine($"{name} and {frend} are best friends!");
Console.WriteLine($"The name {name} has {name?.Length} letters.");
Console.WriteLine($"The name {frend} has {frend?.Length} letters.");

Console.WriteLine("\nPress any key to continue");
Console.ReadKey();


Console.WriteLine("\n\n ------- Question 3. .Trim() method -------\n");

Console.WriteLine("Enter a string with leading or trailing spaces, for example: ''   Orange    ''.");
string? text = Console.ReadLine();
Console.WriteLine($"You entered the ''{text}''");
Console.WriteLine($"Your trimmed string: ''{text?.Trim()}''");
Console.WriteLine($"Your string trimmed from start: ''{text?.TrimStart()}''");
Console.WriteLine($"Your string trimmed from end: ''{text?.TrimEnd()}''");

Console.WriteLine("\nPress any key to continue");
Console.ReadKey();


Console.WriteLine("\n\n ------- Question 4. .Replace method -------\n");

string? text1 = "Apple is the most delicious fruit!";
Console.WriteLine($"I think {text1}");
Console.WriteLine("What is your favorit fruit?");
string? fruit = Console.ReadLine();
text1 = text1.Replace("Apple",fruit);
Console.WriteLine(text1);

Console.WriteLine("\nPress any key to continue");
Console.ReadKey();


Console.WriteLine("\n\n ------- Question 5. .Contains() .StartsWith() .EndsWith() -------\n");

string text2 = "My favorite fruits are apple and pear";
Console.WriteLine($"'{text2}'\n");
Console.WriteLine("Write one of my favorite fruits");
string? myFavoriteFruit = Console.ReadLine();
Console.WriteLine($"It is {text2.Contains(myFavoriteFruit)}");

Console.WriteLine("\nPress any key to display results of using other searching methods");
Console.ReadKey();
Console.WriteLine($"My phrase starts with 'Your'. It is {text2.StartsWith("Your")}!");
Console.WriteLine($"My phrase starts with 'My'. It is {text2.StartsWith("My")}!");
Console.WriteLine($"My phrase ends with 'Apple'. It is {text2.EndsWith("apple")}!");
Console.WriteLine($"My phrase ends with 'Pear'. It is {text2.EndsWith("pear")}!");

Console.WriteLine("\nThank you! Bye!");
Console.ReadKey();
