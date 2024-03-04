START TRANSACTION;

DROP TABLE IF EXISTS member, interest_group, event, member_groups, member_events CASCADE;

CREATE TABLE member
(
	member_id serial,
	last_name varchar (32) not null,
	first_name varchar (32) not null,
	email varchar (100) not null,
	phone_number varchar (11) null,
	date_of_birth date not null,
	wants_emails boolean not null,
	
	CONSTRAINT pk_member_id PRIMARY KEY (member_id)
);

--Create MEMBER table
-- PK member_id
-- last_name
-- first_name
-- email
-- phone_number
-- date_of_birth
-- wants_emails

CREATE TABLE interest_group
(
	group_id serial,
	group_name varchar (100),
	
	CONSTRAINT pk_group_id PRIMARY KEY (group_id),
	CONSTRAINT unique_group_name UNIQUE (group_name)
);

--Create INTEREST GROUP table
-- PK group_number
-- group_name

CREATE TABLE event
(
	event_id serial,
	event_name varchar (100) not null,
	description varchar (500),
	start_date_time timestamp not null,
	duration int not null,
	group_id int not null,
	
	CONSTRAINT pk_event_id PRIMARY KEY (event_id),
	CONSTRAINT fk_group_id FOREIGN KEY (group_id) REFERENCES interest_group (group_id)
	
);
--Create EVENT table
-- PK event_number
-- event_name
-- description
-- start_date_time
-- duration
-- FK group_number

CREATE TABLE member_groups
(
	member_id int not null,
	group_id int not null,
	
	CONSTRAINT pk_member_group_id PRIMARY KEY (member_id, group_id),
	CONSTRAINT fk_member_id FOREIGN KEY (group_id) REFERENCES member (member_id),
	CONSTRAINT fk_group_id FOREIGN KEY (group_id) REFERENCES interest_group (group_id)
);
--Create Table for members in group
-- PK, FK member_id
-- FK group_name

CREATE TABLE member_events
(
	member_id int not null,
	event_id int not null,
	
	CONSTRAINT pk_member_event_id PRIMARY KEY (member_id, event_id),
	CONSTRAINT fk_member_id FOREIGN KEY (member_id) REFERENCES member (member_id),
	CONSTRAINT fk_event_id FOREIGN KEY (event_id) REFERENCES event (event_id)
	
);
--Create Table for members attending events
-- PK, FK member_id
-- FK event_number

INSERT INTO member (last_name, first_name,email,phone_number,date_of_birth,wants_emails)
VALUES ('Johnson', 'Alice', 'alice.johnson@yahoo.com', 16151234567, '7/12/1985', true),
		('Smith', 'Robert', 'robert.smith@gmail.com', 19319876543, '3/25/1978', true),
		('Davis', 'Emily', 'edavis@gmail.com', 19318765432, '11/8/1992', true),
		('Rodriguez', 'Michael', 'michael.rodriguez@extrememail.com', 19312345678, '05/17/1989', true),
		('Baker', 'Jennifer', 'jennifer.baker16@gmail.com', 19313456789, '9/30/1982', true),
		('Adams', 'Daniel', 'skaterduddde45@yahoo.com', 19314567890, '1/22/1995', true),
		('Wilson', 'Samantha', 'samantha.wilson@gmail.com', 19313141592, '4/14/1987', true),
		('Taylor', 'Kevin', 'kevin.taylor@gmail.com', 19316789012, '8/3/1990', false);
		
INSERT INTO interest_group (group_name)
VALUES ('Tech Innovators Network'),
		('Global Business Leaders Association'),
		('Creative Arts Collective');

INSERT INTO event (event_name, description, start_date_time, duration, group_id)
VALUES ('Tech Expo 2024', 'A cutting-edge technology exhibition.', '3/8/2024 09:00:00', 48, (SELECT group_id FROM interest_group WHERE group_name = 'Tech Innovators Network')),
		('Global Leadership Summit', 'An international summit.', '3/15/2024 13:00:00', 72, (SELECT group_id FROM interest_group WHERE group_name = 'Global Business Leaders Association')),
		('Atristry Unleashed Gala', 'An annual gala.', '3/22/2024 19:00:00', 4, (SELECT group_id FROM interest_group WHERE group_name = 'Creative Arts Collective')),
		('Netwoking Mixer', 'An informal networking event.', '3/29/2024 18:30:00', 2, (SELECT group_id FROM interest_group WHERE group_name = 'Tech Innovators Network'));

INSERT INTO member_groups (member_id, group_id)
VALUES ((SELECT member_id FROM member WHERE last_name = 'Johnson'), (SELECT group_id FROM interest_group WHERE group_name = 'Tech Innovators Network')),
		((SELECT member_id FROM member WHERE last_name = 'Johnson'), (SELECT group_id FROM interest_group WHERE group_name = 'Global Business Leaders Association')),
		((SELECT member_id FROM member WHERE last_name = 'Smith'), (SELECT group_id FROM interest_group WHERE group_name = 'Tech Innovators Network')),
		((SELECT member_id FROM member WHERE last_name = 'Smith'), (SELECT group_id FROM interest_group WHERE group_name = 'Global Business Leaders Association')),
		((SELECT member_id FROM member WHERE last_name = 'Davis'), (SELECT group_id FROM interest_group WHERE group_name = 'Global Business Leaders Association')),
		((SELECT member_id FROM member WHERE last_name = 'Davis'), (SELECT group_id FROM interest_group WHERE group_name = 'Creative Arts Collective')),
		((SELECT member_id FROM member WHERE last_name = 'Rodriguez'), (SELECT group_id FROM interest_group WHERE group_name = 'Tech Innovators Network')),
		((SELECT member_id FROM member WHERE last_name = 'Rodriguez'), (SELECT group_id FROM interest_group WHERE group_name = 'Global Business Leaders Association')),
		((SELECT member_id FROM member WHERE last_name = 'Baker'), (SELECT group_id FROM interest_group WHERE group_name = 'Creative Arts Collective')),
		((SELECT member_id FROM member WHERE last_name = 'Adams'), (SELECT group_id FROM interest_group WHERE group_name = 'Creative Arts Collective')),
		((SELECT member_id FROM member WHERE last_name = 'Wilson'), (SELECT group_id FROM interest_group WHERE group_name = 'Creative Arts Collective'));
		
INSERT INTO member_events (member_id, event_id)
VALUES ((SELECT member_id FROM member WHERE last_name = 'Johnson'), (SELECT event_id FROM event WHERE event_name = 'Tech Expo 2024')),
		((SELECT member_id FROM member WHERE last_name = 'Smith'), (SELECT event_id FROM event WHERE event_name = 'Tech Expo 2024')),
		((SELECT member_id FROM member WHERE last_name = 'Davis'), (SELECT event_id FROM event WHERE event_name = 'Global Leadership Summit')),
		((SELECT member_id FROM member WHERE last_name = 'Rodriguez'), (SELECT event_id FROM event WHERE event_name = 'Global Leadership Summit')),
		((SELECT member_id FROM member WHERE last_name = 'Baker'), (SELECT event_id FROM event WHERE event_name = 'Atristry Unleashed Gala')),
		((SELECT member_id FROM member WHERE last_name = 'Adams'), (SELECT event_id FROM event WHERE event_name = 'Atristry Unleashed Gala')),
		((SELECT member_id FROM member WHERE last_name = 'Wilson'), (SELECT event_id FROM event WHERE event_name = 'Atristry Unleashed Gala')),
		((SELECT member_id FROM member WHERE last_name = 'Taylor'), (SELECT event_id FROM event WHERE event_name = 'Netwoking Mixer'));

--Create EVENT table
-- PK event_number
-- event_name
-- description
-- start_date_time
-- duration
-- FK group_number

COMMIT;
--ROLLBACK;