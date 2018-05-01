using Authority.BLL;
using Authority.Entity;
using HWAdmin.Models;
using HWAdmin.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HWAdmin.Controllers
{
    public class GroupManageController : Controller
    {
        private GroupBLL bll = new GroupBLL();

        /// <summary>
        /// 跳转到主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetList(PageResponse pageModel)
        {
            //条件查询
            var query = bll.FindPageList(p => true, p => p.CreateDate, false, pageModel.page, pageModel.limit);
            pageModel.data = query.ToList();
            var json = new JsonResult();
            json.Data = pageModel;
            return json;
        }

        /// <summary>
        /// 显示该组织成员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            //获取相关的账号
            var memberAccount = bll.FindOne(p => p.Id == id).Accounts;
            //根据账号获取相关信息



            return View();
        }

        /// <summary>
        /// 转到编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            var model = bll.FindOne(p => p.Id == id);
            return View(model);
        }

        /// <summary>
        /// 新增 and 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(GroupModelView model)
        {
            var result = new MsgResponse();
            try
            {
                var oldModel = bll.FindOne(p => p.Id == model.Id);
                if (oldModel != null)
                {
                    oldModel.Name = model.Name;
                    oldModel.Description = model.Description;
                    bll.Update(oldModel);
                    result.Message = "修改成功";
                }
                else
                {
                    oldModel = new Group();
                    oldModel.Id = Guid.NewGuid().ToString();
                    oldModel.Name = model.Name;
                    oldModel.Description = model.Description;
                    bll.Add(oldModel);
                    result.Message = "保存成功";
                }
                result.Status = true;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "操作失败 " + ex.Message;
            }
            JsonResult json = new JsonResult();
            json.Data = result;
            return json;
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(string ids)
        {
            var result = new MsgResponse();
            try
            {
                var idArr = ids.Split(',');
                bll.RemoveByIds(idArr);
                result.Status = true;
                result.Message = "删除成功";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "删除失败 " + ex.Message;
            }
            var json = new JsonResult();
            json.Data = result;
            return json;
        }
    }
}
