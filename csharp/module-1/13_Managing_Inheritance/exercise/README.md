# Managing Inheritance exercise

The purpose of this exercise is to practice building class structures using abstract classes and methods and using encapsulation, inheritance, and polymorphism.

## Learning objectives

After completing the exercise, you'll be able to:

- Define and use abstract classes and methods
- Reinforce the concepts of Encapsulation, Inheritance, and Polymorphism

## Evaluation criteria and functional requirements

* The project must not have any build errors.
* Code is clean and presented in an organized format.
* Code is appropriately encapsulated.
* Inheritance is appropriately used to avoid code duplication.
* Abstraction is appropriately used to prevent object creation and enforce needed method creation on inheritance.
* The code meets the defined specifications.

**Notes for all classes**
- Readonly properties don't require a `set` accessor.

### Paint calculator

Your goal is to create classes for a paint calculator. The calculator works by having a customer input dimensions of walls. Then, the calculator lets them know how many gallons of paint they need to purchase. Much of the UI is already complete. You need to implement the underlying `Wall` classes that make the calculations possible.

Each wall has a name, a color, and dimensions. The dimensions needed depend upon the shape of the wall. The application supports rectangular walls, square walls, and triangular walls.

To allow polymorphism and reuse common code, all the other walls inherit from the base `Wall` class. However, the `Wall` class doesn't include any dimensions of its own, so you can't use it in the application as a wall.

If you open `Program`, you'll see there are several blocks of commented out code. After you complete a step, you'll need to uncomment the code. After that, the code compiles.

#### Step One: Implement the `Wall` class

The `Wall` class can't be directly instantiated. It has two properties, `Name` and `Color`, that are readonly. Add a constructor that looks like this:

``` csharp
public Wall(string name, string color)
```

It also has one public method that subclasses have to implement. `GetArea()` takes no parameters and returns an integer representing the total area of the wall.

If you implemented the class correctly, the `WallTests` pass.

There are two places to uncomment code in `Program.cs`—look for `//uncomment after step 1:` and uncomment the line that follows it.

#### Step Two: Implement the `RectangleWall` class

`RectangleWall` extends `Wall` and adds two new properties, `Length` and `Height`, that are readonly. Add a constructor that looks like this:

``` csharp
public RectangleWall(string name, string color, int length, int height)
```

Implement `GetArea()` to return the `Length` multiplied by the `Height`.

Add a `ToString()` method that returns a `string` in the following format:

```
Name (LengthxHeight) rectangle
```

If you implemented the class correctly, the `RectangleWallTests` pass.

There are three places to uncomment code in `Program.cs`—look for `//uncomment after step 2:` and uncomment the line that follows it. If you run the program now, you can calculate the paint needed for rectangle walls.

#### Step Three: Implement the `TriangleWall` class

`TriangleWall` extends `Wall` and adds two new properties, `Base` and `Height`, that are readonly. Add a constructor that looks like this:

``` csharp
public TriangleWall(string name, string color, int @base, int height)
```

Implement `GetArea()` to return the `Base` multiplied by the `Height` and then divided by two.

>Note: Dividing an `int` by another `int` rounds down the answer to the nearest whole number.

Add a `ToString()` method that returns a `string` in the following format:

```
Name (BasexHeight) triangle
```

If you implemented the class correctly, the `TriangleWallTests` pass.

There's one place to uncomment code in `Program.cs`—look for `//uncomment after step 3:` and uncomment the line that follows it. If you run the program now, you can calculate the paint needed for triangle and rectangle walls.

#### Step Four: Implement the `SquareWall` class

`SquareWall` extends `RectangleWall`. Add a constructor that looks like this:

``` csharp
public SquareWall(string name, string color, int sideLength)
```

Add a `ToString()` method that returns a `string` in the following format:

```
Name (SideLengthxSideLength) square
```

`SquareWall` must not declare any properties or methods besides the constructor and `ToString()`.

If you implemented the class correctly, the `SquareWallTests` pass.

There's one place to uncomment code in `Program.cs`—look for `//uncomment after step 4:` and uncomment the line that follows it. If you run the program now, you can calculate the paint needed for all walls.

## Tips and tricks

- There are less explicit details for this exercise, but you have everything you need to complete it. Do your best, and let the unit tests guide your work.
- Abstract classes can't be directly instantiated.
- If a method must be explicitly implemented by a non-abstract class, that means that the method must be abstract.
