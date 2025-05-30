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
        case "1":
            Console.WriteLine("Enter the name of the contact:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the phone number of the contact:");
            string phoneNumber = Console.ReadLine();
            var newContact = new Contact(name, phoneNumber);

            var foundContact = phone.FindContactByPhoneNumber(newContact.PhoneNumber);
            if (foundContact == null)
            {
                phone.AddContact(newContact);
                Console.WriteLine("The contact is added. Select the next Action\n");
            }
            else
            {
                Console.WriteLine($"Contact {foundContact.Name} with such phone number already exists");
                Console.WriteLine("Do you want to update the contact name? (y/n)");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    foundContact.Name = newContact.Name;
                    Console.WriteLine("The contact is updated. Select the next Action\n");
                }
                else
                {
                    Console.WriteLine("Select the next Action\n");
                }
            }
            break;
        case "2":
            Console.WriteLine("Enter the name of the contact:");
            string contactName = Console.ReadLine();
            var contactToRemove = phone.FindContactByName(contactName);
            if (contactToRemove != null)
            {
                phone.RemoveContact(contactToRemove);
                Console.WriteLine("The contact is removed. Select the next Action\n");
            }
            else
            {
                Console.WriteLine("Contact with such name does not exist. Select the next Action\n");
            }
            break;
        case "3":
            phone.ShowContacts();
            Console.WriteLine("\nSelect the next Action\n");
            break;
        case "4":
            phone.TakePhoto();
            Console.WriteLine("The photo is taken. Select the next Action\n");
            break;
        case "5":
            phone.ShowPhotos();
            Console.WriteLine("\nSelect the next Action\n");
            break;
        case "6":
            Console.WriteLine("Enter the number of the photo you want to delete:");
            int number = int.TryParse(Console.ReadLine(), out int notnumber) ? notnumber : 0;
            if (number > 0 && number <= phone.PhotosCount())
            {
                phone.RemovePhoto(number);
                Console.WriteLine("The photo is deleted. Select the next Action\n");
            }
            else
            {
                Console.WriteLine("There is no photo with such number. Select the next Action\n");
            }
            break;
        case "7":
            Console.WriteLine($"Storage used {phone.UsedStorage()} MB from {phone.Capacity} MB\n");
            break;
        case "0":
            Console.WriteLine("The phone is turned off");
            return;
        default:
            Console.WriteLine("There is no such action");
            break;
    }
}



