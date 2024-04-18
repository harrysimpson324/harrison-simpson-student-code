-- Switch to the system (aka master) database
USE master;
GO

-- Delete the ArtGallery Database (IF EXISTS)
DROP DATABASE IF EXISTS ArtGallery;

-- Create a new ArtGallery Database
CREATE DATABASE ArtGallery;
GO

-- Switch to the ArtGallery Database
USE ArtGallery
GO

-- Begin a TRANSACTION that must complete with no errors
BEGIN TRANSACTION;

CREATE TABLE customers
(
	customerId		int				identity(1,1),
	name			varchar(64)		not null,
	address			varchar(100)	not null,
	phone			varchar(11)		null,

	constraint pk_customers primary key (customerId)
);

CREATE TABLE artists
(
	artistId		int				identity(1,1),
	firstName		varchar(64)		not null,
	lastName		varchar(64)		not null,

	constraint pk_artists primary key (artistId)
);

CREATE TABLE art
(
	artCodeId		int				identity(1,1),
	title			varchar(64)		not null,
	artistId		int				not null,

	constraint pk_art primary key (artCodeId),
	constraint fk_art_artists foreign key (artistId) references artists (artistId)
);

CREATE TABLE customer_purchases
(
	customerId		int				not null,
	artCodeId		int				not null,
	purchaseDate	datetime		not null,
	price			money			not null,

	constraint pk_customer_purchases primary key (customerId, artCodeId, purchaseDate),
	constraint fk_customer_purchases_customer foreign key (customerId) references customers (customerId),
	constraint fk_customer_purchases_art foreign key (artCodeId) references art(artCodeId) 
);


COMMIT TRANSACTION;