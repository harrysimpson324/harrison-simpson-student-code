package com.webthreads.store.dao;

import com.webthreads.store.model.Shop;

import java.util.List;

public interface ShopDao {

    List<Shop> getShops();

    Shop getShopById(int id);
}
