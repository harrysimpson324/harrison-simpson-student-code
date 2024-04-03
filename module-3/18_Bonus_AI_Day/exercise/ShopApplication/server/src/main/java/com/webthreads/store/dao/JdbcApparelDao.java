package com.webthreads.store.dao;

import com.webthreads.store.exception.DaoException;
import com.webthreads.store.model.Apparel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.jdbc.CannotGetJdbcConnectionException;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class JdbcApparelDao implements ApparelDao {

    private final JdbcTemplate jdbcTemplate;

    String APPAREL_SELECT = "SELECT apparel_id, title, description, size, price FROM apparel ";
    String ORDER_BY = " ORDER BY apparel_id ASC";

    @Autowired
    public JdbcApparelDao(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public List<Apparel> getApparels() {
        List<Apparel> apparels = new ArrayList<>();
        String sql = APPAREL_SELECT + ORDER_BY;
        try {
            SqlRowSet results = jdbcTemplate.queryForRowSet(sql);
            while (results.next()) {
                Apparel apparel = mapRowToApparel(results);
                apparels.add(apparel);
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        } catch (DataIntegrityViolationException e) {
            throw new DaoException("Data integrity violation", e);
        }
        return apparels;
    }

    @Override
    public Apparel getApparelById(int id) {
        Apparel apparel = null;
        String sql = APPAREL_SELECT + "WHERE apparel_id = ?";
        try {
            SqlRowSet results = jdbcTemplate.queryForRowSet(sql, id);
            if (results.next()) {
                apparel = mapRowToApparel(results);
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        } catch (DataIntegrityViolationException e) {
            throw new DaoException("Data integrity violation", e);
        }
        return apparel;
    }

    @Override
    public Apparel createApparel(Apparel apparel) {
        Apparel newApparel = null;
        String sql = "INSERT INTO apparel (title, description, size, price) VALUES (?, ?, ?, ?) RETURNING apparel_id";
        try {
            int newId = jdbcTemplate.queryForObject(sql, int.class, apparel.getTitle(), apparel.getDescription(), apparel.getSize(), apparel.getPrice());
            newApparel = getApparelById(newId);
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        } catch (DataIntegrityViolationException e) {
            throw new DaoException("Data integrity violation", e);
        }
        return newApparel;
    }

    @Override
    public Apparel updateApparel(Apparel apparel) {
        Apparel updatedApparel = null;
        String sql = "UPDATE apparel SET title = ?, description = ?, size = ?, price = ? WHERE apparel_id = ?";
        try {
            int rowsAffected = jdbcTemplate.update(sql, apparel.getTitle(), apparel.getDescription(), apparel.getSize(), apparel.getPrice(), apparel.getApparelId());

            if (rowsAffected == 0) {
                throw new DaoException("Zero rows affected, expected at least one");
            } else {
                updatedApparel = getApparelById(apparel.getApparelId());
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        } catch (DataIntegrityViolationException e) {
            throw new DaoException("Data integrity violation", e);

        }

        return updatedApparel;
    }

    @Override
    public int deleteApparelById(int id) {
        int numOfRowsAffected = 0;
        String shopApparelSql = "DELETE FROM shop_apparel WHERE apparel_id = ?; ";
        String apparelSql = "DELETE FROM apparel WHERE apparel_id = ?";
        try {
            jdbcTemplate.update(shopApparelSql, id);
            numOfRowsAffected = jdbcTemplate.update(apparelSql, id);
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        } catch (DataIntegrityViolationException e) {
            throw new DaoException("Data integrity violation", e);
        }
        return numOfRowsAffected;
    }

    private Apparel mapRowToApparel(SqlRowSet rs) {
        Apparel apparel = new Apparel();
        apparel.setApparelId(rs.getInt("apparel_id"));
        apparel.setTitle(rs.getString("title"));
        apparel.setDescription(rs.getString("description"));
        apparel.setSize(rs.getString("size"));
        apparel.setPrice(rs.getBigDecimal("price"));
        return apparel;
    }
}