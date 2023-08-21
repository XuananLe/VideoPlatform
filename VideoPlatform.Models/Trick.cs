namespace VideoPlatform.API.Models;

public class Trick
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Video { get; set; }
    
    public Trick(string name)
    {
        Name = name;
    }
    public Trick(int id, string name, string video)
    {
        Id = id;
        Name = name;
        Video = video;
    }
    
    public Trick()
    {
        Name = "";
        Id = 0;
        Video = "";
    }
    
}