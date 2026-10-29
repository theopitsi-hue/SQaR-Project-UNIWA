using System.Collections;

namespace ManageProductsLib
{
    public class Product
    {
        string barcode;
        string country;
        int stock;
        string category;
        double price;
        int discount;

        public Product(string barcode, string country, int stock, string category, double price, int discount)
        {
            this.barcode = barcode;
            this.country = country;
            this.stock = stock;
            this.category = category;
            this.price = price;
            this.discount = discount;
        }
    }

    public class OrderItem
    {
        string barcode;
        int quantity;
        public OrderItem(string barcode, int quantity)
        {
            this.barcode = barcode;
            this.quantity = quantity;
        }
    }

    public static class LibFunctions
    {
        public static void TESTFUNC()
        {

        }

        public static bool CheckBarcode(string barcode, ref string ErrorMsg)
        {
            return false;
        }

        public static string FindCountry(string barcode)
        {
            return null;
        }

        public static void CalculateCost(Product Prd, ref double PriceWithSupplyandTaxes, ref double Discount, ref double FinalPrice)
        {
          
        }

        public static double CalculateTotalCost(Product[] Prds)
        {
            return 0;
        }

        public static Product[] CountryProducts(Product[] Prds, string Country)
        {
            return null;
        }

        public static Product[] ProductsToOrder(Product[] Prds, int StockLimit, string Country, ref Product[] PrdsToOrder)
        {
            return null;
        }

        public static double CalculateOrder(Product[] StockProducts, OrderItem[] OrderProducts, ref string OrderStatus)
        {
            return 0;
        }
    }
}
