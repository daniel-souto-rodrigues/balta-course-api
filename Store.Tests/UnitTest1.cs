using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObject;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name1 = new Name("Thiago", "lastname");
            var documeent = new Document("165456561");
            var email2 = new Email("email@email.com");

            var teste = email2.IsValid;

            var c2 = new Customer(name1, documeent, email2, "21 988820-8420");


            var name = new Name("Daniel", "Rodrigues");
            var document = new Document("16165093760");
            var email = new Email("dantdmc210@gmail.com");

            var c = new Customer(name, document, email, "21988208420");

            var mouse = new Product("Mouse", "Rato", "image.png", 59.0m, 25);
            var teclado = new Product("teclado", "board", "image.png", 499.0m, 25);
            var impressora = new Product("impressora", "printer", "image.png", 699.0m, 10);
            var cadeira = new Product("Cadeira", "chair", "image.png", 59.0m, 25);

            var order = new Order(c);
            // order.AddItem(new OrderItem(mouse, 5));
            // order.AddItem(new OrderItem(teclado, 5));
            // order.AddItem(new OrderItem(cadeira, 5));
            // order.AddItem(new OrderItem(impressora, 5));

            //realizei o pedido
            order.Place();

            //verificar se o pedido é válido
            var valid = order.IsValid;

            //simular pagamento
            order.Pay();

            //simular o envio
            order.Ship();

            //simular o cancelamento
            order.Cancel();

        }
    }
}
