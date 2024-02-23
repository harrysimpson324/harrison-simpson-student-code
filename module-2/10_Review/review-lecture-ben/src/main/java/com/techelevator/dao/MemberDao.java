package com.techelevator.dao;


import com.techelevator.exception.DaoException;
import com.techelevator.model.InterestGroup;
import com.techelevator.model.Member;

import java.util.List;

public interface MemberDao {
    public Member getMemberById(int memberId);

    //public List<Member> getMembersByInterestGroup(InterestGroup group);
    //public List<Member> getMembersByInterestGroupId(int groupId);

}
