using System;

namespace Movies.Models
{
    public class Person
    {
        public int Id;
        public string Name;
        public DateTime? Birthday;
        public DateTime? DeathDate;
        public string Biography;
        public string ProfilePath;
        public string HomePage;

        public Person()
        {
        }

        public Person(int id, string name, DateTime? birthday, DateTime? deathDate, string biography, string profilePath, string homePage)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            DeathDate = deathDate;
            Biography = biography;
            ProfilePath = profilePath;
            HomePage = homePage;
        }

    public override string ToString()
        {
            return "Person{" +
                    "Id=" + Id +
                    ", Name='" + Name + '\'' +
                    ", Birthday=" + Birthday +
                    ", DeathDate=" + DeathDate +
                    ", Biography='" + Biography + '\'' +
                    ", ProfilePath='" + ProfilePath + '\'' +
                    ", HomePage='" + HomePage + '\'' +
                    '}';
        }
    }
}
