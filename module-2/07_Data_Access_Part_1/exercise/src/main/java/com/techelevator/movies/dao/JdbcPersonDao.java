package com.techelevator.movies.dao;

import com.techelevator.movies.model.Movie;
import com.techelevator.movies.model.Person;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

import javax.sql.DataSource;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class JdbcPersonDao implements PersonDao {

    private final JdbcTemplate jdbcTemplate;

    public JdbcPersonDao(DataSource dataSource) {
        this.jdbcTemplate = new JdbcTemplate(dataSource);
    }

    @Override
    public List<Person> getPersons() {
        List<Person> people = new ArrayList<>();
        String sql = "SELECT * FROM person;";
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql);
        while (results.next()) {
            Person toAdd = mapPerson(results);
            people.add(toAdd);
        }
        return people;
    }

    @Override
    public Person getPersonById(int id) {
        Person person = null;
        String sql = "SELECT * FROM person WHERE person_id = ?";
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql, id);
        if (results.next()) {
            person = mapPerson(results);
        }
        return person;
    }

    @Override
    public List<Person> getPersonsByName(String name, boolean useWildCard) {
        List<Person> people = new ArrayList<>();
        String sql = "SELECT * FROM person WHERE person_name ILIKE ?";
        if (useWildCard) {
            name = "%" + name + "%";
        }
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql, name);

        while (results.next()) {
            Person toAdd = mapPerson(results);
            people.add(toAdd);
        }


        return people;
    }

    @Override
    public List<Person> getPersonsByCollectionName(String collectionName, boolean useWildCard) {
        List<Person> people = new ArrayList<>();
        String sql = "SELECT DISTINCT person_id, person_name, birthday, deathday, biography, profile_path, p2.home_page FROM collection " +
                "JOIN movie ON collection.collection_id = movie.collection_id " +
                "JOIN movie_actor ON movie.movie_id = movie_actor.movie_id " +
                "JOIN person p2 ON movie_actor.actor_id = p2.person_id " +
                "WHERE collection_name ILIKE ?;";
        if (useWildCard) {
            collectionName = "%" + collectionName + "%";
        }
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql, collectionName);

        while(results.next()) {
            Person toAdd = mapPerson(results);
            people.add(toAdd);
        }


        return people;
    }

    public Person mapPerson(SqlRowSet rowSet) {

        int id = rowSet.getInt("person_id");
        String name = rowSet.getString("person_name");
        LocalDate birthday = null;
        if (rowSet.getDate("birthday") != null) {
            birthday = rowSet.getDate("birthday").toLocalDate();
        }
        LocalDate deathday = null;
        if (rowSet.getDate("deathday") != null) {
            deathday = rowSet.getDate("deathday").toLocalDate();
        }
        String biography = rowSet.getString("biography");
        String profilePath = rowSet.getString("profile_path");
        String homePage = rowSet.getString("home_page");

        Person person = new Person(id, name, birthday, deathday, biography, profilePath,
                    homePage);
        return person;

    }
}
