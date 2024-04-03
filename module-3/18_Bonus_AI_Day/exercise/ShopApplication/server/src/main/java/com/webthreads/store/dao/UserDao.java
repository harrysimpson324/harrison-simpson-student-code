package com.webthreads.store.dao;

import com.webthreads.store.model.User;
import com.webthreads.store.model.auth.RegisterUserDto;
import java.util.List;

public interface UserDao {

    List<User> getUsers();

    User getUserById(int id);

    User getUserByUsername(String username);

    User createUser(RegisterUserDto user);
}
