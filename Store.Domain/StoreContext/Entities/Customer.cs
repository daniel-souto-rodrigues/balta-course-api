using System.Collections.Generic;
using System.Linq;
using Store.Domain.StoreContext.ValueObject;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _addresses;
        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses =>  _addresses.ToArray();

        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public void AddAddress(Address address)
        {
            //validar endereço
            //add adress
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }


    }
}