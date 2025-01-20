# E Commerce Database Schema
The schema of the Database is represented as an E-R (Entity Relationship) Diagram.
The diagram has been described below.
<img src = "./images/DataBase Schema.png">

## Tables in the Schema
The schema includes some tables such as : 
1. customers : This table stores the details of the customers the entities available in this table are : 
    - id : This is the primary key. This is `INT PRIMARY KEY AUTO_INCREMENT`.
    - first_name : This stores the first name of the customer This is of type `VARCHAR(50) NOT NULL`.
    - last_name : This stores the last name of the customer This is of type `VARCHAR(50) NOT NULL`.
    - email : This entity stores the email id of the customer.
    This type is `VARCHAR(255) UNIQUE NOT NULL`.
    - password : This field stores the password of the user which shoould be hashed earlier before storing it to the database. The type is `VARCHAR(50) NOT NULL`.
2. categories : This table stores the categories of the products.The entities of the categories table are : 
    - id : It is the primary key which store unique id's of the categories. The type is `INT PRIMARY KEY AUTO_INCREMENT`
    - name : It defines the name of the category which should be unique. The type is `VARCHAR(50) NOT NULL UNIQUE`.
3. products : This table sorts all the products available. The entities of this table are : 
    - id : The id stores the unique value given to each product.
    The type is `INT PRIMARY KEY AUTO_INCREMENT`.
    - name : This entity stores the name of the product. The type is `VARCHAR(50) UNIQUE NOT NULL`.
    - price : This entity stores the price of the product. The type is `DECIMAL(10, 3) NOT NULL`.
    - category_id : This is the `FOREIGN KEY` referencing to category table's id. The type is `INT NOT NULL`.
    - rating : This stores the rating of the product in the range of 0 - 5. The type is `INT NOT NULL`. 
4. orders : This table stores the orders made by the customer. The entities of this table are : 
    - id : This id the primary key to store orders uniquely. The type is `INT PRIMARY KEY AUTO_INCREMENT`.
    - total_amount : This field stores the total amount of the order. The type is `DECIMAL(13, 3) NOT NULL`.
    - order_date : This field stores the order date when the order was made. The type is `DATE NOT NULL`.
    - customer_id : This field is `FOREIGN KEY` referencing customer table's id. The type is `INT NOT NULL`.
    - status : This entity stores the status of the order based on pending/delivered. The type is `VARCHAR(10) DEFAULT 'pending'`.
5. order_products : This table stores the products of particular order. The entities of the table are : 
    - order_id : This entity is the `FOREIGN KEY` referencing to order tables's id. The type is `INT NOT NULL`.
    - product_id : This entity is the `FOREIGN KEY` referencing to product table's id. The type is `INT NOT NULL`.
    - quantity : This entity stores the quantity of the product. The type is `INT NOT NULL`.
    - amount : This entity stores the amount of the product as `quantity * price of the product`. The type is ` DECIMAL(10, 3) NOT NULL`.
These are the tables present in the database Now lets have a look at the queries to create the database and perform some operations on the data and tables.
## Queries
### Creating the database and tables
To replicate schema we need to run Schema.sql it will create the complete schema.
```bash
    mysql -u [username] -p
    Enter Password : [your password here]
    source Schema.sql
```
The Schema.sql consist of the code to create all the tables required in the database.
The name of the database is `e_commerce_website`.

The output of the Schema.sql
<img src = "./images/Schema.png">

### Inserting data to tables

First we will insert the customers in the customers table.
```bash
    source InsertCustomers.sql
```

The output of this query will be 
<img src = "./images/InsertCustomers.png">

Then we will insert the categories and products by
```bash
    source InsertCategories.sql
    source InsertProducts.sql
```
This will give us output as 
<img src = "./images/InsertCategories.png">

Then to generate orders we will run the InsertOrders.sql file as
```bash
    source InsertOrders.sql
```
This will give us output as
<img src = "./images/InsertOrders.png">

Now we are completed with populating tables with data.

### Updating Customer & Order Information
We can update customer and Order information by running these files
UpdateCustomer.sql and UpdateOrder.sql
The UpdateCustomer.sql changes the password of the customer and UpdateOrder.sql changes the status of the order to delivered.
To run these files write these commands
```bash
    source UpdateCustomer.sql
    source UpdateOrder.sql
```
The output is 
<img src = "./images/UpdateCustomers.png">

### Retreiving Order information and Product and Customer details

To get order information along with customer and product details we use ShowOrders.sql
```bash
    source ShowOrders.sql
```
The output of the query is 
<img src = "./images.ShowOrders.png">

To get products we can use file ShowProducts.sql

```bash
    source ShowProducts.sql
```
The output is 
<img src = "./images/ShowProducts.png">
### Getting Revennue for Specific time

To get revennue of specific time we can use the GetRevennue.sql file.

```bash
    source GetRevennue.sql
```
The output is 
<img src = "./images/GetRevennue.png">

### Customer With Multiple Orders
To do this first we need to insert a duplicate order for the user and then run the file CustomerWithMultipleOrders.sql
```bash
    INSERT INTO orders (total_amount, order_date, customer_id)
    VALUES
    (260.68, CURDATE(), 3);
    INSERT INTO order_products (order_id, product_id, quantity, amount)
    VALUES
    (3, 1, 2, 260.68);
    source CustomerWithMultipleOrders.sql
```
The output is 
<img src = "./images/CustomerWithMultipleOrders.png">

### Deleting Product and Customers
To delete customer we have to use DeleteCustomer.sql
```bash
    source DeleteCustomer.sql
```
The output is 
<img src = "./images/DeleteCustomer.png">

To delete product we can use the DeleteProduct.sql file

```bash
    source DeleteProduct.sql
```
The output is 
<img src = "./images/DeleteProduct.png">

## Indexing 
Indexes help speed up search operations by allowing MySQL to locate the rows more quickly, reducing the time it takes to search through large amounts of data.

The Indexing makes searching of the data easier but can affect insertion updation and deletion of the data as complete indexing is changed.

We can create index on some tables such as
```sql
    CREATE INDEX idx_customer_id ON orders (customer_id);
``` 
This will help to fetch orders based on the customers easily.
```sql
    CREATE INDEX idx_order_date ON orders (order_date);
```
This will help to access orders by date very easily.

This is all about the E commerce database schema.