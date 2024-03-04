package com.techelevator.reservations.dao;


import com.techelevator.reservations.model.Member;

import java.util.List;

public interface MemberDao {
    public Member getMemberById(int memberId);

    public List<Member> getMembers();

    //public List<Member> getMembersByInterestGroup(InterestGroup group);
    //public List<Member> getMembersByInterestGroupId(int groupId);

}
