use p1g10;

CREATE TYPE gestordefilmes.listaElenco
AS TABLE
(
	id int
);

CREATE TYPE gestordefilmes.listaBanda
AS TABLE
(
	id int
);


CREATE TYPE gestordefilmes.listaEscritor
AS TABLE
(
	id int
);


--ACTORES
--drop procedure gestordefilmes.sp_AddActor;

go
create procedure gestordefilmes.sp_AddActor (
									@nome varchar(50),
									@urlfoto varchar(500),
									@datanascimento date,
									@biografia varchar(600)
									)
as
begin
insert into gestordefilmes.ator values (@nome, @urlfoto, @datanascimento, @biografia);
end
go

--MUSICAS
--drop procedure gestordefilmes.sp_Addmusicas;

go
create procedure gestordefilmes.sp_AddMusica (
									@titulo varchar(50), 
									@genero varchar(20),
									@interprete varchar(50),
									@url varchar(1000)
									)
as
begin
insert into gestordefilmes.musicas values (@titulo, @genero, @interprete, @url);
end
go



--COMPANHIA
--drop procedure gestordefilmes.sp_AddCompanhia;

go
create procedure gestordefilmes.sp_AddCompanhia (
									@nome varchar(50)
									)
as
begin
insert into gestordefilmes.companhia values (@nome);
end
go



--ESCRITOR
--drop procedure gestordefilmes.sp_AddEscritor;

go
create procedure gestordefilmes.sp_AddEscritor (
									@nome varchar(50),
									@urlfoto varchar(1000),
									@datanascimento date,
									@biografia varchar(8000)
									)
as
begin
insert into gestordefilmes.escritor(nome, urlfoto, datanascimento, biografia) values (@nome, @urlfoto, @datanascimento, @biografia);
end
go


--DIRECTOR
--drop procedure gestordefilmes.sp_AddDirector;

go
create procedure gestordefilmes.sp_AddDirector (
									@nome varchar(50),
									@urlfoto varchar(1000),
									@datanascimento date
									)
as
begin
insert into gestordefilmes.diretor values (@nome, @urlfoto, @datanascimento);
end
go



--REALIZADOR
--drop procedure gestordefilmes.sp_AddRealizador;

go
create procedure gestordefilmes.sp_AddRealizador (
									@nome varchar(50),
									@urlfoto varchar(1000),
									@datanascimento date
									)
as
begin
insert into gestordefilmes.realizador values (@nome, @urlfoto, @datanascimento);
end
go


--COMPANHIA
--drop procedure gestordefilmes.sp_AddCompanhia;

go
create procedure gestordefilmes.sp_AddCompanhia (
									@nome varchar(50)
									)
as
begin
insert into gestordefilmes.companhia values (@nome);
end
go


-- FILME
--drop procedure gestordefilmes.sp_AddFilme;

GO
CREATE PROCEDURE gestordefilmes.sp_AddFilme (
									@id INT = NULL OUTPUT,
									@titulo varchar(100), 
									@descricao varchar(8000), 
									@categoria varchar(100),
									@classificacao int,
									@duracao int,
									@idcompanhia int,
									@iddiretor int,
									@idrealizador int,
									@Escritor AS gestordefilmes.listaEscritor READONLY,
									@Elenco AS gestordefilmes.listaElenco READONLY,
									@Banda AS gestordefilmes.listaBanda READONLY
									)
AS
BEGIN

	INSERT into gestordefilmes.filme VALUES (@titulo, @descricao, @categoria, @classificacao, @duracao, @idcompanhia, @iddiretor, @idrealizador);

	SET @id = SCOPE_IDENTITY(); 

	insert into gestordefilmes.escritopor select @id, id from @Escritor;
	insert into gestordefilmes.representadopor select @id, id  from @Elenco;
	insert into gestordefilmes.musicasdofilme select @id, id from @Banda;

END
GO


-- TRAILER
--drop procedure gestordefilmes.sp_AddTrailer;

GO
CREATE PROCEDURE gestordefilmes.sp_AddTrailer (
											@titulo varchar(100),
											@duracao int,
											@data date,
											@url varchar(1000),
											@idioma varchar(50),
											@idfilme int
											)
AS
BEGIN
	INSERT into gestordefilmes.trailer VALUES (@titulo, @duracao, @data, @url, @idioma, @idfilme);
END
GO

-- add pr�mio usa SQL DML diretamente no C#


-- LAN�AMENTO
drop procedure gestordefilmes.sp_Addlancamento;

GO
CREATE PROCEDURE gestordefilmes.sp_Addlancamento (
											@titulo varchar(100),
											@data date,
											@pais varchar(50),
											@idfilme int 
											)
AS
BEGIN
	INSERT into gestordefilmes.lancamento VALUES (@titulo, @data, @pais,  @idfilme);
END
GO

-- ADICIONAR NOVO UTILIZADOR
go
create procedure gestordefilmes.sp_AddNewUser (
									@username varchar(50),
									@pass varchar(128)
									)
as
begin
insert into gestordefilmes.login values (@username, EncryptByPassPhrase('poy5t523dsz2s23zaw4', @pass))
end
go



-- EDITAR ATOR
-- drop procedure gestordefilmes.sp_EditAtor;
go
create procedure gestordefilmes.sp_EditAtor(
									@ator_id int,
									@nome varchar(50),
									@data date,
									@url varchar(500),
									@bio varchar(1000)			
									)
as
begin
update gestordefilmes.ator
set nome = @nome,
	datanascimento = @data,
	urlfoto = @url,
	biografia = @bio
where gestordefilmes.ator.id = @ator_id
end
go

-- exec gestordefilmes.sp_EditAtor @ator_id = 1, @nome = 'Brad Pitt', @data = '1963-12-18', @url = 'https://upload.wikimedia.org/wikipedia/commons/5/51/Brad_Pitt_Fury_2014.jpg', @bio = 'William Bradley Pitt mais conhecido como Brad Pitt (Shawnee, 18 de Dezembro de 1963), é um ator, produtor cinematográfico e empresário americano, fundador e atualmente único dono da produtora de filmes Plan B Entertainment e viticultor e dono da vinícola Miraval, junto de sua mulher Angelina Jolie.';

-- EDITAR REALIZADOR
-- drop procedure gestordefilmes.sp_EditRealizador;
go
create procedure gestordefilmes.sp_EditRealizador(
									@realizador_id int,
									@nome varchar(50),
									@data date,
									@url varchar(500)			
									)
as
begin
update gestordefilmes.realizador
set nome = @nome,
	datanascimento = @data,
	urlfoto = @url
where gestordefilmes.realizador.id = @realizador_id
end
go

-- EDITAR ESCRITOR
-- drop procedure gestordefilmes.sp_EditEscritor;
go
create procedure gestordefilmes.sp_EditEscritor(
									@escritor_id int,
									@nome varchar(50),
									@data date,
									@url varchar(500),
									@bio varchar(1000)			
									)
as
begin
update gestordefilmes.escritor
set nome = @nome,
	datanascimento = @data,
	urlfoto = @url,
	biografia = @bio
where gestordefilmes.escritor.id = @escritor_id
end
go

-- EDITAR DIRETOR
-- drop procedure gestordefilmes.sp_EditDiretor;
go
create procedure gestordefilmes.sp_EditDiretor(
									@diretor_id int,
									@nome varchar(50),
									@data date,
									@url varchar(500)			
									)
as
begin
update gestordefilmes.diretor
set nome = @nome,
	datanascimento = @data,
	urlfoto = @url
where gestordefilmes.diretor.id = @diretor_id
end
go

-- EDITAR MUSICA
-- drop procedure gestordefilmes.sp_EditMusica;
go
create procedure gestordefilmes.sp_EditMusica(
									@musica_id int,
									@titulo varchar(50),
									@genero varchar(20),
									@interprete varchar(50),
									@url varchar(1000)			
									)
as
begin
update gestordefilmes.musicas
set titulo = @titulo,
	genero = @genero,
	interprete = @interprete,
	url = @url
where gestordefilmes.musicas.id = @musica_id
end
go


-- PESQUISAR ATORES 

drop PROCEDURE gestordefilmes.sp_PesquisarAtor

GO
CREATE PROCEDURE gestordefilmes.sp_PesquisarAtor (
									@name varchar(50) = null,
									@biografia varchar(1000) = null 
									)
AS
BEGIN

	declare @out table(id int, nome varchar(50), datanascimento date, biografia varchar(1000));
	declare @tmp table(id int, nome varchar(50), datanascimento date, biografia varchar(1000));

	insert into @out select * from gestordefilmes.udf_AtoresSemURL();

	if not @name is null
		insert into @tmp select * from @out where nome like '%'+@name+'%';
	else
		insert into @tmp select * from @out;

	delete from @out

	if not @biografia is null
		insert into @out select * from @tmp where biografia like '%'+@biografia+'%';
	else
		insert into @out select * from @tmp;

	delete from @tmp;

	select * from @out;

END
go


exec gestordefilmes.sp_PesquisarAtor @name='B', @biografia ='pit';



-- PESQUISAR MUSICAS 

drop PROCEDURE gestordefilmes.sp_PesquisarMusicas


GO
CREATE PROCEDURE gestordefilmes.sp_PesquisarMusicas (
									@titulo varchar(50) = null,
									@genero varchar(20) = null,
									@interprete varchar(50) = null
									)
AS
BEGIN

	declare @out table(id int, titulo varchar(50), genero varchar(20), interprete varchar(50), url varchar(1000));
	declare @tmp table(id int, titulo varchar(50), genero varchar(20), interprete varchar(50), url varchar(1000));


	insert into @out select * from gestordefilmes.udf_Musicas();

	if not @titulo is null
		insert into @tmp select * from @out where titulo like '%'+@titulo+'%';
	else
		insert into @tmp select * from @out;

	delete from @out

	if not @genero is null
		insert into @out select * from @tmp where genero like '%'+@genero+'%';
	else
		insert into @out select * from @tmp;

	delete from @tmp;

	if not @interprete is null
		insert into @tmp select * from @out where interprete like '%'+@interprete+'%';
	else
		insert into @tmp select * from @out;

	select * from @tmp;

END
go

exec gestordefilmes.sp_PesquisarMusicas @titulo='a', @genero='pop';





-- PESQUISAR REALIZADOR 

drop PROCEDURE gestordefilmes.sp_PesquisarRealizador

GO
CREATE PROCEDURE gestordefilmes.sp_PesquisarRealizador (
									@nome varchar(50) = null
									)
AS
BEGIN

	declare @out table(id int, nome varchar(50), urlfoto varchar(1000), datanascimento date);
	declare @tmp table(id int, nome varchar(50), urlfoto varchar(1000), datanascimento date);

	insert into @out select * from gestordefilmes.udf_Realizador();

	if not @nome is null
		insert into @tmp select * from @out where nome like '%'+@nome+'%';
	else
		insert into @tmp select * from @out;

	delete from @out

	select * from @tmp;

END
go





-- PESQUISAR DIRETOR 

drop PROCEDURE gestordefilmes.sp_PesquisarDiretor

GO
CREATE PROCEDURE gestordefilmes.sp_PesquisarDiretor (
									@nome varchar(50) = null
									)
AS
BEGIN

	declare @out table(id int, nome varchar(50), urlfoto varchar(1000), datanascimento date);
	declare @tmp table(id int, nome varchar(50), urlfoto varchar(1000), datanascimento date);

	insert into @out select * from gestordefilmes.udf_Directores();

	if not @nome is null
		insert into @tmp select * from @out where nome like '%'+@nome+'%';
	else
		insert into @tmp select * from @out;

	delete from @out

	select * from @tmp;

END
go


-- PESQUISAR ESCRITOR 

drop PROCEDURE gestordefilmes.sp_PesquisarEscritor

GO
CREATE PROCEDURE gestordefilmes.sp_PesquisarEscritor (
									@name varchar(50) = null,
									@biografia varchar(1000) = null 
									)
AS
BEGIN
	declare @out table(id int, nome varchar(50), urlfoto varchar(1000), datanascimento date, biografia varchar(1000) );
	declare @tmp table(id int, nome varchar(50), urlfoto varchar(1000), datanascimento date, biografia varchar(1000));

	insert into @out select * from gestordefilmes.udf_Escritores();

	if not @name is null
		insert into @tmp select * from @out where nome like '%'+@name+'%';
	else
		insert into @tmp select * from @out;

	delete from @out

	if not @biografia is null
		insert into @out select * from @tmp where biografia like '%'+@biografia+'%';
	else
		insert into @out select * from @tmp;

	delete from @tmp;

	select * from @out;

END
go
