SELECT * FROM Product

SELECT * FROM Product WHERE Quantity <= 5

SELECT * FROM Bill WHERE Bill.DateCreate BETWEEN '02/01/2000' AND '05/25/2000'

SELECT IdProduct, Sum(Price) AS Total_Producto FROM DetailBill GROUP BY IdProduct

SELECT TOP 2 DATEDIFF(DAY, Min(DateCreate),Max(DateCreate)) AS Cada_x_Dias_Compra FROM Bill 
WHERE IdClient = 2