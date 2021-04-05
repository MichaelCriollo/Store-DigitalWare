
Use STORE 

SET IDENTITY_INSERT [TypeProduct] ON
	INSERT INTO [TypeProduct] (IdTypeProduct, [Name]) VALUES (1, N'Pantalon')
	INSERT INTO [TypeProduct] (IdTypeProduct, [Name]) VALUES (2, N'Chaqueta')
	INSERT INTO [TypeProduct] (IdTypeProduct, [Name]) VALUES (3, N'Camiseta')
SET IDENTITY_INSERT [TypeProduct] OFF

SET IDENTITY_INSERT Gender ON
	INSERT INTO Gender (IdGender, [Name]) VALUES (1, N'Masculino')
	INSERT INTO Gender (IdGender, [Name]) VALUES (2, N'Femenino')
SET IDENTITY_INSERT Gender OFF

SET IDENTITY_INSERT [State] ON
	INSERT INTO [State] (IdState, [Name]) VALUES (1, N'Activo')
	INSERT INTO [State] (IdState, [Name]) VALUES (2, N'Inactivo')
SET IDENTITY_INSERT [State] OFF

SET IDENTITY_INSERT Size ON
	INSERT INTO Size (IdSize, [Name]) VALUES (1, N'6')
	INSERT INTO Size (IdSize, [Name]) VALUES (2, N'8')
	INSERT INTO Size (IdSize, [Name]) VALUES (3, N'10')
	INSERT INTO Size (IdSize, [Name]) VALUES (4, N'12')
	INSERT INTO Size (IdSize, [Name]) VALUES (5, N'14')
	INSERT INTO Size (IdSize, [Name]) VALUES (6, N'16')
	INSERT INTO Size (IdSize, [Name]) VALUES (7, N'28')
	INSERT INTO Size (IdSize, [Name]) VALUES (8, N'30')
	INSERT INTO Size (IdSize, [Name]) VALUES (9, N'32')
	INSERT INTO Size (IdSize, [Name]) VALUES (10, N'34')
	INSERT INTO Size (IdSize, [Name]) VALUES (11, N'36')
	INSERT INTO Size (IdSize, [Name]) VALUES (12, N'XS')
	INSERT INTO Size (IdSize, [Name]) VALUES (13, N'S')
	INSERT INTO Size (IdSize, [Name]) VALUES (14, N'M')
	INSERT INTO Size (IdSize, [Name]) VALUES (15, N'L')
	INSERT INTO Size (IdSize, [Name]) VALUES (16, N'XL')
	INSERT INTO Size (IdSize, [Name]) VALUES (17, N'XXL')
SET IDENTITY_INSERT Size OFF

SET IDENTITY_INSERT Color ON
	INSERT INTO Color (IdColor, [Name]) VALUES (1, N'Blanco')
	INSERT INTO Color (IdColor, [Name]) VALUES (2, N'Negro')
	INSERT INTO Color (IdColor, [Name]) VALUES (3, N'Cafe')
	INSERT INTO Color (IdColor, [Name]) VALUES (4, N'Rosado')
	INSERT INTO Color (IdColor, [Name]) VALUES (5, N'Azul')
	INSERT INTO Color (IdColor, [Name]) VALUES (6, N'Amarillo')
	INSERT INTO Color (IdColor, [Name]) VALUES (7, N'Rojo')
	INSERT INTO Color (IdColor, [Name]) VALUES (8, N'Naranja')
	INSERT INTO Color (IdColor, [Name]) VALUES (9, N'Verde')
SET IDENTITY_INSERT Color OFF

SET IDENTITY_INSERT SizeTypeProduct ON
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (1, 1, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (2, 2, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (3, 3, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (4, 4, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (5, 5, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (6, 6, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (7, 7, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (8, 8, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (9, 9, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (10, 10, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (11, 11, 1)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (12, 12, 2)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (13, 13, 2)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (14, 14, 2)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (15, 15, 2)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (16, 16, 2)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (17, 17, 2)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (18, 12, 3)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (19, 13, 3)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (20, 14, 3)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (21, 15, 3)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (22, 16, 3)
	INSERT INTO SizeTypeProduct (IdSizeTypeProduct, IdSize, IdTypeProduct) VALUES (23, 17, 3)
SET IDENTITY_INSERT SizeTypeProduct OFF

SET IDENTITY_INSERT Client ON
	INSERT INTO Client (IdClient, FirstName, LastName, MobilePhone, Email, BirthdayDate, DateCreate, DateEdit) VALUES (1, 'Michael', 'Criollo', '3202926274', 'alejo9851@gmail.com', '1998-12-21', GETDATE(), null)
	INSERT INTO Client (IdClient, FirstName, LastName, MobilePhone, Email, BirthdayDate, DateCreate, DateEdit) VALUES (2, 'Eugenio', 'Rueda', '3202926274', 'eugenio@yopmail.com', '1970-06-15', GETDATE(), null)
SET IDENTITY_INSERT Client OFF

SET IDENTITY_INSERT Bill ON
	INSERT INTO Bill (IdBill, IdClient, TotalPrice, DateCreate, DateEdit) VALUES (1, 1, 999999, GETDATE(), NULL)
	INSERT INTO Bill (IdBill, IdClient, TotalPrice, DateCreate, DateEdit) VALUES (2, 2, 123456789, '2000-02-06', NULL)
	INSERT INTO Bill (IdBill, IdClient, TotalPrice, DateCreate, DateEdit) VALUES (3, 2, 1234567890, '2000-04-20', NULL)
SET IDENTITY_INSERT BILL OFF

SET IDENTITY_INSERT Product ON
	INSERT INTO Product (IdProduct, IdTypeProduct, IdState, IdColor, IdGender, Reference, [Name], PriceUnit, Quantity, DateCreate, DateEdit) VALUES (1,1,1,1,1,'AAA1', 'Producto 1', 10000, 10, GETDATE(), null)
	INSERT INTO Product (IdProduct, IdTypeProduct, IdState, IdColor, IdGender, Reference, [Name], PriceUnit, Quantity, DateCreate, DateEdit) VALUES (2,2,1,1,1,'AAA2', 'Producto 2', 20000, 20, GETDATE(), null)
	INSERT INTO Product (IdProduct, IdTypeProduct, IdState, IdColor, IdGender, Reference, [Name], PriceUnit, Quantity, DateCreate, DateEdit) VALUES (3,3,1,1,1,'AAA3', 'Producto 3', 30000, 5, GETDATE(), null)
SET IDENTITY_INSERT Product OFF

SET IDENTITY_INSERT DetailBill ON
	INSERT INTO DetailBill (IdDetailBill, IdBill, IdProduct, Quantity, Price, DateCreate, DateEdit) VALUES (1, 2, 1, 5, 50000, '2000-02-06', null)
	INSERT INTO DetailBill (IdDetailBill, IdBill, IdProduct, Quantity, Price, DateCreate, DateEdit) VALUES (2, 2, 1, 5, 50000, '2000-02-06', null)
SET IDENTITY_INSERT DetailBill OFF