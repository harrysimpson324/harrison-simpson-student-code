# Exercises for Web API (POST)

This exercise continues the work on the previous messaging application. Before beginning, review the updated starter code. Your task is to enhance the application so it's useable by an administrator who must create, read, update, and delete both topics and messages.

## Before you begin

Run the command `npm install` in the project directory to install any dependencies. Then run the project using the command `npm run dev`.

To test the project and verify completion, you can run the tests using either of the following commands:

* `npm run test:e2e-headless` - This runs the tests in "headless" mode to display the results in the console. Tests run significantly faster this way, but you don't get the additional support of the Cypress UI.
* `npm run test:e2e` - This runs the tests using the Cypress user interface, which may provide extra help, like screenshots, when you're troubleshooting a failed test.

Note: The application and tests can't run simultaneously. If the application is already running, you may see the tests fail with the following message:

```bash
ERROR: "json-server-test" exited with 1.
Error: server closed unexpectedly
```

If this occurs, stop the application in the terminal or run `npx kill-port 3000`, then try to run the tests again.

### Resetting the API data

Since this exercise requires you to write code that modifies the data used by the API server, you may wish to reset the data at some point for your own testing. The `package.json` file contains a custom `npm run` command you can use to reset the data: `npm run reset-data`. You must stop and restart the dev server before you run this command, or you'll still see the modified data.

You don't need to perform this command before running the tests, the test script uses a separate data file that's reset before every test.

## Part One: CRUD Topics

Add methods to support the remaining CRUD operations for Topics in the `src/services/TopicService.js` file.

### Step One: Create a new Topic

Use Postman to make a `POST` request to `/topics` and verify the service endpoint works. Then, in the `TopicService`, develop a new method that takes a topic as a parameter, performs a `POST` request to the URL `/topics`, and returns a `Promise`.

In the `TopicForm` component, locate the `submitForm` method and the **TODO** for add. Update the code to call the create method you just added to `TopicService`. You'll need to add an `import` statement before making a call on the `TopicService` service object.

Remember to check the status code to ensure the request was successful (201).

- On success, use the router to forward the user to the `HomeView`.
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "adding" used to complete the notification message.

### Step Two: Update a Topic

Use Postman to make a `PUT` request to `/topics/:id` and verify the service endpoint works. Then, write a new `TopicService` method that takes a topic id and a topic as parameters, performs a `PUT` request to the URL `/topics/:id`, and returns a `Promise`.

In the `TopicForm` component, locate the `submitForm` method and the **TODO** for edit. To complete the code, call the new update method from the `TopicService`. Remember to check the status code to ensure the request was successful (200).

- On success, use the router to forward the user to the `TopicDetailsView`, setting the topic id param.
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "updating" used to complete the notification message.

### Step Three: Delete a Topic

Use Postman to make a `DELETE` request to `/topics/:id` and verify the service endpoint works. Then, add a new method to `TopicService` that takes a topic id as a parameter, performs a `DELETE` request to the URL `/topics/:id`, and returns a `Promise`.

Open the `TopicDetails` component and locate the `deleteTopic` method and the **TODO** for delete. Update this to call the new delete method from the `TopicService`. Remember to check the status code to ensure the request was successful (200).

- On success, use the router to forward the user to the `HomeView`.
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "deleting" used to complete the notification message.

### Step Four: Run tests

After completing these steps correctly, all tests under `Part One: CRUD Topics` pass.

## Part Two: CRUD Messages

Add methods to support the remaining CRUD operations for Messages in the `src/services/MessageService.js` file.

### Step One: Create a new Message

Use Postman to make a `POST` request to `/messages` and verify the service endpoint works. Then, write a new method that accepts a message as an argument, performs a `POST` request to the URL `/messages`, and returns a `Promise`.

Open the `MessageForm` component and locate the `submitForm` method and the **TODO** for add. Update it to call the new create method from the `MessageService`. Remember to check the status code to ensure the request was successful (201).

- On success, use the router to forward the user to the `TopicDetailsView`, setting the topic id param.
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "adding" used to complete the notification message.

### Step Two: Update a Message

Use Postman to perform a `PUT` request to `/messages/:id`, and verify the service endpoint works. Then, add a new method to the service object that accepts a message id and message as arguments, performs a `PUT` request to the URL `/messages/:id`, and returns a `Promise`.

Open the `MessageForm` component and locate the `submitForm` method and the **TODO** for edit. Call the new update method from the `MessageService` to complete it. Remember to check the status code to ensure the request was successful (200).

- On success, use the router to forward the user to the `MessageDetailsView`, setting the message id param.
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "updating" used to complete the notification message.

### Step Three: Delete a Message

Use Postman to make a `DELETE` request to `/messages/:id` and verify the service endpoint works. Then, develop a new method that accepts a message id, performs a `DELETE` request to the URL `/messages/:id`, and returns a `Promise`.

Open the `MessageDetails` component and locate the `deleteMessage` method and the **TODO** for delete. Update this to call the new delete method from the `MessageService`. Remember to check the status code to ensure the request was successful (200).

- On success, use the router to forward the user to the `TopicDetailsView`, setting the topic id param.
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "deleting" used to complete the notification message.

### Step Four: Run tests

After completing these steps correctly, all tests under `Part Two: CRUD Messages` pass.
