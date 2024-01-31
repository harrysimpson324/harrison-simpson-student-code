package com.techelevator.farm;

public class Cat extends FarmAnimal {

    private String nickname;

    public Cat(String nickname) {
        super("Cat", "meow!");
        this.nickname = nickname;
    }

    public String getNickname() {
        return nickname;
    }

//    @Override
//    public String getSound() {
//        if (isAsleep) {
//            return "purr!";
//        }
//
//        return "meow!";
//    }

    @Override
    public void eat() {
        System.out.println(nickname + " + the Cat eats cat food...");
    }
}
