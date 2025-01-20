INSERT INTO orders (total_amount, order_date, customer_id)
VALUES
(260.68, CURDATE(), 1),
(12027.9, CURDATE(), 3);

INSERT INTO order_products (order_id, product_id, quantity, amount)
VALUES
(1, 1, 2, 260.68),
(2, 6, 2, 28.9),
(2, 3, 1, 11999);