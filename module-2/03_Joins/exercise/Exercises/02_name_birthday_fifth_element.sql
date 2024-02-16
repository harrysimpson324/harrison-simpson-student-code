-- 2. The names and birthdays of actors in "The Fifth Element"
-- Order the results alphabetically (A-Z) by name.
-- (15 rows)

SELECT person_name, birthday
FROM person
join movie_actor ON person_id = actor_id
join movie ON movie_actor.movie_id = movie.movie_id
WHERE title = 'The Fifth Element'
ORDER BY person_name