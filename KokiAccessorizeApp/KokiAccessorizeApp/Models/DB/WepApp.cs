
using Newtonsoft.Json;

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

    


    namespace WebPagesModels
    {

        public class ProductDetails
        {

            public KokiDB.Product Product { get; set; }
            public decimal TotalsSales { get; set; }
            public int TotalOrders { get; set; }
            public int TotalCustomers { get; set; }

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