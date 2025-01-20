CREATE DATABASE IF NOT EXISTS e_commerce_database;
USE e_commerce_database;
CREATE TABLE IF NOT EXISTS categories
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) UNIQUE NOT NULL
);
CREATE TABLE IF NOT EXISTS products
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL UNIQUE,
    price DECIMAL(10, 3) NOT NULL,
    category_id INT NOT NULL,
    rating INT DEFAULT 0,
    CHECK (rating BETWEEN 0 AND 5),
    FOREIGN KEY (category_id) REFERENCES categories(id)
    ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS customers
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(50) NOT NULL
);
CREATE TABLE IF NOT EXISTS orders
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    total_amount DECIMAL(13, 3) NOT NULL,
    order_date DATE NOT NULL,
    customer_id INT NOT NULL,
    status VARCHAR(10) NOT NULL DEFAULT 'pending',
    FOREIGN KEY (customer_id) REFERENCES customers(id)
    ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS order_products
(
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    amount DECIMAL(10,3) NOT NULL,
    FOREIGN KEY (product_id) REFERENCES products(id)
    ON DELETE CASCADE,
    FOREIGN KEY (order_id) REFERENCES orders(id)
    ON DELETE CASCADE,
    PRIMARY KEY(order_id,product_id)
);