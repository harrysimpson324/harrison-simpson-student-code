package com.techelevator.movie.controller;

import com.techelevator.movie.dao.MovieDao;
import com.techelevator.movie.dao.TicketDao;
import com.techelevator.movie.dao.UserDao;
import com.techelevator.movie.exception.DaoException;
import com.techelevator.movie.model.Movie;
import com.techelevator.movie.model.Ticket;
import com.techelevator.movie.model.User;
import org.springframework.http.HttpStatus;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;

import java.security.Principal;
import java.util.List;

@RestController
public class MovieController {
    private final MovieDao movieDao;
    private final TicketDao ticketDao;
    private final UserDao userDao;

    public MovieController(MovieDao movieDao, TicketDao ticketDao, UserDao userDao) {
        this.movieDao = movieDao;
        this.ticketDao = ticketDao;
        this.userDao = userDao;
    }

    @PreAuthorize("isAuthenticated()")
    @RequestMapping( path = "/tickets", method = RequestMethod.GET)
    public List<Ticket> getTicketsForUser(Principal principal) {
        List<Ticket> tickets = null;
        User user = null;

        try {
            user = userDao.getUserByUsername(principal.getName());
            tickets = ticketDao.getTickets(user.getId());
        }
        catch (DaoException e) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Unable to get user or tickets for user");
        }

        return tickets;
    }

    @RequestMapping( path = "/movies/{id}", method = RequestMethod.GET)
    public Movie getMovieById(@PathVariable int id) {
        Movie movie = null;

        try {
            movie = movieDao.getMovieById(id);
        }
        catch (DaoException e) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Unable to get movie title");
        }

        return movie;
    }
    @RequestMapping( path = "/movies/{id}/title", method = RequestMethod.GET)
    public String getMovieTitleById(@PathVariable int id) {
        String title = "";

        try {
            title = movieDao.getMovieTitle(id);
        }
        catch (DaoException e) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Unable to get movie title");
        }

        return title;
    }
}
