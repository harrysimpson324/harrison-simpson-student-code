package com.webthreads.store.controller;

import com.webthreads.store.dao.ApparelDao;
import com.webthreads.store.exception.DaoException;
import com.webthreads.store.model.Apparel;
import org.springframework.http.HttpStatus;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import javax.validation.Valid;
import java.util.List;

@RestController
@CrossOrigin
@PreAuthorize("isAuthenticated()")
@RequestMapping("/apparel")
public class ApparelController {

    private final ApparelDao apparelDao;

    public ApparelController(ApparelDao apparelDao) {
        this.apparelDao = apparelDao;
    }

    @RequestMapping(path = "", method = RequestMethod.GET)
    public List<Apparel> getAllApparels() {
        return apparelDao.getApparels();
    }

    @RequestMapping(path = "/{id}", method = RequestMethod.GET)
    public Apparel getApparelById(@PathVariable int id) {
        Apparel apparel = apparelDao.getApparelById(id);
        if (apparel == null) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Apparel Not Found");
        }
        return apparel;
    }

    @PreAuthorize("hasRole('HQ')")
    @ResponseStatus(HttpStatus.CREATED)
    @RequestMapping(path = "", method = RequestMethod.POST)
    public Apparel createApparel(@Valid @RequestBody Apparel apparel) {
        return apparelDao.createApparel(apparel);
    }

    @PreAuthorize("hasRole('HQ')")
    @RequestMapping(path = "/{id}", method = RequestMethod.PUT)
    public Apparel updateApparel(@PathVariable int id, @Valid @RequestBody Apparel apparel) {
        if (id != apparel.getApparelId()) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "ID in path must match ID in request body");
        }
        try {
            Apparel updatedApparel = apparelDao.updateApparel(apparel);
            return updatedApparel;
        } catch (DaoException e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Apparel Not Found");
        }
    }

    @PreAuthorize("hasRole('HQ')")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    @RequestMapping(path = "/{id}", method = RequestMethod.DELETE)
    public void deleteApparel(@PathVariable int id) {
        int result = apparelDao.deleteApparelById(id);
        if (result != 1) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Apparel Not Found");
        }
    }
}