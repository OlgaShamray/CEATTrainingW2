public class Photo
{
    public string Name { get; set; }
    public string Date { get; set; }
    public double Size { get; set; }

    public Photo()
    {
        Name = "IMG_" + DateTime.Now.ToString("yyyy-mm-dd_HH-mm-ss-fff");
        Date = DateTime.Now.ToString();
        Size = new Random().Next(1, 20); //MB
    }
}
