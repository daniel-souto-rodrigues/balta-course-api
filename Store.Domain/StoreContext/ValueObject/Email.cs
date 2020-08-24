using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObject
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract().Requires()
                .IsEmail(Address, "Address", "O email é inválido")
            );
        }
        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}

