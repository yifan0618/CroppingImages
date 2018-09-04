using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CroppingImages.Controllers
{
    public class CroppingImagesController : Controller
    {
        // GET: CroppingImages
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 接收前台传来的Base64编码
        /// </summary>
        public ActionResult UploadBase()
        {
            Stream ms = Request.Files["avatar"].InputStream;
            Bitmap bmp = new Bitmap(ms);
            var fileName = Guid.NewGuid().ToString().Substring(0,8); //也可以取当前时间作为图片名称
            var fileDir = "/upload/";
            var filePath = fileDir + fileName + ".png";
            if (Directory.Exists(Server.MapPath(fileDir)) == false) //如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(Server.MapPath(fileDir));
            }
            bmp.Save(Server.MapPath(filePath), ImageFormat.Png);
            if (System.IO.File.Exists(Server.MapPath(filePath)))    //判断图片是否保存成功
            {
                return Content(filePath);
            }
            else
            {
                return Content("failure");
            }
        }
    }
}