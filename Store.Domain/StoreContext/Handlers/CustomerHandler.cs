using System;
using FluentValidator;
using Store.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Domain.StoreContext.ValueObject;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //verificar se o CPF já existe
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso"); //return null;

            //verifica se o email já existe
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail já está em uso"); //return null;

            //criar os VO's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar as entidades
            var customer = new Customer(name, document, email, command.Phone);

            //validar entidades e vo's
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(false, "Por favor, Corrija os campos abaixo", Notifications);

            //Persistir o cliente
            _repository.Save(customer);

            //Envia email de boas vindas
            _emailService.Send(email.Address, "hello@oi.com", "Bem vindo", "seja bem vindo ao nosso store");

            return new CommandResult(true, "bem vindo ao Store", new
            {
                Id = customer.Id,
                Name = customer.Name.ToString(),
                Email = customer.Email
            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}