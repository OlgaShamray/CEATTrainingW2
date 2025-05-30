public class Phone
{
    private List<Contact> contacts = new List<Contact>();                                 // encapsulation
    private List<Photo> photos = new List<Photo>();                                       // encapsulation
    public string Owner { get; set; }
    public double Capacity { get; set; }

    public Phone()
    {
        this.Owner = "No Name";
        this.Capacity = 5; //MB
    }

    private void AddContact(Contact newContact)                                          // encapsulation
    {
        ValidateAddContactCapacity();

        if (string.IsNullOrEmpty(newContact.Name))
        {
            throw new ArgumentNullException(nameof(newContact.Name), "Contact name cannot be null (1)");
        }
        if (string.IsNullOrEmpty(newContact.PhoneNumber))
        {
           
            throw new ArgumentNullException(nameof(newContact.PhoneNumber), "Phone number cannot be null (2)");
        }
        contacts.Add(newContact);
    }

    public void AddContact(string newName, string newPhoneNumber)
    {
        var newContact = new Contact(newName, newPhoneNumber);

        AddContact(newContact);
    }

    public void RemoveContact(string contactName)
    {
        if (string.IsNullOrEmpty(contactName))
        {
            throw new ArgumentNullException(nameof(contactName), "Contact name cannot be empty (3)");
        }
        var contactToRemove = FindContactByName(contactName);

        if (contactToRemove == null)
        {
            throw new ArgumentNullException(nameof(contactToRemove), "Contact with such name does not exist (4)");
        }
        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
            Console.WriteLine("The contact is removed.");
        }
    }

    public void ShowContacts()
    {
        Console.WriteLine("|{0,20}|{1,12}|", "Contact Name", "Phone number");
        Console.WriteLine("-----------------------------------");
        if (contacts.Count == 0)
        {
            Console.WriteLine("|           No contacts           |");
        }
        foreach (var contact in contacts)
        {
            Console.WriteLine("|{0,20}|{1,12}|", contact.Name, contact.PhoneNumber);
        }
    }

    public void TakePhoto()
    {
        var newPhoto = new Photo();
        double needsStorage = UsedStorage() + newPhoto.Size;

        if (needsStorage > Capacity)
        {
            throw new InvalidOperationException($"The new photo size is {newPhoto.Size} that will exсeed the phone capacity (5)");
        }
        photos.Add(newPhoto);
        Console.WriteLine("The photo is taken.");
    }

    public void RemovePhoto(int i)
    {
        if ((i < 1) || i > photos.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(i), "There is no photo with such number (6)");
        }
        photos.RemoveAt(i - 1);
        Console.WriteLine("The photo is deleted.");
    }

    public void ShowPhotos()
    {
        Console.WriteLine("|{0,5}|{1,27}|{2,10}|", "#", "Photo Name", "Size, MB");
        Console.WriteLine("---------------------------------------------");
        if (photos.Count == 0)
        {
            Console.WriteLine("|                 No photos                 |");
        }
        int i = 1;
        foreach (var photo in photos)
        {
            Console.WriteLine("|{0,5}|{1,27}|{2,10}|", i++, photo.Name, photo.Size);
        }
    }

    private double UsedStorage()                                                        // encapsulation
    {
        double usedStorageContacts = contacts.Count * 1; //1MB per contact
        double usedStoragePhoto = photos.Sum(x => x.Size);
        double usedStorage = usedStorageContacts + usedStoragePhoto;
        return usedStorage;
    }

    public void ShowStorageInfo()
    {
        Console.WriteLine($"Storage used {UsedStorage()} MB from {Capacity} MB\n");
    }

    public void ValidateAddContactCapacity()
    {
        double needsStorage = UsedStorage() + 1; //1MB per contact
        if (needsStorage > Capacity)
        {
            throw new InvalidOperationException("The phone storage is full. You cannot add more contacts (7)");
        }
    }

    public Contact FindContactByName(string contactName)
    {
        foreach (var contact in contacts)
        {
            if (contact.Name.ToLower() == contactName.ToLower())
            {
                return contact;
            }
        }
        return null;
    }

    public Contact FindContactByPhoneNumber(string phoneNumber)
    {
        foreach (var contact in contacts)
        {
            if (contact.PhoneNumber == phoneNumber)
            {
                return contact;
            }
        }
        return null;
    }
}

