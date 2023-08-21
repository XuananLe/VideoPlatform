namespace VideoPlatform.Models;

public class Submission
{
    public int Id { get; set; }
    public string Video { get; set; }
    public string Description { get; set; }

    public Submission()
    {
        Id = 0;
        Video = "";
        Description = "";
    }
}