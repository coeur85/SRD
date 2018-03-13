using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using KokiDB;
namespace KokiAccessorizeApp.Controllers.Api
{
    public class ProductsOrdersController : ApiController
    {


        KokiAccessorizeAppDBEntities db = new KokiAccessorizeAppDBEntities();

        public IHttpActionResult ProductInfo (WepApp.WebApi.Product model)
        {
            var pro = db.Products.FirstOrDefault(x => x.ProductID == model.ProductID);

            if (pro == null) { return NotFound(); }

            model.CostPrice = pro.CostPrice;
            model.Price = pro.Price;
            model.ProductName = pro.ProductName;
            return Ok(model);


        }


    }
}