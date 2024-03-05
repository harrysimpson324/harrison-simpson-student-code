package com.techelevator.movie.dao;

import com.techelevator.movie.model.Movie;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class JdbcMovieDao implements MovieDao {
    @Override
    public List<Movie> getMovies() {
        return null;
    }
}
