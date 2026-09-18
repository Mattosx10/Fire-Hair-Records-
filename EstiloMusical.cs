using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireHair_Records
{
    internal class EstiloMusical
    {

        private int id;
        private string nome;

        public EstiloMusical(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public int GetId()
        {
            return id;
        }

        public string Getnome()
        {
         return nome; 
        }

        public void Setnome(string nome)
        {
            this.nome = nome;
        }   
    }
}
