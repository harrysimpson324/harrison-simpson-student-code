DROP TABLE IF EXISTS movie_genre;
DROP TABLE IF EXISTS movie_actor;
DROP TABLE IF EXISTS movie;
DROP TABLE IF EXISTS collection;
DROP TABLE IF EXISTS person;
DROP TABLE IF EXISTS genre;

CREATE TABLE [genre] (
    genre_id   INT           NOT NULL IDENTITY (1,1),
    genre_name NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_genre] PRIMARY KEY (genre_id)
);

CREATE TABLE [person] (
    person_id    INT            NOT NULL IDENTITY (1,1),
    person_name  NVARCHAR (200) NOT NULL,
    birthday     DATE           NULL,
    deathday     DATE           NULL,
    biography    NVARCHAR (MAX) NULL,
    profile_path VARCHAR (200)  NULL,
    home_page    VARCHAR (200)  NULL,
	CONSTRAINT [PK_person] PRIMARY KEY (person_id)
);

CREATE TABLE [collection] (
    collection_id   INT           NOT NULL IDENTITY (1,1),
    collection_name VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_collection] PRIMARY KEY (collection_id)
);

CREATE TABLE [movie] (
    movie_id       INT            NOT NULL IDENTITY (1,1),
    title          NVARCHAR (200) NOT NULL,
    overview       NVARCHAR (MAX) NULL,
    tagline        NVARCHAR (400) NULL,
    poster_path    VARCHAR (200)  NULL,
    home_page      VARCHAR (200)  NULL,
    release_date   DATE           NULL,
    length_minutes INT            NOT NULL,
    director_id    INT            NULL,
    collection_id  INT            NULL,
	CONSTRAINT [PK_movie] PRIMARY KEY (movie_id),
    CONSTRAINT [FK_movie_director] FOREIGN KEY (director_id) REFERENCES [person] (person_id),
    CONSTRAINT [FK_movie_collection] FOREIGN KEY (collection_id) REFERENCES [collection] (collection_id)
);

CREATE TABLE [movie_actor] (
    movie_id INT NOT NULL,
    actor_id INT NOT NULL,
	CONSTRAINT [PK_movie_actor] PRIMARY KEY (movie_id, actor_id),
    CONSTRAINT [FK_movie_actor_movie] FOREIGN KEY (movie_id) REFERENCES [movie] (movie_id),
    CONSTRAINT [FK_movie_actor_actor] FOREIGN KEY (actor_id) REFERENCES [person] (person_id)
);

CREATE TABLE [movie_genre] (
    movie_id INT NOT NULL,
    genre_id INT NOT NULL,
	CONSTRAINT [PK_movie_genre] PRIMARY KEY (movie_id, genre_id),
    CONSTRAINT [FK_movie_genre_movie] FOREIGN KEY (movie_id) REFERENCES [movie] (movie_id),
    CONSTRAINT [FK_movie_genre_genre] FOREIGN KEY (genre_id) REFERENCES [genre] (genre_id)
);



SET IDENTITY_INSERT genre ON;
INSERT INTO genre (genre_id, genre_name) VALUES (28, N'Action');
INSERT INTO genre (genre_id, genre_name) VALUES (12, N'Adventure');
INSERT INTO genre (genre_id, genre_name) VALUES (16, N'Animation');
INSERT INTO genre (genre_id, genre_name) VALUES (35, N'Comedy');
INSERT INTO genre (genre_id, genre_name) VALUES (80, N'Crime');
INSERT INTO genre (genre_id, genre_name) VALUES (99, N'Documentary');
INSERT INTO genre (genre_id, genre_name) VALUES (18, N'Drama');
INSERT INTO genre (genre_id, genre_name) VALUES (10751, N'Family');
INSERT INTO genre (genre_id, genre_name) VALUES (14, N'Fantasy');
INSERT INTO genre (genre_id, genre_name) VALUES (36, N'History');
INSERT INTO genre (genre_id, genre_name) VALUES (27, N'Horror');
INSERT INTO genre (genre_id, genre_name) VALUES (10402, N'Music');
INSERT INTO genre (genre_id, genre_name) VALUES (9648, N'Mystery');
INSERT INTO genre (genre_id, genre_name) VALUES (10749, N'Romance');
INSERT INTO genre (genre_id, genre_name) VALUES (878, N'Science Fiction');
INSERT INTO genre (genre_id, genre_name) VALUES (10770, N'TV Movie');
INSERT INTO genre (genre_id, genre_name) VALUES (53, N'Thriller');
INSERT INTO genre (genre_id, genre_name) VALUES (10752, N'War');
INSERT INTO genre (genre_id, genre_name) VALUES (37, N'Western');
SET IDENTITY_INSERT genre OFF;
SET IDENTITY_INSERT person ON;
INSERT [dbo].[person] ([person_id], [person_name], [birthday], [deathday], [biography], [profile_path], [home_page]) VALUES (1, N'George Lucas', CAST(N'1944-05-14' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/WCSZzWdtPmdRxH9LUCVi2JPCSJ.jpg', NULL),
   (2, N'Mark Hamill', CAST(N'1951-09-25' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/zMQ93JTLW8KxusKhOlHFZhih3YQ.jpg', NULL),
   (3, N'Harrison Ford', CAST(N'1942-07-13' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/6MQgrJvdTPFvyErIgn0B2lTLVhr.jpg', NULL),
   (4, N'Carrie Fisher', CAST(N'1956-10-21' AS Date), CAST(N'2016-12-27' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/rfJtncHewKVnHjqpIZvjn24ESeC.jpg', NULL),
   (5, N'Peter Cushing', CAST(N'1913-05-26' AS Date), CAST(N'1994-08-11' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/rxfWFGJm35qJb2jy0jlauhYeNgV.jpg', NULL),
   (6, N'Anthony Daniels', CAST(N'1946-02-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/7kR4kwXtvXtvrsxWeX3QLX5NS5V.jpg', NULL),
   (24, N'Robert Zemeckis', CAST(N'1952-05-14' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/lPYDQ5LYNJ12rJZENtyASmVZ1Ql.jpg', NULL),
   (112, N'Cate Blanchett', CAST(N'1969-05-14' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vUuEHiAR0eD3XEJhg2DWIjymUAA.jpg', NULL),
   (130, N'Kenny Baker', CAST(N'1934-08-24' AS Date), CAST(N'2016-08-13' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/uo3RorCoGDWHecLtqjviwzFExxR.jpg', NULL),
   (335, N'Michael Shannon', CAST(N'1974-08-07' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/6mMczfjM8CiS1WuBOgo5Xom1TcR.jpg', NULL),
   (380, N'Robert De Niro', CAST(N'1943-08-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/cT8htcckIuyI1Lqwt1CvD02ynTh.jpg', NULL),
   (521, N'Michael J. Fox', CAST(N'1961-06-09' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/jdHYYovf6ZGEMKnV7niaiHY1MSt.jpg', NULL),
   (525, N'Christopher Nolan', CAST(N'1970-07-30' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/xuAIuYSmsUzKlUMBFGVZaWsY3DZ.jpg', NULL),
   (529, N'Guy Pearce', CAST(N'1967-10-05' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vTqk6Nh3WgqPubkS23eOlMAwmwa.jpg', NULL),
   (530, N'Carrie-Anne Moss', CAST(N'1967-08-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/ArlQHNKGUOlSDUHdIdjG6nLiT2A.jpg', NULL),
   (532, N'Joe Pantoliano', CAST(N'1951-09-12' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/rMcwHQXkqajl1YNCY6TqrCkT5tu.jpg', NULL),
   (534, N'Mark Boone Junior', CAST(N'1955-03-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/rcncVr356hpfKX9qOrKL3SJlEO7.jpg', NULL),
   (535, N'Russ Fega', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/d0W7kq97Ul8Iz5LZIVNDKxSly8M.jpg', NULL),
   (536, N'Jorja Fox', CAST(N'1968-07-07' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/hCRdbNzZjkhYyVoZPmhYF5OqpaX.jpg', NULL),
   (537, N'Stephen Tobolowsky', CAST(N'1951-05-30' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/4GNQJVEcU4V8AGVMXKM5FVOuW8h.jpg', NULL),
   (538, N'Harriet Sansom Harris', CAST(N'1955-01-08' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/1ShvYCWkZycAGb27ZivGrLx1PhS.jpg', NULL),
   (539, N'Thomas Lennon', CAST(N'1970-08-09' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/s8pw7BfuMxN7P0p5XJ9POfod7zW.jpg', NULL),
   (540, N'Callum Keith Rennie', CAST(N'1960-09-14' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/zOeA4IR4xYde2VlDsHZy2SoPZkc.jpg', NULL),
   (542, N'Kimberly Campbell', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (543, N'Marianne Muellerleile', CAST(N'1948-11-26' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/8mlAV0ChK35WXQrnlKoEzKNNrFR.jpg', NULL),
   (544, N'Larry Holden', CAST(N'1961-05-15' AS Date), CAST(N'2011-02-13' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/wXlesadVDSWinrYPjKLeiay3X0m.jpg', NULL),
   (707, N'Dan Aykroyd', CAST(N'1952-07-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/iVMmeVJx8IpCEjlGBZWzIWvX5Qo.jpg', NULL),
   (778, N'John Ashton', CAST(N'1948-02-22' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/8TzYptb6pPxZJXfrJIu0UoZTNkX.jpg', NULL),
   (887, N'Owen Wilson', CAST(N'1968-11-18' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/op8sGD20k3EQZLR92XtaHoIbW0o.jpg', NULL),
   (925, N'Paul Guilfoyle', CAST(N'1949-04-28' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/c7unxeM13lF9pMhZhYwlNsSFjFe.jpg', NULL),
   (938, N'Djimon Hounsou', CAST(N'1964-04-24' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/hco0KMbrxACYTmBfAkSzCf23CXV.jpg', NULL),
   (1004, N'Danny Aiello', CAST(N'1933-06-20' AS Date), CAST(N'2019-12-12' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/vl71InQaqL3khAPJrvUjsxtynVP.jpg', NULL),
   (1062, N'Christopher Lloyd', CAST(N'1938-10-22' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/nxVjpyb3UrfbPZnEyDNlQVlFAs5.jpg', NULL),
   (1063, N'Lea Thompson', CAST(N'1961-05-31' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/rMwCxywPyDigR9Oz1zMF7uNwT6E.jpg', NULL),
   (1064, N'Crispin Glover', CAST(N'1964-04-20' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/8CUMjcvFK3uHO5fLi51zS40gglr.jpg', NULL),
   (1065, N'Thomas F. Wilson', CAST(N'1959-04-15' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/gg04BCW4bTagLqxTxvw4eUAUoOx.jpg', NULL),
   (1066, N'Claudia Wells', CAST(N'1966-07-05' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/tdB1Qavf7l2sKqTK9aIXxlYApbI.jpg', NULL),
   (1067, N'Marc McClure', CAST(N'1957-03-31' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/c8DFehNqNEDLBALTdAWZzUEN2tD.jpg', NULL),
   (1068, N'Wendie Jo Sperber', CAST(N'1958-09-15' AS Date), CAST(N'2005-11-29' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/dufqiCvSBQUxuHmMXcH6U8fZG4k.jpg', NULL),
   (1069, N'George DiCenzo', CAST(N'1940-04-21' AS Date), CAST(N'2010-08-09' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/8L9fr5601BbUs3UzoCEELnxEKVm.jpg', NULL),
   (1070, N'Frances Lee McCain', CAST(N'1944-07-28' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/cpG16FA90mQ4xC6xxTsUu1p2yRr.jpg', NULL),
   (1072, N'James Tolkan', CAST(N'1931-06-20' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/7rbZdgHphltKv0MVH8oxS0br6mf.jpg', NULL),
   (1074, N'Harry Waters, Jr.', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/leyDoL9wnYRFfUeDyOCourN6wxC.jpg', NULL),
   (1146, N'Julie Delpy', CAST(N'1969-12-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/rOEyooUUapPodwNb52qoyfzTROs.jpg', NULL),
   (1245, N'Scarlett Johansson', CAST(N'1984-11-22' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/6NsMbJXRlDZuDzatN2akFdGuTvx.jpg', NULL),
   (1284, N'Noah Taylor', CAST(N'1969-09-04' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/a9VuohmpqbvcYflOpi0F3ck8L2j.jpg', NULL),
   (1524, N'Harold Ramis', CAST(N'1944-11-21' AS Date), CAST(N'2014-02-24' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/ybP1eurMS1OFdKMIvA9ThNUNuh2.jpg', NULL),
   (1532, N'Bill Murray', CAST(N'1950-09-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/nnCsJc9x3ZiG3AFyiyc3FPehppy.jpg', NULL),
   (1533, N'Andie MacDowell', CAST(N'1958-04-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/swiQfeUHHCFQWc8wFil00OKuzdw.jpg', NULL),
   (1534, N'Chris Elliott', CAST(N'1960-05-31' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/oQ4ZuOGoZ5dPDiLxri6ZPQLewAU.jpg', NULL),
   (1535, N'Brian Doyle-Murray', CAST(N'1945-10-31' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/atVyKPOaZaDncy5RGq1oCrK73iu.jpg', NULL),
   (1536, N'Marita Geraghty', CAST(N'1962-03-26' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/trncDdjDlN81VrMNPr71ZZVZFCR.jpg', NULL),
   (1537, N'Angela Paton', CAST(N'1930-01-11' AS Date), CAST(N'2016-05-16' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/zt2VvSVntPwmmR3ZVxDYVvGEJ5L.jpg', NULL),
   (1538, N'Rick Ducommun', CAST(N'1956-07-03' AS Date), CAST(N'2015-06-12' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/usW5QTa85JuonyRktb3s5HjDD84.jpg', NULL),
   (1539, N'Rick Overton', CAST(N'1954-08-10' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/6TYFFjEKcS7ielkYru6MvJa8jSY.jpg', NULL),
   (1540, N'Robin Duke', CAST(N'1954-03-13' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1542, N'Willie Garson', CAST(N'1964-02-20' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/lsODqbgT4mpzXHxf8MWCYOZGULc.jpg', NULL),
   (1737, N'David Patrick Kelly', CAST(N'1951-01-23' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/pTlRWsOxiTRiKk4SEEOsIwlCSUp.jpg', NULL),
   (1769, N'Sofia Coppola', CAST(N'1971-05-14' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/dzHC2LxmarkBxWLhjp2DRa5oCev.jpg', NULL),
   (1770, N'Akiko Takeshita', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/dKawZTpMtjAYZanVf20wr6a81sL.jpg', NULL),
   (1771, N'Giovanni Ribisi', CAST(N'1974-12-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/nABPeuB360wvWnVMqgpJHq6wHFz.jpg', NULL),
   (1772, N'Anna Faris', CAST(N'1976-11-29' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/y3YKNr4qPPJZ9w4lR2a3yySKotd.jpg', NULL),
   (1773, N'Kazuyoshi Minamimagoe', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1774, N'Kazuko Shibata', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1775, N'Take', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1785, N'Fumihiro Hayashi', CAST(N'1964-09-26' AS Date), CAST(N'2011-07-09' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/46dbVoYGos2a4lmc6qRjYgXF5nt.jpg', NULL),
   (1786, N'Hiroko Kawasaki', CAST(N'1912-04-05' AS Date), CAST(N'1976-06-03' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/u0AsfXm4hF1dv2sqdPTgp3V1hOl.jpg', NULL),
   (1787, N'Daikon', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1896, N'Don Cheadle', CAST(N'1964-11-29' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/b1EVJWdFn7a75qVYJgwO87W2TJU.jpg', NULL),
   (1953, N'Casey Siemaszko', CAST(N'1961-03-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/xmy1MzLV0q39Wwq79UJKs9VuWjj.jpg', NULL),
   (1954, N'Billy Zane', CAST(N'1966-02-24' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/9HIubetYWAVLlHNb9aObL0fc0sT.jpg', NULL),
   (1984, N'Kimberly Scott', CAST(N'1961-12-11' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/hCNssyKntFcwHaJOdkMj9alHVlw.jpg', NULL),
   (2174, N'Kimberly Beck', CAST(N'1956-01-09' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/4lmCWQUfv39KbDjPBkytxMKDj8i.jpg', NULL),
   (2231, N'Samuel L. Jackson', CAST(N'1948-12-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/mXN4Gw9tZJVKrLJHde2IcUHmV3P.jpg', NULL),
   (2275, N'Caitlin Clarke', CAST(N'1952-05-03' AS Date), CAST(N'2004-09-09' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/59PKSNwM5Czk3XWDIsHnBMbiIOz.jpg', NULL),
   (2395, N'Whoopi Goldberg', CAST(N'1955-11-13' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/78LZMMzNUJVfLI1MObxejScwZz5.jpg', NULL),
   (2877, N'Ralph Macchio', CAST(N'1961-11-04' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/kehn6kNTFPlAYrWJzBzrEu6WHJp.jpg', NULL),
   (2954, N'Jeffrey Wright', CAST(N'1965-12-07' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/npJjOiFiAP4wiRDNjKsO8ho03Mg.jpg', NULL),
   (3063, N'Tilda Swinton', CAST(N'1960-11-05' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vJwKUaxQHuMxwr8FOg5OjpEwGMb.jpg', NULL),
   (3088, N'Sterling Hayden', CAST(N'1916-03-26' AS Date), CAST(N'1986-05-23' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/twzaqv1ymkWYKHFF3kbvwaTIrFO.jpg', NULL),
   (3150, N'Tony Curtis', CAST(N'1925-06-03' AS Date), CAST(N'2010-09-29' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/4aSmN9M4BbFJbNaMSnjGJHffehQ.jpg', NULL),
   (3174, N'Richard Bright', CAST(N'1937-06-28' AS Date), CAST(N'2006-02-18' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/potMaJ2u5PRjXZb7qF9lSW1ldNZ.jpg', NULL),
   (3223, N'Robert Downey Jr.', CAST(N'1965-04-04' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/5qHNjhtjMD4YWH3UP0rm4tKwxCL.jpg', NULL),
   (3391, N'Kathleen Turner', CAST(N'1954-06-19' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/fI8r9Hs0hlQuB0FVGDFMkNsLSc.jpg', NULL),
   (3799, N'Billy Dee Williams', CAST(N'1937-04-06' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/dCiHLiCapPuRwKkM1ytVZ7PwYQY.jpg', NULL),
   (4113, N'Claude Rains', CAST(N'1889-11-10' AS Date), CAST(N'1967-05-30' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/l8di3lovLqcJQ8gbHKJltQk5KvD.jpg', NULL),
   (4138, N'Craig Sheffer', CAST(N'1960-04-23' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/w8wAAyXDifuxZDgvuL8U0fuLsLG.jpg', NULL),
   (4385, N'Sergio Leone', CAST(N'1929-01-03' AS Date), CAST(N'1989-04-30' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/rwNuspKZpJnuypQQJsPoAAfLbPh.jpg', NULL),
   (4429, N'Jim Jarmusch', CAST(N'1953-01-22' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/bKtWli68IA7mFygxaobAAQcu5Z9.jpg', NULL),
   (4430, N'Sharon Stone', CAST(N'1958-03-10' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/j0F7ZFbnQpiHPtiAhWMD9wtuyFV.jpg', NULL),
   (4431, N'Jessica Lange', CAST(N'1949-04-20' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/xybRNUGzzJuilStFGmIOSy0WFwQ.jpg', NULL),
   (4432, N'Frances Conroy', CAST(N'1953-11-13' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/aJRQAkO24L6bH8qkkE5Iv1nA3gf.jpg', NULL),
   (4433, N'Alexis Dziena', CAST(N'1984-07-08' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vKZ6blAnr7EXVk5rvmKJsK2jhzS.jpg', NULL),
   (4439, N'Heather Simms', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (4440, N'Brea Frazier', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (4441, N'Pell James', CAST(N'1977-04-30' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/tJKjTQ1Uxd4sibZhJsbcnWZezlV.jpg', NULL),
   (4442, N'Ryan Donowho', CAST(N'1980-09-20' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/bgOSrLTkszycQCVAbRbjr9BmWNs.jpg', NULL),
   (4443, N'Christopher McDonald', CAST(N'1955-02-15' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/bOKl8EPOKe0oWD15HxUKH1ugesg.jpg', NULL),
   (4445, N'Chris Bauer', CAST(N'1966-10-28' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/1AjdNxbVmy6azlOxIfnCX5OruEA.jpg', NULL),
   (4512, N'James Woods', CAST(N'1947-04-18' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/tOArxRwI5AQ3I9WJRiQpHs9gCl3.jpg', NULL),
   (4513, N'Elizabeth McGovern', CAST(N'1961-07-18' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/ihYdCKyr3JPz74tPuvkn1WSNh9b.jpg', NULL),
   (4514, N'Tuesday Weld', CAST(N'1943-08-27' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/fxWpBUgmAJSSIUllJ9vAkTX9DhO.jpg', NULL),
   (4515, N'Treat Williams', CAST(N'1951-12-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/bQ3zECF7TRpF8cwCmxqn4Qv2zHD.jpg', NULL),
   (4516, N'James Hayden', CAST(N'1953-11-25' AS Date), CAST(N'1983-11-08' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/A0l96u277mqrr7diMb9Xbj0idyp.jpg', NULL),
   (4517, N'Joe Pesci', CAST(N'1943-02-09' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/6wPLWhZx5XvNsmEt8QwFoyvizDr.jpg', NULL),
   (4518, N'Larry Rapp', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (4520, N'William Forsythe', CAST(N'1955-06-07' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/g0vIRDw0FemQlX0HGW94b4Kx8nz.jpg', NULL),
   (4521, N'Burt Young', CAST(N'1940-04-30' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/sHe7o1ZkJV5r0WDzkm28xnsNtAu.jpg', NULL),
   (4587, N'Halle Berry', CAST(N'1966-08-14' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/9aLI0LSi7cbieyiskOdsBaneKmp.jpg', NULL),
   (4761, N'Darlanne Fluegel', CAST(N'1958-11-25' AS Date), CAST(N'2017-12-15' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/hZRScPLpN3KpFtWBsIq5NGPhNBQ.jpg', NULL),
   (4785, N'Jeff Goldblum', CAST(N'1952-10-22' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/m8p62pvkVtPxkfAIJhb5AgGw8kA.jpg', NULL),
   (4956, N'Bernardo Bertolucci', CAST(N'1940-03-16' AS Date), CAST(N'2018-11-26' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/ivRWPij5GqHmwuGsd0FpbkQaFYU.jpg', NULL),
   (4971, N'Bud Cort', CAST(N'1948-03-29' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/agiubl6msYlKM7DpghIYDw1pcBN.jpg', NULL),
   (5004, N'Omar Sharif', CAST(N'1932-04-10' AS Date), CAST(N'2015-07-10' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/zEZq6w8ixTFZ7xuP67PdE1YSc1.jpg', NULL),
   (5293, N'Willem Dafoe', CAST(N'1955-07-22' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/ui8e4sgZAwMPi3hzEO53jyBJF9B.jpg', NULL),
   (5401, N'Anthony Quinn', CAST(N'1915-04-21' AS Date), CAST(N'2001-06-03' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/kHMcKl4bzyc43XL1spo79G37jnO.jpg', NULL),
   (5567, N'Romolo Valli', CAST(N'1925-02-07' AS Date), CAST(N'1980-02-01' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/gvh6WBYQImUno8JeKezMk3j7PpT.jpg', NULL),
   (5655, N'Wes Anderson', CAST(N'1969-05-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/b1LH059EGnU01rsZwcqYzNjY7w9.jpg', NULL),
   (5657, N'Anjelica Huston', CAST(N'1951-07-08' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/6hnYeHa7Rc1w1MmQ3JsLSIb7yCX.jpg', NULL),
   (5658, N'Michael Gambon', CAST(N'1940-10-19' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/3jdWkDKf4IODbG4JKTeaC7AzxZH.jpg', NULL),
   (5659, N'Seu Jorge', CAST(N'1970-06-08' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/iJ0TWspJRxanKdUnQraAxjmTCl2.jpg', NULL),
   (5661, N'Matthew Gray Gubler', CAST(N'1980-03-09' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/tHjIUjHFjl4Kzc4XQ7JSd1EHYSU.jpg', NULL),
   (5662, N'Antonio Monda', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (5663, N'Isabella Blow', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (5950, N'Seymour Cassel', CAST(N'1935-01-22' AS Date), CAST(N'2019-04-07' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/3xAx3mu2VxpTIgdYe9RmSpyVwjH.jpg', NULL),
   (6162, N'Paul Bettany', CAST(N'1971-05-27' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vcAVrAOZrpqmi37qjFdztRAv1u9.jpg', NULL),
   (6448, N'Arthur Penn', CAST(N'1922-09-27' AS Date), CAST(N'2010-09-28' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/imHQBWO3DZXfcJM1CcPHsL28PyK.jpg', NULL),
   (6465, N'Grace Zabriskie', CAST(N'1941-05-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/19tr5IbzCmv4x5B3WFlG1RQPwXu.jpg', NULL),
   (6944, N'Octavia Spencer', CAST(N'1972-05-25' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/jnQTP4RRkoWnyO3yL2PgRHZi0tK.jpg', NULL),
   (7036, N'Eric Stoltz', CAST(N'1961-09-30' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/sP5tI3NVHrhmle5qotVz9q2mWfR.jpg', NULL),
   (7037, N'Jean-Hugues Anglade', CAST(N'1955-07-29' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/fB4IkPSOPRmNaJjgNrYkrrLWAKv.jpg', NULL),
   (7038, N'Tai Thai', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (7039, N'Bruce Ramsay', CAST(N'1966-12-31' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/1ohZWBLAplxZRKfJBRWGYfDGk5u.jpg', NULL),
   (7040, N'Kario Salem', CAST(N'1955-05-23' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/mAKOgOVfX0Bih7TADUrIe0jqivc.jpg', NULL),
   (7041, N'Salvator Xuereb', CAST(N'1965-11-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/aJPHt4Y5JMPQ65MsjlD3mUb9tpY.jpg', NULL),
   (7042, N'Gary Kemp', CAST(N'1959-10-16' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/jOxSHoR0GEbPvZ9gNGukyK2IKFG.jpg', NULL),
   (7043, N'Martin Raymond', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (7044, N'Eric Pascal Chaltiel', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (7046, N'Cecilia Peck', CAST(N'1958-05-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/kFroqrLbmVATUFMIoY4KnLKKTo7.jpg', NULL),
   (7406, N'Michael Steinberg', CAST(N'1959-05-15' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (7430, N'Elizabeth Peña', CAST(N'1961-09-23' AS Date), CAST(N'2014-10-14' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/uyUrPmtbwiGFOq8pIfYVQYgmBmK.jpg', NULL),
   (7676, N'William Atherton', CAST(N'1947-07-30' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/d4ArFBoywyW3yZ3RuD1KAC0fXiA.jpg', NULL),
   (7710, N'Laura Betti', CAST(N'1927-05-01' AS Date), CAST(N'2004-07-31' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/bmHSSa73UxMnUJjmooKzPv1INWp.jpg', NULL),
   (7908, N'Frank Oz', CAST(N'1944-05-25' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/mb2JbT8s6LIgaxj6QTph0NW1pmI.jpg', NULL),
   (8297, N'Roger Avary', CAST(N'1965-08-23' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (8691, N'Zoe Saldana', CAST(N'1978-06-19' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vQBwmsSOAd0JDaEcZ5p43J9xzsY.jpg', NULL),
   (8858, N'Ivan Reitman', CAST(N'1946-10-27' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/qMyAjmRVihGFbJPhMTsqvpeOKfX.jpg', NULL),
   (8872, N'Rick Moranis', CAST(N'1953-04-18' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/nCIh203hALUsQW44x3dzpjSA4yf.jpg', NULL),
   (8873, N'Annie Potts', CAST(N'1952-10-28' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/hWIzkAH7jkSkxBfwdudxbSPxeno.jpg', NULL),
   (8874, N'Ernie Hudson', CAST(N'1945-12-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/kgAdQA2ItCDVvKXufeDHc6Omiso.jpg', NULL),
   (8875, N'David Margulies', CAST(N'1937-02-19' AS Date), CAST(N'2016-01-11' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/lKXiPu99KCdETOH9XHMgVGg6z8G.jpg', NULL),
   (9994, N'Helen Hunt', CAST(N'1963-06-15' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vMxBCquKrYRMi7xROpEY0AlBVVt.jpg', NULL),
   (10018, N'Jack Hawkins', CAST(N'1910-09-14' AS Date), CAST(N'1973-07-18' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/pfpe9NQrcrTrxMeU0xGsh1XRBOK.jpg', NULL),
   (10205, N'Sigourney Weaver', CAST(N'1949-10-08' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/sHWCLx54yLtaFtppp5ADjAsrWIc.jpg', NULL),
   (10669, N'Timothy Dalton', CAST(N'1946-03-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/lpmsHv6YrOlODjNdSgr5DEBH2gJ.jpg', NULL),
   (10689, N'Rob Brown', CAST(N'1984-03-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/jVevsp9OsdImQ8YxNjdG3KLYket.jpg', NULL),
   (10734, N'Kenneth Colley', CAST(N'1937-12-07' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/2clSIyNhC3Z725cPX1TR8Hsl1hi.jpg', NULL),
   (10814, N'Wesley Snipes', CAST(N'1962-07-31' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/uBhM3TshYvRhOewXAimtxci9bQo.jpg', NULL),
   (10930, N'Irvin Kershner', CAST(N'1923-04-29' AS Date), CAST(N'2010-11-27' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/imtFUtcASoh2e1Emtt62UuFkIWA.jpg', NULL),
   (11128, N'Arthur Kennedy', CAST(N'1914-02-17' AS Date), CAST(N'1990-01-05' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/fDbTcQYSLDjfGetwF1mEwdFLSnG.jpg', NULL),
   (11390, N'Peter O''Toole', CAST(N'1932-08-02' AS Date), CAST(N'2013-12-14' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/2F15qrkiDp4qhYJnXuFqINIBsHp.jpg', NULL),
   (11673, N'J.J. Cohen', CAST(N'1965-06-22' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/gIqm7AoWQlrSTgw3iZ1Yhz9UI8u.jpg', NULL),
   (12238, N'David Lean', CAST(N'1908-03-25' AS Date), CAST(N'1991-04-16' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/dzwMuydy2x3JwaTBfBSq8c02qz4.jpg', NULL),
   (12248, N'Alec Guinness', CAST(N'1914-04-02' AS Date), CAST(N'2000-08-05' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/4SzPZhHt2irzwPxLp42oFxbYwcW.jpg', NULL),
   (12514, N'Leonardo Cimino', CAST(N'1917-11-04' AS Date), CAST(N'2012-03-03' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/1ZyxIn1yw6wiRXFdnVnQsVz54F0.jpg', NULL),
   (12515, N'José Ferrer', CAST(N'1912-01-08' AS Date), CAST(N'1992-01-26' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/691OuTieryNIqLINzL5NOIB0bOe.jpg', NULL),
   (13550, N'Elias Koteas', CAST(N'1961-03-11' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/luevjlGy0tYQbAbcz0mVxCYqegH.jpg', NULL),
   (13784, N'Burt Lancaster', CAST(N'1913-11-02' AS Date), CAST(N'1994-10-20' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/1M4jic3OitwuwPznjk8yrsolfEZ.jpg', NULL),
   (14371, N'Anthony Quayle', CAST(N'1913-09-07' AS Date), CAST(N'1989-10-20' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/6hTRCasvtV0tjwba4HM7qg906NN.jpg', NULL),
   (14372, N'Donald Wolfit', CAST(N'1902-04-20' AS Date), CAST(N'1968-02-17' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/eRs3Bo7H3D2JwXbiurg9W40CgJb.jpg', NULL),
   (14373, N'Zia Mohyeddin', CAST(N'1933-06-20' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/jAILEtma2lJ0YVrF4gAWXq12P68.jpg', NULL),
   (14668, N'Daphne Zuniga', CAST(N'1962-10-28' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/5vPVk1A28v7ZvvWWvtugOABKwGZ.jpg', NULL),
   (14722, N'Arabella Field', CAST(N'1965-02-05' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (15152, N'James Earl Jones', CAST(N'1931-01-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/oqMPIsXrl9SZkRfIKN08eFROmH6.jpg', NULL),
   (15385, N'Alida Valli', CAST(N'1921-05-31' AS Date), CAST(N'2006-04-22' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/ze8OiV87TYR4PmyuNIobl02ODjo.jpg', NULL),
   (16828, N'Chris Evans', CAST(N'1981-06-13' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/3bOGNsHlrswhyW79uvIHH1V43JI.jpg', NULL),
   (16927, N'Gérard Depardieu', CAST(N'1948-12-27' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/cibkIAJN6ctlqHohhdDEcfbiCAL.jpg', NULL),
   (17488, N'Alice Drummond', CAST(N'1928-05-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/9YIxVH0oozCZalYW8lY5JAtfUvK.jpg', NULL),
   (18248, N'Mary-Louise Parker', CAST(N'1964-08-02' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/1ohhrIZ4OMlLx9DvHjPhQJAIP0F.jpg', NULL),
   (19271, N'Anthony Russo', CAST(N'1970-02-03' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/fIa5wXK7MHAquhefTr3TcnZiYy8.jpg', NULL),
   (19509, N'Jessica Yu', CAST(N'1966-02-14' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (19800, N'Richard Marquand', CAST(N'1937-09-22' AS Date), CAST(N'1987-09-04' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/eEalDQpLsXJqejPDQ3MWGe95UHT.jpg', NULL),
   (20211, N'John Getz', CAST(N'1946-10-15' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/9Ikx6ZzScbmDi2SNyaa0db4MMqL.jpg', NULL),
   (20362, N'Jill Clayburgh', CAST(N'1944-04-30' AS Date), CAST(N'2010-11-05' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/sMdQSgCSlSYdMq4aBAnoaIZYuLT.jpg', NULL),
   (21283, N'Lee Richardson', CAST(N'1926-09-01' AS Date), CAST(N'1999-10-02' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/yqJMNzrKEwLIGnHky1DZZ9Gj4jw.jpg', NULL),
   (23679, N'Billy West', CAST(N'1952-04-16' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/iNQtBsgV4wr3z5CEEFhR5U4Yedk.jpg', NULL),
   (23975, N'Lee Garlington', CAST(N'1953-07-20' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/tbXeeXUl9py2pCeMHchZAxd56Ua.jpg', NULL),
   (24342, N'David Prowse', CAST(N'1935-07-01' AS Date), CAST(N'2020-11-29' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/xTocYiKHlRYN8tfh8vyQFsRXC0K.jpg', NULL),
   (24343, N'Peter Mayhew', CAST(N'1944-05-19' AS Date), CAST(N'2019-04-30' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/bWv4RHLhjH6Ujrfhzm6ZC8ms3f2.jpg', NULL),
   (24368, N'Roscoe Lee Browne', CAST(N'1925-05-02' AS Date), CAST(N'2007-04-11' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/rD6WGpgrPjHVZ76D3UY7D2HKKSF.jpg', NULL),
   (24590, N'Dominique Sanda', CAST(N'1948-03-11' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/7QfgJdp1l1eN3W6FrbDGze1K6Uu.jpg', NULL),
   (26089, N'Garry Chalk', CAST(N'1952-02-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/jESGnBSP0OjFxJejN1OPsjXA9sJ.jpg', NULL),
   (26502, N'Howard Deutch', CAST(N'1950-09-14' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (27165, N'John Hollis', CAST(N'1931-01-24' AS Date), CAST(N'2005-10-18' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/6PKo9EBcT96t2aHcpKJ0epwipp6.jpg', NULL),
   (27597, N'Werner Bruhns', CAST(N'1928-10-10' AS Date), CAST(N'1977-10-16' AS Date), NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (27762, N'Ian McDiarmid', CAST(N'1944-08-11' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/cqEAblt0KJRIGyMXhj5OM5WJ9SN.jpg', NULL),
   (28235, N'Sebastian Shaw', CAST(N'1905-05-29' AS Date), CAST(N'1994-12-23' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/AGGaIPTgcYlZMHkb19ivKfqEng.jpg', NULL),
   (31140, N'Mary Stuart Masterson', CAST(N'1966-06-28' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/gUy2JuS4kmgY8laq2pvJ8tPmqsh.jpg', NULL),
   (31162, N'Daran Norris', CAST(N'1964-11-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/oLaegqPwuEdNNJVqrvcgI6guYsi.jpg', NULL),
   (31363, N'Candace Cameron Bure', CAST(N'1976-04-06' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/qT77k1N61uom9UZNeKUa27BRWQb.jpg', NULL),
   (33032, N'Phil Brown', CAST(N'1916-04-30' AS Date), CAST(N'2006-02-09' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/vVU92p28YEvwpMSxIdzblqRE2sh.jpg', NULL),
   (33185, N'Jeremy Bulloch', CAST(N'1945-02-16' AS Date), CAST(N'2020-12-17' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/sioJ1UcQPgHktGgUXrb5FKBjiYp.jpg', NULL),
   (34027, N'Stefania Sandrelli', CAST(N'1946-06-05' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/2wpRnvlqHOGuHQ1AY6S8tWac1O2.jpg', NULL),
   (34035, N'Francesca Bertini', CAST(N'1892-04-11' AS Date), CAST(N'1985-10-13' AS Date), NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (34039, N'Ellen Schwiers', CAST(N'1930-06-11' AS Date), CAST(N'2019-04-26' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/e4YN7EaLGzISKbhpLqHJxfYedpw.jpg', NULL),
   (34040, N'Anna Henkel-Gronemeyer', CAST(N'1953-03-09' AS Date), CAST(N'1998-11-05' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/fEjvK0LnpJImU8ia3gA0WaHVuNZ.jpg', NULL),
   (35250, N'I.S. Johar', CAST(N'1920-02-16' AS Date), CAST(N'1984-03-10' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/gWEwHJ01f0Iq58f75rW2HfVAjUl.jpg', NULL),
   (35547, N'Harley Cross', CAST(N'1978-03-31' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vd8PIxUqUSHWnk0xPt3F5HPGMpo.jpg', NULL),
   (37221, N'Penn Jillette', CAST(N'1955-03-05' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/zmAaXUdx12NRsssgHbk1T31j2x9.jpg', NULL),
   (38673, N'Channing Tatum', CAST(N'1980-04-26' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/e5p1xrGtPfpJBQR9Pt3B6W4buZP.jpg', NULL),
   (39556, N'Dana Davis', CAST(N'1984-10-04' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/jsMOVi4z2E2kvLS0j3Paxd0NJsk.jpg', NULL),
   (42545, N'Ron Jeremy', CAST(N'1953-03-12' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/p13HTvxofm4GJNx13eeTQk2EXfm.jpg', NULL),
   (49148, N'Calista Flockhart', CAST(N'1964-11-11' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/l5mSlK7fgG4UXKKL9N7dXpl105a.jpg', NULL),
   (50744, N'Olga Karlatos', CAST(N'1947-04-20' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/cdsJAabO7RlSzzQzTYv49n245qG.jpg', NULL),
   (51549, N'Jordan Charney', CAST(N'1937-04-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vdEyvpz09laussmoav4VPulgVG0.jpg', NULL),
   (52037, N'Robert Ri''chard', CAST(N'1983-01-07' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/36cxvHbHtvl476v8lrqY7Cv3Jm7.jpg', NULL),
   (52038, N'Thomas Carter', CAST(N'1953-07-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (53087, N'William Allen Young', CAST(N'1954-01-24' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/3QMYa0lOFs76wXmPuvdmTyz0KUA.jpg', NULL),
   (53184, N'Rick Gonzalez', CAST(N'1979-06-30' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/ghcqBGJwRIreUmeKBgqp1a0cvUy.jpg', NULL),
   (53185, N'Texas Battle', CAST(N'1980-08-09' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/zPzagAtKxbHKrQLAQ69KSYLZxjA.jpg', NULL),
   (53650, N'Anthony Mackie', CAST(N'1979-09-23' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/eZSIDrtTzhvabyjrmIITQLsjx8h.jpg', NULL),
   (55636, N'Donald Sutherland', CAST(N'1935-07-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/pvk7fjJNg9kZQTeuG6ZlfJ8t2Ze.jpg', NULL),
   (55930, N'Steven Tash', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/uCax0ma1q9xJi0g2wQ0ARsZqZKZ.jpg', NULL),
   (57116, N'David Johansen', CAST(N'1950-01-09' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vWhq871aXCZfW3NpYILRxCI86nX.jpg', NULL),
   (57172, N'Ashanti', CAST(N'1980-10-13' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/cYGZBOFNCIk83c0ut6hiQcR3k4o.jpg', NULL),
   (58045, N'Molly Hagan', CAST(N'1961-08-03' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/m5pL170dlh7ex4lTESAK5kKARde.jpg', NULL),
   (60898, N'Sebastian Stan', CAST(N'1982-08-13' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/nKZgixTbHFXpkzzIpMFdLX98GYh.jpg', NULL),
   (61167, N'Frank C. Turner', CAST(N'1951-06-02' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/kvE1I0n9DneoLcMyBJ5VfcIrmE2.jpg', NULL),
   (64552, N'Cédric Zimmerlin', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/vNctEwGAnXe1rFpReCeGiy91ykm.jpg', NULL),
   (64874, N'Ann Marie Lee', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/qpLHRDGbd8tEYgmlbKyC5vdGiug.jpg', NULL),
   (64875, N'Chris Walas', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (64908, N'LisaGay Hamilton', CAST(N'1964-03-25' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/bqfowff4gF0cGaQ1c7F89HAL3DH.jpg', NULL),
   (67520, N'William S. Taylor', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/7KDjJW72JYkytTnA4nnHyOUPzir.jpg', NULL),
   (69249, N'Eddie Byrne', CAST(N'1911-01-31' AS Date), CAST(N'1981-08-21' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/mWivEyJoTjfhOZ1m4EQJGn9lCZh.jpg', NULL),
   (69696, N'Daniel Algrant', CAST(N'1959-09-25' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/mFNt1Sjdvh2J9LqMiNUKt0l3RAf.jpg', NULL),
   (69718, N'Jon Cryer', CAST(N'1965-04-16' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/z2LPFc4oLDaDOYipKTAzZ9rARQ5.jpg', NULL),
   (71266, N'Lynne Thigpen', CAST(N'1948-12-22' AS Date), CAST(N'2003-03-12' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/4ZKG11kZWlrbJccTnXeezL3vdJB.jpg', NULL),
   (71580, N'Benedict Cumberbatch', CAST(N'1976-07-19' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/fBEucxECxGLKVHBznO0qHtCGiMO.jpg', NULL),
   (74296, N'Teller', CAST(N'1948-02-14' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/ixB8pYJHevXQP1aHXaHa8uXy6Tu.jpg', NULL),
   (74568, N'Chris Hemsworth', CAST(N'1983-08-11' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/latNgwckKv3DtJIM8FK06T1GSYj.jpg', NULL),
   (75491, N'Catherine Lambert', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (77940, N'Chynna Phillips', CAST(N'1968-02-12' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/2RSBkmcDFFEqOX7GCtyQKqwgv3x.jpg', NULL),
   (81390, N'Aaron Carter', CAST(N'1987-12-07' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/tmrmsSI7KVnzaM03gxbJ5E8t3ov.jpg', NULL),
   (81809, N'Declan Lowney', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (83339, N'Paul Provenza', CAST(N'1957-07-31' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/9Rca1tz9AxIEjqgIu6O3UPBvzDy.jpg', NULL),
   (83920, N'Nicole Abisinio', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (87066, N'Ike Eisenmann', CAST(N'1962-07-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/w2JV3xw2cKMRvYRzshnkKKD2arB.jpg', NULL),
   (88161, N'Debbi Morgan', CAST(N'1956-09-20' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/5uet40J3x2pLCxdqC07RjNHTzvH.jpg', NULL),
   (90713, N'Lawrence Lessig', CAST(N'1961-06-03' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/6GJ3b2dBUBUTizWW5wyVqno4f3F.jpg', NULL),
   (90714, N'Cory Doctorow', CAST(N'1971-07-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/z3116iV49AXk0A4o9WWEFFG5Ltr.jpg', NULL),
   (94102, N'Ben Lin', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/kr4ceg7kVN8ckQZSwFmu3BJS8bN.jpg', NULL),
   (101652, N'Jennifer Runyon', CAST(N'1960-04-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/1j0Vt7pUROiNvI4ga0KfsNQnlWc.jpg', NULL),
   (105633, N'Michel Ray', CAST(N'1944-07-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/f9YhZADuPRJ43hIw25nGNyga1iF.jpg', NULL),
   (105634, N'Gamil Ratib', CAST(N'1926-08-18' AS Date), CAST(N'2018-09-19' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/xNhv7SpWipwaee8ZgowD1VtoZOg.jpg', NULL),
   (105635, N'John Dimech', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/yieV9k7PcKEIyiiAMoigtfUs3RT.jpg', NULL),
   (111883, N'Billy Morrissette', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (121757, N'Maddie Corman', CAST(N'1970-08-15' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/3Qa8GAf7CARtHeLXPX4GdR5ZFhm.jpg', NULL),
   (131625, N'Shelagh Fraser', CAST(N'1920-11-25' AS Date), CAST(N'2000-08-29' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/2QucvNmG3mOvSflbXRkY5renpQT.jpg', NULL),
   (131724, N'Adrienne Bailon-Houghton', CAST(N'1983-10-24' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/iIsFrw86Bglim2hrODZgbggfavn.jpg', NULL),
   (132538, N'Jack Purvis', CAST(N'1937-07-13' AS Date), CAST(N'1997-11-21' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/mElieLKynpuzRkt8kwovTdL6Mh.jpg', NULL),
   (132539, N'Des Webb', NULL, CAST(N'2002-05-21' AS Date), NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (133581, N'Patricia Gaul', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/5ncPdor53GdBO5gnnBdbmI1WjJj.jpg', NULL),
   (150882, N'Julian Assange', CAST(N'1971-07-03' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/v5RJRSLHISrQsToSMMw8ixMml5w.jpg', NULL),
   (151326, N'Kenneth Kimmins', CAST(N'1941-09-04' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/yIikm0zd7QK7MiO0Hu5qxNrdTy0.jpg', NULL),
   (151529, N'Jason Wingreen', CAST(N'1920-10-09' AS Date), CAST(N'2015-12-25' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/4VlKKV47yNJgV1rF27h2PKrJDqd.jpg', NULL),
   (154171, N'David Strickland', CAST(N'1969-10-14' AS Date), CAST(N'1999-03-22' AS Date), NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (155625, N'Sonya Eddy', CAST(N'1967-06-17' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/u4yQNLmXkijZoXxMYC2Hs3DtA4P.jpg', NULL),
   (156989, N'Kari Coleman', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/rgxyZ0TLlRfcvEYMASmus2JCe0w.jpg', NULL),
   (159319, N'Robyn Cohen', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/hsj8uECKItzalQWP6sBnF7IpQ77.jpg', NULL),
   (159913, N'Allison Kyler', CAST(N'1982-11-05' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (160111, N'Saffron Henderson', CAST(N'1965-09-25' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/az0p9St1cy8Rduq4a8n3kvwHCat.jpg', NULL),
   (164987, N'Gladys Holland', CAST(N'1928-01-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (166606, N'Tony Genaro', CAST(N'1941-01-01' AS Date), CAST(N'2014-05-07' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/QfDoKbyezCA8wYM19Du0PLtF4i.jpg', NULL),
   (168897, N'Lacey Beeman', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/qaFbZVj7XIwRhEDGjIZBa4uc3Db.jpg', NULL),
   (171016, N'Ted Neustadt', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (171345, N'Ellen Whyte', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (172069, N'Chadwick Boseman', CAST(N'1976-11-29' AS Date), CAST(N'2020-08-28' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/mXxiOTrTMJBRSVRfgaSDhOfvfxU.jpg', NULL),
   (190204, N'Andrew Rhodes', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (198472, N'Matthew Moore', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (210815, N'Cindy Chiu', CAST(N'1980-05-12' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (216087, N'Alex McCrindle', CAST(N'1911-08-03' AS Date), CAST(N'1990-04-20' AS Date), NULL, N'https://image.tmdb.org/t/p/w185/LTLiQPMnKESxGVHhZ7n2qPAuMi.jpg', NULL),
   (236327, N'Ken Hudson Campbell', CAST(N'1962-06-05' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/5KmuInp11wKczUQMHlNP26STfzT.jpg', NULL),
   (237167, N'Akiko Monô', CAST(N'1976-04-02' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/udZubK58iXMvzbdNaDeo2W7UZcz.jpg', NULL),
   (294790, N'Pat Bermel', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/irbF4zAeWbmLTAsylM8IbJBjq0c.jpg', NULL),
   (504377, N'Star Price', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (543261, N'Karen Gillan', CAST(N'1987-11-28' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/52kqB0Bei1TaTBx2rABrijVhhTG.jpg', NULL),
   (550843, N'Elizabeth Olsen', CAST(N'1989-02-16' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/wIU675y4dofIDVuhaNWPizJNtep.jpg', NULL),
   (562314, N'Slavitza Jovan', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/uWuMKKVe8xfg57ElWqDNGeq5nZq.jpg', NULL),
   (565123, N'Xavier Boulanger', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/bqCV59wpRrmjAzI5MJd9y2d1B7C.jpg', NULL),
   (565126, N'Philippe Ohrel', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (570737, N'Scott Stringer', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (570738, N'Ezekiel Zabrowski', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1046579, N'Celia McGuire', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1080265, N'Michael Ensign', CAST(N'1944-02-13' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/bL1ufZUtMvsatgLWCjtBGoWrwDZ.jpg', NULL),
   (1084740, N'Rob Roy', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1102384, N'Brian Knappenberger', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/nFkSZQhC9EpjzIO4DMNa4VaN4Tz.jpg', NULL),
   (1132115, N'Marc Jampolsky', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1136406, N'Tom Holland', CAST(N'1996-06-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/l6zPRmg8NI7Y65G5GUqwvjxFdsx.jpg', NULL),
   (1173555, N'Eva Rodriguez', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1173556, N'Erick Vigil', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1173557, N'Edgar Rodriguez', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1173558, N'Angélica Castell', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1173559, N'Casey Stengel', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1185077, N'Françoise Dubois', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1230989, N'Michael Pennington', CAST(N'1943-06-07' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/vNhw2KX9qaNJCYMNEwkSeo3EWMY.jpg', NULL),
   (1234924, N'Bill Randolph', CAST(N'1953-11-10' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1307239, N'Marc Schweyer', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1318541, N'Les Podewell', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1349802, N'Amanda Drew', CAST(N'1969-12-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/dd5NSaGnHJe1F9oEEPHaDGRqcr8.jpg', NULL),
   (1360985, N'Tim Berners-Lee', CAST(N'1955-06-08' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/r5XtvCZoOuMPN0eRnOUkHdKI7Bv.jpg', NULL),
   (1360986, N'Peter Eckersley', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1360987, N'Aaron Swartz', CAST(N'1986-11-08' AS Date), CAST(N'2011-01-11' AS Date), NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1373773, N'Frank Gio', CAST(N'1929-08-15' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/5aNqsOhSgo2vEPMzfJwwkrGUX55.jpg', NULL),
   (1386089, N'Edward Snowden', CAST(N'1983-06-21' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185/q2n2J4HVxty15I9vPJ4j8yX6gdu.jpg', NULL),
   (1417332, N'Jacob Appelbaum', CAST(N'1983-01-01' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1520071, N'Mike Radford', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185/muH3PwEKwiLZ4qzpIEGMChOsqFa.jpg', NULL),
   (1837021, N'Bryan Scott', CAST(N'1965-12-15' AS Date), NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1846009, N'Guy Bechtel', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (1906655, N'Cristiano Nocera', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2044970, N'Lum Chang Pang', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2481294, N'Stephan Füssel', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2481299, N'Benoît Jordan', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2481301, N'Pierre Monnet', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2481303, N'Olivier Deloignon', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2481335, N'Georges Bischoff', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2481337, N'Laurent Héricher', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2481343, N'Cornelia Schneider', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2481345, N'Bettina Wagner', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2571346, N'Tudor Sherrard', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL),
   (2571361, N'Jimmy Carr', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/w185', NULL);
SET IDENTITY_INSERT person OFF;
SET IDENTITY_INSERT collection ON;
INSERT INTO collection (collection_id, collection_name) VALUES (10, 'Star Wars Collection');
INSERT INTO collection (collection_id, collection_name) VALUES (86311, 'The Avengers Collection');
INSERT INTO collection (collection_id, collection_name) VALUES (264, 'Back to the Future Collection');
INSERT INTO collection (collection_id, collection_name) VALUES (109609, 'The Fly (1986) Collection');
INSERT INTO collection (collection_id, collection_name) VALUES (2980, 'Ghostbusters Collection');
SET IDENTITY_INSERT collection OFF;
SET IDENTITY_INSERT movie ON;
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (11, N'Star Wars', N'Princess Leia is captured and held hostage by the evil Imperial forces in their effort to take over the galactic Empire. Venturesome Luke Skywalker and dashing captain Han Solo team together with the loveable robot duo R2-D2 and C-3PO to rescue the beautiful princess and restore peace and justice in the Empire.', N'A long time ago in a galaxy far, far away...', N'https://image.tmdb.org/t/p/w500/6FfCtAuVAW8XJjZ7eWeLibRLWTw.jpg', N'http://www.starwars.com/films/star-wars-episode-iv-a-new-hope', '5/25/1977 12:00:00 AM', 121, '1', '10');
INSERT INTO movie_genre (movie_id, genre_id) VALUES (11, 12);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (11, 28);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (11, 878);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 2);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 3);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 4);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 5);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 12248);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 6);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 130);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 24343);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 24342);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 15152);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 33032);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 131625);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 132538);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 216087);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11, 69249);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (1891, N'The Empire Strikes Back', N'The epic saga continues as Luke Skywalker, in hopes of defeating the evil Galactic Empire, learns the ways of the Jedi from aging master Yoda. But Darth Vader is more determined than ever to capture Luke. Meanwhile, rebel leader Princess Leia, cocky Han Solo, Chewbacca, and droids C-3PO and R2-D2 are thrown into various stages of capture, betrayal and despair.', N'The Adventure Continues...', N'https://image.tmdb.org/t/p/w500/7BuH8itoSrLExs2YZSsM01Qk2no.jpg', N'http://www.starwars.com/films/star-wars-episode-v-the-empire-strikes-back', '5/20/1980 12:00:00 AM', 124, '10930', '10');
INSERT INTO movie_genre (movie_id, genre_id) VALUES (1891, 12);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (1891, 28);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (1891, 878);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 2);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 3);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 4);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 3799);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 6);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 24342);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 24343);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 130);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 7908);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 12248);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 33185);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 151529);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 27165);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 132538);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1891, 132539);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (1892, N'Return of the Jedi', N'Luke Skywalker leads a mission to rescue his friend Han Solo from the clutches of Jabba the Hutt, while the Emperor seeks to destroy the Rebellion once and for all with a second dreaded Death Star.', N'The Empire Falls...', N'https://image.tmdb.org/t/p/w500/mDCBQNhR6R0PVFucJl0O4Hp5klZ.jpg', N'http://www.starwars.com/films/star-wars-episode-vi-return-of-the-jedi', '5/25/1983 12:00:00 AM', 135, '19800', '10');
INSERT INTO movie_genre (movie_id, genre_id) VALUES (1892, 12);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (1892, 28);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (1892, 878);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 2);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 3);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 4);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 3799);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 6);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 24343);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 28235);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 27762);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 7908);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 15152);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 24342);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 12248);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 130);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 1230989);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (1892, 10734);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (299536, N'Avengers: Infinity War', N'As the Avengers and their allies have continued to protect the world from threats too large for any one hero to handle, a new danger has emerged from the cosmic shadows: Thanos. A despot of intergalactic infamy, his goal is to collect all six Infinity Stones, artifacts of unimaginable power, and use them to inflict his twisted will on all of reality. Everything the Avengers have fought for has led up to this moment - the fate of Earth and existence itself has never been more uncertain.', N'An entire universe. Once and for all.', N'https://image.tmdb.org/t/p/w500/7WsyChQLEftFiDOVTGkv3hFpyyt.jpg', N'https://www.marvel.com/movies/avengers-infinity-war', '4/25/2018 12:00:00 AM', 149, '19271', '86311');
INSERT INTO movie_genre (movie_id, genre_id) VALUES (299536, 12);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (299536, 28);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (299536, 878);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 3223);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 74568);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 16828);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 1245);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 71580);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 1136406);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 172069);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 1896);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 8691);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 543261);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 550843);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 6162);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 53650);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (299536, 60898);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (105, N'Back to the Future', N'Eighties teenager Marty McFly is accidentally sent back in time to 1955, inadvertently disrupting his parents'' first meeting and attracting his mother''s romantic interest. Marty must repair the damage to history by rekindling his parents'' romance and - with the help of his eccentric inventor friend Doc Brown - return to 1985.', N'He''s the only kid ever to get into trouble before he was born.', N'https://image.tmdb.org/t/p/w500/xlBivetfrtF84Yx0zISShnNtHYe.jpg', N'http://www.backtothefuture.com/movies/backtothefuture1', '7/3/1985 12:00:00 AM', 116, '24', '264');
INSERT INTO movie_genre (movie_id, genre_id) VALUES (105, 12);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (105, 35);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (105, 878);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (105, 10751);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 521);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1062);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1063);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1064);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1065);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1066);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1067);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1068);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1069);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1070);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1072);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 11673);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1953);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1954);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (105, 1074);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (7214, N'Coach Carter', N'Based on a true story, in which Richmond High School head basketball coach Ken Carter made headlines in 1999 for benching his undefeated team due to poor academic results.', N'It begins on the street. It ends here.', N'https://image.tmdb.org/t/p/w500/eYfA48NXSMzt8W5Iqj6GvKKNb8L.jpg', N'http://www.ibuyanessay.com/', '1/14/2005 12:00:00 AM', 136, '52038', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (7214, 18);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (7214, 36);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 2231);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 10689);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 52037);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 53184);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 38673);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 57172);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 53185);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 168897);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 6944);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 159913);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 210815);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 131724);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 39556);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 155625);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (7214, 88161);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (77, N'Memento', N'Leonard Shelby is tracking down the man who raped and murdered his wife. The difficulty of locating his wife''s killer, however, is compounded by the fact that he suffers from a rare, untreatable form of short-term memory loss. Although he can recall details of life before his accident, Leonard cannot remember what happened fifteen minutes ago, where he''s going, or why.', N'Some memories are best forgotten.', N'https://image.tmdb.org/t/p/w500/yuNs09hvpHVU1cBTCAk9zxsL2oW.jpg', N'http://www.otnemem.com/', '10/11/2000 12:00:00 AM', 113, '525', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (77, 9648);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (77, 53);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 529);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 530);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 532);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 534);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 535);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 536);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 537);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 538);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 539);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 540);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 542);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 543);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (77, 544);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (367220, N'The Blob', N'Coal miners accidentally unleash an alien lifeform that consumes everything in its path.', N'', N'https://image.tmdb.org/t/p/w500/5xOqbSEswdHLAuXDzpahTMnTHA2.jpg', NULL, '1/1/0001 12:00:00 AM', 0, NULL, NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (367220, 878);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (367220, 27);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (367220, 9648);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (367220, 12);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (367220, 2231);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (367220, 4587);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (311, N'Once Upon a Time in America', N'A former Prohibition-era Jewish gangster returns to the Lower East Side of Manhattan over thirty years later, where he once again must confront the ghosts and regrets of his old life.', N'Crime, passion and lust for power.', N'https://image.tmdb.org/t/p/w500/i0enkzsL5dPeneWnjl1fCWm6L7k.jpg', NULL, '5/23/1984 12:00:00 AM', 229, '4385', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (311, 18);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (311, 80);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 380);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 4512);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 4513);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 4517);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 4514);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 4521);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 4515);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 1004);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 3174);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 4516);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 4520);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 4761);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 4518);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 50744);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (311, 1373773);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (947, N'Lawrence of Arabia', N'The story of British officer T.E. Lawrence''s mission to aid the Arab tribes in their revolt against the Ottoman Empire during the First World War. Lawrence becomes a flamboyant, messianic figure in the cause of Arab unity but his psychological instability threatens to undermine his achievements.', N'A mighty motion picture of action and adventure!', N'https://image.tmdb.org/t/p/w500/yBc8a5wQL7FmSra4TgcdNrBcoP9.jpg', NULL, '12/11/1962 12:00:00 AM', 227, '12238', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (947, 12);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (947, 18);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (947, 36);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (947, 10752);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 11390);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 5004);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 12248);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 10018);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 5401);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 12515);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 14371);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 4113);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 11128);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 14372);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 35250);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 105634);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 105633);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 105635);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (947, 14373);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (3870, N'1900', N'Set in Bertolucci''s ancestral region of Emilia, the film chronicles the lives of two men during the political turmoils that took place in Italy in the first half of the 20th century.', N'From the cradle to the grave - victims of history and change!', N'https://image.tmdb.org/t/p/w500/87ELdlKW5h5qpJfVRXITvsDqYJ.jpg', NULL, '5/21/1976 12:00:00 AM', 317, '4956', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (3870, 18);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (3870, 36);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 380);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 16927);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 24590);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 34027);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 7710);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 55636);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 13784);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 3088);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 15385);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 27597);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 5567);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 34035);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 34039);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (3870, 34040);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (507, N'Killing Zoe', N'Zed is an American vault-cracker who travels to Paris to meet up with his old friend Eric. Eric and his gang have planned to raid the only bank in the city which is open on Bastille day. After offering his services, Zed soon finds himself trapped in a situation beyond his control when heroin abuse, poor planning and a call-girl named Zoe all conspire to turn the robbery into a very bloody siege.', N'', N'https://image.tmdb.org/t/p/w500/k3UEKMVnkljOlsO5sLmz87YGlaG.jpg', NULL, '10/1/1993 12:00:00 AM', 96, '8297', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (507, 28);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (507, 80);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (507, 18);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (507, 53);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 7036);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 1146);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 7037);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 7038);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 7039);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 7040);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 7041);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 7042);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 7043);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 7044);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 7046);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 42545);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 164987);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 2174);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (507, 938);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (10344, N'The Fly II', N'Martin Brundle, born of the human/fly, is adopted by his father''s place of employment (Bartok Inc.) while the employees simply wait for his mutant chromosomes to come out of their dormant state.', N'Like Father Like Son', N'https://image.tmdb.org/t/p/w500/gORksEPahEgO409HYJOZlNVyEpe.jpg', NULL, '2/10/1989 12:00:00 AM', 105, '64875', '109609');
INSERT INTO movie_genre (movie_id, genre_id) VALUES (10344, 27);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (10344, 878);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (10344, 53);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 7036);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 14668);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 21283);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 20211);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 61167);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 64874);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 26089);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 160111);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 35547);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 198472);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 1084740);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 190204);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 294790);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (10344, 67520);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (11800, N'Naked in New York', N'Naked in New York begins in the car of grown up Jake, he is talking to us about his girlfriend, Joanne,  and to whom you can turn to for help while facing life. From there it flashes back to his memories of his parents, college, house across from a squirrel infested peanut factory, best friend, writing career and Joanne.', N'Love. Work. Life. Even when you have all the pieces… some assembly is required', N'https://image.tmdb.org/t/p/w500/gAufFGm2Qly8TYrhy4me9X35B7m.jpg', NULL, '11/10/1993 12:00:00 AM', 95, '69696', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (11800, 35);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (11800, 10749);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 7036);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 18248);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 2877);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 20362);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 3150);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 10669);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 71266);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 3391);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 24368);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 2395);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 925);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 49148);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 64908);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 14722);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (11800, 57116);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (15143, N'Some Kind of Wonderful', N'A young tomboy, Watts, finds her feelings for her best friend, Keith, run deeper than just friendship when he gets a date with the most popular girl in school.', N'Before they could stand together, they had to stand alone.', N'https://image.tmdb.org/t/p/w500/lc6KUGAetADDQNxbz3u5dJ27OSb.jpg', NULL, '2/27/1987 12:00:00 AM', 95, '26502', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (15143, 18);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (15143, 10749);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 7036);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 31140);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 1063);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 77940);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 4138);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 778);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 13550);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 121757);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 58045);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 1837021);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 87066);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 31363);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 23975);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 151326);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (15143, 133581);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (61418, N'The Waterdance', N'Author Joel Garcia breaks his neck while hiking, and finds himself in a rehab center with Raymond, an exaggerating ladies man, and Bloss, a racist biker. Considerable tension builds as each character tries to deal with his new found handicap and the problems that go with it, especially Joel, whose lover Anna is having as difficult a time as he is.', N'Sometimes, life happens by accident.', N'https://image.tmdb.org/t/p/w500/Et6tFS1Ch3zOQPZQ3upVNWDg1G.jpg', NULL, '5/13/1992 12:00:00 AM', 106, '7406', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (61418, 18);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 7036);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 9994);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 10814);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 4520);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 7430);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 53087);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 166606);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 6465);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 1984);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 1173555);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 1173556);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 1173557);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 1173558);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (61418, 1173559);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (37146, N'Penn & Teller Get Killed', N'Penn &amp; Teller enjoy playing jokes on each other. When Penn says on an interview show that he wishes he has someone threatening his life so that he "wouldn''t sweat the small stuff," each of them begins a series of pranks on the other to suggest a real threat. Then they find that a real psychopath is interested in them.', N'What more do you want?', N'https://image.tmdb.org/t/p/w500/ja27nQA4Wofys5hAB6f3aDX801q.jpg', NULL, '9/22/1989 12:00:00 AM', 89, '6448', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (37146, 35);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (37146, 12);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 37221);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 74296);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 2275);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 1737);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 12514);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 1046579);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 1234924);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 171345);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 171016);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 2571346);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 111883);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 69718);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 2044970);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 94102);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (37146, 2571361);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (43589, N'Penn & Teller: Off the Deep End', N'Penn & Teller: Off the Deep End is a two-hour special that premiered on NBC on November 13, 2005. It featured magicians Penn & Teller performing a variety of illusions in various locations around the Caribbean, most of which were done underwater or involved marine animals. It also featured a performance by musician Aaron Carter.', N'', N'https://image.tmdb.org/t/p/w500/q0rJR1fzbZCHgpkrSD25inRJYP2.jpg', NULL, '11/13/2005 12:00:00 AM', 88, '504377', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (43589, 35);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (43589, 37221);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (43589, 74296);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (43589, 31162);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (43589, 570737);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (43589, 81390);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (43589, 570738);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (48425, N'Penn & Teller Go Public', N'Penn reads "Casey at the Bat" while Teller escapes from a straight jacket; Penn does a not-wimpy card trick; Teller gives the illusion of reality with a cigarette; Penn eats fire; and the guys show you a trick you can do at home, if you don''t mind taping over Masterpiece Theatre.', N'', N'https://image.tmdb.org/t/p/w500/fZ1r7tHAYp2SQErUd0Xw2ahVWZ3.jpg', NULL, '1/28/1985 12:00:00 AM', 37, NULL, NULL);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (48425, 37221);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (48425, 74296);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (67520, N'Grand Illusions - The Story Of Magic', N'Explore the rich, fascinating culture and history of magic through this six-part series, which takes you inside an alluring and enchanting world. It''s all here, from the mechanical automata of Robert-Houdin to the elaborate illusions of Penn and Teller, from the death-defying escapes of Houdini to the bizarre and tragic feats of the sideshow performers. Come backstage and see what''s behind the curtain.', N'', N'https://image.tmdb.org/t/p/w500/mhWwUqZV3OgbmZCmQjby2DmRjtq.jpg', NULL, '3/25/2003 12:00:00 AM', 160, NULL, NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (67520, 99);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (67520, 37221);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (67520, 74296);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (79207, N'Phobophilia: The Love of Fear', N'More terror/magic hijinks from Penn &amp; Teller, with support from some other players. Paul Provenza spends the whole show trapped in a system of giant tubes. Skits include a new director and an auditioning starlet who can and will do anything, and the Three Stooges on a construction project. Other notable tricks include earthworms finding a photo from a stack, a borrowed ring apparently cut from a volunteer''s stomach, and a bullet swap.', N'', N'https://image.tmdb.org/t/p/w500', NULL, '1/1/1995 12:00:00 AM', 60, '81809', NULL);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (79207, 37221);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (79207, 74296);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (79207, 156989);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (79207, 154171);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (79207, 83339);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (79207, 23679);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (137, N'Groundhog Day', N'A narcissistic TV weatherman, along with his attractive-but-distant producer, and his mawkish cameraman, is sent to report on Groundhog Day in the small town of Punxsutawney, where he finds himself repeating the same day over and over.', N'He’s having the worst day of his life … over, and over …', N'https://image.tmdb.org/t/p/w500/gCgt1WARPZaXnq523ySQEUKinCs.jpg', NULL, '2/11/1993 12:00:00 AM', 101, '1524', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (137, 10749);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (137, 14);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (137, 18);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (137, 35);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1532);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1533);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1534);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 537);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1535);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1537);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1538);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1539);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1540);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1542);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 236327);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 335);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1524);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1536);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (137, 1318541);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (153, N'Lost in Translation', N'Two lost souls visiting Tokyo -- the young, neglected wife of a photographer and a washed-up movie star shooting a TV commercial -- find an odd solace and pensive freedom to be real in each other''s company, away from their lives in America.', N'Everyone wants to be found.', N'https://image.tmdb.org/t/p/w500/wkSzJs7oMf8MIr9CQVICsvRfwA7.jpg', NULL, '9/18/2003 12:00:00 AM', 102, '1769', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (153, 18);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (153, 10749);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (153, 35);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1532);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1245);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1771);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1772);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1770);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1785);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1773);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1774);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1775);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1786);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1787);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 75491);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 237167);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (153, 1185077);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (308, N'Broken Flowers', N'As the devoutly single Don Johnston is dumped by his latest girlfriend, he receives an anonymous pink letter informing him that he has a son who may be looking for him.', N'Sometimes life brings some strange surprises', N'https://image.tmdb.org/t/p/w500/xDjCNGmDOesm8UenVrCBkUv38VT.jpg', NULL, '8/5/2005 12:00:00 AM', 106, '4429', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (308, 35);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (308, 18);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (308, 9648);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (308, 10749);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 1532);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 1146);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 4430);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 3063);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 4431);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 2954);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 4432);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 4433);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 4439);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 4440);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 4441);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 83920);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 4442);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 4443);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (308, 4445);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (421, N'The Life Aquatic with Steve Zissou', N'Renowned oceanographer Steve Zissou has sworn vengeance upon the rare shark that devoured a member of his crew. In addition to his regular team, he is joined on his boat by Ned, a man who believes Zissou to be his father, and Jane, a journalist pregnant by a married man. They travel the sea, all too often running into pirates and, perhaps more traumatically, various figures from Zissou''s past, including his estranged wife, Eleanor.', N'The deeper you go, the weirder life gets.', N'https://image.tmdb.org/t/p/w500/qZoFLNBC78jzboWeDH6Ha0qavF2.jpg', NULL, '12/10/2004 12:00:00 AM', 119, '5655', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (421, 12);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (421, 35);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (421, 18);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 1532);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 887);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 112);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 5657);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 5293);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 4785);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 5658);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 1284);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 4971);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 5659);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 5661);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 5662);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 5663);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 5950);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (421, 159319);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (620, N'Ghostbusters', N'After losing their academic posts at a prestigious university, a team of parapsychologists goes into business as proton-pack-toting "ghostbusters" who exterminate ghouls, hobgoblins and supernatural pests of all stripes. An ad campaign pays off when a knockout cellist hires the squad to purge her swanky digs of demons that appear to be living in her refrigerator.', N'They ain''t afraid of no ghost.', N'https://image.tmdb.org/t/p/w500/h5Qz8J4T8YQnbZzHXM73WVYYVPK.jpg', N'http://www.ghostbusters.com/', '6/8/1984 12:00:00 AM', 107, '8858', '2980');
INSERT INTO movie_genre (movie_id, genre_id) VALUES (620, 35);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (620, 14);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 1532);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 707);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 10205);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 1524);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 8872);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 8873);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 7676);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 8874);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 8875);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 55930);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 101652);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 562314);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 1080265);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 17488);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (620, 51549);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (250658, N'The Internet''s Own Boy: The Story of Aaron Swartz', N'Programming prodigy and information activist Aaron Swartz achieved groundbreaking work in social justice and political organizing. His passion for open access ensnared him in a legal nightmare that ended with the taking of his own life at the age of 26.', N'Information is power.', N'https://image.tmdb.org/t/p/w500/s8qznCAjPRcRwQkvGU6rRdF7mxb.jpg', NULL, '6/27/2014 12:00:00 AM', 105, '1102384', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (250658, 80);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (250658, 99);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (250658, 1360987);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (250658, 1360985);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (250658, 90714);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (250658, 1360986);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (250658, 90713);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (379447, N'Foreveryone.net', N'Foreveryone.net connects the future of the web with the little-known story of its birth. In 1989, 33-year-old computer programmer Tim Berners-Lee invented the world wide web and his visionary decision to make it a free and accessible resource sparked a global revolution in communication. Tim has declared internet access a human right and has called for an “online Magna Carta” to protect privacy and free speech, extend connectivity to populations without access and maintain “One Web” for all. Tim’s dramatic story poses the question: will we fight for the web we want or let it be taken away?', N'The web, past and future.', N'https://image.tmdb.org/t/p/w500/uJEive0zmo4J42IgAAIkFkfbinC.jpg', N'http://www.foreveryone.net/', '1/1/2016 12:00:00 AM', 35, '19509', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (379447, 99);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (379447, 1360985);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (347495, N'Inside the Dark Web', N'Twenty-five years after the world wide web was created, it is now caught in the greatest controversy of its existence - surveillance. With many concerned that governments and corporations can monitor our every move, Horizon meets the hackers and scientists whose technology is fighting back. It is a controversial technology, and some law enforcement officers believe it is leading to risk-free crime on the dark web - a place where almost anything can be bought, from guns and drugs to credit card details.', N'', N'https://image.tmdb.org/t/p/w500/ILguuyDqXnV3uuAhDk0KDSteAZ.jpg', NULL, '9/3/2014 12:00:00 AM', 50, '1520071', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (347495, 99);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (347495, 1349802);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (347495, 1417332);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (347495, 150882);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (347495, 1360985);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (347495, 1386089);
INSERT INTO movie (movie_id, title, overview, tagline, poster_path, home_page, release_date, length_minutes, director_id, collection_id) VALUES (481573, N'The Gutenberg Enigma', N'A portrait of the inventor of the letterpress, who was a key figure in the history of mankind, but also an enthusiastic inventor, a daring businessman, a tenacious troublemaker: the life of Johannes Gutenberg (circa 1400-68).', N'The man who succeeds against all odds', N'https://image.tmdb.org/t/p/w500/cQYMWnUJ3gV7KXSruWjR1DyfuVA.jpg', NULL, '9/25/2017 12:00:00 AM', 86, '1132115', NULL);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (481573, 99);
INSERT INTO movie_genre (movie_id, genre_id) VALUES (481573, 36);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 64552);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 565126);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 565123);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 1906655);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 1307239);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 1360985);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 1846009);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 2481294);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 2481299);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 2481301);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 2481303);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 2481335);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 2481337);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 2481343);
INSERT INTO movie_actor (movie_id, actor_id) VALUES (481573, 2481345);
SET IDENTITY_INSERT movie OFF;


-- reset identity columns for genre, person, and movie to be much higher than the current max
DECLARE @nextGenre INT; SELECT @nextGenre = MAX(genre_id) + 1000 FROM genre;
DECLARE @nextPerson INT; SELECT @nextPerson = MAX(person_id) + 1000000 FROM person;
DECLARE @nextMovie INT; SELECT @nextMovie = MAX(movie_id) + 100000 FROM movie;
DECLARE @nextCollection INT; SELECT @nextCollection = MAX(collection_id) + 100000 FROM collection;

-- MS doesn't allow you to use a variable in CHECKIDENT, so we must reset it like this
DECLARE @sqlG VARCHAR(50); SET @sqlG = 'DBCC CHECKIDENT (''genre'', RESEED, ' + CAST(@nextGenre AS VARCHAR(10)) + ');'
DECLARE @sqlP VARCHAR(50); SET @sqlP = 'DBCC CHECKIDENT (''person'', RESEED, ' + CAST(@nextPerson AS VARCHAR(10)) + ');'
DECLARE @sqlM VARCHAR(50); SET @sqlM = 'DBCC CHECKIDENT (''movie'', RESEED, ' + CAST(@nextMovie AS VARCHAR(10)) + ');'
DECLARE @sqlC VARCHAR(50); SET @sqlC = 'DBCC CHECKIDENT (''collection'', RESEED, ' + CAST(@nextCollection AS VARCHAR(10)) + ');'
EXEC (@sqlG)
EXEC (@sqlP)
EXEC (@sqlM)
EXEC (@sqlC)
