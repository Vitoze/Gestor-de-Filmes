using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeFilmesWFA
{
    class Lancamento
    {
        public string titulo;
        public DateTime data;
        public string pais;
        public int filme_id;

        public Lancamento()
        {

        }

        public Lancamento(string titulo, DateTime data, string pais, int filme_id)
        {
            this.titulo = titulo;
            this.data = data;
            this.pais = pais;
            this.filme_id = filme_id;
        }
    }
}
