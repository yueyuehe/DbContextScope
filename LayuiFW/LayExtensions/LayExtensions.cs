using Common.Extensions;
using Common.Helpers;
using LayuiFW.Attributes;
using LayuiFW.Enums;
using LayuiFW.Helpers;
using LayuiFW.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace System.Web.Mvc
{
    public static class LayExtensions
    {
        /// <summary>
        /// 一个控件
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="attrs"></param>
        /// <returns></returns>
        public static MvcHtmlString LayInputFor<TModel, TResult>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, object attrs = null) where TModel : new()
        {
            var model = htmlHelper.ViewData.Model == null ? new TModel() : htmlHelper.ViewData.Model;

            var value = model == null ? default(TResult) : expression.Compile()(model);
            var member = expression.Body as MemberExpression;
            var proname = "";
            if (member != null)
            {
                proname = member.Member.Name;
            }
            else
            {
                throw new ArgumentException(
                    "'" + expression + "': is not a valid expression for this method");
            }
            //字段类型
            var propInfo = model.GetType().GetProperty(proname);
            var inputModel = LayHtmlHelper.GetPropertyAttributte<InputAttribute>(propInfo) ?? new InputAttribute();
            var des = LayHtmlHelper.GetPropertyAttributte<DescriptionAttribute>(propInfo);
            var attrDic = LayHtmlHelper.GetAttributtes(inputModel);
            if (attrs != null)
            {
                attrDic.Merge(attrs.ToDictionary(), true);
            }
            //判断是否有name属性
            if (!attrDic.ContainsKey("name"))
            {
                attrDic.Add("name", proname);
            }
            //id 属性
            if (!attrDic.ContainsKey("id"))
            {
                attrDic.Add("id", proname);
            }
            //LayFilter 
            if (!attrDic.ContainsKey("LayFilter"))
            {
                attrDic.Add("LayFilter", proname);
            }

            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(attrDic);
            var mainHtml = new TagBuilder("div");
            mainHtml.AddCssClass("layui-form-item");
            var lab = new TagBuilder("label");
            lab.AddCssClass("layui-form-label");
            lab.InnerHtml = des == null ? "" : des.Description;
            var div2 = new TagBuilder("div");

            if (inputModel.DisplayType == DisplayType.block)
            {
                div2.AddCssClass("layui-input-block");
            }
            if (inputModel.DisplayType == DisplayType.inline)
            {
                div2.AddCssClass("layui-input-inline");
            }
            div2.InnerHtml = tagBuilder.ToString();
            mainHtml.InnerHtml = lab.ToString() + div2.ToString();
            return new MvcHtmlString(mainHtml.ToString());
            /*
            < div class="layui-form-item">
                <label class="layui-form-label">输入框</label>
                <div class="layui-input-block">
                     <input type = "text" name="" placeholder="请输入" autocomplete="off" class="layui-input">
                </div>
            </div>
            */
        }

        /// <summary>
        /// table
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="attrs"></param>
        /// <returns></returns>
        public static MvcHtmlString LayTableFor<TModel>(this HtmlHelper<TModel> htmlHelper) where TModel : LayTable, new()
        {
            var model = htmlHelper.ViewData.Model;
            return LayTable(htmlHelper, model);
        }

        public static MvcHtmlString LayTable<TModel>(this HtmlHelper htmlHelper, TModel model) where TModel : LayTable
        {
            //< table id = "demo" lay - filter = "test" ></ table >
            TagBuilder tagBuilder = new TagBuilder("table");
            tagBuilder.MergeAttribute("id", model.ControlId);
            tagBuilder.MergeAttribute("layui", "");
            var mainOption = LayHtmlHelper.GetAttributtes(model);
            List<IDictionary<string, object>> arr = new List<IDictionary<string, object>>();
            foreach (var item in model.GetType().GetProperties())
            {
                var attr = LayHtmlHelper.GetPropertyAttributte<LayColumnAttribute>(item);

                if (attr != null)
                {
                    if (attr.Field == null)
                    {
                        attr.Field = item.Name;
                    }
                    arr.Add(LayHtmlHelper.GetAttributtes(attr));
                }
            }
            mainOption.Add("cols", new object[] { arr });
            tagBuilder.MergeAttribute("lay-options", JsonHelper.Instance.Serialize(mainOption));
            return new MvcHtmlString(tagBuilder.ToString());
        }
        /*
        public static MvcHtmlString LayTree<TModel>(this HtmlHelper<TModel> htmlHelper) where TModel : TreeModel, new()
        {
            var model = htmlHelper.ViewData.Model == null ? new TModel() : htmlHelper.ViewData.Model;
            return LayTree(htmlHelper, model);
        }
        
        public static MvcHtmlString LayTree<TModel>(this HtmlHelper htmlHelper, TModel model)
        {
            TagBuilder tagBuilder = new TagBuilder("table");
            tagBuilder.MergeAttribute("id", model.Id);
            var mainOption = LayHtmlHelper.GetAttributtes(model);
            List<IDictionary<string, object>> arr = new List<IDictionary<string, object>>();
            foreach (var item in model.GetType().GetProperties())
            {
                var attr = LayHtmlHelper.GetPropertyAttributte<LayColumnAttribute>(item);
                if (attr != null)
                {
                    arr.Add(LayHtmlHelper.GetAttributtes(attr));
                }
            }
            mainOption.Add("cols", new object[] { arr });
            tagBuilder.MergeAttribute("lay-options", JsonHelper.Instance.Serialize(mainOption));
            return new MvcHtmlString(tagBuilder.ToString());
        }
        */
    }
}
