using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodosServer.Models;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TodosServer.Security;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TodosServer.Tests
{
    [TestClass]
    public class TodoControllerTests
    {
        private const int INITIAL_ID = -1;
        protected HttpClient client;
        protected JwtGenerator jwtGenerator;
        protected Todo todo;

        [TestInitialize]
        public void Setup()
        {
            var builder = new WebHostBuilder()
                .UseStartup<TodosServer.Startup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build());
            var server = new TestServer(builder);
            client = server.CreateClient();

            todo = new Todo(INITIAL_ID, "test", DateTime.Now.Date, false, "test", new List<string> { "mark" });

            // Setup token generator
            jwtGenerator = new JwtGenerator("T3ch3l3v@t0rC0d1ngB00tc@mp!str1dE");
        }

        [TestMethod]
        public async Task STEP1_unauthenticated_requester_cant_access_any_endpoint()
        {
            var result = await client.GetAsync("/todos");
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, result.StatusCode,
                "Unauthenticated user can access endpoint GET /todos");

            result = await client.GetAsync("/todos/1");
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, result.StatusCode,
                "Unauthenticated user can access endpoint GET /todos/{id}");

            result = await client.GetAsync("/todos/search?task=test");
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, result.StatusCode, 
                "Unauthenticated user can access endpoint GET /todos/search");

            result = await client.PostAsync("/todos",
                new StringContent(JsonConvert.SerializeObject(todo), System.Text.Encoding.UTF8, "application/json"));
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, result.StatusCode, 
                "Unauthenticated user can access endpoint POST /todos");

            result = await client.PutAsync("/todos/1",
                new StringContent(JsonConvert.SerializeObject(todo), System.Text.Encoding.UTF8, "application/json"));
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, result.StatusCode, 
                "Unauthenticated user can access endpoint PUT /todos/{id}");

            result = await client.DeleteAsync("/todos/1");
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, result.StatusCode, 
                "Unauthenticated user can access endpoint DELETE /todos/{id}");
        }

        [TestMethod]
        [Authorize("susan")]
        public async Task STEP2_user_can_create_new_todo()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(7, "susan", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var result = await client.PostAsync("/todos",
                new StringContent(JsonConvert.SerializeObject(todo), System.Text.Encoding.UTF8, "application/json"));
            Assert.AreEqual(System.Net.HttpStatusCode.Created, result.StatusCode, 
                "Didn't receive 201 CREATED when creating new Todo as user susan");

            var returnedTodo = JsonConvert.DeserializeObject<Todo>(await result.Content.ReadAsStringAsync());
            Assert.AreNotEqual(INITIAL_ID, returnedTodo.Id, "ID not updated when new Todo created");

            var retrieveResult = await client.GetAsync($"/todos/{returnedTodo.Id}");
            var retrievedTodo = JsonConvert.DeserializeObject<Todo>(await retrieveResult.Content.ReadAsStringAsync());
            Assert.AreEqual("susan", retrievedTodo.CreatedBy, "createdBy not set to user that created the Todo");
        }


        [TestMethod]
        [Authorize("jessa")]
        public async Task STEP3_1_user_can_retrieve_single_todo_they_created()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(3, "jessa", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var retrieveResult = await client.GetAsync($"/todos/6");
            var retrievedTodo = JsonConvert.DeserializeObject<Todo>(await retrieveResult.Content.ReadAsStringAsync());
            Assert.AreEqual(System.Net.HttpStatusCode.OK, retrieveResult.StatusCode,
                "Didn't receive 200 OK when retrieving Todo that user jessa created");
            Assert.AreEqual(6, retrievedTodo.Id, "GET /todos/6 didn't return correct Todo for user jessa");
        }

        [TestMethod]
        [Authorize("jessa")]
        public async Task STEP3_2_user_can_retrieve_single_todo_they_collaborate_on()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(3, "jessa", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var retrieveResult = await client.GetAsync($"/todos/7");
            var retrievedTodo = JsonConvert.DeserializeObject<Todo>(await retrieveResult.Content.ReadAsStringAsync());
            Assert.AreEqual(System.Net.HttpStatusCode.OK, retrieveResult.StatusCode,
                "Didn't receive 200 OK when retrieving Todo that user jessa collaborates on");
            Assert.AreEqual(7, retrievedTodo.Id, "GET /todos/7 didn't return correct Todo for user jessa");
        }

        [TestMethod]
        [Authorize("liam")]
        public async Task STEP3_3_user_cant_retrieve_todo_they_didnt_create_or_collaborate_on()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(2, "liam", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var retrieveResult = await client.GetAsync($"/todos/7");
            Todo retrievedTodo = JsonConvert.DeserializeObject<Todo>(await retrieveResult.Content.ReadAsStringAsync());
            Assert.AreEqual(System.Net.HttpStatusCode.Forbidden, retrieveResult.StatusCode,
                "Didn't receive 403 FORBIDDEN when retrieving Todo that user liam didn't create or collaborate on");
        }

        [TestMethod]
        [Authorize("jessa")]
        public async Task STEP3_4_user_can_retrieve_todos()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(3, "jessa", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var retrieveResult = await client.GetAsync($"/todos");
            List<Todo> retrievedTodos = JsonConvert.DeserializeObject<List<Todo>>(await retrieveResult.Content.ReadAsStringAsync());
            Assert.AreEqual(System.Net.HttpStatusCode.OK, retrieveResult.StatusCode,
                "Didn't receive 200 OK when retrieving todos as user jessa");
            Assert.AreEqual(4, retrievedTodos.Count, "GET /todos didn't return correct number of Todos for user jessa");
        }

        [TestMethod]
        [Authorize("jaden")]
        public async Task STEP3_5_user_with_no_todos_gets_empty_list()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(8, "jaden", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var retrieveResult = await client.GetAsync($"/todos");
            List<Todo> retrievedTodos = JsonConvert.DeserializeObject<List<Todo>>(await retrieveResult.Content.ReadAsStringAsync());
            Assert.AreEqual(System.Net.HttpStatusCode.OK, retrieveResult.StatusCode,
                "Didn't receive 200 OK when retrieving todos as user jaden");
            Assert.IsNotNull(retrievedTodos, "GET /todos should return an empty list, not null, for user jaden");
            Assert.AreEqual(0, retrievedTodos.Count, "GET /todos didn't return an empty list for user jaden");
        }

        [TestMethod]
        [Authorize("liam")]
        public async Task STEP3_6_user_can_search_todos()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(2, "liam", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var retrieveResult = await client.GetAsync($"/todos/search?task=research");
            Todo[] retrievedTodos = JsonConvert.DeserializeObject<Todo[]>(await retrieveResult.Content.ReadAsStringAsync());
            Assert.AreEqual(System.Net.HttpStatusCode.OK, retrieveResult.StatusCode,
                "Didn't receive 200 OK when searching todos for \"research\" as user liam");
            Assert.AreEqual(1, retrievedTodos.Length, "GET /todos/search?task=research as user liam didn't return correct number of Todos." +
                " Search is case-insensitive and should only return matching Todos that liam owns or is a contributor on");
        }

        [TestMethod]
        [Authorize("jessa")]
        public async Task STEP4_1_user_createdby_can_update_todo()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(3, "jessa", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Todo updatedTodo = new Todo(4, "Updated task", DateTime.Now.Date, false, "jessa", new List<string> { "antoni" });
            var result = await client.PutAsync("/todos/4", new StringContent(JsonConvert.SerializeObject(updatedTodo), Encoding.UTF8, "application/json"));
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Didn't receive 200 OK when updating existing Todo as user jessa");
        }

        [TestMethod]
        [Authorize("antoni")]
        public async Task STEP4_2_user_collaborator_can_update_todo()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(4, "antoni", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Todo updatedTodo = new Todo(4, "Updated task", DateTime.Now.Date, false, "jessa", new List<string> { });
            var result = await client.PutAsync("/todos/4", new StringContent(JsonConvert.SerializeObject(updatedTodo), Encoding.UTF8, "application/json"));
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Didn't receive 200 OK when updating existing Todo as user antoni");
        }

        [TestMethod]
        [Authorize("jessa")]
        public async Task STEP4_3_user_cant_update_todo_they_didnt_create_or_collaborate_on()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(3, "jessa", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Todo updatedTodo = new Todo(1, "Updated task", DateTime.Now.Date, false, "mark", new List<string> { });
            var result = await client.PutAsync("/todos/1", new StringContent(JsonConvert.SerializeObject(updatedTodo), Encoding.UTF8, "application/json"));
            Assert.AreEqual(HttpStatusCode.Forbidden, result.StatusCode, 
                "Didn't receive 403 FORBIDDEN when updating Todo that user jessa didn't create or collaborate on");
        }

        [TestMethod]
        [Authorize("admin", Roles = "ADMIN")]
        public async Task STEP5_1_admin_can_delete_todo()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(9, "admin", "ADMIN");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var result = await client.DeleteAsync("/todos/1");
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode,
                "Didn't receive 204 NO CONTENT when deleting Todo as an ADMIN user");
        }

        [TestMethod]
        [Authorize("jessa")]
        public async Task STEP5_2_nonadmin_cant_delete_todo()
        {
            // Set the token in the Authorization header
            string token = jwtGenerator.GenerateToken(3, "jessa", "USER");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var result = await client.DeleteAsync("/todos/1");
            Assert.AreEqual(HttpStatusCode.Forbidden, result.StatusCode,
                "Didn't receive 403 FORBIDDEN when deleting Todo as a non-ADMIN user");
        }
    }
    
}
