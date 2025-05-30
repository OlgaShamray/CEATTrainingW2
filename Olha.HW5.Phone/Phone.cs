
public class Phone
{
        private List<Contact> contacts = new List<Contact>();
    private List<Photo> photos = new List<Photo>();
    public string Owner { get; set; }
    public double Capacity { get; set; }

    public Phone()
    {
        this.Owner = "No Name";
        this.Capacity = 1000; //MB
    }

    public void AddContact(Contact newContact)
    {
        contacts.Add(newContact);
    }

    public void RemoveContact(Contact contact)
    {
        contacts.Remove(contact);
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
        photos.Add(new Photo());
    }

    public void RemovePhoto(int i)
    {
        photos.RemoveAt(i - 1);
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

    public int PhotosCount()
    {
        return photos.Count;
    }

    public double UsedStorage()
    {
        double usedStorageContacts = contacts.Count * 1; //1MB per contact
        double usedStoragePhoto = photos.Sum(x => x.Size);
        double usedStorage = usedStorageContacts + usedStoragePhoto;
        return usedStorage;
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

