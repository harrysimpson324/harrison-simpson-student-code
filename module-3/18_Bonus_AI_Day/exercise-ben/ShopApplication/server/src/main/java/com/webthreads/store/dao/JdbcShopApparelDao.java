package com.webthreads.store.dao;

import com.webthreads.store.exception.DaoException;
import com.webthreads.store.model.Apparel;
import com.webthreads.store.model.ShopApparel;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.jdbc.CannotGetJdbcConnectionException;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class JdbcShopApparelDao implements ShopApparelDao {

    private final JdbcTemplate jdbcTemplate;

    String ORDER_BY = " ORDER BY apparel_id ASC";

    @Autowired
    public JdbcShopApparelDao(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public List<Apparel> getShopInventory(int shopId) {
        List<Apparel> apparels = new ArrayList<>();
        String apparelSql = "SELECT apparel_id, title, description, size, price FROM apparel " +
                            "WHERE apparel_id IN (SELECT apparel_id FROM shop_apparel WHERE shop_id = ?) " +
                            ORDER_BY;
        String shopApparelSql = "SELECT shop_id, apparel_id, quantity FROM shop_apparel WHERE shop_id = ? " +
                                ORDER_BY;
        try {
            SqlRowSet apparelResults = jdbcTemplate.queryForRowSet(apparelSql, shopId);
            while (apparelResults.next()) {
                Apparel apparel = mapRowToApparel(apparelResults);
                apparels.add(apparel);
            }
            if (apparels.size() > 0) {
                SqlRowSet shopApparelResults = jdbcTemplate.queryForRowSet(shopApparelSql, shopId);
                while (shopApparelResults.next()) {
                    ShopApparel shopApparel = mapRowToShopApparel(shopApparelResults);
                    for (Apparel apparel : apparels) {
                        if (shopApparel.getApparelId() == apparel.getApparelId()) {
                            apparel.setShopInventory(shopApparel);
                            break; // no need to keep looping through apparels
                        }
                    }
                }
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        } catch (DataIntegrityViolationException e) {
            throw new DaoException("Data integrity violation", e);
        }
        return apparels;
    }

    @Override
    public Apparel getShopInventoryByApparelId(int shopId, int apparelId) {
        Apparel apparel = null;
        String apparelSql = "SELECT apparel_id, title, description, size, price FROM apparel " +
                            "WHERE apparel_id IN (SELECT apparel_id FROM shop_apparel WHERE shop_id = ? AND apparel_id = ?) ";
        String shopApparelSql = "SELECT shop_id, apparel_id, quantity FROM shop_apparel WHERE shop_id = ? AND apparel_id = ? ";
        try {
            SqlRowSet apparelResults = jdbcTemplate.queryForRowSet(apparelSql, shopId, apparelId);
            if (apparelResults.next()) {
                apparel = mapRowToApparel(apparelResults);
            }
            if (apparel != null) {
                SqlRowSet shopApparelResults = jdbcTemplate.queryForRowSet(shopApparelSql, shopId, apparelId);
                if (shopApparelResults.next()) {
                    ShopApparel shopApparel = mapRowToShopApparel(shopApparelResults);
                    apparel.setShopInventory(shopApparel);
                }
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        } catch (DataIntegrityViolationException e) {
            throw new DaoException("Data integrity violation", e);
        }
        return apparel;
    }

    @Override
    public void linkShopApparel(int shopId, int apparelId) {
        String sql = "INSERT INTO shop_apparel (shop_id, apparel_id, quantity) VALUES (?, ?, 0)";
        try {
            jdbcTemplate.update(sql, shopId, apparelId);
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        } catch (DataIntegrityViolationException e) {
            throw new DaoException("Data integrity violation", e);
        }
    }

    @Override
    public Apparel updateShopApparel(int shopId, int apparelId, int quantity) {
        String sql = "UPDATE shop_apparel SET quantity = ? WHERE shop_id = ? AND apparel_id = ?";
        try {
            jdbcTemplate.update(sql, quantity, shopId, apparelId);
            return getShopInventoryByApparelId(shopId, apparelId);
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        } catch (DataIntegrityViolationException e) {
            throw new DaoException("Data integrity violation", e);
        }
    }

    @Override
    public void unlinkShopApparel(int shopId, int apparelId) {
        String sql = "DELETE FROM shop_apparel WHERE shop_id = ? AND apparel_id = ?";
        try {
            jdbcTemplate.update(sql, shopId, apparelId);
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        } catch (DataIntegrityViolationException e) {
            throw new DaoException("Data integrity violation", e);
        }
    }

    @Override
    public List<Apparel> getApparelsNotInShop(int shopId) {
        List<Apparel> apparels = new ArrayList<>();
        String sql = "SELECT apparel_id, title, description, size, price FROM apparel " +
                     "WHERE apparel_id NOT IN (SELECT apparel_id FROM shop_apparel WHERE shop_id = ?) " +
                     ORDER_BY;
        try {
            SqlRowSet results = jdbcTemplate.queryForRowSet(sql, shopId);
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

    private Apparel mapRowToApparel(SqlRowSet rs) {
        Apparel apparel = new Apparel();
        apparel.setApparelId(rs.getInt("apparel_id"));
        apparel.setTitle(rs.getString("title"));
        apparel.setDescription(rs.getString("description"));
        apparel.setSize(rs.getString("size"));
        apparel.setPrice(rs.getBigDecimal("price"));

        return apparel;
    }

    private ShopApparel mapRowToShopApparel(SqlRowSet rs) {
        ShopApparel shopApparel = new ShopApparel();
        shopApparel.setShopId(rs.getInt("shop_id"));
        shopApparel.setApparelId(rs.getInt("apparel_id"));
        shopApparel.setQuantity(rs.getInt("quantity"));
        return shopApparel;
    }
}
