# Securing APIs Exercise

In this exercise, you'll continue to work on to the auctions server and client applications. Now that you've built the API and client, you'll add authentication and authorization to them.

Feel free to refer to the student book or tutorial for guidance.

## Step One: Open solution and explore starting code

Before you begin, open the `SecuringAPIsExercise.sln` solution. The solution contains both the server and client projects from the previous days. Review both projects. The code might look familiar to you as it's a continuation of previous exercises.

### Set startup projects

Since the solution contains both client and server applications, you'll have to configure the solution to run both projects simultaneously. In Visual Studio, right-click the solution and select **Set Startup Projects**. In the window that appears, select "Multiple startup projects" and set both "AuctionAppServer" and "AuctionAppClient" to have the action `Start`. You can leave the test projects set to `None`.

### Additional classes

There are some new classes in the server project to support logging in. `LoginController` provides a login endpoint for the API. The classes in `Security` are responsible for hashing passwords and generating JWT tokens. You won't need to modify any of these to complete the exercise.

Similarly, there's some new code in the client project to provide you a way to log in. `AuthenticatedApiService` is a new API service class that handles the login method and error handling. `AuctionApiService` now inherits from `AuthenticatedApiService`. In other words, `AuctionApiService` **is-a** `AuthenticatedApiService`.

### Tests

There are two test projects: `AuctionAppServer.Tests` and `AuctionAppClient.Tests`. Each step of the exercise tells you which project has the test to run.

Feel free to run the server and test the applications together or in Postman. However, your goal is to make sure the tests pass.

> Note: You must stop the client and server to run the tests. Visual Studio doesn't allow testing while the server and client are running.

## Step Two: Complete the login method

In the `AuctionAppClient` project, open `Services/AuthenticatedApiService.cs`, and locate the `Login()` method.

The response handling is already created for you, but you have to create the request. You need to send a `POST` request to the login endpoint `/login` with an object that has `username` and `password` fields.

Once you receive the response, you need to add the JWT token to the `RestClient client` member of the class.

After you complete this step, the `Step2_LoginMethod` test in `AuctionAppClient.Tests` passes.

> Note: If you're having trouble with this, you can review the `Login()` method of the tutorial.

You can test the client application by logging in with `test/test` or `admin/admin` as the username and password.

## Step Three: Add handling of unauthorized and forbidden responses

In `Services/AuthenticatedApiService.cs`, locate the `CheckForError()` method. In the `else if (!response.IsSuccessful)` block, you'll need to add checks for the response status code and throw an `HttpRequestException`. Set the exception message based on the following rules:

* If the status is `Unauthorized`, set an exception message that contains the word "authorization" or "authorize"
* If the status is `Forbidden`, set an exception message that contains the word "forbid" or "permission"
* If the status is neither of those but still unsuccessful, leave the default message that's already there

After you complete this step, the `Step3_ForbiddenResponse`, `Step3_UnauthorizedResponse`, and `Step3_Other4xxResponse` tests in `AuctionAppClient.Tests` pass.

## Step Four: Add authentication to controller methods

In the `AuctionAppServer` project, open `AuctionsController.cs`. All methods must require authentication except `List()`, the method that responds to `/auctions`. See if you can accomplish this by only adding two lines to the class.

After you complete this step, the `Step4_AllMethods_ExpectUnauthorized` and `Step4_GetAuctions_ExpectOk` tests in `AuctionAppServer.Tests` pass.

## Step Five: Add authorization roles

In `AuctionsController.cs`, add the following authorization rules:

- `Create()`: allow `creator` and `admin` roles
- `Update()`: allow `creator` and `admin` roles
- `Delete()`: allow `admin` role

After you complete this step, the `Step5_CreateMethod`, `Step5_UpdateMethod`, and `Step5_DeleteMethod` tests in `AuctionAppServer.Tests` pass.

## Step Six: Return user identity

In `AuctionsController.cs`, locate the `WhoAmI()` method. Instead of returning an empty string, return the logged in user's name.

After you complete this step, the `Step6_WhoAmI` test in `AuctionAppServer.Tests` passes.

---

If you followed the instructions correctly, all tests now pass.
