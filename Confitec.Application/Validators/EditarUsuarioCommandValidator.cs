using Confitec.Application.Commands.EditarUsuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Validators
{
    public class EditarUsuarioCommandValidator : AbstractValidator<EditarUsuarioCommand>
    {
        public EditarUsuarioCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido!");

            RuleFor(p => p.DataNascimento)
                .Must(ValidarDataNascimento)
                .WithMessage("A data de nascimento não pode ser maior que hoje!");
        }

        public bool ValidarDataNascimento(DateTime dataNascimento)
        {
            return dataNascimento.Date > DateTime.Now.Date ? false : true;
        }
    }
}
