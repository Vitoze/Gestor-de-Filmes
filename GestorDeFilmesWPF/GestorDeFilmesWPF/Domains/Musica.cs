using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeFilmesWPF.Domains
{
    class Musica
    {
        public string titulo;
        public string genero;
        public string interprete;
        public string url;

        public Musica()
        {

        }

        public Musica(string titulo, string genero, string interprete, string url)
        {
            this.titulo = titulo;
            this.genero = genero;
            this.interprete = interprete;
            this.url = url;
        }
    }
}
