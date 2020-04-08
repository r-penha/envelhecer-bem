using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnvelhecerBem.Core.Domain
{
    public class Parceiro : Entity<Guid>
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Contato { get; set; }
        public string Telefone { get; set; }
        public DateTime DataRegistro { get; set; }
        public Endereco Endereco { get; set; }
    }
}