-- 16. The names and birthdays of actors born in the 1950s who acted in movies that were released in 1985.
-- Order the results by actor from oldest to youngest.
-- (20 rows)

SELECT DISTINCT person_name, birthday
from movie
FULL OUTER JOIN movie_actor ON movie.movie_id = movie_actor.movie_id
FULL OUTER join person on actor_id = person_id
where release_date BETWEEN '01.01.1985' and '12.31.1985' AND birthday BETWEEN '01.01.1950' and '12.31.1959'
ORDER BY birthday;



