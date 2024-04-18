using System;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public string PosterPath { get; set; }
        public string HomePage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? LengthMinutes { get; set; }
        public int? DirectorId { get; set; }
        public int? CollectionId { get; set; }

        public Movie()
        {
        }

        public Movie(int id, string title, string overview, string tagline, string posterPath, string homePage,
                     DateTime? releaseDate, int? lengthMinutes, int? directorId, int? collectionId)
        {
           Id = id;
           Title = title;
           Overview = overview;
           Tagline = tagline;
           PosterPath = posterPath;
           HomePage = homePage;
           ReleaseDate = releaseDate;
           LengthMinutes = lengthMinutes;
           DirectorId = directorId;
           CollectionId = collectionId;
        }

    public override string ToString()
        {
            return "Movie{" +
                    "Id=" + Id +
                    ", Title='" + Title + '\'' +
                    ", Overview='" + Overview + '\'' +
                    ", Tagline='" + Tagline + '\'' +
                    ", PosterPath='" + PosterPath + '\'' +
                    ", HomePage='" + HomePage + '\'' +
                    ", ReleaseDate=" + ReleaseDate +
                    ", Length=" + LengthMinutes +
                    ", DirectorId=" + DirectorId +
                    ", CollectionId=" + CollectionId +
                    '}';
        }
    }
}
