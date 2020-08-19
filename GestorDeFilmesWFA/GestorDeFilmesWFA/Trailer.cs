using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeFilmesWFA
{
    class Trailer
    {
        public string titulo;
        public int duracao;
        public DateTime data;
        public string foto;
        public string idioma;
        public int filme_id;

        public Trailer()
        {

        }

        public Trailer(string titulo, int duracao, DateTime data, string foto, string idioma, int filme_id)
        {
            this.titulo = titulo;
            this.duracao = duracao;
            this.data = data;
            this.foto = foto;
            this.idioma = idioma;
            this.filme_id = filme_id;
        }
    }
}
