IF DB_ID('PizzaShopLite') IS NOT NULL
BEGIN
	ALTER DATABASE PizzaShopLite SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE PizzaShopLite;
END

CREATE DATABASE PizzaShopLite;
