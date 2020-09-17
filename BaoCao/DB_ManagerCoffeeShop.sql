CREATE DATABASE DB_ManagerCoffeeShop
USE DB_ManagerCoffeeShop;
GO



select @@Servername

SET DATEFORMAT dmy;  

create table account(
	id_user varchar(5) not null primary key,
	password_user varchar(50) not null
)

create table staff (
	id_staff varchar(50) not null primary key,
	staff_Name nvarchar(50) not null,
	birthday date,
	id_sex varchar(1) not null
)

create table sex (
	id_sex varchar(1) not null primary key,
	sex_name bit 
)

create table position(
	id_position varchar(5) not null primary key,
	position_name nvarchar(50) not null
)

create table size_glass(
	id_size_glass varchar(5) not null primary key,
	size_glass nvarchar(5) not null
)

create table unit(
 id_unit varchar(5) not null primary key,
 unit_name nvarchar(10) not null
)

create table product(
	id_product varchar(50) not null primary key,
	product_name nvarchar(50) not null unique
)

create table material(
	id_material varchar(50) not null primary key,
	material_name nvarchar(50) not null unique,
)

create table supplier(
	id_supplier varchar(50) not null primary key,
	supplier nvarchar(50) not null unique
)


create table menu(
	id_menu varchar(50) not null primary key,
	id_product varchar(50) not null,
	id_size_glass varchar(5) not null,
	sale int not null default(0),
	price int not null
)


create table bill_detail(
	id_staff varchar(50) not null,
	id_menu varchar(50) not null,
	amount int not null,
	date_export datetime not null,
	bill float not null,
	primary key(id_staff,id_menu,amount,date_export)
)





create table bill_import(
	id_user varchar(5) not null,
	id_supplier varchar(50) not null,
	id_material varchar(50) not null,
	id_unit varchar(5) not null,
	date_import datetime not null,
	amount int not null,
	price int not null,
	primary key (id_user,id_supplier,id_material,id_unit,date_import)
)

create table staff_info(
	id_staff varchar(50) not null,
	id_position varchar(5) not null,
	id_user varchar(5) not null,
	primary key(id_staff,id_position,id_user)
)

/*create foreign key table staff*/

alter table staff
add foreign key (id_sex) references sex(id_sex)

/*create foreign key table menu*/

alter table menu
add foreign key (id_product) references product(id_product),
	foreign key (id_size_glass) references size_glass(id_size_glass)

/*create foreign key table bill_detail*/

alter table bill_detail
add foreign key (id_staff) references staff(id_staff),
	foreign key (id_menu) references menu(id_menu)


/*create foreign key table bill_import*/
alter table bill_import
add foreign key (id_user) references account(id_user),
	foreign key (id_supplier) references supplier(id_supplier),
	foreign key (id_material) references material(id_material),
	foreign key (id_unit) references unit(id_unit)

/*create foreign key table staff_info*/
alter table staff_info
add foreign key (id_staff) references staff(id_staff),
	foreign key (id_position) references position(id_position),
	foreign key (id_user) references account(id_user)

select @@SERVERNAME

--insert tables
insert into sex
values	('M',1),
		('W',0)

insert into staff values ('hieu',N'Hiếu','2000/02/29','M')

insert into position
values	('QL',N'Quản Lý')


insert into account values ('admin','1');

insert into staff_info
values	('hieu','QL','admin')

insert into unit 
values ('chai',N'Chai'),
		('bich',N'Bịch')

		
insert into size_glass 
values	('L',N'Lớn'),
		('M',N'Nhỏ')



select * from bill_import
SELECT * FROM sys.dm_exec_sessions
order by login_time desc

SELECT t.[text], s.last_execution_time
FROM sys.dm_exec_cached_plans AS p
INNER JOIN sys.dm_exec_query_stats AS s
      ON p.plan_handle = s.plan_handle
CROSS APPLY sys.dm_exec_sql_text(p.plan_handle) AS t
WHERE t.[text] LIKE N'%seat%'
ORDER BY s.last_execution_time DESC;


select price from menu where  id_product and id_size_glass

select * from staff,staff_info where staff.id_staff=staff_info.id_staff 
select count(*) from account where id_user='admin' and password_user='12' or 1=1
select * from product 
select * from material
select * from supplier
select * from size_glass
select * from account
select * from staff_info
select * from staff
select * from sex
select *  from bill_detail

delete from bill_detail

select product.product_name,id_size_glass, SUM(amount),SUM(bill) from bill_detail,product,menu where bill_detail.id_menu=menu.id_menu and menu.id_product=product.id_product  and date_export between '2020/08/01' and '2020-08-30' group by product.product_name,id_size_glass

select * from menu inner join product on menu.id_product=product.id_product 
select * from menu

select * from menu where id_product='cafe_a5a08'

delete from staff where id_staff = 'asd_47098'


select product_name,count(id_size_glass) as 'amount' from menu
inner join product 
on menu.id_product=product.id_product
where product_name=N'Trà Sữa'
group by product_name

--produce
create proc LoginUser @username nvarchar(100),@password nvarchar(100)
as
begin
	select count(*) from account where id_user=@username and password_user=@password
end


create proc GetSize @product nvarchar(254),@size nvarchar(5)
as
begin 
	declare @count int
	select count(id_size_glass) as 'amount' from menu
				inner join product 
				on menu.id_product=product.id_product
				where product.id_product=@product  and id_size_glass= @size
				group by product_name
end

	

 create proc GetProduct @product nvarchar(254)
 as
 begin
	declare @count int
	set @count= (select count(id_size_glass) as 'amount' from menu
				inner join product 
				on menu.id_product=product.id_product
				where product_name=@product  and id_size_glass= @size
				group by product_name)
end



