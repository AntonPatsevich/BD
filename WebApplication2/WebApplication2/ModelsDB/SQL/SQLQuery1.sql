create table lots_type--type
(
id int not null identity(1,1) primary key, 
Type_Def nvarchar(200) not null,
)
create table district--район
(
id int not null identity(1,1) primary key,
district_def nvarchar (200),
)

create table street--улица
(
id int not null identity(1,1) primary key,
street_def nvarchar (200),
district_id int,
foreign key (district_id) references district(id)
)

--create table positions
--(
--id int not null identity(1,1) primary key,
--position nvarchar(50) not null
--)
--go

--create table employer(
--id int not null identity(1,1) primary key,
--FIO nvarchar(50) not null,
--position_id int not null
--foreign key (position_id ) references positions(id)
--)
--go
--create table customer(
--id int not null identity(1,1) primary key,
--FIO nvarchar(50) not null,
--email nvarchar(40) not null,
--passwords nvarchar (8)
--)
--go

create table lot --товар
(
id int not null identity(1,1) primary key,
name_lot nvarchar(200) not null, 
Descriptionn nvarchar(150) not null, 
price money not null,
area decimal,
typeid int,
likes int not null,
street_id int,
number_house int not null,
number_flat int null,
count_rooms int null,
foreign key (typeid) references lots_type(id),
foreign key (street_id) references street(id)
)

go
create table orderus--заказ
(
id int not null identity(1,1) primary key,
lot_id int,
employer_id NVARCHAR(128),
customer_id NVARCHAR(128),
date_selling date not null,
foreign key (lot_id) references lot(id),
foreign key (employer_id) references AspNetUsers(Id),
foreign key (customer_id) references AspNetUsers(Id)
)
go
insert lots_type values (N'Жилой дом')
insert lots_type values (N'Квартира')
insert lots_type values (N'Офис')
insert lots_type values (N'Складское помещение')

insert into lot (name_lot,Descriptionn,price,area,typeid,likes,street_id,number_house,number_flat,count_rooms) values ('Название', 'Описание',2000,23,2,4,2,8,4,3)
insert into lot (name_lot,Descriptionn,price,area,typeid,likes,street_id,number_house,number_flat,count_rooms) values ('Название1', 'Описание1',2002,23,2,4,2,8,4,5)

insert district values (N'Московский')
insert district values (N'Заводской')
insert district values (N'Фрунзенский')

insert street values (N'Красная',4)
insert street values (N'Белецкого',5)
insert street values (N'Колесникова',6)




 