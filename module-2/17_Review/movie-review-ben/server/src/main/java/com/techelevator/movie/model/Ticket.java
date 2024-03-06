package com.techelevator.movie.model;

public class Ticket {
    private int ticketId;
    private int movieId;
    private int userId;
    private String movieDate;

    public Ticket() {

    }

    public Ticket(int ticketId, int movieId, int userId, String movieDate) {
        this.ticketId = ticketId;
        this.movieId = movieId;
        this.userId = userId;
        this.movieDate = movieDate;
    }

    public int getTicketId() {
        return ticketId;
    }

    public int getMovieId() {
        return movieId;
    }

    public int getUserId() {
        return userId;
    }

    public String getMovieDate() {
        return movieDate;
    }

    public void setTicketId(int ticketId) {
        this.ticketId = ticketId;
    }

    public void setMovieId(int movieId) {
        this.movieId = movieId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public void setMovieDate(String movieDate) {
        this.movieDate = movieDate;
    }
}
