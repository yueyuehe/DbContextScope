using LayuiFW.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LayuiFW.LayExtensions
{
    public static class TextAreaExtensions
    {
        private static string classStr = "layui-textarea";

        /// <summary>
        /// 通过使用指定的 HTML 帮助器、窗体字段的名称、文本内容、行数和列数以及指定的 HTML 特性，返回指定的 textarea 元素。
        /// </summary>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例</param>
        /// <param name="name"> 要返回的窗体字段的名称。</param>
        /// <returns> textarea 元素。</returns>
        public static MvcHtmlString LayTextArea(this HtmlHelper htmlHelper, string name)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr);
            return htmlHelper.TextArea(name, attrs);
        }

        /// <summary>
        /// 通过使用指定的 HTML 帮助器、窗体字段的名称、文本内容、行数和列数以及指定的 HTML 特性，返回指定的 textarea 元素。
        /// </summary>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例</param>
        /// <param name="name"> 要返回的窗体字段的名称。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> textarea 元素。</returns>
        public static MvcHtmlString LayTextArea(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return htmlHelper.TextArea(name, attrs);
        }

        /// <summary>
        /// 通过使用指定的 HTML 帮助器、窗体字段的名称、文本内容、行数和列数以及指定的 HTML 特性，返回指定的 textarea 元素。
        /// </summary>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例</param>
        /// <param name="name"> 要返回的窗体字段的名称。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> textarea 元素。</returns>
        public static MvcHtmlString LayTextArea(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return htmlHelper.TextArea(name, attrs);
        }

        /// <summary>
        /// 通过使用指定的 HTML 帮助器、窗体字段的名称、文本内容、行数和列数以及指定的 HTML 特性，返回指定的 textarea 元素。
        /// </summary>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例</param>
        /// <param name="name"> 要返回的窗体字段的名称。</param>
        /// <param name="value"> 文本内容。</param>
        /// <returns> textarea 元素。</returns>
        public static MvcHtmlString LayTextArea(this HtmlHelper htmlHelper, string name, string value)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr);
            return htmlHelper.TextArea(name, value, attrs);
        }

        /// <summary>
        /// 通过使用指定的 HTML 帮助器、窗体字段的名称、文本内容、行数和列数以及指定的 HTML 特性，返回指定的 textarea 元素。
        /// </summary>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例</param>
        /// <param name="name"> 要返回的窗体字段的名称。</param>
        /// <param name="value"> 文本内容。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> textarea 元素。</returns>
        public static MvcHtmlString LayTextArea(this HtmlHelper htmlHelper, string name, string value, object htmlAttributes)
        {

            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return htmlHelper.TextArea(name, value, attrs);
        }

        /// <summary>
        /// 通过使用指定的 HTML 帮助器、窗体字段的名称、文本内容、行数和列数以及指定的 HTML 特性，返回指定的 textarea 元素。
        /// </summary>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例</param>
        /// <param name="name"> 要返回的窗体字段的名称。</param>
        /// <param name="value"> 文本内容。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> textarea 元素。</returns>
        public static MvcHtmlString LayTextArea(this HtmlHelper htmlHelper, string name, string value, IDictionary<string, object> htmlAttributes)
        {

            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return htmlHelper.TextArea(name, value, attrs);
        }

        /// <summary>
        /// 通过使用指定的 HTML 帮助器、窗体字段的名称、文本内容、行数和列数以及指定的 HTML 特性，返回指定的 textarea 元素。
        /// </summary>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例</param>
        /// <param name="name"> 要返回的窗体字段的名称。</param>
        /// <param name="value"> 文本内容。</param>
        /// <param name="rows"> 行数。</param>
        /// <param name="columns">列数。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> textarea 元素。</returns>
        public static MvcHtmlString LayTextArea(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, object htmlAttributes)
        {

            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return htmlHelper.TextArea(name, value, rows, columns, attrs);
        }
   
        /// <summary>
        /// 通过使用指定的 HTML 帮助器、窗体字段的名称、文本内容、行数和列数以及指定的 HTML 特性，返回指定的 textarea 元素。
        /// </summary>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例</param>
        /// <param name="name"> 要返回的窗体字段的名称。</param>
        /// <param name="value"> 文本内容。</param>
        /// <param name="rows"> 行数。</param>
        /// <param name="columns">列数。</param>
        /// <param name="htmlAttributes"> 一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns> textarea 元素。</returns>
        public static MvcHtmlString LayTextArea(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, IDictionary<string, object> htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return htmlHelper.TextArea(name, value, rows, columns, attrs);
        }

        /// <summary>
        /// 使用指定 HTML 特性以及行数和列数，为由指定表达式表示的对象中的每个属性返回对应的 HTML textarea 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">属性的类型</typeparam>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression"> 一个表达式，用于标识包含要呈现的属性的对象。</param>
        /// <returns> 一个由表达式表示的对象中的每个属性所对应的 HTML textarea 元素。</returns>
        public static MvcHtmlString LayTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {

            var attrs = LayHtmlHelper.AddLayUIClass(classStr);
            return htmlHelper.TextAreaFor(expression, attrs);
        }

        /// <summary>
        /// 使用指定 HTML 特性以及行数和列数，为由指定表达式表示的对象中的每个属性返回对应的 HTML textarea 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">属性的类型</typeparam>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression"> 一个表达式，用于标识包含要呈现的属性的对象。</param>
        /// <param name="htmlAttributes">一个包含要为该元素设置的 HTML 特性的字典。</param>
        /// <returns> 一个由表达式表示的对象中的每个属性所对应的 HTML textarea 元素。</returns>
        public static MvcHtmlString LayTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return htmlHelper.TextAreaFor(expression, attrs);
        }

        /// <summary>
        /// 使用指定 HTML 特性以及行数和列数，为由指定表达式表示的对象中的每个属性返回对应的 HTML textarea 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">属性的类型</typeparam>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression"> 一个表达式，用于标识包含要呈现的属性的对象。</param>
        /// <param name="htmlAttributes">一个包含要为该元素设置的 HTML 特性的字典。</param>
        /// <returns> 一个由表达式表示的对象中的每个属性所对应的 HTML textarea 元素。</returns>
        public static MvcHtmlString LayTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return htmlHelper.TextAreaFor(expression, attrs);
        }

        /// <summary>
        /// 使用指定 HTML 特性以及行数和列数，为由指定表达式表示的对象中的每个属性返回对应的 HTML textarea 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">属性的类型</typeparam>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression"> 一个表达式，用于标识包含要呈现的属性的对象。</param>
        /// <param name="rows"> 行数。</param>
        /// <param name="columns">列数。</param>
        /// <param name="htmlAttributes">一个包含要为该元素设置的 HTML 特性的字典。</param>
        /// <returns> 一个由表达式表示的对象中的每个属性所对应的 HTML textarea 元素。</returns>
        public static MvcHtmlString LayTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, object htmlAttributes)
        {

            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return htmlHelper.TextAreaFor(expression, rows, columns, attrs);

        }
   
        /// <summary>
        /// 使用指定 HTML 特性以及行数和列数，为由指定表达式表示的对象中的每个属性返回对应的 HTML textarea 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">属性的类型</typeparam>
        /// <param name="htmlHelper"> 此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression"> 一个表达式，用于标识包含要呈现的属性的对象。</param>
        /// <param name="rows"> 行数。</param>
        /// <param name="columns">列数。</param>
        /// <param name="htmlAttributes">一个包含要为该元素设置的 HTML 特性的字典。</param>
        /// <returns> 一个由表达式表示的对象中的每个属性所对应的 HTML textarea 元素。</returns>
        public static MvcHtmlString LayTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, IDictionary<string, object> htmlAttributes)
        {
            var attrs = LayHtmlHelper.AddLayUIClass(classStr, htmlAttributes);
            return htmlHelper.TextAreaFor(expression, rows, columns, attrs);
        }
    }
}
