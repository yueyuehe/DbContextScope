using HWAdmin.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LayuiFW.Model;
using System.ComponentModel;
using HWAdmin.BLL.System;
using HWAdmin.Entity.System;
using HWAdmin.Common.Config.AppStr;
using HWAdmin.Common.Extensions;
using HWAdmin.IBLL.System;
using Mehdime.Entity.Enums;

namespace HWAdmin.Web.Controllers
{
    public class GroupManageController : Controller
    {
        private IGroupBLL bll;

        /// <summary>
        /// 跳转到主页
        /// </summary>
        /// <returns></returns>
        [Description("跳转到主页")]
        public ActionResult Index()
        {
            HttpContext.Items["HttpContext_Account_ID"] = "Account_ID";
            var model = new GroupModel();
            model.Url = "/GroupManage/GetList";
            //throw new Exception("故意的错误！");
            return View(model);
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetList(TableData pageModel)
        {
            //条件查询
            pageModel.count = bll.Count();
            var query = bll.FindPageList(p => true, p => p.CreateDate, OrderTypeOption.DESC, pageModel.page, pageModel.limit);
            pageModel.data = query.ToList().MapToList<Group, GroupModel>();
            var json = new JsonResult
            {
                Data = pageModel
            };
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
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
        /// 转到新增页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View("Edit");
        }

        /// <summary>
        /// 新增 and 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(GroupModel model)
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
                    oldModel = new Group
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = model.Name,
                        Description = model.Description
                    };
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
            var json = new JsonResult
            {
                Data = result
            };
            return json;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGroupTree()
        {
            TreeModel model = new TreeModel();
            model.elem = "#tree";
            model.nodes.AddRange(new List<Node>() { new Node() { name = "1111" }, new Node { name = "222" } });
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = model;
            return result;
        }

        public JsonResult GetTreeData()
        {
            var groups = bll.FindList(p => p.DeleteFlg == Entity.Enum.DeleteFlg.N);

            List<Node> list = new List<Node>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(new Node() { name = "tree" + i });
            }
            list[0].children.Add(new Node() { name = "ttt222" });
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = list;
            return result;
        }
    }
}
