using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeFilmesWFA
{
    class Filme
    {
        public string titulo;
        public string descricao;
        public int classificacao;
        public int duracao;
        public int companhia_id;
        public int diretor_id;
        public int realizador_id;

        public Filme()
        {

        }

        public Filme(string titulo, string descricao, int classificacao, int duracao, int companhia_id, int diretor_id, int realizador_id)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.classificacao = classificacao;
            this.duracao = duracao;
            this.companhia_id = companhia_id;
            this.diretor_id = diretor_id;
            this.realizador_id = realizador_id;
        }
    }
}
