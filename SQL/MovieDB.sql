----Ex1
--CREATE TABLE [dbo].[Customers] (
--    [Id]              INT            IDENTITY (1, 1) NOT NULL,
--    [Firstname]       NVARCHAR (100) NOT NULL,
--    [Lastname]        NVARCHAR (100) NOT NULL,
--    [BillingAddress]  NVARCHAR (150) NOT NULL,
--    [BillingZip]      NVARCHAR (50)  NOT NULL,
--    [BillingCity]     NVARCHAR (100) NOT NULL,
--    [DeliveryAddress] NVARCHAR (150) NOT NULL,
--    [DeliveryZip]     NVARCHAR (50)  NOT NULL,
--    [DeliveryCity]    NVARCHAR (100) NOT NULL,
--    [EmailAddress]    NVARCHAR (150) NOT NULL,
--    [PhoneNo]         NVARCHAR (50)  NOT NULL,
--    PRIMARY KEY CLUSTERED ([Id] ASC)
--);

--CREATE TABLE [dbo].[Movies] (
--    [Id]          INT            IDENTITY (1, 1) NOT NULL,
--    [Title]       NVARCHAR (255) NOT NULL,
--    [Director]    NVARCHAR (100) NOT NULL,
--    [ReleaseYear] DATE           NOT NULL,
--    [Price]       MONEY          NOT NULL,
--    PRIMARY KEY CLUSTERED ([Id] ASC)
--);

--CREATE TABLE [dbo].[Orders] (
--    [Id]         INT  IDENTITY (1, 1) NOT NULL,
--    [OrderDate]  DATE NOT NULL,
--    [CustomerId] INT  NOT NULL,
--    PRIMARY KEY CLUSTERED ([Id] ASC),
--    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id])
--);

--CREATE TABLE [dbo].[OrderRows] (
--    [Id]      INT   IDENTITY (1, 1) NOT NULL,
--    [OrderId] INT   NOT NULL,
--    [MovieId] INT   NOT NULL,
--    [Price]   MONEY NOT NULL,
--    PRIMARY KEY CLUSTERED ([Id] ASC),
--    FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movies] ([Id]),
--    FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id])
--);


----Ex2

--INSERT INTO Customers 
--VALUES('Jonas', 'Gray', '23 Green Corner Street', '56743', 'Birmingham', '23 Green Corner Street', '56743', 'Birmingham', 'jonas.gray@hotmail.com', '0708123456'),
--('Jane', 'Harolds', '10 West Street', '48213', 'London', '10 West Street', '48213', 'London', 'Jane_h77@gmail.com', '0701245512'),
--('Peter', 'Birro', '12 Fox Street', '45561', 'New York', '89 Moose Plaza', '45321', 'Seattle', 'peter_the_great@hotmail.com', '0739484322')

--INSERT INTO Movies
--VALUES('Interstellar', 'Christoper Nolan', '2014', 179),
--('Hobbit: Battle of the five armies', 'Peter Jackson', '2014', 179),
--('The Wolf of Wall Street', 'Martin Scorcese', '2013', 119),
--('Pulp Fiction', 'Quentin Tarantino', '1994', 49)

----Ex3
--INSERT INTO Orders
--VALUES('2015-01-01', (SELECT Id FROM Customers WHERE Firstname = 'Jonas' AND Lastname = 'Gray'))

--INSERT INTO OrderRows
--VALUES(
--    (SELECT TOP(1) Id FROM Orders ORDER BY Id DESC), 
--    (SELECT id From Movies WHERE Title LIKE '%Inter%'), 
--    (SELECT price FROM Movies WHERE Title LIKE '%Inter%')
--),(
--    (SELECT TOP(1) Id FROM Orders ORDER BY Id DESC),
--    (SELECT id From Movies WHERE Title LIKE '%Pulp%'),
--    (SELECT price FROM Movies WHERE Title LIKE '%Pulp%')
--)

--INSERT INTO Orders
--VALUES('2015-01-15', (SELECT Id FROM Customers WHERE Firstname = 'Peter' AND Lastname = 'Birro'))

--INSERT INTO OrderRows
--VALUES(
--    (SELECT TOP(1) Id FROM Orders ORDER BY Id DESC), 
--    (SELECT id From Movies WHERE Title LIKE '%Wolf%'), 
--    (SELECT price FROM Movies WHERE Title LIKE '%Wolf%')
--),(
--    (SELECT TOP(1) Id FROM Orders ORDER BY Id DESC),
--    (SELECT id From Movies WHERE Title LIKE '%Wolf%'),
--    (SELECT price FROM Movies WHERE Title LIKE '%Wolf%')
--)

--INSERT INTO Orders
--VALUES('2014-12-20', (SELECT Id FROM Customers WHERE Firstname = 'Jonas' AND Lastname = 'Gray'))

--INSERT INTO OrderRows
--VALUES(
--    (SELECT TOP(1) Id FROM Orders ORDER BY Id DESC), 
--    (SELECT id From Movies WHERE Title LIKE '%Wolf%'), 
--    (SELECT price FROM Movies WHERE Title LIKE '%Wolf%')
--)


----Ex4
--UPDATE Movies SET price = 169 WHERE ReleaseYear = '2014';
--SELECT price FROM Movies WHERE ReleaseYear = '2014';


----Ex5
--SELECT Firstname, Lastname, PhoneNo, EmailAddress FROM Customers

--SELECT * FROM Movies ORDER BY ReleaseYear DESC

--SELECT Title, Price FROM Movies ORDER BY Price

----I seem to have overcomplicated this one;
--SELECT Firstname, Lastname, DeliveryAddress, DeliveryZip, DeliveryCity 
--FROM Customers WHERE Id IN (SELECT Orders.CustomerId 
--FROM Orders WHERE Orders.Id IN (SELECT OrderRows.OrderId 
--FROM OrderRows WHERE MovieId IN (SELECT Movies.Id 
--FROM Movies WHERE Title LIKE '%Wolf%')))

----Revised version
--SELECT DISTINCT Firstname, Lastname, DeliveryAddress, DeliveryZip, DeliveryCity
--FROM Customers c
--JOIN Orders o On c.Id = o.CustomerId 
--JOIN OrderRows orows On o.Id = orows.OrderId
--JOIN Movies m On orows.MovieId = m.Id
--WHERE m.Title Like '%Wolf%'

--SELECT o.Id, o.OrderDate, c.Firstname, c.Lastname, SUM(orows.Price) AS Total 
--FROM OrderRows orows
--JOIN Orders o ON orows.OrderId = o.Id
--JOIN Customers c ON o.CustomerId = c.Id
--GROUP BY o.Id, o.OrderDate, c.Firstname, c.Lastname

----Optional;
--SELECT c.Firstname, c.Lastname, COUNT(DISTINCT m.Id) AS Bought, COUNT(DISTINCT o.Id) AS Orders, SUM(orows.Price) AS Total
--FROM Customers c
--JOIN Orders o On c.Id = o.CustomerId 
--JOIN OrderRows orows On o.Id = orows.OrderId
--JOIN Movies m On orows.MovieId = m.Id
--GROUP BY c.Firstname, c.Lastname

--SELECT COUNT(DISTINCT o.Id) AS Orders, SUM(orows.Price) AS Total
--FROM OrderRows orows
--JOIN Orders o On orows.OrderId = o.Id

----Ex6
--ALTER TABLE Customers
--ADD CellNo nvarchar(50)

--UPDATE Customers
--SET CellNo = PhoneNo

--UPDATE Customers
--SET PhoneNo = ''

