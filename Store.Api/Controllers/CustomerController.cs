using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.ValueObject;
using Store.Shared.Commands;

namespace Store.Api.Controllers
{
    [Route("v1/customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;
        
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        
        [HttpGet]
        [Route("")]
        [ResponseCache(Location = ResponseCacheLocation.Client ,Duration = 60)]
        public IEnumerable<ListCustomerResult> Get()
        {

            return _repository.Get();
        }

        [HttpGet]
        [Route("/{id}")]
        public GetCustomerResult GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("/{id}/orders")]
        public IEnumerable<ListCustomerOrdersResult> GetOrders(Guid id)
        {
           return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("")]
        public ICommandResult Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("/{id}")]
        public Customer Put(Guid id, [FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("/{id}")]
        public object Delete(Guid id)
        {
            return new { message = "Cliente deletado com sucesso!" };
        }


    }
}