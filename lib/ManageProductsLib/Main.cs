using System.Collections;

namespace ManageProductsLib
{
    

    public class Product
    {
        public string barcode;
        public string country;
        public int stock;
        public string category;
        public double price;
        public int discount;

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
        public static List<String> PRD_CATEGORIES = new List<String> { 
            "Ηλεκτρονικά", 
            "Καλλυντικά", 
            "Αλκοόλ", 
            "Τρόφιμα",
            "Αναψυκτικά χωρίς αλκοόλ", 
            "Βιβλία" 
        };

        public static bool CheckBarcode(string barcode, ref string ErrorMsg)
        {
            ErrorMsg = "";

            if (barcode == null)
            {
                ErrorMsg = "Barcode is null.";
                return false;
            }

            if (barcode.Length == 0)
            {
                ErrorMsg = "Barcode is empty.";
                return false;
            }

            if (barcode.Length != 13)
            {
                ErrorMsg = "Barcode must contain exactly 13 digits.";
                return false;
            }

            for (int i = 0; i < barcode.Length; i++)
            {
                //LITERAL check of the char code to ensure its 1-9
                if (barcode[i] < '0' || barcode[i] > '9')
                {
                    ErrorMsg = "Barcode must contain only numeric digits.";
                    return false;
                }
            }

            //actual validation for the code itself, sum up
            int sum = 0;

            for (int i = 0; i < 12; i++)
            {
                //char to int
                int digit = int.Parse(barcode[i].ToString());

                //enalax artia perita
                if (i % 2 == 0)
                    sum += digit;
                else
                    sum += digit * 3;
            }

            int expectedCheckDigit = (10 - (sum % 10)) % 10;
            int actualCheckDigit = int.Parse(barcode[12].ToString());

            if (expectedCheckDigit != actualCheckDigit)
            {
                ErrorMsg = "Invalid check digit.";
                return false;
            }

            return true;
        }

        public static string FindCountry(string barcode)
        {
            string errorMsg = "";

            if (!CheckBarcode(barcode, ref errorMsg))
                return "Unknown";

            int prefix = int.Parse(barcode.Substring(0, 3));

            switch (prefix)
            {
                case int n when (n >= 0 && n <= 19):
                    return "ΗΠΑ";
                case int n when (n >= 20 && n <= 29):
                    return "Εσωτερική χρήση";
                case int n when (n >= 30 && n <= 37):
                    return "Γαλλία";
                case int n when (n == 380):
                    return "Βουλγαρία";
                case int n when (n >= 400 && n <= 440):
                    return "Γερμανία";
                case int n when (n == 471):
                    return "Ταϊβάν";
                case int n when (n == 520):
                    return "Ελλάδα";
                case int n when (n == 529):
                    return "Κύπρος";
                case int n when (n == 590):
                    return "Πολωνία";
                case int n when (n >= 690 && n <= 695):
                    return "Κίνα";
                case int n when (n == 73):
                    return "Σουηδία";
                case int n when (n >= 80 && n <= 83):
                    return "Ιταλία";
                case int n when (n == 84):
                    return "Ισπανία";

                default:
                    return "Unknown";
            }
        }

        public static void CalculateCost(Product Prd, ref double PriceWithSupplyandTaxes, ref double Discount, ref double FinalPrice)
        {
            //5% supply cost added
            double supplyPrice = Prd.price * 1.05;

            double vatRate = 0.24; //default vat%

            var normlCategory = Prd.category.Normalize().ToLower();

            if (normlCategory.Equals("τρόφιμα".Normalize().ToLower()) || 
                normlCategory.Equals("Αναψυκτικά χωρίς αλκοόλ".Normalize().ToLower())){
                vatRate = 0.13;

            }else if (normlCategory.Equals("βιβλία".Normalize().ToLower())){
                vatRate = 0.06;
            }

            PriceWithSupplyandTaxes = supplyPrice * (1 + vatRate);

            Discount = PriceWithSupplyandTaxes * (Prd.discount / 100f);

            FinalPrice = Math.Round(PriceWithSupplyandTaxes - Discount,2);
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
