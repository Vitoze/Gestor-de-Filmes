using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeFilmesWPF.Domains
{
    class Ator
    {
        public string nome;
        public string foto;
        public DateTime datanascimento;
        public string biografia;

        public Ator()
        {

        }

        public Ator(string nome, string foto, DateTime datanascimento, string biografia)
        {
            this.nome = nome;
            this.foto = foto;
            this.datanascimento = datanascimento;
            this.biografia = biografia;
        }
    }
}
