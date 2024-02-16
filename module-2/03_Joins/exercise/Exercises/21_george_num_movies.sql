-- 21. For every person in the person table with the first name of "George", list the number of movies they've been in. Name the count column 'num_of_movies'.
-- Include all Georges, even those that have not appeared in any movies. Display the names in alphabetical order.
-- (59 rows)
-- TIP: This one can be a little tricky. If you're off by one, look closer at each clause of your statement. There's something you can change to get a different result set.

SELECT person_name, COUNT(movie_actor.movie_id) AS num_of_movies
from person 
LEFT OUTER join movie_actor on person_id = actor_id
--in movie on movie_actor.movie_id = movie.movie_id
WHERE person_name ILIKE 'George %'
GROUP BY person_id
ORDER BY person_name;