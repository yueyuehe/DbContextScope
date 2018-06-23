using Common.Extensions;
using LayuiFW.Attributes;
using LayuiFW.Enums;
using LayuiFW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Helpers
{
    public class LayHtmlHelper
    {

        #region 辅助方法
        /// <summary>
        /// 添加 class
        /// </summary>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static IDictionary<string, object> AddLayUIClass(string classStr, IDictionary<string, object> htmlAttributes = null)
        {
            if (htmlAttributes == null)
            {
                htmlAttributes = new Dictionary<string, object>
                {
                    { "class", classStr }
                };
                return htmlAttributes;
            }
            if (htmlAttributes.Keys.Contains("class"))
            {
                htmlAttributes["class"] = htmlAttributes["class"] + " " + classStr;
            }
            else
            {
                htmlAttributes.Add("class", classStr);
            }
            return htmlAttributes;
        }

        public static IDictionary<string, object> AddLayUIClass(string classStr, object attrObject)
        {
            var htmlAttributes = attrObject.ToDictionary();
            if (htmlAttributes == null)
            {
                htmlAttributes = new Dictionary<string, object>
                {
                    { "class", classStr }
                };
                return htmlAttributes;
            }
            if (htmlAttributes.Keys.Contains("class"))
            {
                htmlAttributes["class"] = htmlAttributes["class"] + " " + classStr;
            }
            else
            {
                htmlAttributes.Add("class", classStr);
            }
            return htmlAttributes;
        }
        #endregion

        /// <summary>
        ///  获取input的属性
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, object> GetAttributtes(InputAttribute model)
        {
            IDictionary<string, object> dic = new Dictionary<string, object>
            {
                { "class", "layui-input" }
            };
            if (model == null)
                return dic;
            if (model.IsReadOnly)
            {
                dic.Add("readonly", "readonly");
            }
            if (model.IsRequired)
            {
                dic.Add("required", "required");
            }
            if (model.IsDisabled)
            {
                dic.Add("disabled", "disabled");
            }
            if (model.MaxNumber != null)
            {
                dic.Add("max", model.MaxNumber);
            }
            if (model.MinNumber != null)
            {
                dic.Add("min", model.MinNumber);
            }
            if (model.Name != null)
            {
                dic.Add("name", model.Name);
            }
            if (model.Id != null)
            {
                dic.Add("id", model.Id);
            }
            if (model.Placeholder != null)
            {
                dic.Add("placeholder", model.Placeholder);
            }
            if (model.Height != null)
            {
                dic.Add("height", model.Height);
            }
            if (model.Pattern != null)
            {
                dic.Add("pattern", model.Pattern);
            }
            if (model.Value != null)
            {
                dic.Add("value", model.Value);
            }
            if (model.Width != null)
            {
                dic.Add("width", model.Width);
            }
            if (model.Maxlength != null)
            {
                dic.Add("maxlength", model.Maxlength);
            }

            if (model.Verify != null && model.Verify.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in model.Verify)
                {
                    switch (item)
                    {
                        case VerifyType.Required:
                            sb.Append("required|");
                            break;
                        case VerifyType.Phone:
                            sb.Append("phone|");
                            break;
                        case VerifyType.Email:
                            sb.Append("email|");
                            break;
                        case VerifyType.Url:
                            sb.Append("url|");
                            break;
                        case VerifyType.Number:
                            sb.Append("number|");
                            break;
                        case VerifyType.Date:
                            sb.Append("date|");
                            break;
                        case VerifyType.Identity:
                            sb.Append("identity|");
                            break;
                        default:
                            break;
                    }
                }
                dic.Add("lay-verify", sb.Remove(sb.Length - 1, 1).ToString());

            }
            if (model.LayFilter != null)
            {
                dic.Add("lay-filter", model.LayFilter);
            }

            return dic;
        }

        public static IDictionary<string, object> GetAttributtes(LayTable model)
        {
            IDictionary<string, object> dic = new Dictionary<string, object>();
            if (model.Url != null)
            {
                dic.Add("url", model.Url);
            }
            if (model.Method != null)
            {
                dic.Add("method", model.Method);
            }

            if (model.Width != null)
            {
                dic.Add("width", model.Width);
            }
            if (model.Height != null)
            {
                dic.Add("height", model.Height);
            }
            if (model.CellMinWidth != null)
            {
                dic.Add("cellMinWidth", model.CellMinWidth);
            }
            if (model.Data != null)
            {
                dic.Add("data", model.Data);
            }

            if (model.Page)
            {
                dic.Add("page", model.Page);
            }
            if (model.Limit != null)
            {
                dic.Add("limit", model.Limit);
            }
            if (model.Limits != null)
            {
                dic.Add("limits", model.Limits);
            }
            dic.Add("loading", model.Loading);
            if (model.Text != null)
            {
                dic.Add("text", new { none = model.Text });
            }
            if (model.Sortfield != null)
            {
                dic.Add("initSort", new { field = model.Sortfield, type = model.SortType });
            }
            if (model.ControlId != null)
            {
                dic.Add("id", model.ControlId);
            }
            if (model.Even)
            {
                dic.Add("even", model.Even);
            }

            switch (model.Skin)
            {
                case SkinType.line:
                    dic.Add("skin", "line");
                    break;
                case SkinType.nob:
                    dic.Add("skin", "nob");
                    break;
                case SkinType.row:
                    dic.Add("skin", "row");
                    break;

                default: break;
            }

            switch (model.Size)
            {
                case SizeType.lg:
                    dic.Add("size", "lg");
                    break;
                case SizeType.sm:
                    dic.Add("size", "sm");
                    break;
                default: break;
            }

            return dic;
        }

        public static IDictionary<string, object> GetAttributtes(LayColumnAttribute model)
        {
            IDictionary<string, object> dic = new Dictionary<string, object>();
            if (model.Field != null)
            {
                dic.Add("field", model.Field);
            }
            if (model.Title != null)
            {
                dic.Add("title", model.Title);
            }
            if (model.Width != null)
            {
                dic.Add("width", model.Width);
            }
            if (model.MinWidth != null)
            {
                dic.Add("minWidth", model.MinWidth);
            }
            if (model.EventClick != null)
            {
                dic.Add("eventClick", model.EventClick);
            }
            if (model.Style != null)
            {
                dic.Add("style", model.Style);
            }
            if (model.Toolbar != null)
            {
                dic.Add("toolbar", model.Toolbar);
            }
            if (model.Templet != null)
            {
                dic.Add("templet", model.Templet);
            }

            if (model.Colspan != null)
            {
                dic.Add("colspan", model.Colspan);
            }

            if (model.Rowspan != null)
            {
                dic.Add("rowspan", model.Rowspan);
            }

            if (model.LAY_CHECKED)
            {
                dic.Add("LAY_CHECKED", model.LAY_CHECKED);
            }
            if (model.Sort)
            {
                dic.Add("sort", model.Sort);
            }
            if (model.Unresize)
            {
                dic.Add("unresize", model.Unresize);
            }
            switch (model.Type)
            {
                case ColumnType.checkbox:
                    dic.Add("type", "checkbox");
                    break;
                case ColumnType.normal:
                    dic.Add("type", "normal");
                    break;
                case ColumnType.numbers:
                    dic.Add("type", "numbers");
                    break;
                case ColumnType.space:
                    dic.Add("type", "space");
                    break;
                default:
                    break;
            }
            switch (model.FixedType)
            {
                case FixedType.df:

                    break;
                case FixedType.right:
                    dic.Add("fixed", "right");
                    break;
                case FixedType.left:
                    dic.Add("fixed", "left");
                    break;
                default:
                    break;
            }

            switch (model.Edit)
            {
                case EditType.Text:
                    dic.Add("edit", "text");
                    break;
                case EditType.NoEdit:

                    break;
                default:
                    break;
            }
            switch (model.Align)
            {
                case AlignType.center:
                    dic.Add("align", "center");
                    break;
                case AlignType.left:
                    dic.Add("align", "left");
                    break;
                case AlignType.right:
                    dic.Add("align", "right");
                    break;
                default:
                    break;
            }

            return dic;
        }

        /// <summary>
        /// 获取字段的特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propInfo"></param>
        /// <returns></returns>
        public static T GetPropertyAttributte<T>(PropertyInfo propInfo)
        {
            object[] objAttrs = propInfo.GetCustomAttributes(typeof(T), true);
            if (objAttrs.Length > 0)
            {
                return (T)objAttrs[0];
            }
            return default(T);

        }



    }
}
