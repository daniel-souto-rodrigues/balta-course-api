using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObject
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract().Requires()
                .HasMinLen(FirstName, 3, "FirstName", "o nome deve conter no mínimo de 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "o nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "o sobrenome deve conter no mínimo de 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "o sobrenome deve conter no máximo 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString() => $"{FirstName} {LastName}";

    }
}