namespace Movies.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Genre() { }

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return "Genre{" +
                    "Id=" + Id +
                    ", Name='" + Name + '\'' +
                    '}';
        }
    }
}
