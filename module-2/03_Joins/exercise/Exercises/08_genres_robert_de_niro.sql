-- 8. The genres of movies that Robert De Niro has appeared in that were released in 2010 or later, sorted alphabetically.
-- (6 rows)

SELECT DISTINCT genre_name
FROM person
JOIN movie_actor ON person_id = actor_id
join movie ON movie_actor.movie_id = movie.movie_id
join movie_genre ON movie.movie_id = movie_genre.movie_id
join genre ON movie_genre.genre_id = genre.genre_id
WHERE person_name = 'Robert De Niro' AND movie.release_date > '01_01_2010'
ORDER BY genre_name;