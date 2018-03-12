namespace KokiDB
{


    public partial class Product
    {

        public string FullName {
            get
            {
                return ProductName = "#" + ProductID.ToString() + " - " + ProductName + " (" + ProductCategory.CategoryName + ")";
            }
        }


    }
}