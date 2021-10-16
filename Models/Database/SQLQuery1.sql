create database ReviewWeb
go
use ReviewWeb
go

create table Users (
	ID int IDENTITY(1,1) PRIMARY KEY,
	UserName nvarchar(50),
	Email nvarchar(100),
	Pwd varchar(100)
);

create table Admin (
	AdminName nvarchar(50) NOT NULL,
	Pwd varchar(50)
);

create table Company (
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(MAX),
	Address nvarchar(MAX),
	Logo nvarchar(max),
	Web varchar(100),
	Rating float,
	UserRequest int,
	Confirm bit,
	FieldID int,
);

create table Review (
	ReviewId int IDENTITY(1,1) PRIMARY KEY,
	UserId int,
	ComId int,
	DateCreated Date,
	Rating int,
	Content nvarchar(max),
	Incognito bit,
)

create table Field (
	ID int IDENTITY(1, 1) PRIMARY KEY,
	FieldName nvarchar(100),
)


insert into Admin values ('admin', '123456')

insert into Users values ('Quynh', 'quynh@gmail.com', '123456')
insert into Users values ('Sang', 'sang@gmail.com', '123456')
insert into Users values ('Hung', 'hung@gmail.com', '123456')

insert into Field values ('Dịch vụ')
insert into Field values ('Phần mềm')
insert into Field values ('Bất động sản')



