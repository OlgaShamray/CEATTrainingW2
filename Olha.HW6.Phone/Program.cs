Console.WriteLine("Hello, it is your Phone");
Console.WriteLine("Select the action and enter it's number:\n");
Console.WriteLine("1. Add contact");
Console.WriteLine("2. Remove contact");
Console.WriteLine("3. Show contacts");
Console.WriteLine("4. Take a photo");
Console.WriteLine("5. Show photos");
Console.WriteLine("6. Delete photo");
Console.WriteLine("7. Show used storage");
Console.WriteLine("0. Turn off the phone\n");

var phone = new Phone();

while (true)
{
    string action = Console.ReadLine();
    switch (action)
    {
        case "1": // Add contact
            try
            {
                phone.ValidateAddContactCapacity();

                Console.WriteLine("Enter the name of the contact:");
                string newName = Console.ReadLine();
                Console.WriteLine("Enter the phone number of the contact:");
                string newPhoneNumber = Console.ReadLine();

                var foundContact = phone.FindContactByPhoneNumber(newPhoneNumber);

                if (foundContact != null)
                {
                    Console.WriteLine($"Contact {foundContact.Name} with such phone number already exists.");
                    Console.WriteLine("Do you want to update the contact name? (y/n)");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y")
                    {
                        foundContact.Name = newName;
                        Console.WriteLine("The contact is updated.");
                    }
                }
                else
                {
                    phone.AddContact(newName, newPhoneNumber);
                    Console.WriteLine("The contact is added.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error message 11: {ex.Message}");
                //throw new InvalidOperationException("Invalid operation 11", ex);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error message 12: {ex.Message}");
                //throw new InvalidOperationException("Invalid operation 12", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message 13: {ex.Message}");
                //throw new InvalidOperationException("Invalid operation 13", ex);
            }
            Console.WriteLine("Select the next Action\n");
            break;

        case "2": // Remove contact
            try
            {
                Console.WriteLine("Enter the name of the contact:");
                string contactName = Console.ReadLine();
                phone.RemoveContact(contactName);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error message 21: {ex.Message}");
                //throw new InvalidOperationException("Invalid operation 21", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message 22: {ex.Message}");
                //throw new InvalidOperationException("Invalid operation 22", ex);
            }
            Console.WriteLine("Select the next Action\n");
            break;

        case "3": // Show contacts
            phone.ShowContacts();
            Console.WriteLine("\nSelect the next Action\n");
            break;

        case "4": // Take photo
            try
            {
                phone.TakePhoto();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error message 41: {ex.Message}");
                //throw new InvalidOperationException("Invalid operation 41", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message 42: {ex.Message}");
                //throw new InvalidOperationException("Invalid operation 42", ex);
            }
            Console.WriteLine("Select the next Action\n");
            break;

        case "5": // Show photos
            phone.ShowPhotos();
            Console.WriteLine("\nSelect the next Action\n");
            break;

        case "6": // Delete photo
            try
            {
                Console.WriteLine("Enter the number of the photo you want to delete:");
                int number = int.TryParse(Console.ReadLine(), out int notnumber) ? notnumber : 0;
                phone.RemovePhoto(number);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error message 61: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message 62: {ex.Message}");
            }
            Console.WriteLine("\nSelect the next Action\n");
            break;

        case "7": // Show used storage
            phone.ShowStorageInfo();
            break;

        case "0": // Turn off the phone
            Console.WriteLine("The phone is turned off");
            return;

        default:
            Console.WriteLine("There is no such action");
            break;
    }
}


