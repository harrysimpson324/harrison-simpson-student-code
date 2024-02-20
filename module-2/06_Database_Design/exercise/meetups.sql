Start transaction;

--was getting a lot of errors regarding use of the word "group" since that is a keyword in postgreSQL, decided to use groop instead.
--Since the only foreign key I used was group_id in event as one(group) to many(events) relationship, I didn't put it at the end, i just did it in the event table declaration.

DROP TABLE IF EXISTS event_member, groop_member, member, groop, event CASCADE;

CREATE table member (
	member_id serial NOT NULL,
	last_name varchar(30) NOT NULL,
	first_name varchar(30) NOT NULL,
	email varchar(100) ,
	phone varchar(15) ,
	birthdate date,
	wantsReminder boolean NOT NULL,
	CONSTRAINT pk_member PRIMARY KEY (member_id)
);

CREATE TABLE groop (
	groop_id serial NOT NULL,
	groop_name varchar(100) NOT NULL,
	CONSTRAINT pk_groop PRIMARY KEY (groop_id),
	CONSTRAINT uq_groop_name UNIQUE (groop_name)
);

CREATE TABLE event (
	event_id serial NOT NULL,
	event_name varchar(100) NOT NULL,
	description varchar(500) ,
	start_date date,
	start_time time,
	duration_minutes int,
	groop_id int,
	CONSTRAINT pk_event PRIMARY KEY (event_id),
	CONSTRAINT fk_event FOREIGN KEY (groop_id) REFERENCES groop(groop_id),
	CONSTRAINT check_duration CHECK (duration_minutes > 29)
);

CREATE TABLE event_member (
	event_id int NOT NULL,
	member_id int NOT NULL,
	CONSTRAINT pk_event_member PRIMARY KEY (event_id, member_id),
	CONSTRAINT fk_event_member_event FOREIGN KEY (event_id) REFERENCES event(event_id),
	CONSTRAINT fk_event_member_member FOREIGN KEY (member_id) REFERENCES member(member_id)
);

CREATE TABLE groop_member (
	groop_id int NOT NULL,
	member_id int NOT NULL,
	CONSTRAINT pk_groop_member PRIMARY KEY (groop_id, member_id),
	CONSTRAINT fk_groop_member_groop FOREIGN KEY (groop_id) REFERENCES groop(groop_id),
	CONSTRAINT fk_groop_member_member FOREIGN KEY (member_id) REFERENCES member(member_id)
);

INSERT INTO groop (groop_name) VALUES('Hopscotch Club');
INSERT INTO groop (groop_name) VALUES('Weekend Boys and Weekend Girls Association');
INSERT INTO groop (groop_name) VALUES('Thirty Silver Dollars Coven of Worship');
INSERT INTO groop (groop_name) VALUES('Trout Almondine Appreciators');
INSERT INTO groop (groop_name) VALUES('Trevors Big Day Is Everyday Club');

INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Heather', 'Hopper', false);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Sylver', 'Plate', false);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Nether', 'Portand', false);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Lenny', 'Learner', false);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Face', 'Demons', false);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Trevor', 'Little', true);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Bobby', 'Reynolds', false);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Dinglejohn', 'Schmidt', false);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Chungledown', 'Bim', false);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Fabio', 'Goose', false);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('Cocaine', 'Bear', false);
INSERT INTO member(first_name, last_name, wantsReminder) VALUES('The', 'Rock', false);

INSERT INTO event(event_name, description, start_date, start_time, duration_minutes, groop_id) 
VALUES ('Lets Go Hopping!', 'Time to put on our hopping shoes and go to town!', '01.01.2024', '12:00', 60, (SELECT groop_id FROM groop where groop_name = 'Hopscotch Club'));
INSERT INTO event(event_name, description, start_date, start_time, duration_minutes, groop_id) 
VALUES ('Lets Go Hopping Again (within reason!)', 'Last time we got a little out of hand, folks. Lets have fun, but keep it PG this time!', '02.01.2024', '12:00', 30, (SELECT groop_id FROM groop where groop_name = 'Hopscotch Club'));
INSERT INTO event(event_name, description, start_date, start_time, duration_minutes, groop_id) 
VALUES ('Venture to Ikea', 'Its time for an IKEA run, weekend fam. Lets see some furniture slathered in meetballs (meat you there!)', '03.09.2024', '9:00am', 95, (SELECT groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO event(event_name, description, start_date, start_time, duration_minutes, groop_id) 
VALUES ('Its Finally My Big Day!', 'Weekly event series: Come and hang out with me, Trevor Little, on my big day!', '02.29.2024', '08:00am', 360, (SELECT groop_id FROM groop where groop_name = 'Trevors Big Day Is Everyday Club'));

INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Chungledown'), (select groop_id FROM groop where groop_name = 'Thirty Silver Dollars Coven of Worship'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'The'), (select groop_id FROM groop where groop_name = 'Thirty Silver Dollars Coven of Worship'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Face'), (select groop_id FROM groop where groop_name = 'Thirty Silver Dollars Coven of Worship'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Heather'), (select groop_id FROM groop where groop_name = 'Hopscotch Club'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Sylver'), (select groop_id FROM groop where groop_name = 'Hopscotch Club'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Nether'), (select groop_id FROM groop where groop_name = 'Hopscotch Club'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Dinglejohn'), (select groop_id FROM groop where groop_name = 'Hopscotch Club'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Fabio'), (select groop_id FROM groop where groop_name = 'Trout Almondine Appreciators'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Cocaine'), (select groop_id FROM groop where groop_name = 'Trout Almondine Appreciators'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Bobby'), (select groop_id FROM groop where groop_name = 'Trout Almondine Appreciators'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Lenny'), (select groop_id FROM groop where groop_name = 'Trout Almondine Appreciators'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Nether'), (select groop_id FROM groop where groop_name = 'Trout Almondine Appreciators'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Chungledown'), (select groop_id FROM groop where groop_name = 'Trout Almondine Appreciators'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Trevor'), (select groop_id FROM groop where groop_name = 'Trevors Big Day Is Everyday Club'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Heather'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Sylver'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Nether'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Lenny'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Face'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Bobby'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Dinglejohn'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Chungledown'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Fabio'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'Cocaine'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));
INSERT INTO groop_member(member_id, groop_id)
VALUES((SELECT member_id FROM member where first_name = 'The'), (select groop_id FROM groop where groop_name = 'Weekend Boys and Weekend Girls Association'));

INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Lets Go Hopping!'), 
		(SELECT member_id FROM member WHERE first_name = 'Heather'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Lets Go Hopping!'), 
		(SELECT member_id FROM member WHERE first_name = 'Sylver'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Lets Go Hopping!'), 
		(SELECT member_id FROM member WHERE first_name = 'Nether'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Lets Go Hopping Again (within reason!)'), 
		(SELECT member_id FROM member WHERE first_name = 'Heather'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Lets Go Hopping Again (within reason!)'), 
		(SELECT member_id FROM member WHERE first_name = 'Sylver'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'Heather'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'Sylver'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'Nether'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'Lenny'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'Face'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'Bobby'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'Dinglejohn'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'Chungledown'));				
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'Fabio'));		
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'Cocaine'));		
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Venture to Ikea'), 
		(SELECT member_id FROM member WHERE first_name = 'The'));
INSERT INTO event_member(event_id, member_id) 
VALUES ((SELECT event_id FROM event WHERE event_name = 'Its Finally My Big Day!'), 
		(SELECT member_id FROM member WHERE first_name = 'Trevor'));		
		
		
-- ONE foreign key to add i think?
--nope

	
--ROLLBACK;
COMMIT;

