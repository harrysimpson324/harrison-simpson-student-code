package com.techelevator.movie.dao;

import com.techelevator.movie.exception.DaoException;
import com.techelevator.movie.model.Movie;
import com.techelevator.movie.model.Ticket;
import org.springframework.jdbc.CannotGetJdbcConnectionException;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class JdbcTicketDao implements TicketDao {

    private final JdbcTemplate jdbcTemplate;

    public JdbcTicketDao(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }
    @Override
    public List<Ticket> getTickets(int userId) {
        List<Ticket> tickets = new ArrayList<>();

        String sql = "select ticket_id, movie_id, user_id, ticket_date from ticket WHERE user_id = ?;";

        try {
            SqlRowSet results = jdbcTemplate.queryForRowSet(sql, userId);
            while (results.next()) {
                tickets.add(mapRowToTicket(results));
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        }

        return tickets;
    }

    @Override
    public Ticket buyTicket(int userId, Movie movie, String movieDate) {
        return null;
    }

    public Ticket mapRowToTicket(SqlRowSet rowSet) {
        // ticket_id, movie_id, user_id, ticket_date
        Ticket ticket = new Ticket();
        ticket.setTicketId(rowSet.getInt("ticket_id"));
        ticket.setMovieId(rowSet.getInt("movie_id"));
        ticket.setUserId(rowSet.getInt("user_id"));
        ticket.setMovieDate(rowSet.getString("ticket_date"));

        return ticket;
    }
}
