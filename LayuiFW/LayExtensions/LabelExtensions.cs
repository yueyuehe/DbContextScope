using LayuiFW.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;

namespace LayuiFW.LayExtensions
{
    public static class LabelExtensions
    {


        private static string classStr = "layui-form-label";
     
        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <typeparam name="TModel"> 模型的类型。</typeparam>
        /// <typeparam name="TValue"> 值的类型。</typeparam>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr);
            return html.LabelFor(expression, attrs);
        }

        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <typeparam name="TModel"> 模型的类型。</typeparam>
        /// <typeparam name="TValue"> 值的类型。</typeparam>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return html.LabelFor(expression, attrs);
        }

        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <typeparam name="TModel"> 模型的类型。</typeparam>
        /// <typeparam name="TValue"> 值的类型。</typeparam>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return html.LabelFor(expression, attrs);
        }

        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <typeparam name="TModel"> 模型的类型。</typeparam>
        /// <typeparam name="TValue"> 值的类型。</typeparam>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <param name="labelText">  要显示的标签文本。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr);
            return html.LabelFor(expression, labelText, attrs);
        }

        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <typeparam name="TModel"> 模型的类型。</typeparam>
        /// <typeparam name="TValue"> 值的类型。</typeparam>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <param name="labelText">  要显示的标签文本。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return html.LabelFor(expression, labelText, attrs);
        }

        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <typeparam name="TModel"> 模型的类型。</typeparam>
        /// <typeparam name="TValue"> 值的类型。</typeparam>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <param name="labelText">  要显示的标签文本。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, IDictionary<string, object> htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return html.LabelFor(expression, labelText, attrs);
        }

        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabel(this HtmlHelper html, string expression)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr);
            return html.Label(expression, attrs);
        }
     
        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <param name="labelText">  要显示的标签文本。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabel(this HtmlHelper html, string expression, string labelText)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr);
            return html.Label(expression, labelText, attrs);
        }

        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabel(this HtmlHelper html, string expression, object htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return html.Label(expression, attrs);
        }

        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabel(this HtmlHelper html, string expression, IDictionary<string, object> htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return html.Label(expression, attrs);
        }

        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <param name="labelText">  要显示的标签文本。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabel(this HtmlHelper html, string expression, string labelText, object htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return html.Label(expression, labelText, attrs);
        }

        /// <summary>
        /// 返回一个 HTML label 元素以及由指定表达式表示的属性的属性名称
        /// </summary>
        /// <param name="html">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识要显示的属性。</param>
        /// <param name="labelText">  要显示的标签文本。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> 一个 HTML label 元素以及由表达式表示的属性的属性名称。</returns>
        public static MvcHtmlString LayLabel(this HtmlHelper html, string expression, string labelText, IDictionary<string, object> htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return html.Label(expression, labelText, attrs);
        }

    }
}
