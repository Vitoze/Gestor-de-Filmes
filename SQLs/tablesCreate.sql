create schema gestordefilmes;
go 

drop table gestordefilmes.filme; 
drop table gestordefilmes.escritopor; 
drop table gestordefilmes.representadopor; 
drop table gestordefilmes.musicasdofilme; 
drop table gestordefilmes.trailer; 
drop table gestordefilmes.lancamento; 
drop table gestordefilmes.premio; 
drop table gestordefilmes.realizador; 
drop table gestordefilmes.ator; 
drop table gestordefilmes.diretor; 
drop table gestordefilmes.escritor; 
drop table gestordefilmes.companhia; 
drop table gestordefilmes.musicas; 


create table gestordefilmes.filme(
	id int NOT NULL Identity,
	titulo varchar(100), 
	descricao varchar(8000), 
	categoria varchar(100),
	classificacao int,
	duracao int,
	idcompanhia int,
	iddiretor int,
	idrealizador int, 
	constraint PKFID primary key (id),
	constraint FKCID foreign key (idcompanhia) references gestordefilmes.companhia(id),
	constraint FKDID foreign key (iddiretor) references gestordefilmes.diretor(id),
	constraint FKRID foreign key (idrealizador) references gestordefilmes.realizador(id)
);

create table gestordefilmes.musicas(
	id int not null Identity,
	titulo varchar(50), 
	genero varchar(20),
	interprete varchar(50),
	url varchar(1000),
	constraint PKMID primary key (id)
);

create table gestordefilmes.companhia(
	id int not null Identity,
	nome varchar(50),
	constraint PKCID primary key (id) 
);

create table gestordefilmes.escritor(
	id int not null Identity,
	nome varchar(50),
	urlfoto varchar(1000),
	datanascimento date,
	biografia varchar(8000),
	constraint PKEID primary key (id)
);

create table gestordefilmes.diretor(
	id int not null Identity,
	nome varchar(50),
	urlfoto varchar(1000),
	datanascimento date,
	constraint PKDID primary key (id)
);

create table gestordefilmes.ator(
	id int not null Identity,
	nome varchar(50),
	urlfoto varchar(500),
	datanascimento date,
	biografia varchar(1000),
	constraint PKAID primary key (id)
);

create table gestordefilmes.realizador(
	id int not null Identity,
	nome varchar(50),
	urlfoto varchar(1000),
	datanascimento date,
	constraint PKRID primary key (id)
);

create table gestordefilmes.premio(
	id int not null Identity,
	idfilme int,
	ano int,
	tipo varchar(20),
	descricao varchar(200),
	constraint PKPATD primary key (id, tipo, descricao),
	constraint FKFID foreign key (idfilme) references gestordefilmes.filme(id)
);

create table gestordefilmes.lancamento(
	id int not null Identity,
	titulo varchar(100),
	data date,
	pais varchar(50),
	idfilme int,
	constraint PKLID primary key (id),
	constraint FKLFID foreign key (idfilme) references gestordefilmes.filme(id)
);

create table gestordefilmes.trailer(
	id int not null Identity,
	titulo varchar(100),
	duracao int,
	data date,
	url varchar(1000),
	idioma varchar(50),
	idfilme int,
	constraint PKTID primary key (id),
	constraint FKTFID foreign key (idfilme) references gestordefilmes.filme(id)
);

create table gestordefilmes.musicasdofilme(
	idfilme int not null,
	idmusica int not null,
	constraint PKFIDMID primary key (idfilme, idmusica),
	constraint FKMDFFID foreign key (idfilme) references gestordefilmes.filme(id),
	constraint FKMID foreign key (idmusica) references gestordefilmes.musicas(id)
);

create table gestordefilmes.representadopor(
	idfilme int not null,
	idator int not null,
	constraint PKRPFIDMID primary key (idfilme, idator),
	constraint FKRPFID foreign key (idfilme) references gestordefilmes.filme(id),
	constraint FKAID foreign key (idator) references gestordefilmes.ator(id)
);

create table gestordefilmes.escritopor(
	idfilme int not null,
	idescritor int not null,
	constraint PKEPFIDMID primary key (idfilme, idescritor),
	constraint FKEPFID foreign key (idfilme) references gestordefilmes.filme(id),
	constraint FKEID foreign key (idescritor) references gestordefilmes.escritor(id)
);


create table gestordefilmes.login(
	idUser int not null Identity,
	username  varchar(50),
	pass varbinary(128)
); 

