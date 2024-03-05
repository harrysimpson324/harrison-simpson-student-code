package com.techelevator.movie.controller;

import com.techelevator.movie.dao.MovieDao;
import com.techelevator.movie.dao.TicketDao;
import com.techelevator.movie.dao.UserDao;
import org.springframework.web.bind.annotation.RestController;

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
}
