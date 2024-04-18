BEGIN TRANSACTION;

CREATE TABLE customer (
    customer_id int identity,
    first_name varchar(20) NOT NULL,
    last_name varchar(20) NOT NULL,
    street_address varchar(50) NOT NULL,
    city varchar(50) NOT NULL,
    phone_number varchar(10) NULL,
    email_address varchar(50) NULL,
    email_offers bit NOT NULL CONSTRAINT DF_email_offers DEFAULT (0),
    CONSTRAINT PK_customer PRIMARY KEY(customer_id)
);

CREATE TABLE sale (
    sale_id int identity,
    total numeric(6,2) NULL,
    is_delivery bit NOT NULL CONSTRAINT DF_is_delivery DEFAULT (0),
    customer_id int NULL, --nullable foreign key
    CONSTRAINT PK_order PRIMARY KEY(sale_id),
    CONSTRAINT FK_sale_customer_id FOREIGN KEY(customer_id) REFERENCES customer(customer_id),
    CONSTRAINT CK_total CHECK (total > 0)
);

INSERT INTO customer (first_name, last_name, street_address, city, phone_number, email_address, email_offers) VALUES ('Deanne', 'Mallon', '9709 Ryan Alley', 'Saydol Falls', '3441091536', null, 0);
INSERT INTO customer (first_name, last_name, street_address, city, phone_number, email_address, email_offers) VALUES ('Elenore', 'Mamwell', '561 Claremont Alley', 'Mayport', null, 'emamwell2@gmail.com', 1);
INSERT INTO customer (first_name, last_name, street_address, city, phone_number, email_address, email_offers) VALUES ('Madge', 'Lampaert', '1 Upham Road', 'Kingford', '2647680585', null, 0);
INSERT INTO customer (first_name, last_name, street_address, city, phone_number, email_address, email_offers) VALUES ('Dud', 'Dobbins', '27417 Ronald Regan Plaza', 'Oakview', '8043468703', 'ddobbins3@aol.com', 1);
INSERT INTO customer (first_name, last_name, street_address, city, phone_number, email_address, email_offers) VALUES ('Row', 'Woofenden', '79 Hanson Road', 'Oakview', null, null, 0);
INSERT INTO customer (first_name, last_name, street_address, city, phone_number, email_address, email_offers) VALUES ('Robin', 'Besnardeau', '87 Vidon Terrace', 'Oakview', '3106161864', null, 0);

INSERT INTO sale (total, is_delivery, customer_id) VALUES (11.99, 0, 1);
INSERT INTO sale (total, is_delivery, customer_id) VALUES (14.87, 0, 2);
INSERT INTO sale (total, is_delivery, customer_id) VALUES (13.90, 1, 2);
INSERT INTO sale (total, is_delivery, customer_id) VALUES (109.05, 0, 2);
INSERT INTO sale (total, is_delivery, customer_id) VALUES (23.98, 1, 3);
INSERT INTO sale (total, is_delivery, customer_id) VALUES (41.25, 0, 3);
INSERT INTO sale (total, is_delivery, customer_id) VALUES (38.35, 0, 4);
INSERT INTO sale (total, is_delivery, customer_id) VALUES (19.29, 1, 4);
INSERT INTO sale (total, is_delivery, customer_id) VALUES (44.43, 1, 4);
INSERT INTO sale (total, is_delivery, customer_id) VALUES (35.97, 0, 6);
INSERT INTO sale (total, is_delivery, customer_id) VALUES (27.27, 1, 6);

COMMIT;
