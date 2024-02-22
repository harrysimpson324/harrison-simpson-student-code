package com.techelevator.projects.dao;

import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.jdbc.CannotGetJdbcConnectionException;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

import com.techelevator.projects.exception.DaoException;
import com.techelevator.projects.model.Department;

public class JdbcDepartmentDao implements DepartmentDao {

	private final String DEPARTMENT_SELECT = "SELECT d.department_id, d.name FROM department d ";
	
	private final JdbcTemplate jdbcTemplate;

	public JdbcDepartmentDao(DataSource dataSource) {
		this.jdbcTemplate = new JdbcTemplate(dataSource);
	}

	@Override
	public Department getDepartmentById(int id) throws DaoException {
		Department department = null;
		String sql = DEPARTMENT_SELECT +
				" WHERE d.department_id=?";

		try {
			SqlRowSet results = jdbcTemplate.queryForRowSet(sql, id);
			if (results.next()) {
				department = mapRowToDepartment(results);
			}
		} catch (CannotGetJdbcConnectionException e) {
			throw new DaoException("Error connecting to server/database with jdbcTemplate (CannotGetJdbcConnectionException)", e);
		} catch (DataIntegrityViolationException e) {
			throw new DaoException("Error with primary keys/foreign keys (DataIntegrityViolationException)", e);
		}

		return department;
	}

	@Override
	public List<Department> getDepartments() throws DaoException {
		List<Department> departments = new ArrayList<>();
		String sql = DEPARTMENT_SELECT;

		try {
			SqlRowSet results = jdbcTemplate.queryForRowSet(sql);
			while (results.next()) {
				departments.add(mapRowToDepartment(results));
			}
		} catch (CannotGetJdbcConnectionException e) {
			throw new DaoException("Error connecting to server/database with jdbcTemplate (CannotGetJdbcConnectionException)", e);
		} catch (DataIntegrityViolationException e) {
			throw new DaoException("Error with primary keys/foreign keys (DataIntegrityViolationException)", e);
		}
		
		return departments;
	}

	@Override
	public Department createDepartment(Department department) {
		String sql = "INSERT INTO department (name) " +
				"VALUES(?) RETURNING department_id";
		int newId = 0;

		try {
			newId = jdbcTemplate.queryForObject(sql, int.class, department.getName());
		} catch (CannotGetJdbcConnectionException e) {
			throw new DaoException("Error connecting to server/database with jdbcTemplate (CannotGetJdbcConnectionException)", e);
		} catch (DataIntegrityViolationException e) {
			throw new DaoException("Error with primary keys/foreign keys (DataIntegrityViolationException)", e);
		}
		department.setId(newId);
		return department;
	}

	@Override
	public Department updateDepartment(Department department) {
		String sql = "UPDATE department SET name = ? WHERE department_id = ? RETURNING ";
		int id;
		String name;
		try {

			id = jdbcTemplate.queryForObject(sql + "department_id;", int.class, department.getName(), department.getId());
			name = jdbcTemplate.queryForObject("SELECT name FROM department WHERE department_id = ?;", String.class, id);

		} catch (CannotGetJdbcConnectionException e) {
			throw new DaoException("Error connecting to server/database with jdbcTemplate (CannotGetJdbcConnectionException)", e);
		} catch (DataIntegrityViolationException e) {
			throw new DaoException("Error with primary keys/foreign keys (DataIntegrityViolationException)", e);
		}
		return new Department(id, name);



	}

	@Override
	public int deleteDepartmentById(int id) {
		int numRows = 0;
		String sqlDepartment = "DELETE FROM department WHERE department_id = ?;";
		String sqlEmployee = "UPDATE employee SET department_id = 0 " +
				"WHERE department_id = ?;";

		try {
			jdbcTemplate.update(sqlEmployee, id);
			numRows = jdbcTemplate.update(sqlDepartment, id);

		} catch (CannotGetJdbcConnectionException e) {
			throw new DaoException("Error connecting to server/database with jdbcTemplate (CannotGetJdbcConnectionException)", e);
		} catch (DataIntegrityViolationException e) {
			throw new DaoException("Error with primary keys/foreign keys (DataIntegrityViolationException)", e);
		}

		return numRows;

	}

	private Department mapRowToDepartment(SqlRowSet results) {
		Department department = new Department();
		department.setId(results.getInt("department_id"));
		department.setName(results.getString("name"));
		return department;
	}

}
