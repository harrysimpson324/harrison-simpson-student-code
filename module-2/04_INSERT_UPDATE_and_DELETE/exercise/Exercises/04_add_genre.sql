-- 4. Add a "Sports" genre to the genre table. Add the movie "Coach Carter" to the newly created genre. (1 row each)

INSERT INTO genre (genre_name)
VALUES ('Sports');

INSERT INTO movie_genre (movie_id, genre_id)
select movie_id, (SELECT genre_id from genre where genre_name = 'Sports')
from movie
where title = 'Coach Carter';