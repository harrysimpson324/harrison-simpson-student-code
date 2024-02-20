package com.techelevator.dao;

import com.techelevator.model.City;
import com.techelevator.model.Park;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

import javax.sql.DataSource;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class JdbcParkDao implements ParkDao {

    private final JdbcTemplate jdbcTemplate;

    public JdbcParkDao(DataSource dataSource) {
        this.jdbcTemplate = new JdbcTemplate(dataSource);
    }

    @Override
    public int getParkCount() {
        int count = 0;
        String sql = "SELECT COUNT(*) AS count FROM park;";
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql);
        if (results.next()) {
            count = results.getInt("count");
        }
        return count;
    }
    
    @Override
    public LocalDate getOldestParkDate() {
        LocalDate dateEstablished = null;

        String sql = "SELECT MIN(date_established) AS date_established " +
                     "FROM park;";
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql);
        if (results.next()) {
            if (results.getDate("date_established") != null) {
                dateEstablished = results.getDate("date_established").toLocalDate();
            }
        }

        return dateEstablished;
    }
    
    @Override
    public double getAverageParkArea() {
        double avgArea = 0.0;
        String sql = "SELECT AVG(area) AS avg_area FROM park;";
        SqlRowSet results = jdbcTemplate.queryForRowSet(sql);
        if (results.next()) {
            avgArea = results.getDouble("avg_area");
        }

        return avgArea;
    }
    
    @Override
    public List<String> getParkNames() {
        return new ArrayList<>();
    }
    
    @Override
    public Park getRandomPark() {
        return new Park();
    }

    @Override
    public List<Park> getParksWithCamping() {
        return new ArrayList<>();
    }

    @Override
    public Park getParkById(int parkId) {
        return new Park();
    }

    @Override
    public List<Park> getParksByState(String stateAbbreviation) {
        return new ArrayList<>();
    }

    @Override
    public List<Park> getParksByName(String name, boolean useWildCard) {
        List<Park> parks = new ArrayList<>();
        String sql = "SELECT park_id, park_name, date_established, area, has_camping FROM park " +
                     "WHERE park_name ILIKE ?;";

        if (useWildCard) {
            name = "%" + name + "%";
        }

        SqlRowSet results = jdbcTemplate.queryForRowSet(sql, name);
        while (results.next()) {
            Park park = mapRowToPark(results);
            parks.add(park);
//            parks.add(mapRowToPark(results));
        }


        return parks;
    }

    private Park mapRowToPark(SqlRowSet rowSet) {
        Park park = new Park();
        park.setParkId(rowSet.getInt("park_id"));
        park.setParkName(rowSet.getString("park_name"));
        park.setDateEstablished(rowSet.getDate("date_established").toLocalDate());
        park.setArea(rowSet.getDouble("area"));
        park.setHasCamping(rowSet.getBoolean("has_camping"));

        return park;
    }


}
