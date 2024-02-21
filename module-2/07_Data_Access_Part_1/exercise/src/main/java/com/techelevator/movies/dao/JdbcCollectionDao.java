package com.techelevator.movies.dao;

import com.techelevator.movies.model.Collection;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

import javax.sql.DataSource;
import java.util.ArrayList;
import java.util.List;

public class JdbcCollectionDao implements CollectionDao{

    private final JdbcTemplate jdbcTemplate;

    public JdbcCollectionDao(DataSource dataSource) {
        this.jdbcTemplate = new JdbcTemplate(dataSource);
    }

    @Override
    public List<Collection> getCollections() {
        List<Collection> collections = new ArrayList<>();
        SqlRowSet results = jdbcTemplate.queryForRowSet("SELECT * FROM collection ORDER BY collection_id ASC;");
        while(results.next()) {
            Collection collection = new Collection(results.getInt("collection_id"), results.getString("collection_name"));
            collections.add(collection);
        }
        return collections;
    }

    @Override
    public Collection getCollectionById(int id) {
        SqlRowSet resultById = jdbcTemplate.queryForRowSet("SELECT collection_name FROM collection WHERE collection_id = ?;", id);
        if (resultById.next()) {
            return new Collection(id, resultById.getString("collection_name"));
        }

        return null;

    }

    @Override
    public List<Collection> getCollectionsByName(String name, boolean useWildCard) {

        SqlRowSet results = null;
        List<Collection> collections = new ArrayList<>();


        if (useWildCard) {
            String wildName = "%" + name + "%";
            String sql = "SELECT * FROM collection WHERE collection_name ILIKE ?;";
            results = jdbcTemplate.queryForRowSet(sql, wildName);
        }
        else {
            String sql = "SELECT * FROM collection WHERE collection_name ILIKE ?;";
            results = jdbcTemplate.queryForRowSet(sql, name);
        }

        while(results.next()) {
            Collection toAdd = new Collection(results.getInt("collection_id"), results.getString("collection_name"));
            collections.add(toAdd);
        }


        return collections;
    }
}
