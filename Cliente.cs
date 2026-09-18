using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FireHair_Records
{
    internal class Cliente
    {
        private int id;
        private string nome;
        private string telefone;
        private string email;
        private string endereco;
        private bool BloqueadoCliente;

        public Cliente(int id, string nome, string telefone, string email, string endereco)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
            this.endereco = endereco;
            BloqueadoCliente = false;
        }
        public int Getid()
        {
            return id;
        }
        public string GetNome()
        {
            return nome;
        }
        public string GetTelefone() 
        { 
            return telefone; 
        }
        public string GetEmail()
        {
            return email;
        }
        public string GetEndereco()
        {
            return endereco;
        }
        public bool GetVerificarBloqueio()
        {
            return this.BloqueadoCliente;
        }
        public static bool VerificarNome(string nome) 
        { 
            return !string.IsNullOrWhiteSpace(nome) && nome.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)); 
        }

        public static bool VerificarTelefone(string telefone) 
        { 
            return !string.IsNullOrWhiteSpace(telefone) && telefone.All(c => char.IsDigit(c) || c == '-' || c == '(' || c == ')' || char.IsWhiteSpace(c)) && telefone.Length >= 10; 
        }

        public static bool VerificarEmail(string email) 
        {
            return !string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains("."); 
        }
        public void Setnome(string nomeNovo)
        {
            bool valido = !string.IsNullOrWhiteSpace(nomeNovo) && nomeNovo.All(char.IsLetter);

            if (valido)
            {
                this.nome = nomeNovo;
            }
            else
            {
                Console.WriteLine("O nome deve conter apenas letras e não pode estar vazio.");
            }

        }
        public void Settelefone(string telefoneNovo)
        {
            bool valido = !string.IsNullOrWhiteSpace(telefoneNovo) && telefoneNovo.All(char.IsDigit);
            if (valido && telefoneNovo.Length >= 10)
            {
                this.telefone = telefoneNovo;
            }
            else
            {
                Console.WriteLine("O telefone deve conter apenas números, não pode estar vazio e deve ter pelo menos 10 dígitos.");
            }
        }
        public void Setemail(string emailNovo)
        {
            if (emailNovo.Contains("@") && emailNovo.Contains("."))
            {
                this.email = emailNovo;
            }
            else
            {
                Console.WriteLine("O email está incorreto.");
            }
            
        }
        public void Setendereco(string enderecoNovo)
        {
            this.endereco = enderecoNovo;
        }
        public void BloquearCliente()
        {
            this.BloqueadoCliente = true;
        }
        public void DesbloquearCliente()
        {
            this.BloqueadoCliente = false;
        }

    }
}
