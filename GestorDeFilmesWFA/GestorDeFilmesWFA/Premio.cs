using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeFilmesWFA
{
    class Premio
    {
        public int ano;
        public string tipo;
        public string descricao;
        public int filme_id;

        public Premio()
        {

        }

        public Premio(int ano, string tipo, string descricao, int filme_id)
        {
            this.ano = ano;
            this.tipo = tipo;
            this.descricao = descricao;
            this.filme_id = filme_id;
        }
    }
}
