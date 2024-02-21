package com.techelevator.movies.dao;

import com.techelevator.movies.model.Movie;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

import javax.sql.DataSource;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class JdbcMovieDao implements MovieDao {

    private final JdbcTemplate jdbcTemplate;

    public JdbcMovieDao(DataSource dataSource) {
        this.jdbcTemplate = new JdbcTemplate(dataSource);
    }

    @Override
    public List<Movie> getMovies() {

        List<Movie> movies = new ArrayList<>();
        String sql = "SELECT * FROM movie;";
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql);

        while (results.next()) {
            Movie toAdd = mapMovie(results);
            movies.add(toAdd);
        }
        return movies;
    }

    @Override
    public Movie getMovieById(int id) {

        String sql = "SELECT * FROM movie WHERE movie_id = ?";
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql, id);

        Movie movie = null;
        if (results.next()) {
            movie = mapMovie(results);
        }
        return movie;

    }

    @Override
    public List<Movie> getMoviesByTitle(String title, boolean useWildCard) {

        List<Movie> movies = new ArrayList<>();

        String sql = "SELECT * FROM movie WHERE title ILIKE ?";
        if(useWildCard) {
            title = "%" + title + "%";
        }
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql, title);
        while(results.next()) {
            Movie movie = mapMovie(results);
            movies.add(movie);
        }

        return movies;
    }

    @Override
    public List<Movie> getMoviesByDirectorNameAndBetweenYears(String directorName, int startYear,
                                                              int endYear, boolean useWildCard) {

        List<Movie> movies = new ArrayList<>();
        String sql = "SELECT movie_id, title, overview, tagline, poster_path, movie.home_page, release_date, length_minutes, " +
                "director_id, collection_id FROM movie JOIN person ON person.person_id = movie.director_id " +
                "WHERE person_name ILIKE ? AND release_date BETWEEN ? AND ?;";
        LocalDate start = LocalDate.of(startYear, 1, 1);
        LocalDate end = LocalDate.of(endYear, 12, 31);


        if (useWildCard) {
            directorName = "%" + directorName + "%";
        }

        SqlRowSet results = jdbcTemplate.queryForRowSet(sql, directorName, start, end);
        while (results.next()) {
            Movie toAdd = mapMovie(results);
            movies.add(toAdd);
        }

        return movies;
    }

    public Movie mapMovie(SqlRowSet rowSet) {

        int id = rowSet.getInt("movie_id");
        String title = rowSet.getString("title");
        String overview = rowSet.getString("overview");
        String tagline = rowSet.getString("tagline");
        String posterPath = rowSet.getString("poster_path");
        String homePage = rowSet.getString("home_page");
        LocalDate releaseDate = null;
        if (rowSet.getDate("release_date") != null) {
            releaseDate = rowSet.getDate("release_date").toLocalDate();
        }
        int lengthMinutes = rowSet.getInt("length_minutes");
        int directorId = rowSet.getInt("director_id");
        int collectionId = rowSet.getInt("collection_id");

        Movie movie = new Movie(id, title, overview, tagline, posterPath,
                homePage, releaseDate, lengthMinutes, directorId, collectionId);


        return movie;
    }
}
