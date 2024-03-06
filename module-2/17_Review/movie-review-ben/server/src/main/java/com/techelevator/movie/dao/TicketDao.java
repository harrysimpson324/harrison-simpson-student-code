package com.techelevator.movie.dao;

import com.techelevator.movie.model.Movie;
import com.techelevator.movie.model.Ticket;

import java.util.List;

public interface TicketDao {
    public List<Ticket> getTickets(int userId);

    public Ticket buyTicket(int userId, Movie movie, String movieDate);

}
