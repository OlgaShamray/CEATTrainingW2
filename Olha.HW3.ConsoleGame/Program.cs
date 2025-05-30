
Console.WriteLine("Hello I have a number for you");
int min = 1;
int max = 100;
int number = 0; // the user's number
int randomnumber = 0;
string y = "y";
do
{
    randomnumber = new Random().Next(min, max);
    Console.WriteLine($"Please enter a number from {min} to {max}");
    int i = 0;  // the number of tries
    do
    {
        string anumber = Console.ReadLine();
        number = int.TryParse(anumber, out int outnumber) ? outnumber : 0;

        if (number == 0)
        {
            Console.WriteLine("Oops! Enter a number");
            continue; // skip the rest of the code in the loop // to not count this try
            //return; // exit the program
            //break;  // exit the loop
        }
        else if (number > randomnumber)
        {
            Console.WriteLine("The number is too big. Please try again");
        }
        else if (number < randomnumber)
        {
            Console.WriteLine("The number is too small. Please try again");
        }
        else
        {
            Console.WriteLine("Yes! The number is " + randomnumber);
        }
        i++; //count the number of tries

    } while (number != randomnumber);
    Console.WriteLine($"You guessed right on the {i} try!");

    Console.WriteLine("\nDo you want to play again? (y/n)");
    y = Console.ReadLine();
} while (y == "y" || y == "Y");