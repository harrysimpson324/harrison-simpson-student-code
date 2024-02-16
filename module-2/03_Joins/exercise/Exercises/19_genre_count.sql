-- 19. The genre name and the number of movies in each genre. Name the count column 'num_of_movies'.
-- Order the results from the highest movie count to the lowest.
-- (19 rows, the highest expected count is around 400).

SELECT genre_name, COUNT(movie.title) AS num_of_movies
from movie
join movie_genre ON movie.movie_id = movie_genre.movie_id
join genre on movie_genre.genre_id = genre.genre_id
GROUP BY genre_name
ORDER BY num_of_movies DESC;