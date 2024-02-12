-- SELECT
-- Use a SELECT statement to return a literal string
SELECT 'Hello, SQL!';

-- Use a SELECT statement to add two numbers together (and label the result "sum")
SELECT 2 + 2 AS sum;


-- SELECT ... FROM
-- Write queries to retrieve...
SELECT state_name
FROM state;

-- The names from all the records in the state table
SELECT *
FROM state;

SELECT state_name, state_abbreviation
FROM state;


-- The names and populations of all cities
SELECT city_name, population
FROM city;

-- All columns from the park table
SELECT * FROM 
park;



-- ORDERING RESULTS

-- Populations of all states from largest to smallest.
-- Note ASC is default
SELECT state_name, population
FROM state
ORDER BY population DESC;


-- Change sort order to DESC to see largest to smallest


-- States sorted alphabetically (A-Z) within their census region. The census regions are sorted in reverse alphabetical (Z-A) order.
-- Note order of columns in the ORDER BY: census_region is the major sort, state_name the minor sort,
--   meaning it's sorted within the major column, i.e. census_region.
-- Note order of columns in the SELECT only controls order columns are returned (i.e. "displayed"), not sort order.
SELECT state_name, census_region
FROM state
ORDER BY census_region DESC, state_name ASC;

-- The biggest park by area
-- Note that area isn't in the SELECT, but can be used in the ORDER BY
SELECT park_name, area
FROM park
ORDER BY area DESC;


-- LIMITING RESULTS

-- The 10 largest cities by populations
SELECT city_name, population
FROM city
ORDER BY population DESC
LIMIT 10;

-- The 20 oldest parks from oldest to youngest in years, sorted alphabetically by name.
-- SELECT park_name, (CURRENT_DATE - date_established) / 365 AS age
SELECT park_name, date_part('year', CURRENT_DATE) - date_part('year', date_established) AS age
FROM park
ORDER BY age DESC, park_name ASC
LIMIT 20;

--SELECT * FROM park ORDER BY date_established DESC;


-- SELECT __ FROM __ WHERE
-- Write queries to retrieve...

-- The names of cities in California (CA)
SELECT city_name
FROM city
WHERE state_abbreviation = 'CA'
ORDER BY city_name;


-- The names and state abbreviations of cities NOT in California
SELECT city_name, state_abbreviation
FROM city
WHERE state_abbreviation <> 'CA'
ORDER BY city_name;

-- The names and areas of cities smaller than 25 square kilometers
SELECT city_name, area
FROM city
WHERE area < 25
ORDER BY area;

-- The names from all records in the state table that have no assigned census region
SELECT state_name 
FROM state
WHERE census_region IS NULL
ORDER BY state_name;

-- The names and census regions from all records in the state table that have an assigned census region
SELECT state_name, census_region
FROM state
WHERE census_region IS NOT NULL
ORDER BY state_name;


-- WHERE with AND/OR
-- Write queries to retrieve...

-- The names, areas, and populations of cities smaller than 25 sq. km. with more than 100,000 people
SELECT city_name, area, population
FROM city
WHERE area < 25 AND population > 100000
ORDER BY city_name;

-- The names and census regions of all states (and territories and districts) not in the Midwest region (including those that don't have any census region)
SELECT state_name, census_region
FROM state
WHERE census_region <> 'Midwest' OR census_region IS NULL
ORDER BY state_name;

-- The names, areas, and populations of cities in California (CA) or Florida (FL)
SELECT city_name, state_abbreviation, area, population 
FROM city
WHERE state_abbreviation = 'CA' OR state_abbreviation = 'FL'

-- The names, areas, and populations of cities in New England -- Connecticut (CT), Maine (ME), Massachusetts (MA), New Hampshire (NH), Rhode Island (RI) and Vermont (VT)
SELECT city_name, state_abbreviation, area, population 
FROM city
WHERE state_abbreviation IN ('CT', 'ME', 'MA', 'NH', 'RI', 'VT')
ORDER BY city_name;

SELECT city_name, state_abbreviation, area, population 
FROM city
WHERE state_abbreviation NOT IN ('CT', 'ME', 'MA', 'NH', 'RI', 'VT')
ORDER BY city_name;

-- SELECT statements involving math
-- Write a query to retrieve the names and areas of all parks in square METERS
-- (the values in the database are stored in square kilometers)
-- Label the second column "area_in_square_meters"

SELECT park_name, (area * 1000000) As area_in_square_meters
FROM park;

-- All values vs. distinct values

-- Write a query to retrieve the names of all cities and notice repeats (like Springfield and Columbus)
SELECT city_name
FROM city;

-- Do it again, but without the repeats (note the difference in row count)
SELECT DISTINCT city_name, state_abbreviation
FROM city
ORDER BY city_name;


-- LIKE
-- Write queries to retrieve...

-- The names of all cities that begin with the letter "A"
SELECT city_name
FROM city
WHERE city_name LIKE 'A%';


-- The names of all cities that end with "Falls"
SELECT city_name 
FROM city
WHERE city_name LIKE '% Falls'

-- The names of all cities that contain a space
SELECT city_name
FROM city
WHERE city_name LIKE '% %';


-- BETWEEN
-- Write a query to retrieve the names and areas of parks of at least 100 sq. kilometers but no more than 200 sq. kilometers
SELECT park_name, area
FROM park
WHERE area BETWEEN 100 AND 200;


-- DATES
-- Write a query to retrieve the names and dates established of parks established before 1900
SELECT park_name, date_established
FROM park
WHERE date_established < '1900-1-1';
