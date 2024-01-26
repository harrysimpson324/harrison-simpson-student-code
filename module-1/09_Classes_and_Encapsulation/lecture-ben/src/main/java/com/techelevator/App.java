package com.techelevator;

import java.util.ArrayList;
import java.util.List;

public class App {

    private List<Lemonade> glasses = new ArrayList<>();

    public void run() {
        System.out.println("** Welcome to the Gray Lemonade Stand **");
        for (int i = 0; i < 2; i++) {
            Lemonade glass = new Lemonade("Pink", false);
            glasses.add(glass);
            glass = new Lemonade("Regular", false);
            glasses.add(glass);
            glass = new Lemonade("Strawberry", false);
            glasses.add(glass);
            glass = new Lemonade("Pink", true);
            glasses.add(glass);
            glass = new Lemonade("Regular", true);
            glasses.add(glass);
            glass = new Lemonade("Strawberry", true);
            glasses.add(glass);
        }

        for (Lemonade glass : glasses) {
            System.out.println(glass.getFlavor() + " lemon" + (glass.isFrozen() ? "pop" : "ade") + " costs " + glass.getCost());
        }



    }

    public boolean isTreatAvailable(String flavor, boolean frozen) {

        for (Lemonade glass : glasses) {
            if (glass.getFlavor().equals(flavor) && frozen == glass.isFrozen()) {
                return true;
            }
        }

        return false;
    }

    public static Recipe createRecipe(String flavor) {
        if (flavor.equals("Pink")) {
            return new Recipe(new String[] {"pink lemonade mix"});
        }

    }

    /*
    Class design

    Inventory (raw materials

    Pink/regular/strawberry lemonade

    Frozen (lemonade pops) or liquid (drinks)

    Salted snack food product

    money

    recipe



     */
}
