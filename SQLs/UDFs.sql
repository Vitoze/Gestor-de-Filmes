use p1g10


-- Tabela completa de ATORES 

--drop function gestordefilmes.udf_Atores;
go
CREATE FUNCTION gestordefilmes.udf_Atores () RETURNS table
AS
	RETURN 
	(
		SELECT *
		FROM gestordefilmes.ator
	);
go


go
CREATE FUNCTION gestordefilmes.udf_AtoresSemURL () RETURNS table
AS
	RETURN 
	(
		SELECT id, nome, datanascimento, biografia
		FROM gestordefilmes.ator
	);
go




-- Tabela completa de MUSICAS 

--drop function gestordefilmes.udf_Musicas;
go
CREATE FUNCTION gestordefilmes.udf_Musicas () RETURNS table
AS
	RETURN 
	(
		SELECT *
		FROM gestordefilmes.musicas
	);
go


-- Tabela completa de ESCRITORES 

--drop function gestordefilmes.udf_Escritores;
go
CREATE FUNCTION gestordefilmes.udf_Escritores () RETURNS table
AS
	RETURN 
	(
		SELECT *
		FROM gestordefilmes.escritor
	);
go


-- Tabela completa de DIRECTOR 

--drop function gestordefilmes.udf_Directores;
go
CREATE FUNCTION gestordefilmes.udf_Directores () RETURNS table
AS
	RETURN 
	(
		SELECT *
		FROM gestordefilmes.diretor
	);
go


-- Tabela completa de REALIZADOR 

--drop function gestordefilmes.udf_Realizador;
go
CREATE FUNCTION gestordefilmes.udf_Realizador () RETURNS table
AS
	RETURN 
	(
		SELECT *
		FROM gestordefilmes.realizador
	);
go


-- Tabela id, titulo de FILME 
--drop function gestordefilmes.udf_Filme;
go
CREATE FUNCTION gestordefilmes.udf_Filme () RETURNS table
AS
	RETURN 
	(
		SELECT id, titulo
		FROM gestordefilmes.filme
	);
go


go
CREATE FUNCTION gestordefilmes.udf_FilmeAll () RETURNS table
AS
	RETURN 
	(
		SELECT *
		FROM gestordefilmes.filme
	);
go


-- Tabela id, nome de COMPANHIA 
--drop function gestordefilmes.udf_Companhia;
go
CREATE FUNCTION gestordefilmes.udf_Companhia () RETURNS table
AS
	RETURN 
	(
		SELECT id, nome
		FROM gestordefilmes.companhia
	);
go


-- Tabela id, nome de COMPANHIA 
drop function gestordefilmes.udf_VerifyLogin;


go
CREATE FUNCTION gestordefilmes.udf_VerifyLogin (@username  varchar(20), @pass  varchar(200)) RETURNS table
AS
	RETURN 
	(
		SELECT DISTINCT idUser
		FROM gestordefilmes.login
		where gestordefilmes.login.username=@username and 
		convert(varchar(10), DECRYPTBYPASSPHRASE ('poy5t523dsz2s23zaw4',gestordefilmes.login.pass)) = @pass

	);
go

--Select * from gestordefilmes.udf_VerifyLogin('userTest1','qwerty'); 


-- Tabela ator de Ator com nome 
-- drop function gestordefilmes.udf_GetAtor;
go
CREATE FUNCTION gestordefilmes.udf_GetAtor(@nome varchar(50)) RETURNS table
AS
	RETURN 
	(
		SELECT id, nome, datanascimento, urlfoto, biografia
		FROM gestordefilmes.ator
		WHERE gestordefilmes.ator.nome = @nome
	);
go

-- select * from gestordefilmes.udf_GetAtor('Brad Pitt');

-- Tabela realizador de Realizador com nome 
--drop function gestordefilmes.udf_GetRealizador;
go
CREATE FUNCTION gestordefilmes.udf_GetRealizador(@nome varchar(50)) RETURNS table
AS
	RETURN 
	(
		SELECT id, nome, datanascimento, urlfoto
		FROM gestordefilmes.realizador
		WHERE gestordefilmes.realizador.nome = @nome
	);
go


-- Tabela escritor de Escritor com nome 
-- drop function gestordefilmes.udf_GetEscritor;
go
CREATE FUNCTION gestordefilmes.udf_GetEscritor(@nome varchar(50)) RETURNS table
AS
	RETURN 
	(
		SELECT id, nome, datanascimento, urlfoto, biografia
		FROM gestordefilmes.escritor
		WHERE gestordefilmes.escritor.nome = @nome
	);
go

-- Tabela diretor de Diretor com nome 
--drop function gestordefilmes.udf_GetDiretor;
go
CREATE FUNCTION gestordefilmes.udf_GetDiretor(@nome varchar(50)) RETURNS table
AS
	RETURN 
	(
		SELECT id, nome, datanascimento, urlfoto
		FROM gestordefilmes.diretor
		WHERE gestordefilmes.diretor.nome = @nome
	);
go

-- Tabela musicas de Musicas com nome 
--drop function gestordefilmes.udf_GetMusica;
go
CREATE FUNCTION gestordefilmes.udf_GetMusica(@nome varchar(50)) RETURNS table
AS
	RETURN 
	(
		SELECT id, titulo, genero, interprete, url
		FROM gestordefilmes.musicas
		WHERE gestordefilmes.musicas.titulo = @nome
	);
go


-- Tabela Prémios
drop function gestordefilmes.udf_GetPremios;

go
CREATE FUNCTION gestordefilmes.udf_GetPremios() RETURNS table
AS
	RETURN 
	(
		SELECT ano, tipo, descricao
		FROM gestordefilmes.premio
	);
go


select * from gestordefilmes.udf_GetPremios();