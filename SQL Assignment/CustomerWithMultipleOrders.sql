SELECT customers.first_name, customers.last_name FROM customers
INNER JOIN orders ON orders.customer_id = customers.id
GROUP BY orders.customer_id
HAVING count(orders.customer_id) > 1;