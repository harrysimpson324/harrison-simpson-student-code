-- 3. Did you know Eric Stoltz was originally cast as Marty McFly in "Back to the Future"? Add Eric Stoltz to the list of actors for "Back to the Future" (1 row)


INSERT INTO movie_actor (actor_id, movie_id)
SELECT person_id, (Select movie_id from movie where title = 'Back to the Future')
 from person 
 where person_name = 'Eric Stoltz';
