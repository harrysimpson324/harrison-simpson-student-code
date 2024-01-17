package com.techelevator;

public class Exercises {

    /**
     * For the purposes of this exercise, the following naming rules are tested:
     *
     * Variable names:
     *  - must start with a lowercase character a-z.
     *  - underscore ('_') characters are not allowed.
     *  - dollar sign ('$') characters are not allowed.
     *  - must be at least two characters in length.
     *  - You are encouraged to create descriptive names and are required to camel case them as appropriate.
     *
     * Constant names:
     *  - must start with an uppercase character A-Z.
     *  - dollar sign ('$') characters are not allowed.
     *  - must be at least two characters in length.
     *  - You are encouraged to create descriptive names and are required to upper case them as appropriate.
     *
     * Due to practical limitations, camel case and pascal case are not tested other than checking the first
     * character of the name is lower case for variables and upper case for constants. Your instructor will
     * manually review your solution checking for the correct casing.
     */

	public static void main(String[] args) {

        /* Exercise 1
        1. 4 birds are sitting on a branch. 1 flies away. How many birds are left on
        the branch?
        */
		// ### EXAMPLE:
		int birdsOnABranch = 4;
		int birdsThatFlyAway = 1;
		int birdsRemaining = birdsOnABranch - birdsThatFlyAway;

        /* Exercise 2
        2. There are 6 birds and 3 nests. How many more birds are there than
        nests?
        */
		// ### EXAMPLE:
		int numberOfBirds = 6;
		int numberOfNests = 3;
		int numberOfExtraBirds = numberOfBirds - numberOfNests;

        /* Exercise 3
        3. 3 raccoons are playing in the woods. 2 go home to eat dinner. How
        many raccoons are left in the woods?
        */
		int racoonsInWoods = 3;
		int racoonsWentHome = 2;
		int racoonsLeftInWoods = racoonsInWoods - racoonsWentHome;


        /* Exercise 4
        4. There are 5 flowers and 3 bees. How many less bees than flowers?
        */
		int flowers = 5;
		int bees = 3;
		int differenceFlowersBees = flowers - bees;


        /* Exercise 5
        5. 1 lonely pigeon was eating breadcrumbs. Another pigeon came to eat
        breadcrumbs, too. How many pigeons are eating breadcrumbs now?
        */
		int numPigeons = 1;
		numPigeons++;


        /* Exercise 6
        6. 3 owls were sitting on the fence. 2 more owls joined them. How many
        owls are on the fence now?
        */
		int numOwlsOnFence = 3;
		numOwlsOnFence += 2;


        /* Exercise 7
        7. 2 beavers were working on their home. 1 went for a swim. How many
        beavers are still working on their home?
        */
		int beaversWorking = 2;
		int beaversSwimming = 1;
		beaversWorking = beaversWorking - beaversSwimming;


        /* Exercise 8
        8. 2 toucans are sitting on a tree limb. 1 more toucan joins them. How
        many toucans in all?
        */
		int toucansInTree = 2;
		toucansInTree++;


        /* Exercise 9
        9. There are 4 squirrels in a tree with 2 nuts. How many more squirrels
        are there than nuts?
        */
		int squirrelsInTree = 4;
		int nuts = 2;
		int additionalSquirrels = squirrelsInTree - nuts;



        /* Exercise 10
        10. Mrs. Hilt found a quarter, 1 dime, and 2 nickels. How much money did
        she find?
        */
		final double QUARTER = 0.25;
		final double DIME = 0.1;
		final double NICKEL = 0.05;
		double hiltsComeUp = QUARTER + DIME + 2*NICKEL;


        /* Exercise 11
        11. Mrs. Hilt's favorite first grade classes are baking muffins. Mrs. Brier's
        class bakes 18 muffins, Mrs. MacAdams's class bakes 20 muffins, and
        Mrs. Flannery's class bakes 17 muffins. How many muffins does first
        grade bake in all?
        */
		int brierClassMuffins = 18;
		int macAdamsClassMuffins = 20;
		int flanneryClassMuffins = 17;
		int firstGradeMuffins = brierClassMuffins+macAdamsClassMuffins+flanneryClassMuffins;


        /* Exercise 12
        12. Mrs. Hilt bought a yoyo for 24 cents and a whistle for 14 cents. How
        much did she spend in all for the two toys?
        */
		double yoyoCost = 0.24;
		double whistleCost = 0.14;
		double hiltSpendingOnToys = yoyoCost + whistleCost;




        /* Exercise 13
        13. Mrs. Hilt made 5 Rice Krispies Treats. She used 8 large marshmallows
        and 10 mini marshmallows.How many marshmallows did she use
        altogether?
        */
		int largeMallows = 8;
		int smallMallows = 10;
		int totalMallows = largeMallows + smallMallows;


        /* Exercise 14
        14. At Mrs. Hilt's house, there was 29 inches of snow, and Brecknock
        Elementary School received 17 inches of snow. How much more snow
        did Mrs. Hilt's house have?
        */
		int hiltInchesSnow = 29;
		int brecknockInchesSnow = 17;
		int differenceInchesSnow = hiltInchesSnow-brecknockInchesSnow;


        /* Exercise 15
        15. Mrs. Hilt has $10. She spends $3 on a toy truck and $2.50 on a pencil
        case. How much money does she have left?
        */
		double hiltsWallet = 10.0;
		int costTruck = 3;
		double costPencil = 2.5;
		double hiltsWalletAfterPurchase = hiltsWallet - costPencil - costTruck;



        /* Exercise 16
        16. Josh had 16 marbles in his collection. He lost 7 marbles. How many
        marbles does he have now?
        */
		int joshStartingMarbles = 16;
		int joshLostMarbles = 7;
		int joshNewMarbles = joshStartingMarbles - joshLostMarbles;



        /* Exercise 17
        17. Megan has 19 seashells. How many more seashells does she need to
        find to have 25 seashells in her collection?
        */
		int meganShells = 19;
		int desiredShells = 25;
		int shellsNeeded = desiredShells - meganShells;


        /* Exercise 18
        18. Brad has 17 balloons. 8 balloons are red and the rest are green. How
        many green balloons does Brad have?
        */
		int totalBallons = 17;
		int redBallons = 8;
		int greenBallons = totalBallons - redBallons;


        /* Exercise 19
        19. There are 38 books on the shelf. Marta put 10 more books on the shelf.
        How many books are on the shelf now?
        */
		int booksInitiallyOnShelf = 38;
		int booksAdded = 10;
		int booksNowOnShelf = booksInitiallyOnShelf + booksAdded;


        /* Exercise 20
        20. A bee has 6 legs. How many legs do 8 bees have?
        */
		final int LEGS_PER_BEE = 6;
		int numBees = 8;
		int totalLegs = numBees*LEGS_PER_BEE;


        /* Exercise 21
        21. Mrs. Hilt bought an ice cream cone for 99 cents. How much would 2 ice
        cream cones cost?
        */
		double costIceCream = 0.99;
		int numIceCreams = 2;
		double costIceCreams = costIceCream*numIceCreams;


        /* Exercise 22
        22. Mrs. Hilt wants to make a border around her garden. She needs 125
        rocks to complete the border. She has 64 rocks. How many more rocks
        does she need to complete the border?
        */
		int hiltsRocks = 64;
		int rocksDesired = 125;
		int rocksNeeded = rocksDesired - hiltsRocks;


        /* Exercise 23
        23. Mrs. Hilt had 38 marbles. She lost 15 of them. How many marbles does
        she have left?
        */
		int hiltsStartingMarbles = 38;
		int hiltsLostMarbles = 15;
		int hiltsFinalMarbles = hiltsStartingMarbles - hiltsLostMarbles;


        /* Exercise 24
        24. Mrs. Hilt and her sister drove to a concert 78 miles away. They drove 32
        miles and then stopped for gas. How many miles did they have left to drive?
        */
		int totalMiles = 78;
		int milesDrove = 32;
		int milesToGo = totalMiles - milesDrove;


        /* Exercise 25
        25. Mrs. Hilt spent 1 hour and 30 minutes shoveling snow on Saturday
        morning and 45 minutes shoveling snow on Saturday afternoon. How
        much total time (in minutes) did she spend shoveling snow?
        */
		final int MINUTES_PER_HOUR = 60;
		int saturdayShovelTime = 1*MINUTES_PER_HOUR + 30;
		int sundayShovelTime = 45;
		int totalShovelTime = saturdayShovelTime+sundayShovelTime;


        /* Exercise 26
        26. Mrs. Hilt bought 6 hot dogs. Each hot dog cost 50 cents. How much
        money did she pay for all of the hot dogs?
        */
		final double COST_HOT_DOG = 0.5;
		int numHotDogs = 6;
		double totalGlizzyCost = numHotDogs*COST_HOT_DOG;



        /* Exercise 27
        27. Mrs. Hilt has 50 cents. A pencil costs 7 cents. How many pencils can
        she buy with the money she has?
        */
		int hiltsCents = 50;
		int pencilCostInCents = 7;
		int numPencils = hiltsCents/pencilCostInCents;


        /* Exercise 28
        28. Mrs. Hilt saw 33 butterflies. Some of the butterflies were red and others
        were orange. If 20 of the butterflies were orange, how many of them
        were red?
        */
		int totalButterflies = 33;
		int orangeButterflies = 20;
		int redButterflies = totalButterflies - orangeButterflies;


        /* Exercise 29
        29. Kate gave the clerk $1.00. Her candy cost 54 cents. How much change
        should Kate get back?
        */
		double kateMoneyGiven = 1.00;
		double candyCost = 0.54;
		double change = kateMoneyGiven - candyCost;


        /* Exercise 30
        30. Mark has 13 trees in his backyard. If he plants 12 more, how many trees
        will he have?
        */
		int treesInYard = 13;
		int treesToPlant = 12;
		int hypotheticalNewTreeCountInYard = treesInYard + treesToPlant;


        /* Exercise 31
        31. Joy will see her grandma in two days. How many hours until she sees
        her?
        */
		final int HOURS_PER_DAY = 24;
		int numDaysToGrandma = 2;
		int hoursToGrandma = numDaysToGrandma*HOURS_PER_DAY;


        /* Exercise 32
        32. Kim has 4 cousins. She wants to give each one 5 pieces of gum. How
        much gum will she need?
        */
		int numCousins = 4;
		int gumPerCousin = 5;
		int gumNeeded = gumPerCousin*numCousins;


        /* Exercise 33
        33. Dan has $3.00. He bought a candy bar for $1.00. How much money is
        left?
        */
		int danDollars = 3;
		int danCandyBarCost = 1;
		double danFinalDollars = (double)danDollars - danCandyBarCost;



        /* Exercise 34
        34. 5 boats are in the lake. Each boat has 3 people. How many people are
        on boats in the lake?
        */
		int peoplePerBoat = 3;
		int numBoatsOnLake = 5;
		int peopleInBoats = peoplePerBoat*numBoatsOnLake;


        /* Exercise 35
        35. Ellen had 380 legos, but she lost 57 of them. How many legos does she
        have now?
        */
		int ellenStartingLegos = 380;
		int ellenLostLegos = 57;
		int ellenFinalLegos = ellenStartingLegos - ellenLostLegos;


        /* Exercise 36
        36. Arthur baked 35 muffins. How many more muffins does Arthur have to
        bake to have 83 muffins?
        */
		int muffinsDesired = 83;
		int muffinsBaked = 35;
		int muffinsNeeded = muffinsDesired - muffinsBaked;



        /* Exercise 37
        37. Willy has 1400 crayons. Lucy has 290 crayons. How many more
        crayons does Willy have then Lucy?
        */
		int willyCrayons = 1400;
		int lucyCrayons = 290;
		int differenceWillyLucyCrayons = willyCrayons - lucyCrayons;


        /* Exercise 38
        38. There are 10 stickers on a page. If you have 22 pages of stickers, how
        many stickers do you have?
        */
		final int STICKERS_PER_PAGE = 10;
		int pagesOfStickers = 22;
		int totalStickers = pagesOfStickers*STICKERS_PER_PAGE;


        /* Exercise 39
        39. There are 100 cupcakes for 8 children to share. How much will each
        person get if they share the cupcakes equally?
        */
		int numCupcakes = 100;
		int numChildren = 8;
		double cupcakesPerChild = (double)numCupcakes/numChildren;


        /* Exercise 40
        40. She made 47 gingerbread cookies which she will distribute equally in
        tiny glass jars. If each jar is to contain six cookies, how many
        cookies will not be placed in a jar?
        */
		int totalCookies = 47;
		int cookieRemainder = 47%6;


        /* Exercise 41
        41. She also prepared 59 croissants which she plans to give to her 8
        neighbors. If each neighbor received an equal number of croissants,
        how many will be left with Marian?
        */
		int numCroissants = 59;
		int numNeighbors = 8;
		int leftoverCroissants = 59%8;


        /* Exercise 42
        42. Marian also baked oatmeal cookies for her classmates. If she can
        place 12 cookies on a tray at a time, how many trays will she need to
        prepare 276 oatmeal cookies at a time?
        */
		final int COOKIES_PER_TRAY = 12;
		int cookiesDesired = 276;
		int traysNeeded = cookiesDesired/COOKIES_PER_TRAY;




        /* Exercise 43
        43. Marian’s friends were coming over that afternoon so she made 480
        bite-sized pretzels. If one serving is equal to 12 pretzels, how many
        servings of bite-sized pretzels was Marian able to prepare?
        */
		final int NUM_PRETZELS_IN_SERVING = 12;
		int numPretzels = 480;
		int servingsPretzelsMade = numPretzels/NUM_PRETZELS_IN_SERVING;


        /* Exercise 44
        44. Lastly, she baked 53 lemon cupcakes for the children living in the city
        orphanage. If two lemon cupcakes were left at home, how many
        boxes with 3 lemon cupcakes each were given away?
        */
		int totalCupcakes = 53;
		int cupcakesLeftAtHome = 2;
		final int CUPCAKES_PER_BOX = 3;
		int numBoxesCupcakes = (totalCupcakes - cupcakesLeftAtHome)/CUPCAKES_PER_BOX;


        /* Exercise 45
        45. Susie's mom prepared 74 carrot sticks for breakfast. If the carrots
        were served equally to 12 people, how many carrot sticks were left
        uneaten?
        */
		int numCarrotSticks = 74;
		int numPeopleToServeEqually = 12;
		int leftoverCarrotSticks = numCarrotSticks%numPeopleToServeEqually;


        /* Exercise 46
        46. Susie and her sister gathered all 98 of their teddy bears and placed
        them on the shelves in their bedroom. If every shelf can carry a
        maximum of 7 teddy bears, how many shelves will be filled?
        */
		int numTeddyBears = 98;
		final int MAX_BEARS_PER_SHELF = 7;
		int totalShelvesOfBears = numTeddyBears/MAX_BEARS_PER_SHELF;


        /* Exercise 47
        47. Susie’s mother collected all family pictures and wanted to place all of
        them in an album. If an album can contain 20 pictures, how many
        albums will she need if there are 480 pictures?
        */
		final int PICTURES_PER_ALBUM = 20;
		int numPicturesToAlbumize = 480;
		int numAlbumsToPicturize = numPicturesToAlbumize/PICTURES_PER_ALBUM;


        /* Exercise 48
        48. Joe, Susie’s brother, collected all 94 trading cards scattered in his
        room and placed them in boxes. If a full box can hold a maximum of 8
        cards, how many boxes were filled and how many cards are there in
        the unfilled box?
        */
		int numTradingCards = 94;
		final int CARDS_PER_BOX = 8;
		int numBoxesFilled = 94/8;
		int numCardsInUnfilledBox = 94%8;


        /* Exercise 49
        49. The Milky Way galaxy contains 300 billion stars. The Andromeda galaxy
        contains 1 trillion stars. How many stars do the two galaxies contain combined?
        */
		long milkyStars = 300000000000L;
		long andromedaStars = 1000000000000L;
		long totalStars = milkyStars+andromedaStars;



        /* Exercise 50
        50. Cristina baked 17 croissants. If she planned to serve this equally to
        her seven guests, how many will each have?
        */
		int cristinaCroissants = 17;
		int numCristinaGuests = 7;
		double croissantPerGuest = (double)cristinaCroissants/numCristinaGuests;


	    /* Exercise 51
	    51. Bill and Jill are house painters. Bill can paint a standard room in 2.15 hours, while Jill averages
	    1.90 hours. How long will it take the two painters working together to paint 5 standard rooms?
	    Hint: Calculate the rate at which each painter can complete a room (rooms / hour), combine those rates, 
	    and then divide the total number of rooms to be painted by the combined rate.
	    */
		int numRoomsToPaint = 5;
		final double BILL_PAINTING_RATE = 1/2.15;
		final double JILL_PAINTING_RATE = 1/1.90;
		double timeToPaintRooms = 5/(BILL_PAINTING_RATE+JILL_PAINTING_RATE);
     

	    /* Exercise 52
	    52. Create and assign variables to hold a first name, last name, and middle initial. Using concatenation,
		build an additional variable to hold the full name in the order of last name, first name, middle initial. The
		last and first names should be separated by a comma followed by a space, and the middle initial must end
		with a period. Use "Grace", "Hopper, and "B" for the first name, last name, and middle initial.
		Example: "John", "Smith, "D" —> "Smith, John D."
	    */
		String firstName = "Grace";
		String lastName = "Hopper";
		char middleInitial = 'B';
		String fullName = lastName + ", " + firstName + " " + middleInitial + ".";


	    /* Exercise 53
	    53. The distance between New York and Chicago is 800 miles, and the train has already travelled 537 miles.
	    What percentage of the trip as a whole number has been completed?
	    */
		final int DISTANCE_BETWEEN_NYC_AND_CHICAGO = 800;
		int distanceTravelledOnTrain = 537;
		int travelPercentCompleted = (int)((double)distanceTravelledOnTrain / DISTANCE_BETWEEN_NYC_AND_CHICAGO * 100);

	}

}
