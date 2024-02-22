package com.techelevator.dao;

import com.techelevator.model.Park;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.time.LocalDate;

public class JdbcParkDaoTests extends BaseDaoTests {

    private static final Park PARK_1 =
            new Park(1, "Park 1", LocalDate.parse("1800-01-02"), 100, true);
    private static final Park PARK_2 =
            new Park(2, "Park 2", LocalDate.parse("1900-12-31"), 200, false);
    private static final Park PARK_3 =
            new Park(3, "Park 3", LocalDate.parse("2000-06-15"), 300, false);

    private JdbcParkDao sut;

    @Before
    public void setup() {
        sut = new JdbcParkDao(dataSource);
    }

    @Test
    public void getParkById_with_valid_id_returns_correct_park() {
        Assert.fail();
    }

    @Test
    public void getParkById_with_invalid_id_returns_null_park() {
        Assert.fail();
    }

    @Test
    public void getParksByState_with_valid_state_returns_correct_parks() {
        Assert.fail();
    }

    @Test
    public void getParksByState_with_invalid_state_returns_empty_list() {
        Assert.fail();
    }

    @Test
    public void createPark_creates_park() {
        Assert.fail();
    }

    @Test
    public void updatePark_updates_park() {
        Assert.fail();
    }

    @Test
    public void deleteParkById_deletes_park() {
        Assert.fail();
    }

    @Test
    public void linkParkState_adds_park_to_list_of_parks_in_state() {
        Assert.fail();
    }

    @Test
    public void unlinkParkState_removes_park_from_list_of_parks_in_state() {
        Assert.fail();
    }

    private void assertParksMatch(Park expected, Park actual) {
        Assert.assertEquals(expected.getParkId(), actual.getParkId());
        Assert.assertEquals(expected.getParkName(), actual.getParkName());
        Assert.assertEquals(expected.getDateEstablished(), actual.getDateEstablished());
        Assert.assertEquals(expected.getArea(), actual.getArea(), 0.1);
        Assert.assertEquals(expected.getHasCamping(), actual.getHasCamping());
    }

}
