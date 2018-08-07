using Common.Helpers;
using Common.Model;
using qqliwuwang.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qqliwuwang.Controllers
{
    public class FileUploadController : Controller
    {

        // GET: FileUp
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 上传单个文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FileUploadSingle()
        {
            SimditorUploadReturnModel returnModel = new SimditorUploadReturnModel();
            var path = "";
            try
            {
                if (Request.Files.Count == 0)
                {
                    throw new Exception("未检测到上传的文件!");
                }
                var item = Request.Files[0];

                var root = PathHepler.WebRoot();
                var folder = Common.Helpers.CommonHelper.CreateFolderPath(PathType.Month);

                folder = Path.Combine("Image", folder);
                var fileName = Common.Helpers.CommonHelper.CreateNewFileName(item.FileName);
                path = Path.Combine(root, folder, fileName);
                if (!FileHelper.IsExistDirectory(Path.Combine(root, folder)))
                {
                    FileHelper.CreateDirectory(Path.Combine(root, folder));
                }
                item.SaveAs(path);
                returnModel.file_path = Path.Combine(ConfigManagerHelper.GetConfigValue("DoMain"), folder, fileName);
                if (!returnModel.file_path.StartsWith("http") && !returnModel.file_path.StartsWith("/"))
                {
                    returnModel.file_path = "/" + returnModel.file_path;
                }

                returnModel.success = true;
            }
            catch (Exception ex)
            {
                returnModel.msg = ex.Message;
                returnModel.success = false;
                if (string.IsNullOrWhiteSpace(path))
                {
                    path = "/Image/slt.png";
                }
                returnModel.file_path = Path.Combine(ConfigManagerHelper.GetConfigValue("DoMain"), path);
            }
            JsonResult jr = new JsonResult();
            jr.Data = returnModel;
            return jr;
        }

        /// <summary>
        /// 下载网络上的文件
        /// </summary>
        /// <returns></returns>
        public ActionResult DownloadWebFile(string url)
        {
            ResponseData res = new ResponseData();
            if (string.IsNullOrEmpty(url))
            {
                res.Message = "url格式不正确!";
                res.Success = false;
            }
            try
            {
                var returnUrl = DownHelper.DownLoadFile(url);
                var obj = new { Url = returnUrl };
                res.UserData = obj;
            }
            catch (Exception ex)
            {
                res.Message = url + ":" + ex.Message;
                res.Success = false;
            }
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            jr.Data = res;
            return jr;

        }
    }
}