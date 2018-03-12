
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

    }

}