# Tutorial for managing inheritance

In this tutorial, you'll be working on classes for a shipping company. You'll create new classes for several delivery options, and use the `abstract` and `protected` keywords to require and restrict inheritance. You'll also seal a method.

To get started, open the `ShippingCompany.sln` in Visual Studio. It includes a basic `Shipment` class to represent a package for delivery, and a `Program` class that you'll use later in the tutorial.

## Design

The company wants to offer the following delivery options:

- Truck Delivery
- Drone Delivery
- Air Delivery

Each delivery option has the following properties:

- Origin : `string` _(the origin of the shipment)_
- Destination : `string` _(the destination of the shipment)_
- Distance : `int` _(the distance between the origin and destination in miles)_
- Shipment: `Shipment`_(the object representing the package for delivery)_

Each delivery option has the following method:

- `GetDuration()`

What makes each of these types of deliveries unique is the time that it takes to make the delivery. A truck driving across the country takes a lot longer than the Air Delivery. Since each delivery type is unique, each class has a different implementation of the `GetDuration()` method.

If you were to jump right in and start writing code without any planning, you might end up with the following three classes:

![3 Delivery Classes](./img/3-delivery-classes-csharp.png)

Notice how similar all those classes are. Duplicate code is a red flag - there's probably a better way to design your application. In this case, each of the classes share state - also known as properties - but have one method, `GetDuration()` that's unique. This is a great opportunity to use an abstract class. A better approach might look like this:

![3 Delivery Classes](./img/delivery-abstract-class-csharp.png)

## Step One: Create the `Delivery` class

Now that you have a good idea of what your application looks like, you can write some code. Start by creating a new class `Delivery.cs`. Then, create four properties and all of the getters and setters for each:

```csharp
public class Delivery
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public int Distance { get; set; }
    public Shipment Shipment { get; set; }
}
```

Next, you need to declare a  `GetDuration()` method without providing any implementation, but require any class that extends `Delivery` to implement it. To do this, make it an abstract method:

```csharp
public abstract int GetDuration();
```

Only abstract classes can contain abstract methods, so after adding the `abstract` keyword to a method, the IDE marks it as an error until you also add the `abstract` keyword to the class. Making the class abstract means you can't create instances of this class--using it requires inheriting from it. After that, your `Delivery` class looks like this:

```csharp
public abstract class Delivery
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public int Distance { get; set; }
    public Shipment Shipment { get; set; }

    public abstract int GetDuration();
}
```

## Step Two: Create the `TruckDelivery` class

Now that you have the base `Delivery` class, you can create the class for the truck delivery option. Create a new class named `TruckDelivery` that extends the `Delivery` class.

```csharp
public class TruckDelivery : Delivery
{

}
```

You'll see an error at this point, because this class doesn't yet provide an implementation for `GetDuration()`. By making that method abstract, you've ensured that every child class implements the method--they won't compile until they do.

For the sake of simplicity, assume trucks always drive at their top speed of 60 mph. If the truck goes at that speed across the whole distance, you can determine how long it would take to complete the delivery with this implementation of `GetDuration()`:

```csharp
public class TruckDelivery : Delivery
{
    public const double TruckTopSpeed = 60.0;

    public override int GetDuration()
    {
        double decimalHours = base.Distance / TruckTopSpeed;
        int hours = (int) decimalHours;
        int minutes = (int) Math.Round((decimalHours - hours) * 60);
        return (hours * 60) + minutes; //duration in minutes
    }
}
```

## Step Three: Create the `DroneDelivery` and `AirDelivery` classes

Next, create the `DroneDelivery` and `AirDelivery` classes in the same way you created the `TruckDelivery` class.

Drone delivery works like the truck delivery option with a little wrinkle. The smallest delivery drones have a top speed of 100 mph, but can only carry 1 pound packages. As the total weight of the shipment increases, larger, slower drones are necessary, which this method represents by dividing the top speed by the weight:

```csharp
public class DroneDelivery : Delivery
{
    public const double DroneTopSpeed = 100.0;

    public override int GetDuration()
    {
        double topSpeedWithWeight = DroneTopSpeed / Shipment.Weight;
        double decimalHours = base.Distance / topSpeedWithWeight;
        int hours = (int) decimalHours;
        int minutes = (int) Math.Round((decimalHours - hours) * 60);
        return (hours * 60) + minutes;              
    }
}
```

All air deliveries take one day. Remember that `GetDuration()` method returns minutes, so you need to convert one day to minutes:

```csharp
public class AirDelivery : Delivery
{
    private const int OneDayInMinutes = 24 * 60;

    public override int GetDuration()
    {
        return OneDayInMinutes;
    }
}
```

At this point, you've created an abstract class and three classes that inherit from it. By making `GetDuration()` an abstract method, you required each of those child classes to provide their own implementation for it.

## Step Four: Add an `ConvertHoursToMinutes()` method

Notice that both the `TruckDelivery` and `DroneDelivery` classes convert hours into minutes in their `GetDuration()` methods. That's an opportunity to refactor that code and move it into the `Delivery` class. Add the following method to the `Delivery` class:

```csharp
public int ConvertHoursToMinutes(double decimalHours)
{
    int hours = (int)decimalHours;
    int minutes = (int)Math.Round((decimalHours - hours) * 60);
    return (hours * 60) + minutes; //duration in minutes;
}
```

Then, refactor the `GetDuration()` method of `TruckDelivery` like this:

```csharp
public override int GetDuration()
{
    double decimalHours = (double)base.Distance / TruckTopSpeed;
    return ConvertHoursToMinutes(decimalHours);
}
```

And then refactor the `GetDuration()` method of `DroneDelivery` like this:

```csharp
public override int GetDuration()
{
    double topSpeedWithWeight = DroneTopSpeed / Shipment.Weight;
    double decimalHours = base.Distance / topSpeedWithWeight;
    return ConvertHoursToMinutes(decimalHours);
}
```

Go to the `Main()` method in the `Program` class, and create an instance of `TruckDelivery`:

```csharp
static void Main(string[] args)
{
    TruckDelivery myDelivery = new TruckDelivery();
}
```

Add another line to the `Main()` method, type `myDelivery.` and look at the list of methods IntelliSense suggests. First in the list is `ConvertHoursToMinutes()`. As the class designer, you added that method for use within the family of classes that inherit from `Delivery`, but didn't intend for it to be generally available. It clutters the list of methods and might cause confusion about why `TruckDelivery` offers a `ConvertHoursToMinutes()` method that has no clear relationship to delivery by truck.

The `ConvertHoursToMinutes()` method is available to the `Program` class because it's `public`. If you change it to `private`, Visual Studio no longer suggests it in the popup list of methods, because then you can only call it from within the `Delivery` class. The problem with making it `private`, though, is that it breaks the `TruckDelivery` and `DroneDelivery` classes, because now they can't access `ConvertHoursToMinutes()`.

The solution is to change the access modifier on `ConvertHoursToMinutes()` to `protected`:

```csharp
protected int ConvertHoursToMinutes(double decimalHours)
{
    int hours = (int)decimalHours;
    int minutes = (int)Math.Round((decimalHours - hours) * 60);
    return (hours * 60) + minutes; //duration in minutes;
}
```

Now you can call the method from classes that inherit from `Delivery`, but not in unrelated classes like `Program`. This is better encapsulation.

## Step Five: Add a sealed method to the `Delivery` class

Finally, add a new method to the `Delivery` class named `GetExpectedArrival()`. When provided with the departure date and time this method returns the expected arrival date and time:

```csharp
public DateTime GetExpectedArrival(DateTime departure)
{
    return departure.AddMinutes(GetDuration());
}
```

Notice the absence of the keywords `sealed` and `virtual`. By default, methods are automatically sealed unless they're explicitly declared `virtual`, in which case, it's the overriding method in the subclass that controls whether the method is `sealed`.

Try overriding `GetExpectedArrival` in one of the child classes like `AirDelivery`, and you'll get a compiler error.

By restricting inheritance in this way, you make it clear that you expect child classes to rely on the `GetDuration()` method for calculations related to delivery speed, and prevent a misunderstanding like going the other direction and basing `GetDuration()` on a date calculated in `GetExpectedArrival()`. While either approach could possibly work, doing things consistently across a codebase facilitates understanding and reduces maintenance.

## Next Steps

* Try adding another class to represent a different type of delivery, and notice how the requirements and restrictions you've put in place on `Delivery` help you build the new class correctly.
* Review classes you've created in past exercises and see if you notice opportunities to better encapsulate methods with the `protected` access modifier.
