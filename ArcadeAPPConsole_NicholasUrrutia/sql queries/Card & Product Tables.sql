use project0

create table ProductDetails
(
	pId int primary key identity,
	pName varchar(30),
	pCategory varchar(25),
	pSize varchar (20),
	pQtyBought int,
	pQtyLeftInStock int,
	pPrice int,
	pDateBought DateTime
)

create table CardDetails
(
	cId int primary key identity,
	cName varchar (30),
	cEmail varchar (30),
	cTier int not null,
	cDateSubbed DateTime,
	cBalance float not null, --real is a sort of double value as well
	cTickets int not null
)

select * from CardDetails