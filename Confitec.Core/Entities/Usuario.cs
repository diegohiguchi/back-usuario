using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridadeId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int EscolaridadeId { get; private set; }
        public int HistoricoEscolarId { get; private set; }
        public Escolaridade Escolaridade { get; private set; }
        public HistoricoEscolar HistoricoEscolar { get; private set; }

        public void AdicionarHistoricoEscolar(string formato, string nome)
        {
            HistoricoEscolar = new HistoricoEscolar(formato, nome);
        }

        public void AlterarUsuario(string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridadeId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
        }

    }
}
