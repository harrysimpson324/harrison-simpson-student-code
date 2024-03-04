package com.techelevator.reservations.dao;

import com.techelevator.reservations.exception.DaoException;
import com.techelevator.reservations.model.Member;
import org.springframework.jdbc.CannotGetJdbcConnectionException;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Component;

import javax.sql.DataSource;
import java.util.ArrayList;
import java.util.List;

@Component
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

    public List<Member> getMembers() {
        List<Member> members = new ArrayList<>();
        String sql = "SELECT member_id, first_name, last_name, email, phone_number, date_of_birth, wants_emails " +
                "FROM member ORDER BY last_name, first_name;";

        try {
            SqlRowSet results = jdbcTemplate.queryForRowSet(sql);
            while (results.next()) {
                members.add(mapRowToMember(results));
            }
        } catch (CannotGetJdbcConnectionException e) {
            throw new DaoException("Unable to connect to server or database", e);
        }
        return members;
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
