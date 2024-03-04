package com.techelevator.reservations.controllers;
import com.techelevator.reservations.dao.HotelDao;
import com.techelevator.reservations.dao.MemberDao;
import com.techelevator.reservations.dao.ReservationDao;
import com.techelevator.reservations.exception.DaoException;
import com.techelevator.reservations.model.Hotel;
import com.techelevator.reservations.model.Reservation;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import javax.validation.Valid;
import com.techelevator.reservations.model.Member;
import java.util.List;

@RestController
public class MemberController {

    private MemberDao memberDao;

    public MemberController(MemberDao memberDao) {
        this.memberDao = memberDao;
    }

    @RequestMapping( path = "/members", method = RequestMethod.GET)
    public List<Member> Members() {
        return memberDao.getMembers();
    }


}
