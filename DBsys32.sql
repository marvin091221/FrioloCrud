create database DBsys32

use DBsys32

create table [User](
	id int primary key not null,
	username nvarchar(255) not null,
	[pssword] nvarchar(255) not null
)

create table [role](
	id int primary key not null,
	roleName nvarchar(255) not null
)

select * from [user]