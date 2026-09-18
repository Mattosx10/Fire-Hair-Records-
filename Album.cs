using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireHair_Records
{
    internal class Album
    {
        private int id;
        private string nome;
        private string artista;
        private int anoLancamento;
        private int qtdEstoque;

        private EstiloMusical estiloMusical;
        public Album(int id, string nome, string artista, int anoLancamento, int qtdEstoque, EstiloMusical estiloMusical)
        {
            this.id = id;
            this.nome = nome;
            this.artista = artista;
            this.anoLancamento = anoLancamento;
            this.qtdEstoque = qtdEstoque;
            this.estiloMusical = estiloMusical;
        }
        public int GetId()
        {
            return id;
        }
        public string GetNome()
        {
            return nome;
        }
        public string GetArtista() 
        { 
            return artista; 
        }
        public EstiloMusical GetEstiloMusical()
        {
            return estiloMusical;
        }
        public int GetAnoLancamento()
        {
            return anoLancamento;
        }
        public int GetQtdEstoque()
        {
            return qtdEstoque;
        }
        public bool AlugarAlbum()
        {
           
            if (this.qtdEstoque > 0)
            {
                this.qtdEstoque--;
                Console.WriteLine($"\n - Álbum '{nome}' alugado com sucesso. Estoque restante: {this.qtdEstoque}");
                return true;
            }
                Console.WriteLine($"\n - Álbum '{nome}' indisponível para aluguel. Estoque esgotado.");
                return false;
            
        }
        public void DevolverAlbum()
        {
            this.qtdEstoque++;
           
        }
    }
}
