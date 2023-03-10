create database [InternetKafeSamoilov493]
go

use [InternetKafeSamoilov493]
go


Create table Category
(
CategoryID int PRIMARY KEY IDENTITY,
CategoryName nvarchar(40) not null
)
go

Create table [Product]
(
ProductID int Primary key identity,
ProductCategory int foreign key references Category(CategoryID) not null,
ProductName nvarchar(100) not null,
ProductIngredients nvarchar(max) not null,
ProductCost decimal(19,4) not null, --цена 4 знака после запятой максимум
)
go

Create table [Role]
(
RoleID int not null Primary key IDENTITY,
RoleName nvarchar(30) not null
)
go

Create table [User]
(
UserID int Primary Key IDENTITY,
UserRole int  Foreign key references [Role](RoleID) not null,
UserName nvarchar(30) not null,
UserSureName nvarchar(30) not null,
UserLogin nvarchar(50) unique not null,
UserPassword nvarchar(50) not null
)
go


Insert Into Category values('Напитки')
go
Insert Into Category values('Горячее')
go


Insert Into [Role] values ('Клиент')
go
Insert Into [Role] values ('Администратор')
go


Insert Into Product values (2,'Макароны по флотски','Спагетти, мясо',300)
go
Insert Into Product values(2, 'Пицца Пепперони','Тесто, колбаса, сыр',550)
go
Insert Into Product values(1, 'Чай','Вода, чай',100)
go

Insert Into [User] Values(2,'Дмитрий','Самойлов','dimalogin','dimapassword')
go
Insert Into [User] Values(1, 'Вася','Сидоров','vasya123','vasya221')
go

--SELECT u.*, r.RoleName fROM [User] as u, [Role] as r WHERE UserLogin='' And UserPassword='' and r.RoleID = u.UserRole
--SELECT p.*, c.CategoryName from [Product] as p, category as c where p.ProductCategory = c.CategoryID
--UPDATE [Product] set [ProductCost] = where ProductID = 

--drop database [InternetKafeSamoilov493]