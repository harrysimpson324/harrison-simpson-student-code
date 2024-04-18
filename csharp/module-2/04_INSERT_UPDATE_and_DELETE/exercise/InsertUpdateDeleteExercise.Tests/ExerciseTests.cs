using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsertUpdateDeleteExercise.Tests
{
    [TestClass]
    public class ExerciseTests
    {
        private static string mainConnectionString;
        private static string movieConnectionString;
        private SqlConnection conn;
        private TransactionScope transaction;
        private static string exerciseFolder;
        private static List<string> exerciseFiles;

        [ClassInitialize]
        public static void InitializeTestClass(TestContext context)
        {
            SetConnectionStrings("MovieDBTemp");
            exerciseFiles = GetExerciseSqlFiles();
            if (exerciseFiles.Count == 0)
            {
                Assert.Fail("Exercise folder and files not found. Please check that the exercise folder is in the same directory or in a directory above where these tests are running from.");
            }

            // create a smaller temporary database with the same schema but less irrelevant data
            string sqlCreate = File.ReadAllText("MovieDBTemp-create.sql");
            string sqlLoad = File.ReadAllText("MovieDBTemp-load.sql");

            using (SqlConnection mainConn = new SqlConnection(mainConnectionString))
            using (SqlConnection movieConn = new SqlConnection(movieConnectionString))
            {
                mainConn.Open();
                SqlCommand cmdCreate = new SqlCommand(sqlCreate, mainConn);
                cmdCreate.ExecuteNonQuery();

                movieConn.Open();
                SqlCommand cmdLoad = new SqlCommand(sqlLoad, movieConn);
                cmdLoad.ExecuteNonQuery();
            }
        }

        [ClassCleanup]
        public static void AfterAllTests()
        {
            // drop the temporary database
            string sql = File.ReadAllText("MovieDBTemp-drop.sql");

            using (SqlConnection conn = new SqlConnection(mainConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Initializes the database for the test.
        /// </summary>
        [TestInitialize]
        public void BeforeEachTest()
        {
            // Begin the transaction
            transaction = new TransactionScope();
        }

        /// <summary>
        /// Cleans up the database after each test.
        /// </summary>
        [TestCleanup]
        public void AfterEachTest()
        {
            if (transaction != null)
            {
                transaction.Dispose();
            }
        }

        [TestMethod]
        public void ExerciseProblem01()
        {
            int expectedRowsAffected = 1;

            string sqlVerify = "SELECT person_name, birthday FROM person WHERE person_name = 'Lisa Byway';";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("person_name");
            dtExpected.Columns.Add("birthday", typeof(DateTime));
            dtExpected.Rows.Add(new object[] { "Lisa Byway", new DateTime(1984, 4, 15) });

            CheckAnswerForProblem("01", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem02()
        {
            int expectedRowsAffected = 1;

            string sqlVerify = "SELECT title, overview, release_date, length_minutes FROM movie WHERE title = 'Euclidean Pi';";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("title");
            dtExpected.Columns.Add("overview");
            dtExpected.Columns.Add("release_date", typeof(DateTime));
            dtExpected.Columns.Add("length_minutes", typeof(int));
            dtExpected.Rows.Add(new object[] { "Euclidean Pi", "The epic story of Euclid as a pizza delivery boy in ancient Greece", new DateTime(2015, 3, 14), 194 });

            CheckAnswerForProblem("02", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem03()
        {
            int expectedRowsAffected = 1;

            string sqlVerify = "SELECT count(*) as count FROM movie_actor WHERE movie_id = 105 AND actor_id = 7036;";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("count", typeof(int));
            dtExpected.Rows.Add(new object[] { 1 });

            CheckAnswerForProblem("03", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem04()
        {
            int expectedRowsAffected = 2;

            string sqlVerify = "SELECT (SELECT count(*) FROM genre WHERE genre_name = 'Sports') as genre_count, (SELECT count(*) FROM movie_genre WHERE genre_id IN (SELECT genre_id FROM genre WHERE genre_name = 'Sports') AND movie_id = 7214) as movie_genre_count;";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("genre_count", typeof(int));
            dtExpected.Columns.Add("movie_genre_count", typeof(int));
            dtExpected.Rows.Add(new object[] { 1, 1 });

            CheckAnswerForProblem("04", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem05()
        {
            int expectedRowsAffected = 1;

            string sqlVerify = "SELECT title FROM movie WHERE movie_id = 11;";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("title");
            dtExpected.Rows.Add(new object[] { "Star Wars: A New Hope" });

            CheckAnswerForProblem("05", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem06()
        {
            int expectedRowsAffected = 3;

            string sqlVerify = "SELECT overview FROM movie WHERE length_minutes > 210 ORDER BY movie_id;";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("overview");
            dtExpected.Rows.Add(new object[] { "This is a long movie. 229 minutes long." });
            dtExpected.Rows.Add(new object[] { "This is a long movie. 227 minutes long." });
            dtExpected.Rows.Add(new object[] { "This is a long movie. 317 minutes long." });

            CheckAnswerForProblem("06", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem07()
        {
            int expectedRowsAffected = 14;

            string sqlVerify = "SELECT count(*) as actor_count FROM movie_actor WHERE movie_id = 299536;";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("actor_count", typeof(int));
            dtExpected.Rows.Add(new object[] { 0 });

            CheckAnswerForProblem("07", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem08()
        {
            int expectedRowsAffected = 6;

            string sqlVerify = "SELECT (SELECT count(*) FROM movie_actor WHERE actor_id = 37221) as actor_count, (SELECT count(*) FROM person WHERE person_id = 37221) as person_count;";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("actor_count", typeof(int));
            dtExpected.Columns.Add("person_count", typeof(int));
            dtExpected.Rows.Add(new object[] { 0, 0 });

            CheckAnswerForProblem("08", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem09()
        {
            int expectedRowsAffected = 16;

            string sqlVerify = "SELECT (SELECT count(*) FROM movie_actor WHERE movie_id = 77) as actor_count, (SELECT count(*) FROM movie_genre WHERE movie_id = 77) as genre_count, (SELECT count(*) FROM movie WHERE movie_id = 77) as movie_count;";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("actor_count", typeof(int));
            dtExpected.Columns.Add("genre_count", typeof(int));
            dtExpected.Columns.Add("movie_count", typeof(int));
            dtExpected.Rows.Add(new object[] { 0, 0, 0 });

            CheckAnswerForProblem("09", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem10()
        {
            int expectedRowsAffected = 1;

            string sqlVerify = "SELECT home_page, profile_path FROM person WHERE person_id = 34035;";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("home_page");
            dtExpected.Columns.Add("profile_path");
            dtExpected.Rows.Add(new object[] { "No image", null });

            CheckAnswerForProblem("10", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem11()
        {
            int expectedRowsAffected = 2;

            string sqlVerify = "SELECT CASE WHEN director_id IS NOT NULL THEN 1 ELSE 0 END as director_set FROM movie WHERE movie_id = 367220;";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("director_set", typeof(int));
            dtExpected.Rows.Add(new object[] { 1 });

            CheckAnswerForProblem("11", expectedRowsAffected, sqlVerify, dtExpected);
        }

        [TestMethod]
        public void ExerciseProblem12()
        {
            int expectedRowsAffected = 6;

            string sqlVerify = "SELECT (SELECT count(*) FROM collection WHERE collection_name = 'Bill Murray Collection') as collection_count, (SELECT count(*) FROM movie m JOIN movie_actor ma ON m.movie_id = ma.movie_id WHERE actor_id = 1532 AND collection_id = (SELECT collection_id FROM collection WHERE collection_name = 'Bill Murray Collection')) as movie_count;";

            DataTable dtExpected = new DataTable();
            dtExpected.Columns.Add("collection_count", typeof(int));
            dtExpected.Columns.Add("movie_count", typeof(int));
            dtExpected.Rows.Add(new object[] { 1, 5 });

            CheckAnswerForProblem("12", expectedRowsAffected, sqlVerify, dtExpected);
        }

        private void CheckAnswerForProblem(string problemNumber, int expectedRowsAffected, string sqlVerify, DataTable dtExpected)
        {
            string sqlActual = GetStudentQuery(problemNumber);

            sqlActual = Regex.Replace(sqlActual, "--[^\n]*(\n|$)", "");
            Assert.IsFalse(string.IsNullOrWhiteSpace(sqlActual), "No query found for this exercise. Make sure you've saved your changes to the exercise file.");

            int actualRowsAffected = ExecuteNonQuery(sqlActual);
            if (actualRowsAffected < expectedRowsAffected)
            {
                Assert.Fail("Your query didn't affect enough rows");
            }
            else if (actualRowsAffected > expectedRowsAffected)
            {
                Assert.Fail("Your query affected too many rows");
            }

            DataTable dtVerify = LoadDataTable(sqlVerify);

            // compare expected and actual data
            CompareData(dtExpected, dtVerify);
        }

        private static void CompareData(DataTable dtExpected, DataTable dtVerify)
        {
            Assert.AreEqual(dtExpected.Rows.Count, dtVerify.Rows.Count, "Returned row count doesn't match expected results. Please check your SQL for errors.");

            for (int i = 0; i < dtExpected.Rows.Count; i++)
            {
                foreach (DataColumn dc in dtExpected.Columns)
                {
                    Assert.AreEqual(dtExpected.Rows[i][dc.ColumnName], dtVerify.Rows[i][dc.ColumnName], $"Data returned doesn't match data expected for row {i + 1} in column \"{dc.ColumnName}\"");
                }
            }
        }

        private string GetStudentQuery(string problemNumber)
        {
            string exerciseFile = $"{exerciseFiles.FirstOrDefault(f => f.StartsWith(problemNumber))}";
            if (exerciseFile == null)
            {
                Assert.Fail($"No exercise file found. Check that the file name begins with {problemNumber}.");
            }

            string exerciseFilePath = $"{exerciseFolder}/{exerciseFile}";
            if (!File.Exists(exerciseFilePath))
            {
                Assert.Fail("Exercise file doesn't exist.");
            }

            string sql = File.ReadAllText(exerciseFilePath);

            return sql;
        }

        private int ExecuteNonQuery(string sql)
        {
            int rowsAffected = -1;
            using (conn = new SqlConnection(movieConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        private DataTable LoadDataTable(string sql)
        {
            using (conn = new SqlConnection(movieConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                return dt;
            }
        }

        private static List<string> GetExerciseSqlFiles()
        {
            string folderToFind = "Exercises";
            string currPath = System.Environment.CurrentDirectory;
            List<string> exerFiles = new List<string>();

            if (currPath.Contains("\\"))
            {
                currPath = currPath.Replace("\\", "/");
            }

            while (exerFiles.Count == 0)
            {
                if (Directory.GetDirectories(currPath).Any(d => d.EndsWith(folderToFind)))
                {
                    currPath = Directory.GetDirectories(currPath).FirstOrDefault(d => d.EndsWith(folderToFind));
                    exerciseFolder = currPath.Replace("\\", "/");

                    if (Directory.GetFiles(exerciseFolder).Count(f => f.EndsWith(".sql")) > 0)
                    {
                        List<string> tempExerciseFiles = Directory.GetFiles(exerciseFolder).Where(f => f.EndsWith(".sql")).ToList();

                        // get just the filenames so that we don't have to hard code the exercise file names and can find just by number
                        foreach (string ef in tempExerciseFiles)
                        {
                            exerFiles.Add(ef.Replace(exerciseFolder, "").Replace("\\", "").Replace("/", ""));
                        }
                        break;
                    }
                }
                else
                {
                    if (currPath == "C:" || currPath == "/") //ran out of locations to check
                    {
                        break;
                    }

                    //go up one level
                    currPath = currPath.Substring(0, currPath.LastIndexOf("/"));
                }
            }

            return exerFiles;
        }

        private static void SetConnectionStrings(string defaultDbName)
        {
            string host = Environment.GetEnvironmentVariable("DB_HOST") ?? @".\SQLEXPRESS";
            string dbName = Environment.GetEnvironmentVariable("DB_DATABASE") ?? defaultDbName;
            string username = Environment.GetEnvironmentVariable("DB_USERNAME");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            if (username != null && password != null)
            {
                mainConnectionString = $"Data Source={host};Initial Catalog=master;User Id={username};Password={password};";
                movieConnectionString = $"Data Source={host};Initial Catalog={dbName};User Id={username};Password={password};";
            }
            else
            {
                mainConnectionString = $"Data Source={host};Initial Catalog=master;Integrated Security=SSPI;";
                movieConnectionString = $"Data Source={host};Initial Catalog={dbName};Integrated Security=SSPI;";
            }
        }
    }
}
