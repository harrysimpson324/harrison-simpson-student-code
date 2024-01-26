package com.techelevator;

import java.math.BigDecimal;

public class Lemonade {
    // properties
    private String flavor = "Regular";
    private boolean frozen = false;
    private Recipe recipe; // TODO Fill out the recipe class
    private BigDecimal cost = new BigDecimal("0.50");
    private String wittySaying;

    // constructors
    public Lemonade(String flavor, boolean frozen, BigDecimal cost) {
        this.flavor = flavor;
        this.frozen = frozen;
        this.cost = cost;
        this.recipe = App.createRecipe(flavor);
    }

    public Lemonade(String flavor, boolean frozen) {
        this(flavor, frozen, new BigDecimal("0.50"));
    }

    public Lemonade(String flavor) {
        this(flavor, false, new BigDecimal("0.50"));
    }

    // gettrs and setters
    public String getFlavor() {
        return flavor;
    }

    public boolean isFrozen() {
        return frozen;
    }

    public BigDecimal getCost() {
        return cost;
    }

    public void setCost(BigDecimal cost) {
        this.cost = cost;
    }

    // other methods
}
