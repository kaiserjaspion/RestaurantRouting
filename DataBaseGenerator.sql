if not exists (select * from sys.databases where name = 'DbKitchenQueue')
	begin 
		Create Database DbKitchenQueue;
	end
else
	begin
		use DbKitchenQueue;
	end
go

IF NOT EXISTS (SELECT * FROM sys.syslogins WHERE name = 'KitchenOrder')
	BEGIN
		CREATE login KitchenOrder with Password = 'bptrtor21'
	END;
GO

if not exists(select * from sys.tables where name = 'Area')
	begin
		Create Table Area (
			IdArea bigint primary key clustered identity,
			AreaName varchar(50) not null,
			AreaQueue varchar(50) not null,
			IsActive bit not null default 1,
			DtCreated DateTime not null default getdate(),
			CreatedBy varchar(150) not null default 'Bruno Pires'
		);
	end
go

if not exists(select * from sys.tables where name = 'FoodType')
	begin
		Create Table FoodType (
			IdFood bigint primary key clustered identity,
			FoodName varchar(50) not null,
			IsActive bit not null default 1,
			DtCreated DateTime not null default getdate(),
			CreatedBy varchar(150) not null default 'Bruno Pires'
		);
	end
go

if not exists(select * from sys.tables where name = 'Menu')
	begin
		Create Table Menu (
			IdMenu bigint primary key clustered identity,
			MenuName varchar(50) not null,
			MenuFoodType bigint not null,
			MenuAreaType bigint not null,
			IsActive bit not null default 1,
			DtCreated DateTime not null default getdate(),
			CreatedBy varchar(150) not null default 'Bruno Pires'
		);
		Alter table Menu add CONSTRAINT MenuArea FOREIGN KEY (MenuAreaType) references Area(IdArea)
		Alter table Menu add CONSTRAINT MenuFoodType FOREIGN KEY (MenuFoodType) references FoodType(IdFood)
	end
go

if not exists(select * from sys.tables where name = 'Ingredient')
	begin
		Create Table Ingredient (
			IdIngredient bigint primary key clustered identity,
			IngredientName varchar(50) not null,
			IsActive bit not null default 1,
			DtCreated DateTime not null default getdate(),
			CreatedBy varchar(150) not null default 'Bruno Pires'
		);
		
	end
go

if not Exists (select * from sys.tables where name = 'MenuIngredient')
	begin
		Create table MenuIngredient(
			IdMenuIngredient bigint primary key clustered identity,
			IdIngredient bigint not null,
			IdMenu bigint not null,
			IngredientQuantity decimal(17,3) not null,
			IsActive bit not null default 1,
			DtCreated DateTime not null default getdate(),
			CreatedBy varchar(150) not null default 'Bruno Pires'
		);
		Alter table MenuIngredient add CONSTRAINT IngredientMenu FOREIGN KEY (IdMenu) references Menu(IdMenu)
		Alter table MenuIngredient add CONSTRAINT MenuIngredient FOREIGN KEY (IdIngredient) references Ingredient(IdIngredient)
	end
go

if exists(select * from sys.tables where name = 'Area')
	begin
		insert into Area(AreaName,AreaQueue) values 
									('Fries','FriesQueue')
									,('Grill','GrillQueue')
									,('Salad','SaladQueue')
									,('Drink','DrinkQueue')
									,('Desert','DesertQueue');
	end
go


if exists(select * from sys.tables where name = 'FoodType')
	begin
		insert into FoodType(FoodName) values 
									('Main Course')
									,('Pizza')
									,('Cocktail')
									,('IceCream')
									,('Salad')
									,('sandwich')
									,('food entrees')
									,('food portion')
									,('Cake');
	end
go

if  exists(select * from sys.tables where name = 'Menu')
	begin
		insert into Menu(MenuName,MenuFoodType,MenuAreaType)
			values ('French Fries',7,1),
			('T-Bone Steak',1,2),
			('Caesar Salad',5,3),
			('Chocolate Ice Cream',4,5),
			('Cheese Balls',8,1),
			('Mozzaarella',2,2),
			('Brownie',9,5),
			('Mojito',3,4);
	end
go

if  exists(select * from sys.tables where name = 'Ingredient')
	begin
		insert into Ingredient(IngredientName)
			values ('potatoes'),
				('Salt'),
				('Butter'),
				('Lettuce'),
				('Tomatoes'),
				('Onions'),
				('Bread'),
				('Rice'),
				('Chicken'),
				('Garlic'),
				('Lemon'),
				('Milk'),
				('Milk Cream'),
				('Chocolate Powder'),
				('Mozzarella'),
				('All purpose flour'),
				('Tomatoes sauce'),
				('Tequila'),
				('Mint'),
				('Sugar'),
				('Ice'),
				('White Rum'),
				('Sparkling water'),
				('T-Bone');
	end
go

if  exists(select * from sys.tables where name = 'MenuIngredient')
	begin
		insert into MenuIngredient(IdMenu,IdIngredient,IngredientQuantity)
			values (1,1,0.600),
			(1,2,0.006),
			(2,24,0.600),
			(2,2,0.030),
			(2,3,0.200),
			(2,8,0.400),
			(3,4,0.250),
			(3,2,0.006),
			(3,9,0.200),
			(3,10,1),
			(3,11,1),
			(3,7,0.200),
			(4,12,0.200),
			(4,13,0.200),
			(4,14,0.100),
			(5,15,0.150),
			(5,16,0.200),
			(5,12,0.500),
			(6,15,0.500),
			(6,16,0.500),
			(6,12,0.200),
			(6,17,0.400),
			(7,3,0.200),
			(7,12,0.200),
			(7,14,0.150),
			(7,16,0.150),
			(7,20,0.150),
			(8,19,1),
			(8,11,1),
			(8,20,0.200),
			(8,21,3),
			(8,22,0.150),
			(8,23,0.300);

	end
go
