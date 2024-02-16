-- 7. Remove the actor appearances in "Avengers: Infinity War" (14 rows)
-- Note: Don't remove the actors themeselves, just make it so it seems no one appeared in the movie.

DELETE FROM movie_actor
where movie_id IN (select movie_id from movie where title = 'Avengers: Infinity War');