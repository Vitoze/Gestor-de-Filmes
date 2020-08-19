using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeFilmesWPF.Domains
{
    class Diretor
    {
        public string nome;
        public string foto;
        public DateTime datanascimento;

        public Diretor()
        {

        }

        public Diretor(string nome, string foto, DateTime datanascimento)
        {
            this.nome = nome;
            this.foto = foto;
            this.datanascimento = datanascimento;
        }
    }
}
