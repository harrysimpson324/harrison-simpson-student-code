package com.techelevator.movie.model;

import java.util.List;

public class Movie {
    private int movieId;
    private String title;
    private String[] genres;
    private String[] actors;
    private String director;

    public Movie() {

    }

    public Movie(int movieId, String title, String[] genres, String[] actors, String director) {
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

    public String[] getGenres() {
        return genres;
    }

    public String[] getActors() {
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

    public void setGenres(String[] genres) {
        this.genres = genres;
    }

    public void setActors(String[] actors) {
        this.actors = actors;
    }

    public void setDirector(String director) {
        this.director = director;
    }
}
