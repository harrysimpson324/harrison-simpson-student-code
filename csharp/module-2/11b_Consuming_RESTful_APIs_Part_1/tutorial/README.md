# Web Services GET tutorial (C#)

In this tutorial, you'll work on a command-line application that displays meetup locations. The command-line application is partially complete. You'll write the remaining functionality. You'll need to call a web API to both get a list of locations and the details for a single location.

## Step One: Start the server

Before you start, you need to ensure that the web API is up and running. You need to change directories into the `./server/` folder.

Next, from the command line, run the command `npm install` to install any dependencies. You won't need to do this on any subsequent run.

While still in the command line, run the command `npm start` to start the json-server application. If there aren't any errors, you'll see the following, which means that you've successfully set up your web API:


```shell
  \{^_^}/ hi!

  Loading ./locations.json
  Done

  Resources
  http://127.0.0.1:3000/locations

  Home
  http://127.0.0.1:3000

  Type s + enter at any time to create a snapshot of the database
  Watching...
```

> Note that the name `localhost` resolves to `127.0.0.1`, so when you see that IP address in the message, it means that json-server is ready to respond to requests on `localhost`.

When json-server is running on port 3000, no other applications—including other copies of json-server—are able to use port 3000. To free up the port, be sure to stop json-server when you're finished with this tutorial. You do that by selecting the terminal where you typed `npm start` and pressing `Ctrl+C`. Or if you've already closed that terminal, open a new terminal and type:

```
taskkill -T -F -IM node.exe
```

or

```
npx kill-port 3000
```

## Step Two: Explore the API

Before moving on to the next step, explore the web API using Postman. You can access the following endpoints:

- GET: http://localhost:3000/locations
- GET: http://localhost:3000/locations/{id} (id values 1-6 are valid)

## Step Three: Review the starting code

The Visual Studio solution is in the `./client/` folder. Open the solution and review the following code:

* `Program.cs`: The program entry point creates an instance of `LocationApp` and calls its `Run()` method.
* `LocationApp.cs`: The `Run()` method runs a loop that presents a menu to the user, waits for a selection and then acts on the selection.
* `Models`:
  * `Location.cs`: Represents the data model for a location object.
* `Services`:
  * `LocationConsoleService.cs`: This class is responsible for all interaction with the user. It displays data and messages to the console, and reads input from the user's keyboard. It's good design to separate user interface logic from business and data access logic.
  * `ConsoleService.cs`: This is a base class that provides useful functions for user output and input, such as prompting a user for a number between a minimum and maximum value. This class appears in the projects for the next few units. `LocationConsoleService` derives from this class.
  * `LocationApiService.cs`: This class is responsible for all client calls to the API server.

In this tutorial, you'll write the code which gets data from the server by calling API endpoints in the `LocationApiService.cs` file.

## Step Four: Inspect the console application

Open `LocationApp.cs`. Notice the two member variables near the top:

```csharp
// LocationApp.cs
private readonly LocationApiService locationApiService;
private readonly LocationConsoleService console = new LocationConsoleService();
```

`LocationApp` uses methods in `LocationConsoleService` to interact with the user, and methods in `LocationApiService` to get data from the server.

The `Run()` method is a loop (`while (true)`) that shows the user a menu and then acts on the user's selection. If the user enters **1** to list all locations, the `ShowLocations()` method is called. If the user selects option **2**, `ShowLocationDetails()` is called. Currently, each of these methods prints a "not implemented" error message.

## Step Five: List all locations

To implement the first menu option, you need to call the `/locations` API endpoint to get all locations, then print the results to the screen.

### Implement `LocationApiService.GetAllLocations()`

Open `Services/LocationApiService.cs`. In the constructor, the "base URL" for the API is set to the private member variable `apiUrl`.

The method to get all locations must create a `RestClient`. This is the class that you use to perform HTTP requests to the web API. Then, make a `GET /locations` HTTP request to retrieve data from the server.

The locations API returns an array of locations, so the return type is a `List` of `Location`s. By providing the type, the RestSharp library automatically converts the response into that type and is available in the `Data` property of the response. The conversion process is called deserialization:

```csharp
// LocationApiService.cs
public List<Location> GetAllLocations()
{
    RestClient client = new RestClient(apiUrl);
    RestRequest request = new RestRequest("locations");
    IRestResponse<List<Location>> response = client.Get<List<Location>>(request);
    return response.Data;
}
```

### Implement `LocationApp.ShowLocations()`

Next, in `LocationApp.cs`, find the `ShowLocations()` method and replace the method body with this code which calls `GetAllLocations()` and displays the results to the user:

```csharp
// LocationApp.cs
private void ShowLocations()
{
    List<Location> listLocations = locationApiService.GetAllLocations();
    console.PrintLocations(listLocations);
    console.Pause();
}
```

If you run the application and select option **1**, you'll see a list of meetup locations.

## Step Six: Get Location data

When the user selects menu option **2**, they'll see a list of locations, and then a prompt to select one. After selecting a location, the program shows the details for that location. You'll need to add a second API call to get a single location from the server.

### Implement `LocationApiService.GetDetailsForLocation()`

Once again, you'll create a `RestClient`, and execute a `GET` request, this time to the `/locations/{id}` endpoint. Add this method to `LocationApiService.cs`:

```csharp
// LocationApiService.cs
public Location GetDetailsForLocation(int locationId)
{
    RestClient client = new RestClient(apiUrl);
    RestRequest requestOne = new RestRequest($"locations/{locationId}");
    IRestResponse<Location> response = client.Get<Location>(requestOne);
    return response.Data;
}
```

This is very similar to `GetAllLocations()`, with the following differences:

* Since the server returns a single location, the return type is a single object, not a list of objects.
* The endpoint contains the ID of the location in its path, so the endpoint string is built using the `locationId` passed into the method.

### Implement `LocationApp.ShowLocationDetails()`

The purpose of this method is to display a list of locations to the user (like option 1), and then prompt the user for a location ID to see the details. When the user inputs an ID, it calls `GetDetailsForLocation()` and displays the location information. In `LocationApp.cs`, replace the contents of `ShowLocationDetails()` with the following:

```csharp
// LocationApp.cs
private void ShowLocationDetails()
{
    List<Location> listLocations = locationApiService.GetAllLocations();
    int locationId = console.PromptForLocationId(listLocations, "view");
    if (locationId == 0)
    {
        // User cancel
        return;
    }
    Location location = locationApiService.GetDetailsForLocation(locationId);
    console.PrintLocation(location);
    console.Pause();
}
```

If you now run the application and select option **2** and a valid location ID, you'll see a list of meetup locations.

## Summary

In this tutorial you learned:

- How to make an HTTP GET request using Postman and inspect the result
- How to make an HTTP GET request to a RESTful web service using C# to process the response
- How to convert a single JSON object into a C# object
- How to convert an array of JSON objects into an array of C# objects

### Don't forget to stop _json-server_

When you're done with the tutorial, remember to stop _json-server_. Directions are under **Step One**.

