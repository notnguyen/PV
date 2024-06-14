create database nguyen4;
use nguyen4;

CREATE TABLE Address (
    id INT PRIMARY KEY IDENTITY(1,1),
    street VARCHAR(255) NOT NULL,
    houseNumber INT NOT NULL,
    city VARCHAR(100) NOT NULL,
    postalCode VARCHAR(20) NOT NULL,
    state VARCHAR(100) NOT NULL
);

CREATE TABLE Book (
    id INT PRIMARY KEY IDENTITY(1,1),
    title VARCHAR(255) NOT NULL,
    author VARCHAR(100) NOT NULL,
    genre VARCHAR(100),
    pages INT
);

CREATE TABLE Customer (
    id INT PRIMARY KEY IDENTITY(1,1),
    userName VARCHAR(50) NOT NULL,
    password VARCHAR(255) NOT NULL,
    firstName VARCHAR(100) NOT NULL,
    lastName VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    phoneNumber VARCHAR(20)
);

CREATE TABLE Order_ (
    id INT PRIMARY KEY IDENTITY(1,1),
    customerID INT FOREIGN KEY REFERENCES Customer(id),
    supplierID INT FOREIGN KEY REFERENCES Supplier(id),
    addressID INT FOREIGN KEY REFERENCES Address(id),
    orderDate DATE NOT NULL,
    totalPrice DECIMAL(10, 2) NOT NULL,
    totalAmount INT NOT NULL,
    isShipped BIT NOT NULL
);


CREATE TABLE OrderBook (
    id INT PRIMARY KEY IDENTITY(1,1),
    bookID INT FOREIGN KEY REFERENCES Book(id),
    orderID INT FOREIGN KEY REFERENCES Order_(id),
    amount INT NOT NULL,
    price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Supplier (
    id INT PRIMARY KEY IDENTITY(1,1),
    firstName VARCHAR(100) NOT NULL,
    lastName VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    phoneNumber VARCHAR(20)
);

SELECT * FROM Address;
SELECT * FROM Book;
SELECT * FROM Customer;
SELECT * FROM Order_;
SELECT * FROM OrderBook;
SELECT * FROM Supplier;
