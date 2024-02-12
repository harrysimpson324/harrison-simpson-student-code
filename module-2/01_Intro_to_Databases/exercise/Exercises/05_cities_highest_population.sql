-- 5. The name, state abbreviation, and population of the 5 cities with the highest population.
-- (5 rows)
SELECT state_name, state_abbreviation, population
FROM state
ORDER BY population DESC
LIMIT 5;
