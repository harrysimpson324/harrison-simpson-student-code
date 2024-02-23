package com.techelevator.projects.dao;

import com.techelevator.projects.exception.DaoException;
import com.techelevator.projects.model.Timesheet;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.sql.Time;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

import static org.junit.Assert.assertNotNull;

public class JdbcTimesheetDaoTests extends BaseDaoTests {

    private static final Timesheet TIMESHEET_1 = new Timesheet(1, 1, 1,
            LocalDate.parse("2021-01-01"), 1.0, true, "Timesheet 1");
    private static final Timesheet TIMESHEET_2 = new Timesheet(2, 1, 1,
            LocalDate.parse("2021-01-02"), 1.5, true, "Timesheet 2");
    private static final Timesheet TIMESHEET_3 = new Timesheet(3, 2, 1,
            LocalDate.parse("2021-01-01"), 0.25, true, "Timesheet 3");
    private static final Timesheet TIMESHEET_4 = new Timesheet(4, 2, 2,
            LocalDate.parse("2021-02-01"), 2.0, false, "Timesheet 4");

    private JdbcTimesheetDao dao;

    private Timesheet testTimesheetNoTimesheetId;


    @Before
    public void setup() {
        dao = new JdbcTimesheetDao(dataSource);
        testTimesheetNoTimesheetId = new Timesheet();
        testTimesheetNoTimesheetId.setProjectId(2);
        testTimesheetNoTimesheetId.setEmployeeId(2);
        testTimesheetNoTimesheetId.setDateWorked(LocalDate.of(2021, 02, 01));
        testTimesheetNoTimesheetId.setHoursWorked(2.0);
        testTimesheetNoTimesheetId.setBillable(true);
        testTimesheetNoTimesheetId.setDescription("Timesheet 5");

    }

    @Test
    public void getTimesheetById_with_valid_id_returns_correct_timesheet() {
        Timesheet test = dao.getTimesheetById(1);
        assertTimesheetsMatch(test, TIMESHEET_1);

        test = dao.getTimesheetById(2);
        assertTimesheetsMatch(test, TIMESHEET_2);
    }

    @Test
    public void getTimesheetById_with_invalid_id_returns_null_timesheet() {
        Timesheet test = dao.getTimesheetById(5);
        Assert.assertNull(test);
    }

    @Test
    public void getTimesheetsByEmployeeId_with_valid_employee_id_returns_list_of_timesheets_for_employee() {
        List<Timesheet> timesheets = dao.getTimesheetsByEmployeeId(1);
        Assert.assertEquals("Does not return the correct number of timesheets.", 2, timesheets.size());

        List<Timesheet> expecteds = new ArrayList<>();
        expecteds.add(TIMESHEET_1);
        expecteds.add(TIMESHEET_2);
        for (int i = 0; i < expecteds.size(); i++) {
                assertTimesheetsMatch(timesheets.get(i), expecteds.get(i));
        }
    }

    @Test
    public void getTimesheetsByEmployeeId_with_invalid_employee_id_returns_empty_list_of_timesheets() {
        List<Timesheet> timesheets = dao.getTimesheetsByEmployeeId(3);
        Assert.assertEquals("Does not return an empty list when given an invalid employee id.", 0, timesheets.size());
        Assert.assertNotNull("Method returns a null list instead of an empty one.",timesheets);
    }

    @Test
    public void getTimesheetsByProjectId_with_valid_project_id_returns_list_of_all_timesheets_for_project() {
        List<Timesheet> timesheets = dao.getTimesheetsByProjectId(1);
        Assert.assertEquals( "Method did not return the correct number of timesheets.", 3, timesheets.size());

        List<Timesheet> expecteds = new ArrayList<>();
        expecteds.add(TIMESHEET_1);
        expecteds.add(TIMESHEET_2);
        expecteds.add(TIMESHEET_3);

        for (int i = 0; i < timesheets.size(); i++) {
            assertTimesheetsMatch(expecteds.get(i), timesheets.get(i));
        }
    }

    @Test
    public void getTimesheetsByProjectId_with_invalid_project_id_returns_empty_list_of_timesheets() {
        List<Timesheet> timesheets = dao.getTimesheetsByProjectId(3);
        Assert.assertNotNull( "Method returns a null pointer rather than an empty list.",timesheets);
        Assert.assertEquals("Method does not return an empty list (theres something in it).", 0, timesheets.size());
    }

    @Test
    public void createTimesheet_creates_timesheet() {
        Timesheet newTimesheet = new Timesheet();
        newTimesheet.setProjectId(2);
        newTimesheet.setEmployeeId(2);
        newTimesheet.setDateWorked(LocalDate.of(2021, 02, 01));
        newTimesheet.setHoursWorked(2.0);
        newTimesheet.setBillable(true);
        newTimesheet.setDescription("Timesheet 5");

        Timesheet toTest = dao.createTimesheet(testTimesheetNoTimesheetId);
        Assert.assertNotNull("Create timesheet returns a null timesheet when it shouldn't.", toTest);

        newTimesheet.setTimesheetId(5);

        assertTimesheetsMatch(newTimesheet, toTest);
    }

    @Test
    public void updateTimesheet_updates_timesheet() {
        Timesheet toUpdate = dao.getTimesheetById(4);
        toUpdate.setEmployeeId(1);
        toUpdate.setProjectId(2);
        toUpdate.setDescription("Timesheeeeeet 4");
        toUpdate.setBillable(true);
        toUpdate.setHoursWorked(3.0);

        Timesheet updated = dao.updateTimesheet(toUpdate);
        Assert.assertNotNull(updated);

        Timesheet checkDatabase = dao.getTimesheetById(4);

        assertTimesheetsMatch(updated, checkDatabase);
        assertTimesheetsMatch(toUpdate, checkDatabase);

    }

    @Test
    public void deleteTimesheetById_deletes_timesheet() {
        int numDeleted = dao.deleteTimesheetById(4);
        Assert.assertEquals(1, numDeleted);

        Timesheet retrieved = dao.getTimesheetById(4);
        Assert.assertNull(retrieved);
    }

    @Test
    public void getBillableHours_returns_correct_total() {
        double time11 = dao.getBillableHours(1, 1);
        double time21 = dao.getBillableHours(2, 1);
        double time22 = dao.getBillableHours(2, 2);

        //when employee_id = 1 and project_id = 1 (both billable)
        Assert.assertEquals("Does not work across multiple timesheets", 2.5, time11, 0.001);

        //when employee_id = 2 and project_id = 1 (both billable)
        Assert.assertEquals("Method does not return correct value when isBillable = true", 0.25, time21, 0.001);

        //when employee_id = 2 and project_id = 2 (not billable)
        Assert.assertEquals("Method does not return correct value when isBillable = false", 0, time22, 0.001);


    }

    private void assertTimesheetsMatch(Timesheet expected, Timesheet actual) {
        Assert.assertEquals(expected.getTimesheetId(), actual.getTimesheetId());
        Assert.assertEquals(expected.getEmployeeId(), actual.getEmployeeId());
        Assert.assertEquals(expected.getProjectId(), actual.getProjectId());
        Assert.assertEquals(expected.getDateWorked(), actual.getDateWorked());
        Assert.assertEquals(expected.getHoursWorked(), actual.getHoursWorked(), 0.001);
        Assert.assertEquals(expected.isBillable(), actual.isBillable());
        Assert.assertEquals(expected.getDescription(), actual.getDescription());
    }

}
