package com.techelevator.movie.dao;

import com.techelevator.movie.exception.DaoException;
import com.techelevator.movie.model.Movie;
import com.techelevator.movie.model.Ticket;
import org.springframework.jdbc.CannotGetJdbcConnectionException;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class JdbcMovieDao implements MovieDao {

    private final JdbcTemplate jdbcTemplate;

    public JdbcMovieDao(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public List<Movie> getMovies() {
        List<Movie> movies = new ArrayList<>();

        String sql = "SELECT movie.movie_id, title, STRING_AGG(distinct p1.person_name, ',') AS director_name, " +
                "       STRING_AGG(distinct p2.person_name, ',') AS actors, STRING_AGG(distinct genre_name, ',') AS genres " +
                "FROM movie " +
                "LEFT JOIN person p1 ON movie.director_id = p1.person_id " +
                "LEFT JOIN movie_actor m1 ON movie.movie_id = m1.movie_ID " +
                "LEFT JOIN person p2 ON m1.actor_id = p2.person_id " +
                "LEFT JOIN movie_genre ON movie.movie_id = movie_genre.movie_id " +
                "LEFT JOIN genre ON movie_genre.genre_id = genre.genre_id " +
                "GROUP BY movie.movie_id;";
        try {
            SqlRowSet results = jdbcTemplate.queryForRowSet(sql);
            while (results.next()) {
                movies.add(mapRowToMovie(results));
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        }
        return movies;
    }

    @Override
    public Movie getMovieById(int id) {
        Movie movie = null;

        String sql = "SELECT movie.movie_id, title, STRING_AGG(distinct p1.person_name, ',') AS director_name, " +
                "       STRING_AGG(distinct p2.person_name, ',') AS actors, STRING_AGG(distinct genre_name, ',') AS genres " +
                "FROM movie " +
                "LEFT JOIN person p1 ON movie.director_id = p1.person_id " +
                "LEFT JOIN movie_actor m1 ON movie.movie_id = m1.movie_ID " +
                "LEFT JOIN person p2 ON m1.actor_id = p2.person_id " +
                "LEFT JOIN movie_genre ON movie.movie_id = movie_genre.movie_id " +
                "LEFT JOIN genre ON movie_genre.genre_id = genre.genre_id " +
                "WHERE movie.movie_id = ? " +
                "GROUP BY movie.movie_id" +
                "ORDER BY p2.person_name;";
        try {
            SqlRowSet results = jdbcTemplate.queryForRowSet(sql, id);
            if (results.next()) {
                movie = mapRowToMovie(results);
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        }
        return movie;
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

    public Movie mapRowToMovie(SqlRowSet rowSet) {
        // movie_id, title, director_name, actors, genres
        Movie movie = new Movie();
        movie.setMovieId(rowSet.getInt("movie_id"));
        movie.setTitle(rowSet.getString("title"));
        movie.setDirector(rowSet.getString("director_name"));
        movie.setActors(rowSet.getString("actors").split(","));
        movie.setGenres(rowSet.getString("genres").split(","));

        return movie;
    }
}
