using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(int id, string nome, string sobrenome, string email, DateTime dataNascimento, string formato, string nomeHistoricoEscolar, int escolaridadeId)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Formato = formato;
            NomeHistoricoEscolar = nomeHistoricoEscolar;
            EscolaridadeId = escolaridadeId;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Formato { get; set; }
        public string NomeHistoricoEscolar { get; set; }
        public int EscolaridadeId { get; set; }
    }
}
