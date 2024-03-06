package com.techelevator.movie.dao;

import com.techelevator.movie.model.Movie;

import java.util.List;

public interface MovieDao {
    public List<Movie> getMovies();

    public String getMovieTitle(int id);
}
