package com.techelevator.movie.services;

import com.techelevator.movie.model.Movie;
import com.techelevator.movie.model.Ticket;
import com.techelevator.util.BasicLogger;
import org.springframework.http.*;
import org.springframework.web.client.ResourceAccessException;
import org.springframework.web.client.RestClientResponseException;
import org.springframework.web.client.RestTemplate;

import java.util.List;

public class MovieService {

    private final String baseUrl;
    private String authToken;
    private final RestTemplate restTemplate = new RestTemplate();

    public MovieService(String url) {
        this.baseUrl = url;
    }

    public Ticket[] getTickets() {
        Ticket[] tickets = null;

        HttpHeaders headers = new HttpHeaders();
        headers.setBearerAuth(authToken);
        HttpEntity<Void> entity = new HttpEntity<>(headers);
        try {
            ResponseEntity<Ticket[]> response =
                    restTemplate.exchange(baseUrl + "/tickets",
                            HttpMethod.GET, entity, Ticket[].class);
            tickets = response.getBody();
        } catch (RestClientResponseException | ResourceAccessException e) {
            BasicLogger.log(e.getMessage());
        }

        return tickets;
    }

    public String getMovieTitleById(int id) {
        String title = "";
        try {
            title = restTemplate.getForObject(baseUrl + "/movies/"+id+"/title", String.class);
        } catch (RestClientResponseException | ResourceAccessException e) {
            BasicLogger.log(e.getMessage());
        }

        return title;
    }

    public void setAuthToken(String authToken) {
        this.authToken = authToken;
    }


}
