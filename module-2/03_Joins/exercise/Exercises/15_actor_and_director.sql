-- 15. The title of the movie and the name of director for movies where the director was also an actor in the same movie.
-- Order the results by movie title (A-Z)
-- (73 rows)

SELECT title, p2.person_name
from person p1
join movie_actor ON person_id = actor_id
join movie on movie_actor.movie_id = movie.movie_id
join person p2 on director_id = p2.person_id
WHERE director_id = movie_actor.actor_id
ORDER BY title;