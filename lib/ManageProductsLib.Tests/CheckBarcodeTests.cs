namespace ManageProductsLib.Tests
{
    [TestClass]
    public class CheckBarcodeTests
    {
        [DataTestMethod]
        [DataRow("5201234567894", true)]
        [DataRow("0000000000000", true)]
        [DataRow("1234567890123", false)]
        [DataRow("", false)]
        [DataRow(null, false)]
        [DataRow("123456789012", false)]
        [DataRow("12345678901234", false)]
        [DataRow("52012345678A1", false)]
        public void CheckBarcode_ReturnsExpectedResult(string barcode, bool expected)
        {
            string errorMsg = "";

            bool result = LibFunctions.CheckBarcode(barcode, ref errorMsg);

            Assert.AreEqual(expected, result);
        }
    }
}
