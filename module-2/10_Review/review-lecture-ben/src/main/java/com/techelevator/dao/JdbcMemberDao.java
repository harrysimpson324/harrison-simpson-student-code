package com.techelevator.dao;

import com.techelevator.exception.DaoException;
import com.techelevator.model.City;
import com.techelevator.model.Member;
import com.techelevator.model.InterestGroup;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.jdbc.CannotGetJdbcConnectionException;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

import javax.sql.DataSource;

import java.util.ArrayList;
import java.util.List;

public class JdbcMemberDao implements MemberDao {

    private final JdbcTemplate jdbcTemplate;

    public JdbcMemberDao(DataSource dataSource) {
        this.jdbcTemplate = new JdbcTemplate(dataSource);
    }

    public Member getMemberById(int memberId) {
        Member member = null;
        String sql = "SELECT member_id, first_name, last_name, email, phone_number, date_of_birth, wants_emails " +
                "FROM member " +
                "WHERE member_id = ?;";

//        String alt_sql = "SELECT person_id, first_name, last_name, phone_number, date_of_birth, email, wants_emails " +
//                "FROM person " +
//                "JOIN email ON person.email = email.email " +
//                "WHERE person_id = ?";
        try {
            SqlRowSet results = jdbcTemplate.queryForRowSet(sql, memberId);
            if (results.next()) {
                member = mapRowToMember(results);
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        }
        return member;
    }

    private Member mapRowToMember(SqlRowSet rowSet) {
        Member member = new Member();
        member.setMemberId(rowSet.getInt("member_id"));
        member.setFirstName(rowSet.getString("first_name"));
        member.setLastName(rowSet.getString("last_name"));
        member.setEmail(rowSet.getString("email"));
        member.setPhone(rowSet.getString("phone_number"));
        if (rowSet.getDate("date_of_birth") != null) {
            member.setDateOfBirth(rowSet.getDate("date_of_birth").toLocalDate());
        }
        member.setFirstName(rowSet.getString("first_name"));

        return member;
    }


}
