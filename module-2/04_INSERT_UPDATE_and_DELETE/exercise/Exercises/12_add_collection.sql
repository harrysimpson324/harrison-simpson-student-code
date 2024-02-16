-- 12. Create a "Bill Murray Collection" in the collection table. For the movies that have Bill Murray in them, set
--     their collection ID to the "Bill Murray Collection". (1 row, 6 rows)

INSERT into collection(collection_name)
VALUES ('Bill Murray Collection');

UPDATE movie
SET collection_id = (select collection_id from collection where collection_name = 'Bill Murray Collection')
Where movie_id IN (select movie.movie_id 
				  from movie 
				  join movie_actor ON movie.movie_id = movie_actor.movie_id
				  join person ON actor_id = person_id
				  where person_name = 'Bill Murray');