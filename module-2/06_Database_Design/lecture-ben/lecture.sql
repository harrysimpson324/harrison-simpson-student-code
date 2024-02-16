START TRANSACTION;

DROP TABLE IF EXISTS person, purchase, artwork CASCADE;

-- Create PERSON table
--   PK customer_id
--   first name
--   last name
--   address NULLABLE
--   phone number NULLABLE

CREATE TABLE person
(
	person_id serial,
	first_name varchar(32) not null,
	last_name varchar(32) not null,
	address varchar(100) null,
	phone varchar(11) null,
	
	CONSTRAINT pk_person PRIMARY KEY (person_id)
);

-- Create ARTWORK table
--   PK artwork_id
--   person_id
--   title
CREATE TABLE artwork
(
	artwork_id serial,
	artist_id int not null,
	title varchar(100) not null,
	
	CONSTRAINT pk_artwork PRIMARY KEY (artwork_id),
	CONSTRAINT fk_artwork_person FOREIGN KEY (artist_id) REFERENCES person(person_id)
	
);


-- Create PURCHASE table
--   PK artwork_id
--   PK person_id
--   PK purchase_date
--   price

CREATE TABLE purchase
(
	artwork_id int not null,
	customer_id int not null,
	purchase_date timestamp not null,
	price money not null,
	
	CONSTRAINT pk_purchase PRIMARY KEY (artwork_id, customer_id, purchase_date),
	CONSTRAINT fk_purchase_artwork FOREIGN KEY (artwork_id) REFERENCES artwork(artwork_id),
	CONSTRAINT fk_purchase_person FOREIGN KEY (customer_id) REFERENCES person(person_id)	
);

-- INSERT data into PERSON table


-- INSERT data into ARTWORK table


-- INSERT data into PURCHASE table 


-- ALTER constrataints to add foreign keys and null/not null



COMMIT;
--ROLLBACK;