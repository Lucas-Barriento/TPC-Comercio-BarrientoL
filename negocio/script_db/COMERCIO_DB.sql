USE master
GO
DROP DATABASE IF EXISTS COMERCIO_DB
GO
CREATE DATABASE COMERCIO_DB
GO
USE COMERCIO_DB
GO
--TABLAS

CREATE TABLE DBO.USUARIO
	(ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	USUARIO VARCHAR(30) NOT NULL,
	PASS VARCHAR(30) NOT NULL,
	TIPO INT NOT NULL)

CREATE TABLE DBO.CLIENTE
	(ID INT PRIMARY KEY NOT NULL,
	NOMBRE VARCHAR(30) NOT NULL,
	APELLIDO VARCHAR(30) NOT NULL,
	DOMICILIO VARCHAR(30) NOT NULL,
	LOCALIDAD VARCHAR(30) NOT NULL,
	ESTADO BIT NOT NULL DEFAULT 1)

CREATE TABLE DBO.MARCA
	(ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NOMBRE VARCHAR(30) NOT NULL,
	ESTADO BIT NOT NULL DEFAULT 1)

CREATE TABLE DBO.CATEGORIA
	(ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NOMBRE VARCHAR(30) NOT NULL,
	ESTADO BIT NOT NULL DEFAULT 1)

CREATE TABLE DBO.PROVEEDOR
	(ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NOMBRE VARCHAR(30) NOT NULL,
	DOMICILIO VARCHAR(50) NOT NULL,
	LOCALIDAD VARCHAR(50) NOT NULL,
	EMAIL VARCHAR(50) NOT NULL,
	TELEFONO VARCHAR(20) NOT NULL,
	ESTADO BIT NOT NULL DEFAULT 1)

CREATE TABLE DBO.PRODUCTO
	(ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NOMBRE VARCHAR(50) NOT NULL,
	IDMARCA INT FOREIGN KEY REFERENCES MARCA(ID),
	IDCATEGORIA INT FOREIGN KEY REFERENCES CATEGORIA(ID),
	STOCK INT NOT NULL,
	STOCKMINIMO INT NOT NULL,
	PRECIO MONEY NOT NULL,
	PORCENTAJEGANANCIA DECIMAL(10,2) NOT NULL,
	ESTADO BIT NOT NULL DEFAULT 1)

CREATE TABLE DBO.VENTA
	(ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IDCLIENTE INT NOT NULL FOREIGN KEY REFERENCES CLIENTE(ID),
	FECHAVENTA DATE NOT NULL,
	PRECIOFINAL MONEY NOT NULL)

	CREATE TABLE DBO.DETALLEVENTA
	(ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDPRODUCTO INT NOT NULL FOREIGN KEY REFERENCES PRODUCTO(ID),
	IDVENTA INT NOT NULL FOREIGN KEY REFERENCES VENTA(ID),
	CANTIDAD INT NOT NULL,
	PRECIOPARCIAL MONEY NOT NULL)
	
CREATE TABLE DBO.COMPRA
	(ID INT  PRIMARY KEY NOT NULL IDENTITY(10100001,1),
	IDPROVEEDOR INT FOREIGN KEY REFERENCES PROVEEDOR(ID),
	FECHACOMPRA DATE NOT NULL,
	PRECIOTOTAL MONEY NOT NULL)
	
CREATE TABLE DBO.DETALLECOMPRA
	(ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDPRODUCTO INT NOT NULL FOREIGN KEY REFERENCES PRODUCTO(ID),
	IDCOMPRA INT NOT NULL FOREIGN KEY REFERENCES COMPRA(ID),
	CANTIDAD INT NOT NULL,
	PRECIOPARCIAL MONEY NOT NULL)
	
CREATE TABLE DBO.PROVEEDORES_PRODUCTOS
	(ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDPRODUCTO INT NOT NULL FOREIGN KEY REFERENCES PRODUCTO(ID),
	IDPROVEEDOR INT NOT NULL FOREIGN KEY REFERENCES PROVEEDOR(ID)
	)
go
-- PROCEDIMIENTOS
CREATE PROCEDURE SP_INSERTPROVEEDOR_NUEVOPRODUCTO(@IDPROVEEDOR BIGINT)--despues de agregar un nuevo producto,se agregan los proveedores asociados
AS 
BEGIN
	INSERT INTO PROVEEDORES_PRODUCTOS VALUES((select ident_current('producto')),@IDPROVEEDOR)--ident_current() DEVUELVE EL ULTIMO ID CREADO EN LA TABLA ESPECIFICADA 
END
go
CREATE PROCEDURE SP_ELIMINAR_PROVEEDORESXIDPRODUCTO(@IDPRODUCTO BIGINT)--elimina un proveedor asociado a un producto
AS
BEGIN
	IF EXISTS (SELECT * FROM PROVEEDORES_PRODUCTOS WHERE IDPRODUCTO=@IDPRODUCTO)
	BEGIN
		DELETE FROM PROVEEDORES_PRODUCTOS WHERE IDPRODUCTO=@IDPRODUCTO
	END
END
go
CREATE PROCEDURE SP_AGREGAR_ITEMS_COMPRA(
@IDPRODUCTO BIGINT,@CANTIDAD BIGINT,@PRECIOPARCIAL MONEY)
AS
BEGIN
	insert into DETALLECOMPRA values (@IDPRODUCTO,(select ident_current('COMPRA')),@CANTIDAD,@PRECIOPARCIAL)
END
go
CREATE PROCEDURE SP_AGREGAR_ITEMS_VENTA(
@IDPRODUCTO BIGINT,@CANTIDAD BIGINT,@PRECIOPARCIAL MONEY)
AS
BEGIN
	insert into DETALLEVENTA values (@IDPRODUCTO,(select ident_current('VENTA')),@CANTIDAD,@PRECIOPARCIAL)
END
----------------------------------

--INSERT
	insert into MARCA values ('Samsung','1'),('Topmega','1'),('Acer','1'),('Xiaomi','1'),('Nike','1'),('TopMega',1),('Sony',1),('Motorola',1),('Noblex',1),('Exo',1),('Nivea',1),('Lux',1),('O`Neill',1)
	insert into CATEGORIA values ('Smartphones','1'),('Relojes','1'),('Bicicletas','1'),('Indumentaria','1'),('Farmacia','1'),('Playstation',1),('Parlantes',1),('Notebooks',1),('Gorras',1),('Perfumeria',1),('Televisores',1)
	insert into VENTA values (37763043,GETDATE(),1000)
	insert into PROVEEDOR values ('Multipoint','Calle falsa 123','Benavidez','email@multipoint.com','0111556589593', '1'),('GoldTech','Brandsen 805','La Boca','email@goldtech.com','01113323634', '1')
	insert into PRODUCTO values ('Samsung a12',1,1,1,1,15000,10,1),
				 ('Bicicleta R29 21V',2,3,1,1,70000,5,1),
				 ('Playstation 5',7,6,1,1,120000,10,1),
				 ('Moto Edge 30',8,1,1,1,120000,10,1),
				 ('Xiaomi Smart Band 7',1,1,1,1,20000,15,1),
				 ('Smart TV 4K UHD Samsung 50" UN50AU7000',1,11,1,1,118999,20,1),
				 ('Parlante Bluetooth Noblex MNT720P',9,7,1,1,89999,7,1),
				 ('Notebook Acer Nitro 5',3,1,1,1,240000,15,1),
				 ('Notebook Exo Smart 14,1"',10,8,1,1,89999,9,1),
				 ('Desodorante antitranspirante Nivea Men',11,10,1,1,524.20,3,1),
				 ('Jabon liquido Lux Orquidea X 250ml',12,10,1,1,532,4,1),
				 ('Protector Solar Nivea Sun Protect Kids',11,10,1,1,1400.25,25,1),
				 ('Gorra State O`Neill S23',13,9,1,1,6500,5,1)
	insert into CLIENTE values ('37763043','Lucas','Barriento','La Rioja 431','Pacheco',1),('12131415','Juan','Perez','Calle falsa 123','Pilar',1)
	insert into USUARIO values ('test','test',1),('admin','admin',2)
	insert into PROVEEDORES_PRODUCTOS values (2,1),(2,2),(3,2),(4,1),(5,2),(6,1),(6,2),(7,1),(8,2),(9,1),(9,2),(10,1),(11,1),(12,2),(13,2)

------------------------------
	SELECT CAST('TRUE'AS BIT)--
	