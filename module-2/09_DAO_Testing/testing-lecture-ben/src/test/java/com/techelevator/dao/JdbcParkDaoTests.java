package com.techelevator.dao;

import com.techelevator.model.City;
import com.techelevator.model.Park;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.time.LocalDate;
import java.util.List;

public class JdbcParkDaoTests extends BaseDaoTests {

    private static final Park PARK_1 =
            new Park(1, "Park 1", LocalDate.parse("1800-01-02"), 100, true);
    private static final Park PARK_2 =
            new Park(2, "Park 2", LocalDate.parse("1900-12-31"), 200, false);
    private static final Park PARK_3 =
            new Park(3, "Park 3", LocalDate.parse("2000-06-15"), 300, false);

    private Park testPark;
    private JdbcParkDao sut;

    @Before
    public void setup() {
        sut = new JdbcParkDao(dataSource);
        testPark = new Park(0, "Test Park", LocalDate.parse("1900-06-02"), 999, true);
    }

    @Test
    public void getParkById_with_valid_id_returns_correct_park() {
        Park park = sut.getParkById(1);
        assertParksMatch(PARK_1, park);

        park = sut.getParkById(2);
        assertParksMatch(PARK_2, park);

    }

    @Test
    public void getParkById_with_invalid_id_returns_null_park() {
        Park park = sut.getParkById(99);
        Assert.assertNull(park);
    }

    @Test
    public void getParksByState_with_valid_state_returns_correct_parks() {
        List<Park> parks = sut.getParksByState("AA");
        Assert.assertEquals("Incorrect number of parks in state", 2, parks.size());
        assertParksMatch(PARK_1, parks.get(0));
        assertParksMatch(PARK_3, parks.get(1));

        parks = sut.getParksByState("BB");
        Assert.assertEquals("Incorrect number of parks in state", 1, parks.size());
        assertParksMatch(PARK_2, parks.get(0));
    }

    @Test
    public void getParksByState_with_invalid_state_returns_empty_list() {
        List<Park> parks = sut.getParksByState("XX");
        Assert.assertEquals("Incorrect number of parks in state", 0, parks.size());
    }

    @Test
    public void createPark_creates_park() {
        Park createdPark = sut.createPark(testPark);
        Assert.assertNotNull(createdPark);

        int newId = createdPark.getParkId();
        Assert.assertTrue(newId > 0);

        Park retrievedPark = sut.getParkById(newId);
        assertParksMatch(createdPark, retrievedPark);
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
        int preLinkCount = sut.getParksByState("BB").size();
        sut.linkParkState(3, "BB");
        List<Park> parks = sut.getParksByState("BB");
        int postLinkCount = parks.size();

        Assert.assertEquals("Should have added one park to state", preLinkCount + 1, postLinkCount);
        assertParksMatch(PARK_2, parks.get(0));
        assertParksMatch(PARK_3, parks.get(1));
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
