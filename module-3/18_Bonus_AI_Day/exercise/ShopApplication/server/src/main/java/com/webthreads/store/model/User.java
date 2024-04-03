package com.webthreads.store.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.webthreads.store.model.auth.Authority;

import java.util.HashSet;
import java.util.Objects;
import java.util.Set;

public class User {

   private int userId;
   private String username;
   @JsonIgnore
   private String password;
   private String email;
   private String firstname;
   private String lastname;
   private Integer shopId;
   @JsonIgnore
   private boolean activated;
   private Set<Authority> authorities = new HashSet<>();

   public User() { }

   public int getUserId() {
      return userId;
   }

   public void setUserId(int userId) {
      this.userId = userId;
   }

   public String getUsername() {
      return username;
   }

   public void setUsername(String username) {
      this.username = username;
   }

   public String getPassword() {
      return password;
   }

   public void setPassword(String password) {
      this.password = password;
   }

   public String getFirstname() {
      return firstname;
   }

   public void setFirstname(String firstname) {
      this.firstname = firstname;
   }

   public String getLastname() {
      return lastname;
   }

   public void setLastname(String lastname) {
      this.lastname = lastname;
   }

   public String getEmail() {
      return email;
   }

   public void setEmail(String email) {
      this.email = email;
   }

   public Integer getEmployeeShopId() {
      return shopId;
   }

   public void setEmployeeShopId(Integer shopId) {
      this.shopId = shopId;
   }

   public boolean isActivated() {
      return activated;
   }

   public void setActivated(boolean activated) {
      this.activated = activated;
   }

   public Set<Authority> getAuthorities() {
      return authorities;
   }

   public void setAuthorities(String authority) {
      this.authorities.add(new Authority(authority));
   }
   public void setAuthorities(String[] authorities) {
      for (String authority : authorities) {
         this.authorities.add(new Authority(authority));
      }
   }
   public void setAuthorities(Set<Authority> authorities) {
      this.authorities = authorities;
   }

   @Override
   public boolean equals(Object o) {
      if (this == o) return true;
      if (o == null || getClass() != o.getClass()) return false;
      User user = (User) o;
      return userId == user.userId;
   }

   @Override
   public int hashCode() {
      return Objects.hash(userId);
   }

}
