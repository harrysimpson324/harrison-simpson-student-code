package com.webthreads.store.controller;

import com.webthreads.store.dao.ApparelDao;
import com.webthreads.store.dao.ShopApparelDao;
import com.webthreads.store.dao.ShopDao;
import com.webthreads.store.exception.DaoException;
import com.webthreads.store.model.Apparel;
import com.webthreads.store.model.Shop;
import com.webthreads.store.model.ShopApparelDto;

import org.springframework.http.HttpStatus;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;

import javax.validation.Valid;

@RestController
@CrossOrigin
@PreAuthorize("isAuthenticated()")
@RequestMapping("/shops")
public class ShopController {

    private final ShopApparelDao shopApparelDao;
    private final ApparelDao apparelDao;
    private final ShopDao shopDao;

    public ShopController(ShopApparelDao shopApparelDao, ApparelDao apparelDao, ShopDao shopDao) {
        this.shopApparelDao = shopApparelDao;
        this.apparelDao = apparelDao;
        this.shopDao = shopDao;
    }

    @RequestMapping(path = "", method = RequestMethod.GET)
    public List<Shop> getShops() {
        try {
            List<Shop> shops = shopDao.getShops();
            return shops;
        } catch (DaoException e) {
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Unable to retrieve shops");
        }
    }

    @RequestMapping(path = "/{shopId}", method = RequestMethod.GET)
    public Shop getShopById(@PathVariable int shopId) {
        try {
            Shop shop = shopDao.getShopById(shopId);
            if (shop == null) {
                throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Shop Not Found");
            }
            return shop;
        } catch (DaoException e) {
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Unable to retrieve shop");
        }
    }

    @RequestMapping(path = "/{shopId}/apparel", method = RequestMethod.GET)
    public List<Apparel> getShopInventory(@PathVariable int shopId, @RequestParam(required = false) Boolean inventory) {
        if (inventory == null) {
            inventory = true;
        }
        try {
            Shop shop = shopDao.getShopById(shopId);
            if (shop == null) {
                throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Shop Not Found");
            }
            if (inventory) {
                return shopApparelDao.getShopInventory(shopId);
            } else {
                // indicates client wants apparel *not* in shop inventory
                return shopApparelDao.getApparelsNotInShop(shopId);
            }
        } catch (DaoException e) {
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Unable to retrieve shop inventory");
        }
    }

    @PreAuthorize("hasRole('SHOP')")
    @ResponseStatus(HttpStatus.CREATED)
    @RequestMapping(path = "/{shopId}/apparel/{apparelId}", method = RequestMethod.POST)
    public void linkShopApparel(@PathVariable int shopId, @PathVariable int apparelId) {
        try {
            Apparel existingShopApparel = shopApparelDao.getShopInventoryByApparelId(shopId, apparelId);
            if (existingShopApparel != null) {
                throw new ResponseStatusException(HttpStatus.CONFLICT, "Apparel already exists in shop inventory");
            }

            Apparel existingApparel = apparelDao.getApparelById(apparelId);
            if (existingApparel == null) {
                throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Apparel Not Found");
            }

            Shop existingShop = shopDao.getShopById(shopId);
            if (existingShop == null) {
                throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Shop Not Found");
            }

            shopApparelDao.linkShopApparel(shopId, apparelId);
        } catch (DaoException e) {
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Shop and apparel could not be linked");
        }
    }

    @PreAuthorize("hasRole('SHOP')")
    @RequestMapping(path = "/{shopId}/apparel/{apparelId}", method = RequestMethod.PUT)
    public Apparel updateShopApparel(@PathVariable int shopId, @PathVariable int apparelId, @Valid @RequestBody ShopApparelDto shopApparelDto) {
        if (shopApparelDto.getShopId() != shopId) {
            throw new ResponseStatusException(HttpStatus.CONFLICT, "Shop IDs in path and body must match");
        }

        if (shopApparelDto.getApparelId() != apparelId) {
            throw new ResponseStatusException(HttpStatus.CONFLICT, "Apparel IDs in path and body must match");
        }

        Apparel existingShopApparel = shopApparelDao.getShopInventoryByApparelId(shopId, apparelId);
        if (existingShopApparel == null) {
            throw new ResponseStatusException(HttpStatus.CONFLICT, "Apparel does not exist in shop inventory");
        }

        try {
            Apparel updatedApparel = shopApparelDao.updateShopApparel(shopId, apparelId, shopApparelDto.getQuantity());
            return updatedApparel;
        } catch (DaoException e) {
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Shop apparel could not be updated");
        }
    }

    @PreAuthorize("hasRole('SHOP')")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    @RequestMapping(path = "/{shopId}/apparel/{apparelId}", method = RequestMethod.DELETE)
    public void unlinkShopApparel(@PathVariable int shopId, @PathVariable int apparelId) {
        Apparel existingShopApparel = shopApparelDao.getShopInventoryByApparelId(shopId, apparelId);
        if (existingShopApparel == null) {
            throw new ResponseStatusException(HttpStatus.CONFLICT, "Apparel does not exist in shop inventory");
        }

        try {
            shopApparelDao.unlinkShopApparel(shopId, apparelId);
        } catch (DaoException e) {
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Shop and apparel could not be unlinked");
        }
    }
}