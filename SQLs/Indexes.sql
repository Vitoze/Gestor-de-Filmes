-- index da tabela filmes, colunas: titulo, categoria, classificação, companhia, diretor, realizador;

CREATE INDEX filmeTitulo ON gestordefilmes.filme (titulo);
CREATE INDEX filmeCategoria ON gestordefilmes.filme (categoria);
CREATE INDEX filmeClassificacao ON gestordefilmes.filme (classificacao);
CREATE INDEX filmeCompanhia ON gestordefilmes.filme (idcompanhia);
CREATE INDEX filmeDiretor ON gestordefilmes.filme (iddiretor);
CREATE INDEX filmeRealizador ON gestordefilmes.filme (idrealizador);

-- index da tabela musicas, colunas: titulo, genero, interprete;

CREATE INDEX musicaTitulo ON gestordefilmes.musicas (titulo);
CREATE INDEX musicaGenero ON gestordefilmes.musicas (genero);
CREATE INDEX musicaInterprete ON gestordefilmes.musicas (interprete);

-- index da tabela escritor, colunas: nome;

CREATE INDEX escritorNome ON gestordefilmes.escritor (nome);

-- index da tabela diretor, colunas: nome;

CREATE INDEX diretorNome ON gestordefilmes.diretor (nome);

-- index da tabela ator, colunas: nome;

CREATE INDEX atorNome ON gestordefilmes.ator (nome);

-- index da tabela realizador, colunas: nome;

CREATE INDEX realizadorNome ON gestordefilmes.realizador (nome);

-- index da tabela premio, colunas: filme, ano, tipo;

CREATE INDEX premioFilme ON gestordefilmes.premio (idfilme);
CREATE INDEX premioAno ON gestordefilmes.premio (ano);
CREATE INDEX premioTipo ON gestordefilmes.premio (tipo);

-- index da tabela lancamento, colunas: filme, titulo, data, país;

CREATE INDEX lancamentoFilme ON gestordefilmes.lancamento (idfilme);
CREATE INDEX lancamentoTitulo ON gestordefilmes.lancamento (titulo);
CREATE INDEX lancamentoData ON gestordefilmes.lancamento (data);
CREATE INDEX lancamentoPais ON gestordefilmes.lancamento (pais);

-- index da tabela trailer, colunas: filme, titulo, data, idioma;

CREATE INDEX trailerFilme ON gestordefilmes.trailer (idfilme);
CREATE INDEX trailerTitulo ON gestordefilmes.trailer (titulo);
CREATE INDEX trailerData ON gestordefilmes.trailer (data);
CREATE INDEX trailerIdioma ON gestordefilmes.trailer (idioma);