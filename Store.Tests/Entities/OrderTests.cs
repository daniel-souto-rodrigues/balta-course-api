using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Store.Domain.StoreContext.ValueObject;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _cadeira;
        private Product _headset;
        private Product _impressora;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("Thiago", "lastname");
            var document = new Document("165456561");
            var email = new Email("email@email.com");
            _customer = new Customer(name, document, email, "21988208420");
            _order = new Order(_customer);

            _mouse = new Product("mouse", "rato", "image.png", 100m, 10);
            _cadeira = new Product("cadeira", "info", "image.png", 100m, 10);
            _headset = new Product("headset", "info", "image.png", 100m, 10);
            _impressora = new Product("impressora", "rato", "image.png", 100m, 10);
        }


        // consigo criar um novo pedido?
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }
        // ao criar o pedido o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // ao adicionar um novo item a quantidade de itens deve mudar
        [TestMethod]
        public void OnAddItemQuantityShouldChange()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_cadeira, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void OnAddItemProductQuantityShouldBeChanged()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // ao confirmar pedido deve gerar um número
        [TestMethod]
        public void ShouldGenerateNumberWhenOrderConfirm()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }


        // ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void StatusShouldBePaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Dados mais 10 produtos, dever haver duas entregas
        [TestMethod]
        public void ShouldReturnTwoWhenPurchasedTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // ao cancelar pedido o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // ao cancelar o pedido deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            _order.Cancel();
            foreach (var item in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled ,item.Status);
            }
            
        }
    }
}
