BEGIN TRANSACTION;

DROP TABLE IF EXISTS shop_apparel, apparel, shop, users CASCADE;

CREATE TABLE shop (
    shop_id serial NOT NULL,
    name varchar(256) NOT NULL,
    street_address varchar(256) NOT NULL,
    city varchar(100) NOT NULL,
    state varchar(2) NOT NULL,
    zip varchar(11) NOT NULL,
	CONSTRAINT PK_shop PRIMARY KEY(shop_id)
);

CREATE TABLE apparel (
    apparel_id serial NOT NULL,
    title varchar(100) NOT NULL,
    description varchar(256) NOT NULL,
    size varchar(20) NOT NULL,
    price numeric(7,2) NOT NULL,
	CONSTRAINT PK_apparel PRIMARY KEY(apparel_id)
);

CREATE TABLE shop_apparel (
    shop_id int NOT NULL,
    apparel_id int NOT NULL,
    quantity int NOT NULL,
    CONSTRAINT FK_shop_apparel_shop FOREIGN KEY(shop_id) REFERENCES shop(shop_id),
    CONSTRAINT FK_shop_apparel_apparel FOREIGN KEY(apparel_id) REFERENCES apparel(apparel_id)
);

CREATE TABLE users (
    user_id serial NOT NULL,
    username varchar(50) NOT NULL UNIQUE,
	password_hash varchar(200) NOT NULL,
    email varchar(200) NOT NULL,
    first_name varchar(50) NOT NULL,
    last_name varchar(50) NOT NULL,
    role varchar(50) NOT NULL,
    employee_shop_id int NULL,
	CONSTRAINT PK_user PRIMARY KEY(user_id),
    CONSTRAINT FK_user_shop FOREIGN KEY(employee_shop_id) REFERENCES shop(shop_id)
);

INSERT INTO shop (name, street_address, city, state, zip) VALUES
    ('Fashion Avenue', '456 Fashion Street', 'Seattle', 'WA', '98101'),
    ('Style Central', '789 Style Avenue', 'Auburn', 'WA', '98000');
    -- ('Trendy Threads', '321 Trendy Road', 'Seattle', 'WA', '98101'),
    -- ('Chic Boutique', '987 Chic Boulevard', 'Seattle', 'WA', '98101'),
    -- ('Fashion Forward', '654 Fashion Lane', 'Kent', 'WA', '98200');

INSERT INTO apparel (title, description, size, price) VALUES
    ('T-Shirt', 'Cotton crew neck t-shirt', 'M', 19.99),
    ('Jeans', 'Slim-fit denim jeans', '32x32', 49.99),
    ('Dress', 'Floral print summer dress', 'S', 39.99),
    ('Sneakers', 'Canvas sneakers', '9', 29.99),
    ('Jacket', 'Leather biker jacket', 'L', 79.99);

INSERT INTO shop_apparel (shop_id, apparel_id, quantity) VALUES
    (1, 1, 10),
    (1, 2, 12),
    (1, 3, 8),
    (2, 3, 5),
    (2, 4, 100),
    (2, 5, 10);

INSERT INTO users (username, password_hash, email, first_name, last_name, role, employee_shop_id) VALUES
    ('user_hq', '$2a$10$9kGzKgPc6t1V02sVUDAzNuIAlS3Tc4gO4LmLD.bMR80.IWWrsgS..', 'alex@webthreads.com', 'Alex', 'Peron', 'ROLE_HQ', NULL),
    ('user_shop', '$2a$10$9kGzKgPc6t1V02sVUDAzNuIAlS3Tc4gO4LmLD.bMR80.IWWrsgS..', 'jo@webthreads.com', 'Jo', 'Cutteridge', 'ROLE_SHOP', 1);

COMMIT;
