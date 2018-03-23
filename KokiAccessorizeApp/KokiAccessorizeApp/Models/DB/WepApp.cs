
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WepApp
{

    public class InfoMessages
    {
       public enum messageType
        {
            Sucsess = 1,
            Error = 2
        }

        public messageType MessageType { get; set; }
        public string Message { get; set; }


    }

    public class categories
        {
            public string CategoryName { get; set; }
            public int ProductCount { get; set; }

        }
    public class OrderStatus
    {
        public string OrderSatuesNAme { get; set; }
        public int StatusID { get; set; }
        public int OrdersCount { get; set; }

    }


    namespace WebPagesModels
    {

        public class ProductDetails
        {

            public KokiDB.Product Product { get; set; }
            public decimal TotalsSales { get; set; }
            public int TotalOrders { get; set; }
            public int TotalCustomers { get; set; }
            public List<KokiDB.Order> Orders { get; set; }

            public ProductDetails() { Orders = new List<KokiDB.Order>(); }

        }
        public class PhotoUpload
        {
            public int ProductID { get; set; }
            public string PhotoBase64 { get; set; }

        }
        public class DeleteProduct
        {
            public KokiDB.Product Product { get; set; }
            public bool CanBeDleted { get; set; }

        }
        public class loginModel
        {
            public string username { get; set; }
            public string password { get; set; }
            public string message { get; set; }

        }
        public class DeleteCustomer
        {
            public KokiDB.Customer Customer { get; set; }
            public bool CanBeDleted { get; set; }

        }
        public class HomePage
        {
            public List<categories> Categories { get; set; }
            public List<OrderStatus> Orders { get; set; }


            public HomePage() { Categories = new List<categories>(); Orders = new List<OrderStatus>(); }
        }


       

    }


    namespace WebApi
    {

        public class Product
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int ProductID { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string ProductName { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public decimal Price { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public decimal CostPrice { get; set; }

        }



    }

}