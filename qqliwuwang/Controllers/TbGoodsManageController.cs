using HWAdmin.Common.Extensions;
using HWAdmin.Common.Model;
using Gift;
using LayuiFW.Model;
using qqliwuwang.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/**
 * 功能:增删查该改
 * 
 * 转到编辑页面 转到添加页面
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
namespace qqliwuwang.Controllers
{
    public class TbGoodsManageController : Controller
    {
        /// <summary>
        /// 商品类操作对象
        /// </summary>
        TbGoodsManage bll = new TbGoodsManage();

        /// <summary>
        /// 转到列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = new Qq_Article();
            return View(model);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <returns></returns>
        public ActionResult TbGoodsData(BsPageRequest pageModel, Qq_TbGood queryModel)
        {
            var page = bll.Page(pageModel.PageNum, pageModel.Limit, queryModel, pageModel.Sort, pageModel.Order);
            BsPageResponse resData = new BsPageResponse();
            resData.rows = page.Items;
            resData.total = page.TotalItems;
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = resData;
            return result;
        }


        // GET: TbGoodsManage/Details/5
        public ActionResult Details(int id)
        {
            var model = bll.FindById(id);
            return View(model);
        }


        // GET: TbGoodsManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new Qq_TbGood());
            }
            else
            {
                var model = bll.FindById(id.Value);
                if (string.IsNullOrWhiteSpace(model.ShowImageUrl))
                {
                    model.ShowImageUrl = "/Image/slt.png";
                }
                else
                {
                    model.ShowImageUrl = Path.Combine(Server.MapPath("~"), model.ShowImageUrl);
                }
                return View(model);
            }
        }

        // POST: TbGoodsManage/Edit/5
        [HttpPost]
        public ActionResult Edit(Qq_TbGood model)
        {
            try
            {
                var entity = bll.FindById(model.Id);
                entity.Title = model.Title;
                entity.HeadContent = model.HeadContent;
                entity.DeleteFlag = model.DeleteFlag;
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files.Get(0);
                    var filepath = new FileManage().CreateFileName(ImageType.Goods, file.FileName);
                    file.SaveAs(filepath);
                    entity.ShowImageUrl = filepath;
                }
                bll.Save(entity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        // POST: TbGoodsManage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <returns></returns>
        public ActionResult Upload()
        {
            //返回的数据模型
            var res = new Response();
            JsonResult jr = new JsonResult();
            jr.Data = res;

            if (Request.Files.Count == 0)
            {
                res.Status = false;
                res.Message = "操作失败:没有检测到上传的文件！";
                return jr;
            }
            try
            {
                var file = Request.Files[0];
                if (!file.FileName.EndsWith(".xls"))
                {
                    res.Message = "操作失败:文件不是.xls类型！";
                    return jr;
                }
                var dt = HWAdmin.Common.Helpers.NPOIHelper.ImportExceltoDt(file.InputStream);
                ///换列名称
                if (dt.Rows.Count > 0)
                {
                    ///移出第一行
                    dt.Rows.RemoveAt(0);
                    //进行数据绑定 datatable->list
                    var list = dt.ToList<Qq_TbGood>();
                    //补充数据
                    for (var i = 0; i < list.Count; i++)
                    {
                        if (string.IsNullOrWhiteSpace(list[i].GoodsNumber))
                        {
                            list.RemoveAt(i--);
                        }
                    }
                    foreach (var item in list)
                    {
                        item.CreateTime = DateTime.Now;
                        item.UpdateTime = item.CreateTime;
                        if (item.IsPlanGoods == "是")
                        {
                            item.IsPlanGoods = "1";
                        }
                        else
                        {
                            item.IsPlanGoods = "0";
                        }
                    }
                    bll.Save(list);
                }
                else
                {
                    res.Status = false;
                    res.Message = "操作失败:excel中没有可导入的数据！";
                    return jr;
                }
                res.Status = true;
                res.Message = "操作成功!";
                return jr;
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Message = "操作失败:" + ex.Message;
                return jr;
            }
        }

        /// <summary>
        /// 下载模板
        /// </summary>
        public void DownloadTemplete()
        {
            var root = Server.MapPath("~");
            var path = Path.Combine(root, "App_Data/Template/淘宝商品导入模板.xls");
            HWAdmin.Common.Helpers.NPOIHelper.ExportByWeb(path, "淘宝商品导入模板.xls");
        }

        /// <summary>
        /// 转到上传页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Import()
        {
            return View();
        }
    }
}
