-- 12. The titles of the movies in the "Star Wars Collection" that weren't directed by George Lucas, sorted alphabetically.
-- (5 rows)

SELECT title
from movie
join collection ON collection.collection_id = movie.collection_id
join person ON person_id = director_id
WHERE person_name != 'George Lucas' AND collection_name = 'Star Wars Collection'
ORDER BY title;