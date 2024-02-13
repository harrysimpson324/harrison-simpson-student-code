-- CONCATENATING OUTPUTS

-- All city names and their state abbreviation.
SELECT (city_name || ', ' || state_abbreviation) AS city_state
FROM city;


-- The all parks by name and date established.

SELECT ('Name: ' || park_name || ', Area: ' || area) AS park_area
FROM park;


-- The census region and state name of all states in the West & Midwest sorted in ascending order.
SELECT CONCAT(census_region, ': ', state_name) as region_and_state 
FROM state
WHERE census_region ILIKE '%west'
ORDER BY region_and_state;


-- SUBQUERIES

-- List all cities in the western census region
SELECT city_name, state_abbreviation
FROM city
WHERE state_abbreviation IN (
	SELECT state_abbreviation
	FROM state
	WHERE census_region = 'West');



SELECT state_abbreviation
FROM state
WHERE census_region = 'West';

SELECT * FROM city;


-- List all cities in states with "garden" in their nickname
SELECT city_name, state_abbreviation, (SELECT state_nickname FROM state WHERE city.state_abbreviation = state.state_abbreviation) AS state_nickname
FROM city
WHERE state_abbreviation IN (
	SELECT state_abbreviation
	FROM state
	WHERE state_nickname ILIKE '%garden%'
);


SELECT state_name, state_abbreviation, state_nickname
FROM state
WHERE state_nickname ILIKE '%garden%'


-- Get the parks with the smallest and largest areas
SELECT park_name, area
FROM park
WHERE area = (SELECT MAX(area) FROM park) OR area = (SELECT MIN(area) FROM park)
ORDER BY area

SELECT park_name, MAX(area), MIN(area)
FROM park


-- Get the state name and census region for all states with a national park
SELECT state_name, census_region
FROM state
WHERE state_abbreviation IN (
	SELECT DISTINCT state_abbreviation
	FROM park_state
)
ORDER BY census_region, state_name


SELECT DISTINCT state_abbreviation
FROM park_state
ORDER BY state_abbreviation




-- Subqueries aren't limited to WHERE clauses, can appear in SELECT list (must return only 1 result)
-- Include state name rather than the state abbreviation while counting the number of cities in each state,
--   ordered from most cities to least.
SELECT COUNT(city_name) AS cities, (SELECT state_name FROM state WHERE state_abbreviation = city.state_abbreviation) AS state_name
FROM city
GROUP BY state_abbreviation
ORDER BY cities DESC;

SELECT COUNT(city_name) AS cities, state_abbreviation
FROM city
GROUP BY state_abbreviation
ORDER BY cities DESC;

SELECT COUNT(census_region) AS census_count, COUNT(state_abbreviation) AS states, COUNT(*) AS all_rows, AVG(area) AS average_area, census_region
FROM state
GROUP BY census_region


-- AGGREGATE FUNCTIONS

-- Average population across all the states. Note the use of alias, common with aggregated values.
SELECT round(AVG(population), 0) AS avg_state_population
FROM state;

-- Total population in the West and South census regions
SELECT SUM(population) AS west_south_population
FROM state
WHERE census_region = 'West' OR census_region = 'South';

-- The number of cities with populations greater than 1 million
SELECT COUNT(population) as big_cities_count
FROM city
WHERE population > 1000000;

-- The number of state nicknames.
SELECT COUNT(state_nickname) AS nickname_count, COUNT(*) AS row_count
FROM state

-- The area of the smallest and largest parks.
SELECT MAX(area) AS largest, MIN(area) AS smallest
FROM park


-- GROUP BY

-- Count the number of cities in each state, ordered from most cities to least.


-- Determine the average park area depending upon whether parks allow camping or not.
SELECT has_camping, round(AVG(area)) AS avg_park_are
FROM park
GROUP BY has_camping

-- Sum of the population of cities in each state ordered by state abbreviation.
SELECT state_abbreviation, SUM(population) AS sum_city_population
FROM city
GROUP BY state_abbreviation
ORDER BY sum_city_population DESC
LIMIT 5


-- The smallest city population in each state ordered by city population.
SELECT state_abbreviation, MIN(population) AS smallest_city
FROM city
GROUP BY state_abbreviation
ORDER BY smallest_city DESC



