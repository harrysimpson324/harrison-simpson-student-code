-- 14. The names of actors who've appeared in the movies in the "Back to the Future Collection", sorted alphabetically.
-- (28 rows)

select DISTINCT person_name
from person
join movie_actor on person_id = actor_id
join movie on movie.movie_id = movie_actor.movie_id
join collection on movie.collection_id = collection.collection_id
WHERE collection_name = 'Back to the Future Collection'
ORDER BY person_name;