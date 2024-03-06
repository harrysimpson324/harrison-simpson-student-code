package com.techelevator.movie.model;

import java.util.List;

public class Movie {
    private int movieId;
    private String title;
    private List<String> genres;
    private List<String> actors;
    private String director;

    public Movie(int movieId, String title, List<String> genres, List<String> actors, String director) {
        this.movieId = movieId;
        this.title = title;
        this.genres = genres;
        this.actors = actors;
        this.director = director;
    }

    public int getMovieId() {
        return movieId;
    }

    public String getTitle() {
        return title;
    }

    public List<String> getGenres() {
        return genres;
    }

    public List<String> getActors() {
        return actors;
    }

    public String getDirector() {
        return director;
    }

    public void setMovieId(int movieId) {
        this.movieId = movieId;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setGenres(List<String> genres) {
        this.genres = genres;
    }

    public void setActors(List<String> actors) {
        this.actors = actors;
    }

    public void setDirector(String director) {
        this.director = director;
    }
}
