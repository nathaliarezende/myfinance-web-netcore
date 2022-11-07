
create database myfinance;

use myfinance;

create table plano_contas(
	id_plano_contas int identity(1,1) not null,
	descricao varchar(50) not null,
	tipo char(1) not null,
	primary key(id_plano_contas)
);

create table responsavel(
	id_responsavel int identity(1,1) not null,
	nome varchar(30) not null
	primary key(id_responsavel)
);

create table transacao(
	id_transacao bigint identity(1,1) not null,
	data date not null,
	valor decimal(18,2) not null,
	tipo char(1) not null,
	historico text null,
	id_plano_conta int not null,
	id_usuario int not null,
	primary key(id_transacao),
	foreign key(id_plano_conta) references plano_contas,
	foreign key(id_usuario) references responsavel
);