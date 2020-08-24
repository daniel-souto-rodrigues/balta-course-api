using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.ValueObject;

namespace Store.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document inValidDocument;

        public DocumentTests()
        {
            validDocument = new Document("91658830989");
            inValidDocument = new Document("12345678910");
        }

        [TestMethod]
        public void SholdReturnNotificationWhenDocumentIsNotValid()
        {

            Assert.AreEqual(false, inValidDocument.IsValid);
            Assert.AreEqual(1, inValidDocument.Notifications.Count);
        }

        [TestMethod]
        public void SholdReturnNotNotificationWhenDocumentIsValid()
        {

            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
