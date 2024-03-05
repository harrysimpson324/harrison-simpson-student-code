package com.techelevator.movie.dao;

import com.techelevator.movie.exception.DaoException;
import com.techelevator.movie.model.Movie;
import org.springframework.jdbc.CannotGetJdbcConnectionException;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class JdbcMovieDao implements MovieDao {

    private final JdbcTemplate jdbcTemplate;

    public JdbcMovieDao(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public List<Movie> getMovies() {
        return null;
    }

    public String getMovieTitle(int id) {
        String title = "";
        String sql = "SELECT title FROM movie WHERE movie_id = ?;";
        try {
            title = jdbcTemplate.queryForObject(sql, String.class, id);
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        }

        return title;
    }
}
