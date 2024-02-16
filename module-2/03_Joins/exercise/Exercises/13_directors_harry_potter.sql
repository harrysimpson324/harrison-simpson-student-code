-- 13. The directors of the movies in the "Harry Potter Collection", sorted alphabetically.
-- (4 rows)

SELECT DISTINCT person_name
from person
join movie on person_id = director_id
join collection on movie.collection_id = collection.collection_id
WHERE collection_name = 'Harry Potter Collection'
ORDER BY person_name;