package com.techelevator.movie.dao;

import com.techelevator.movie.model.Movie;

import java.util.List;

public interface MovieDao {
    public List<Movie> getMovies();
    public Movie getMovieById(int id);

    public String getMovieTitle(int id);
}
