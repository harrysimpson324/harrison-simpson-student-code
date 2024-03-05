package com.techelevator.movie.dao;

import com.techelevator.movie.model.RegisterUserDto;
import com.techelevator.movie.model.User;

import java.util.List;

public interface UserDao {

    List<User> getUsers();

    User getUserById(int id);

    User getUserByUsername(String username);

    User createUser(RegisterUserDto user);
}
