using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KokiDB;

namespace KokiAccessorizeApp.Controllers.Api
{
    public class PhotosController : ApiController
    {


        KokiAccessorizeAppDBEntities db = new KokiAccessorizeAppDBEntities();
        public IHttpActionResult UploadPhoto(WepApp.WebPagesModels.PhotoUpload model)
        {

            var p = db.Products.Find(model.ProductID);

            if (p == null) { return BadRequest(); }
            else
            {
                ProductPhoto photo = new ProductPhoto();
                photo.ProductID = p.ProductID;
                photo.Product = p;
                photo.PhotoBase64 = model.PhotoBase64;
                p.ProductPhotos.Add(photo);
                db.SaveChanges();


                return Ok();

            }


        }


    }
}
