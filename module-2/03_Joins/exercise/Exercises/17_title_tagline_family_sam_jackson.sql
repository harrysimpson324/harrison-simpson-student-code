-- 17. The titles and taglines of movies that are in the "Family" genre that Samuel L. Jackson has acted in.
-- Order the results alphabetically by movie title.
-- (4 rows)

SELECT title, tagline
from person
join movie_actor ON person_id = actor_id
join movie on movie_actor.movie_id = movie.movie_id
join movie_genre ON movie.movie_id = movie_genre.movie_id
join genre on movie_genre.genre_id = genre.genre_id
where genre_name = 'Family' and person_name = 'Samuel L. Jackson'
order by title