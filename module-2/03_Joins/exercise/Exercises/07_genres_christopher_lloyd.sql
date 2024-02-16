-- 7. The genres of movies that Christopher Lloyd has appeared in, sorted alphabetically.
-- (8 rows) Hint: DISTINCT will prevent duplicate values in your query results.

SELECT DISTINCT genre_name
FROM person
JOIN movie_actor ON person_id = actor_id
join movie ON movie_actor.movie_id = movie.movie_id
join movie_genre ON movie.movie_id = movie_genre.movie_id
join genre ON movie_genre.genre_id = genre.genre_id
WHERE person_name = 'Christopher Lloyd'
ORDER BY genre_name;