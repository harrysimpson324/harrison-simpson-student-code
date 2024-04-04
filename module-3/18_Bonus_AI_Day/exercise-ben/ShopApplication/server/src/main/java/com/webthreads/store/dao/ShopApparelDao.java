package com.webthreads.store.dao;

import com.webthreads.store.model.Apparel;
import java.util.List;

public interface ShopApparelDao {

    List<Apparel> getShopInventory(int shopId);

    Apparel getShopInventoryByApparelId(int shopId, int apparelId);

    void linkShopApparel(int shopId, int apparelId);

    Apparel updateShopApparel(int shopId, int apparelId, int quantity);

    void unlinkShopApparel(int shopId, int apparelId);

    List<Apparel> getApparelsNotInShop(int shopId);
}
