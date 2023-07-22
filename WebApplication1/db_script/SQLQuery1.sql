create database db_test
use db_test
go
create table ProductAbhay (Productid int primary key, Name varchar(250) not null , Description varchar(250) null, Price float not null, Category varchar(15) not null)

select * from ProductAbhay

insert into ProductAbhay(Productid,Name,Description,Price,Category) values (1,'Oreo','Delisious',10,'biscuit')
insert into ProductAbhay(Productid,Name,Description,Price,Category) values (2,'Parle-G','Yummy',10,'biscuit')
insert into ProductAbhay(Productid,Name,Description,Price,Category) values (3,'Marie Gold','Good Taste',10,'biscuit')
insert into ProductAbhay(Productid,Name,Description,Price,Category) values (4,'Bourbon','Choclaty',10,'biscuit')
insert into ProductAbhay(Productid,Name,Description,Price,Category) values (5,'Jim-Jam','tasty',10,'biscuit')