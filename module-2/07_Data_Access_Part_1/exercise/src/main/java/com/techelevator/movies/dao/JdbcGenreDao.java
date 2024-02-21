package com.techelevator.movies.dao;

import com.techelevator.movies.model.Genre;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

import javax.sql.DataSource;
import java.util.ArrayList;
import java.util.List;

public class JdbcGenreDao implements GenreDao {

    private final JdbcTemplate jdbcTemplate;

    public JdbcGenreDao(DataSource dataSource) {
        this.jdbcTemplate = new JdbcTemplate(dataSource);
    }

    @Override
    public List<Genre> getGenres() {
        List<Genre> genres = new ArrayList<>();
        String sql = "SELECT * FROM genre";
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql);
        while(results.next()) {
            genres.add(new Genre(results.getInt("genre_id"), results.getString("genre_name")));
        }

        return genres;
    }

    @Override
    public Genre getGenreById(int id) {
        Genre genre = null;
        String sql = "SELECT genre_name FROM genre WHERE genre_id = ?;";
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql, id);
        if (results.next()) {
            genre = new Genre(id, results.getString("genre_name"));
        }
        return genre;
    }

    @Override
    public List<Genre> getGenresByName(String name, boolean useWildCard) {
        List<Genre> genres = new ArrayList<>();
        String holder = name;

        if (useWildCard) {
            name = "%" + name + "%";
        }
        String sql = "SELECT * FROM genre WHERE genre_name ILIKE ?;";
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql, name);

        while (results.next()) {
            Genre toAdd = new Genre(results.getInt("genre_id"), holder);
            genres.add(toAdd);
        }

        return genres;
    }
}
