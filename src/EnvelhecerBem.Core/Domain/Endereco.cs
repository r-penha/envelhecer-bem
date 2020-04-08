using System;

namespace EnvelhecerBem.Core.Domain
{
    public class Endereco : ValueObject<Endereco>
    {
        // Necessário para o Entity Framework
        protected Endereco()
        {

        }

        public Endereco(string logradouro, string numero, string complemento, string cidade, string uf, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Uf = uf;
            Cep = cep;
        }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public string Cep { get; private set; }
    }
}