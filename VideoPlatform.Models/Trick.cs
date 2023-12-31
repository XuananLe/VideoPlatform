namespace VideoPlatform.Models
{
    public class Trick
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Trick(string name)
        {
            Name = name;
        }

        public Trick(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Trick()
        {
            Name = "";
            Id = 0;
        }
    }

    // 1 trick has many submissions
}