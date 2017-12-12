--Ex1

--Ex2

--INSERT INTO Customers 
--VALUES('Jonas', 'Gray', '23 Green Corner Street', '56743', 'Birmingham', '23 Green Corner Street', '56743', 'Birmingham', 'jonas.gray@hotmail.com', '0708123456'),
--('Jane', 'Harolds', '10 West Street', '48213', 'London', '10 West Street', '48213', 'London', 'Jane_h77@gmail.com', '0701245512'),
--('Peter', 'Birro', '12 Fox Street', '45561', 'New York', '89 Moose Plaza', '45321', 'Seattle', 'peter_the_great@hotmail.com', '0739484322')

--INSERT INTO Movies
--VALUES('Interstellar', 'Christoper Nolan', '2014', 179),
--('Hobbit: Battle of the five armies', 'Peter Jackson', '2014', 179),
--('The Wolf of Wall Street', 'Martin Scorcese', '2013', 119),
--('Pulp Fiction', 'Quentin Tarantino', '1994', 49)

--Ex3
--INSERT INTO Orders
--VALUES('2015-01-01', (SELECT Id FROM Customers WHERE Firstname = 'Jonas' AND Lastname = 'Gray'))

--INSERT INTO OrderRows
--VALUES(
--	(SELECT TOP(1) Id FROM Orders ORDER BY Id DESC), 
--	(SELECT id From Movies WHERE Title LIKE '%Inter%'), 
--	(SELECT price FROM Movies WHERE Title LIKE '%Inter%')
--),(
--	(SELECT TOP(1) Id FROM Orders ORDER BY Id DESC),
--	(SELECT id From Movies WHERE Title LIKE '%Pulp%'),
--	(SELECT price FROM Movies WHERE Title LIKE '%Pulp%')
--)


--INSERT INTO Orders
--VALUES('2015-01-15', (SELECT Id FROM Customers WHERE Firstname = 'Peter' AND Lastname = 'Birro'))

--INSERT INTO OrderRows
--VALUES(
--	(SELECT TOP(1) Id FROM Orders ORDER BY Id DESC), 
--	(SELECT id From Movies WHERE Title LIKE '%Wolf%'), 
--	(SELECT price FROM Movies WHERE Title LIKE '%Wolf%')
--),(
--	(SELECT TOP(1) Id FROM Orders ORDER BY Id DESC),
--	(SELECT id From Movies WHERE Title LIKE '%Wolf%'),
--	(SELECT price FROM Movies WHERE Title LIKE '%Wolf%')
--)

--INSERT INTO Orders
--VALUES('2014-12-20', (SELECT Id FROM Customers WHERE Firstname = 'Jonas' AND Lastname = 'Gray'))

--SELECT c.Id, c.Firstname, o.Id, o.OrderDate From Customers c
--JOIN Orders o on o.CustomerId=c.Id


--Ex4
--UPDATE Movies SET price = 169 WHERE ReleaseYear = '2014';
--SELECT price FROM Movies WHERE ReleaseYear = '2014';


--Ex5
SELECT Firstname, Lastname, PhoneNo, EmailAddress FROM Customers

SELECT * FROM Movies ORDER BY ReleaseYear DESC

SELECT Title, Price FROM Movies ORDER BY Price

SELECT Firstname, Lastname, DeliveryAddress, DeliveryZip, DeliveryCity 
FROM Customers WHERE Id IN (SELECT Orders.CustomerId 
FROM Orders WHERE Orders.Id IN (SELECT OrderRows.OrderId 
FROM OrderRows WHERE MovieId IN (SELECT Movies.Id 
FROM Movies WHERE Title LIKE '%Wolf%')))
