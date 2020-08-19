use p1g10

-- trigger delete ator
go
CREATE TRIGGER gestordefilmes.t_removerAtor ON gestordefilmes.ator 
INSTEAD OF DELETE
AS
PRINT 'Operação para eliminar Ator não é permitida!';
GO

-- trigger delete filme
go
CREATE TRIGGER gestordefilmes.t_removerFilme ON gestordefilmes.filme 
INSTEAD OF DELETE
AS
PRINT 'Operação para eliminar Filme não é permitida!';
GO


-- trigger delete musica
go
CREATE TRIGGER gestordefilmes.t_removerMusica ON gestordefilmes.musicas 
INSTEAD OF DELETE
AS
PRINT 'Operação para eliminar Musica não é permitida!';
GO

-- trigger delete escritor
go
CREATE TRIGGER gestordefilmes.t_removerEscritor ON gestordefilmes.escritor 
INSTEAD OF DELETE
AS
PRINT 'Operação para eliminar Escritor não é permitida!';
GO

-- trigger delete diretor
go
CREATE TRIGGER gestordefilmes.t_removerDiretor ON gestordefilmes.diretor 
INSTEAD OF DELETE
AS
PRINT 'Operação para eliminar Diretor não é permitida!';
GO

-- trigger delete companhia
go
CREATE TRIGGER gestordefilmes.t_removerCompanhia ON gestordefilmes.companhia 
INSTEAD OF DELETE
AS
PRINT 'Operação para eliminar Companhia não é permitida!';
GO

-- trigger delete lancamento
go
CREATE TRIGGER gestordefilmes.t_removerLancamento ON gestordefilmes.lancamento 
INSTEAD OF DELETE
AS
PRINT 'Operação para eliminar Lançamento não é permitida!';
GO

-- trigger delete premio
go
CREATE TRIGGER gestordefilmes.t_removerPremio ON gestordefilmes.premio 
INSTEAD OF DELETE
AS
PRINT 'Operação para eliminar Premio não é permitida!';
GO

-- trigger delete realizador
go
CREATE TRIGGER gestordefilmes.t_removerRealizador ON gestordefilmes.realizador 
INSTEAD OF DELETE
AS
PRINT 'Operação para eliminar Realizador não é permitida!';
GO

-- trigger delete trailer
go
CREATE TRIGGER gestordefilmes.t_removerTrailer ON gestordefilmes.trailer 
INSTEAD OF DELETE
AS
PRINT 'Operação para eliminar Trailer não é permitida!';
GO

-- trigger delete escritopor
go
CREATE TRIGGER gestordefilmes.t_removerEscritopor ON gestordefilmes.escritopor 
INSTEAD OF DELETE
AS
PRINT 'Operação não é permitida!';
GO

-- trigger delete musicasdofilme
go
CREATE TRIGGER gestordefilmes.t_removerMusicasdofilme ON gestordefilmes.musicasdofilme 
INSTEAD OF DELETE
AS
PRINT 'Operação não é permitida!';
GO

-- trigger delete representadorpor
go
CREATE TRIGGER gestordefilmes.t_removerRepresentadopor ON gestordefilmes.representadorpor 
INSTEAD OF DELETE
AS
PRINT 'Operação não é permitida!';
GO

-- http://www.devmedia.com.br/triggers-no-sql-server-teoria-e-pratica-aplicada-em-uma-situacao-real/28194