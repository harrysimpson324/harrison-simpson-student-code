package com.webthreads.store.dao;

import com.webthreads.store.exception.DaoException;
import com.webthreads.store.model.Shop;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.CannotGetJdbcConnectionException;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class JdbcShopDao implements ShopDao {

    private final JdbcTemplate jdbcTemplate;

    @Autowired
    public JdbcShopDao(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public List<Shop> getShops() {
        List<Shop> shops = new ArrayList<>();
        String sql = "SELECT shop_id, name, street_address, city, state, zip FROM shop;";
        try {
            SqlRowSet results = jdbcTemplate.queryForRowSet(sql);
            while (results.next()) {
                Shop shop = mapRowToShop(results);
                shops.add(shop);
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        }
        return shops;
    }

    @Override
    public Shop getShopById(int shopId) {
        Shop shop = null;
        String sql = "SELECT shop_id, name, street_address, city, state, zip FROM shop WHERE shop_id = ?;";
        try {
            SqlRowSet results = jdbcTemplate.queryForRowSet(sql, shopId);
            if (results.next()) {
                shop = mapRowToShop(results);
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        }
        return shop;
    }

    private Shop mapRowToShop(SqlRowSet results) {
        Shop shop = new Shop();
        shop.setShopId(results.getInt("shop_id"));
        shop.setName(results.getString("name"));
        shop.setStreetAddress(results.getString("street_address"));
        shop.setCity(results.getString("city"));
        shop.setState(results.getString("state"));
        shop.setZipCode(results.getString("zip"));
        return shop;
    }
}
