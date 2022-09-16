
create database myfinance;

use myfinance;

create table plano_contas(
	id int identity(1,1) not null,
	descricao varchar(50) not null,
	tipo char(1) not null,
	primary key(id)
);

create table transacao(
	id bigint identity(1,1) not null,
	data date not null,
	valor decimal(18,2) not null,
	tipo char(1) not null,
	historico text null,
	id_plano_conta int not null,
	primary key(id),
	foreign key(id_plano_conta) references plano_contas
);