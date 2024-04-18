-- INSERT

-- Add Disneyland to the park table. (It was established on 7/17/1955, has an area of 2.1 square kilometers and does not offer camping.)

INSERT INTO park (park_name, date_established, area, has_camping)
VALUES ('Disneyland', '7/17/1955', 2.1, 0);

-- Add Hawkins, IN (with a population of 30,000 and an area of 38.1 square kilometers) and Cicely, AK (with a popuation of 839 and an area of 11.4 square kilometers) to the city table.

INSERT INTO city (city_name, state_abbreviation, population, area)
VALUES ('Hawkins', 'IN', 30000, 38.1), ('Cicely', 'AK', 839, 11.4);

-- Since Disneyland is in California (CA), add a record representing that to the park_state table.

INSERT INTO park_state (park_id, state_abbreviation)
    SELECT park_id, 'CA'
        FROM park
        WHERE park_name = 'Disneyland';


-- UPDATE

-- Change the state nickname of California to "The Happiest Place on Earth."

UPDATE state
    SET state_nickname = 'The Happiest Place on Earth'
    WHERE state_abbreviation = 'CA';

-- Increase the population of California by 1,000,000.

UPDATE state
    SET population = population + 1000000
    WHERE state_abbreviation = 'CA';

-- Change the capital of California to Anaheim.

UPDATE state
    SET capital = (SELECT city_id FROM city WHERE city_name = 'Anaheim' AND state_abbreviation = 'CA')
    WHERE state_abbreviation = 'CA';

-- Change California's nickname back to "The Golden State", reduce the population by 1,000,000, and change the capital back to Sacramento.

UPDATE state
    SET state_nickname = 'The Golden State',
        population = population - 1000000,
        capital = (SELECT city_id FROM city WHERE city_name = 'Sacramento' AND state_abbreviation = 'CA')
    WHERE state_abbreviation = 'CA';


-- DELETE

-- Delete Hawkins, IN from the city table.

DELETE FROM city
    WHERE city_name = 'Hawkins' AND state_abbreviation = 'IN';

-- Delete all cities with a population of less than 1,000 people from the city table.

DELETE FROM city
    WHERE population < 1000;


-- REFERENTIAL INTEGRITY

-- Try adding a city to the city table with "XX" as the state abbreviation.

INSERT INTO city (city_name, state_abbreviation, population, area)
VALUES ('Springfield', 'XX', 32000, 50);

-- Try deleting California from the state table.

DELETE FROM state
    WHERE state_abbreviation = 'CA';

-- Try deleting Disneyland from the park table. Try again after deleting its record from the park_state table.

DELETE FROM park
    WHERE park_name = 'Disneyland';

DELETE FROM park_state
    WHERE park_id = (
        SELECT park_id
            FROM park
            WHERE park_name = 'Disneyland'
    );


-- CONSTRAINTS

-- NOT NULL constraint
-- Try adding Smallville, KS to the city table without specifying its area or population.

INSERT INTO city (city_name, state_abbreviation)
VALUES ('Smallville', 'KS');

-- DEFAULT constraint
-- Try adding Smallville, KS again, specifying an area but not a population.

INSERT INTO city (city_name, state_abbreviation, area)
VALUES ('Smallville', 'KS', 0.5);

-- Retrieve the new record to confirm it has been given a default, non-null value for population.

SELECT *
    FROM city
    WHERE city_name = 'Smallville';

-- UNIQUE constraint
-- Try changing California's nickname to "Vacationland" (which is already the nickname of Maine).

UPDATE state
    SET state_nickname = 'Vacationland'
    WHERE state_abbreviation = 'CA';

-- CHECK constraint
-- Try changing the census region of Florida (FL) to "Southeast" (which is not a valid census region).

UPDATE state
    SET census_region = 'Southeast'
    WHERE state_abbreviation = 'FL';


-- TRANSACTIONS

-- Delete the record for Smallville, KS within a transaction.

BEGIN TRANSACTION;
DELETE FROM city
    WHERE city_name = 'Smallville' AND state_abbreviation = 'KS';
COMMIT;

-- Delete all of the records from the park_state table, but then "undo" the deletion by rolling back the transaction.

BEGIN TRANSACTION;
DELETE FROM park_state;
SELECT COUNT(*) FROM park_state;
ROLLBACK;
SELECT COUNT(*) FROM park_state;

-- Update all of the cities to be in the state of Texas (TX), but then roll back the transaction.

BEGIN TRANSACTION;
UPDATE city SET state_abbreviation = 'TX';
SELECT TOP 5 city_name, state_abbreviation FROM city;
ROLLBACK;
SELECT TOP 5 city_name, state_abbreviation FROM city;


-- Demonstrate two different SQL connections trying to access the same table where one is inside of a transaction but hasn't committed yet.

-- Run in a separate query tab/window:
BEGIN TRANSACTION;
INSERT INTO city (city_name, state_abbreviation, population, area)
VALUES ('Schrodinger''s City', 'NJ', 0, 0);
-- (Notice there's no COMMIT or ROLLBACK.)

-- This statement won't finish executing while the city table is locked.
SELECT * FROM city WHERE city_name = 'Schrodinger''s City';

-- Using WITH (NOLOCK) you can peek at the data, ROLLBACK the transaction in the other tab, and show it disappeared.
SELECT * FROM city WITH (NOLOCK) WHERE city_name = 'Schrodinger''s City';
