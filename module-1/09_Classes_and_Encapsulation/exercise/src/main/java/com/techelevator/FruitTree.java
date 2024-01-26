package com.techelevator;

public class FruitTree {

    //properties
    private String typeOfFruit;

    private int piecesOfFruitLeft;

    //constructors

    public FruitTree(String typeOfFruit, int startingPiecesOfFruit) {
        this.typeOfFruit = typeOfFruit;
        piecesOfFruitLeft = startingPiecesOfFruit;
    }

    //setters

    //getters

    public String getTypeOfFruit() {
        return typeOfFruit;
    }

    public int getPiecesOfFruitLeft() {
        return piecesOfFruitLeft;
    }

    //other class methods

    public boolean pickFruit(int numberOfPiecesToRemove) {

        if (numberOfPiecesToRemove > piecesOfFruitLeft) {
            return false;
        }

        piecesOfFruitLeft -= numberOfPiecesToRemove;
        return true;

    }

}
