-- 11. Hollywood is remaking the classic movie "The Blob" and doesn't have a director yet. Add yourself to the person
--     table, and assign yourself as the director of "The Blob" (the movie is already in the movie table). (1 record each)

INSERT into person (person_name, birthday)
VALUES('Harry Simpson', '11.11.1995');

UPDATE movie
set director_id = (select person_id from person where person_name = 'Harry Simpson')
Where title = 'The Blob';