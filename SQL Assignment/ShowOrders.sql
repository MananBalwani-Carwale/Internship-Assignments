SELECT orders.id, orders.order_date, orders.total_amount, customers.first_name, customers.last_name,
products.name AS product, categories.name AS category FROM customers 
INNER JOIN orders ON customers.id = orders.customer_id
INNER JOIN order_products ON orders.id = order_products.order_id 
INNER JOIN products ON order_products.product_id = products.id
INNER JOIN categories ON products.category_id = categories.id; 