using System.Globalization;

var enUSformat = System.Globalization.CultureInfo.GetCultureInfo("en-US");
List<double> numbers = new List<double> { 0.5, -1.8, 2.20, 3.14, 4, 5.025, 6.300, 7.777 };


Console.WriteLine("=== 1 === \n");
//Task1. For each element, add its index to its value, and output the resulting collection to console
List<double> numbers1 = new List<double>();
foreach (var number in numbers)
{
    numbers1.Add(number + numbers.IndexOf(number));
}
Console.WriteLine("Initial collection: ");
Console.WriteLine(string.Join(", ", numbers.Select(x => x.ToString("0.###", enUSformat)))); // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings?spm=5aebb161.41936baa.0.0.734c4adeifWvDB
Console.WriteLine("Resulting collection: ");
Console.WriteLine(string.Join(", ", numbers1.Select(x => x.ToString("0.###", enUSformat))));


Console.WriteLine("\n=== 2 === \n");
//Task 2. Output elements of the collection one by one (use console.readline as a separator), until user enters "x" to the program
OutputOneByOne(numbers1, enUSformat);


Console.WriteLine("\n=== 3 === \n");
//Task 3. Read numbers one by one from console and save them to new collection. Do that until user enters "not a number" string
List<double> numbers3 = InputOneByOne(enUSformat);
//OutputOneByOne(numbers3, enUSformat);


Console.WriteLine("\n=== 4 === \n");
//Task 4. if there are 0 elements in the new collection after step 3, repeat it (until user enters some numbers),
// then repeat step 2 (output numbers until user enters "x"
Console.WriteLine($"New collections contains {numbers3.Count} elements\n");
while (numbers3.Count == 0)
{
    numbers3 = InputOneByOne(enUSformat);
}
OutputOneByOne(numbers3, enUSformat);


#region InputOneByOn method
List<double> InputOneByOne(CultureInfo cultureinfo)
{
    List<double> newCollection = new List<double>();

    Console.WriteLine("Enter a number for new collection");
    string userInput = Console.ReadLine();

    while (double.TryParse(userInput.Replace(",", "."), cultureinfo, out double outnumber))
    {
        newCollection.Add(outnumber);
        Console.WriteLine("Enter the next number or enter \"not a number\" to stop");
        userInput = Console.ReadLine();
    }
    return newCollection;
}
#endregion  

#region OutputOneByOne method
void OutputOneByOne(List<double> collectionName, CultureInfo cultureinfo)
{
    if (collectionName.Count == 0)
    {
        Console.WriteLine("No elements in the collection");
    }
    else
    {
        Console.WriteLine("Enter any key to output elements of the collection one by one or enter 'x' to exit");
        foreach (var number in collectionName)
        {
            if (Console.ReadLine() == "x")
            {
                break;
            }
            else
            {
                Console.WriteLine(number.ToString("0.###", cultureinfo));
            }
        }
    }
}
#endregion