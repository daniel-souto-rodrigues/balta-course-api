using FluentValidator;
using FluentValidator.Validation;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        //fail fast validation
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
               .HasMinLen(FirstName, 3, "FirstName", "o nome deve conter no mínimo de 3 caracteres")
               .HasMaxLen(FirstName, 40, "FirstName", "o nome deve conter no máximo 40 caracteres")
               .HasMinLen(LastName, 3, "LastName", "o sobrenome deve conter no mínimo de 3 caracteres")
               .HasMaxLen(LastName, 40, "LastName", "o sobrenome deve conter no máximo 40 caracteres")
               .IsEmail(Email, "Address", "O email é inválido")
               .HasLen(Document, 11, "Document", "Cpf inválido")
           );
            return IsValid;
        }

        //se o usuário existe no banco (Email)
        //se o usuário existe no banco (CPF)
    }
}