use project0

create table login(
	username varchar(20),
	password varchar(20)
)

alter table login alter column username varchar(20) not null

alter table login add constraint pk_username primary key(username)

insert into login values('User1', 'Pass@1234')
insert into login values('User2', 'Pass@1235')
insert into login values('Guy1', 'AvgShmo')
insert into login values('Nicholas', 'NerdsRCool')
insert into login values('BigBoss', 'ILikeCa$h')

select * from login