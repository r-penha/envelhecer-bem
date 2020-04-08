using System;

namespace EnvelhecerBem.Core.Domain
{
    public class Cliente : Entity<Guid>
    {
        public string Cpf { get;  set; }
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Telefone { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public DateTime DataRegistro { get; set; }
        public Sexo Sexo { get;  set; }
        public TipoPlano Plano { get; set; }
        public Endereco Endereco { get;  set; }
    }
}