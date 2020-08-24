using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.CustomerCommands.Inputs;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Daniel";
            command.LastName = "Rodrigues";
            command.Document = "16165093760";
            command.Email = "danielsr98@gmail.com";
            command.Phone = "21988808420";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
