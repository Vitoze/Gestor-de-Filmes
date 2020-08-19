using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeFilmesWPF.Domains
{
    class Trailer
    {
        public string titulo;
        public int duracao;
        public DateTime data;
        public string url;
        public string idioma;
        public int filme_id;

        public Trailer()
        {

        }

        public Trailer(string titulo, int duracao, DateTime data, string url, string idioma, int filme_id)
        {
            this.titulo = titulo;
            this.duracao = duracao;
            this.data = data;
            this.url = url;
            this.idioma = idioma;
            this.filme_id = filme_id;
        }
    }
}
