namespace Movies.Models
{
    public class Collection
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Collection() { }

        public Collection(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return "Collection{" +
                    "Id=" + Id +
                    ", Name='" + Name + '\'' +
                    '}';
        }
    }
}
