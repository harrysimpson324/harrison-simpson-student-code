package com.techelevator.movie.dao;

import com.techelevator.movie.model.Movie;
import com.techelevator.movie.model.Ticket;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class JdbcTickDao implements TicketDao {
    @Override
    public List<Ticket> getTickets(int userId) {
        return null;
    }

    @Override
    public Ticket buyTicket(int userId, Movie movie, String movieDate) {
        return null;
    }
}
