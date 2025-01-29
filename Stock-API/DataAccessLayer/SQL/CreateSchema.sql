CREATE DATABASE stock_db;
USE stock_db;
CREATE TABLE stocks
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    profile_id VARCHAR(10) NOT NULL,
    price INT NOT NULL,
    fuel_type VARCHAR(10) NOT NULL,
    kms INT NOT NULL,
    name VARCHAR(50) NOT NULL,
    make_year YEAR(4) NOT NULL,
    make_model VARCHAR(50) NOT NULL,
    make_name VARCHAR(50) NOT NULL
);