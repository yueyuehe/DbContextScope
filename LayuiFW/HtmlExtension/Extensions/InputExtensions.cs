// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc.Properties;
using System.Web.Routing;

namespace System.Web.Mvc.Html
{
    public static class InputExtensions
    {
        // CheckBox

        public static MvcHtmlString CheckBox(this LayuiHelper htmlHelper, string name)
        {
            return CheckBox(htmlHelper, name, htmlAttributes: (object)null);
        }

        public static MvcHtmlString CheckBox(this LayuiHelper htmlHelper, string name, bool isChecked)
        {
            return CheckBox(htmlHelper, name, isChecked, htmlAttributes: (object)null);
        }

        public static MvcHtmlString CheckBox(this LayuiHelper htmlHelper, string name, bool isChecked, object htmlAttributes)
        {
            return CheckBox(htmlHelper, name, isChecked, LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString CheckBox(this LayuiHelper htmlHelper, string name, object htmlAttributes)
        {
            return CheckBox(htmlHelper, name, LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString CheckBox(this LayuiHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
        {
            return CheckBoxHelper(htmlHelper, metadata: null, name: name, isChecked: null, htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString CheckBox(this LayuiHelper htmlHelper, string name, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            return CheckBoxHelper(htmlHelper, metadata: null, name: name, isChecked: isChecked, htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString CheckBoxFor<TModel>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {
            return CheckBoxFor(htmlHelper, expression, htmlAttributes: null);
        }

        public static MvcHtmlString CheckBoxFor<TModel>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes)
        {
            return CheckBoxFor(htmlHelper, expression, LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString CheckBoxFor<TModel>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            bool? isChecked = null;
            if (metadata.Model != null)
            {
                bool modelChecked;
                if (Boolean.TryParse(metadata.Model.ToString(), out modelChecked))
                {
                    isChecked = modelChecked;
                }
            }

            return CheckBoxHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), isChecked, htmlAttributes);
        }

        private static MvcHtmlString CheckBoxHelper(LayuiHelper htmlHelper, ModelMetadata metadata, string name, bool? isChecked, IDictionary<string, object> htmlAttributes)
        {
            RouteValueDictionary attributes = ToRouteValueDictionary(htmlAttributes);

            bool explicitValue = isChecked.HasValue;
            if (explicitValue)
            {
                attributes.Remove("checked"); // Explicit value must override dictionary
            }

            return InputHelper(htmlHelper,
                               InputType.CheckBox,
                               metadata,
                               name,
                               value: "true",
                               useViewData: !explicitValue,
                               isChecked: isChecked ?? false,
                               setId: true,
                               isExplicitValue: false,
                               format: null,
                               htmlAttributes: attributes);
        }

        // Hidden

        public static MvcHtmlString Hidden(this LayuiHelper htmlHelper, string name)
        {
            return Hidden(htmlHelper, name, value: null, htmlAttributes: null);
        }

        public static MvcHtmlString Hidden(this LayuiHelper htmlHelper, string name, object value)
        {
            return Hidden(htmlHelper, name, value, htmlAttributes: null);
        }

        public static MvcHtmlString Hidden(this LayuiHelper htmlHelper, string name, object value, object htmlAttributes)
        {
            return Hidden(htmlHelper, name, value, LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Hidden(this LayuiHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            return HiddenHelper(htmlHelper,
                                metadata: null,
                                value: value,
                                useViewData: value == null,
                                expression: name,
                                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString HiddenFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return HiddenFor(htmlHelper, expression, (IDictionary<string, object>)null);
        }

        public static MvcHtmlString HiddenFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return HiddenFor(htmlHelper, expression, LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString HiddenFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return HiddenHelper(htmlHelper,
                                metadata,
                                metadata.Model,
                                false,
                                ExpressionHelper.GetExpressionText(expression),
                                htmlAttributes);
        }

        private static MvcHtmlString HiddenHelper(LayuiHelper htmlHelper, ModelMetadata metadata, object value, bool useViewData, string expression, IDictionary<string, object> htmlAttributes)
        {
            Binary binaryValue = value as Binary;
            if (binaryValue != null)
            {
                value = binaryValue.ToArray();
            }

            byte[] byteArrayValue = value as byte[];
            if (byteArrayValue != null)
            {
                value = Convert.ToBase64String(byteArrayValue);
            }

            return InputHelper(htmlHelper,
                               InputType.Hidden,
                               metadata,
                               expression,
                               value,
                               useViewData,
                               isChecked: false,
                               setId: true,
                               isExplicitValue: true,
                               format: null,
                               htmlAttributes: htmlAttributes);
        }

        // Password

        public static MvcHtmlString Password(this LayuiHelper htmlHelper, string name)
        {
            return Password(htmlHelper, name, value: null);
        }

        public static MvcHtmlString Password(this LayuiHelper htmlHelper, string name, object value)
        {
            return Password(htmlHelper, name, value, htmlAttributes: null);
        }

        public static MvcHtmlString Password(this LayuiHelper htmlHelper, string name, object value, object htmlAttributes)
        {
            return Password(htmlHelper, name, value, LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Password(this LayuiHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            return PasswordHelper(htmlHelper, metadata: null, name: name, value: value, htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString PasswordFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return PasswordFor(htmlHelper, expression, htmlAttributes: null);
        }

        public static MvcHtmlString PasswordFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return PasswordFor(htmlHelper, expression, LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString PasswordFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return PasswordHelper(htmlHelper,
                                  ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData),
                                  ExpressionHelper.GetExpressionText(expression),
                                  value: null,
                                  htmlAttributes: htmlAttributes);
        }

        private static MvcHtmlString PasswordHelper(LayuiHelper htmlHelper, ModelMetadata metadata, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            return InputHelper(htmlHelper,
                               InputType.Password,
                               metadata,
                               name,
                               value,
                               useViewData: false,
                               isChecked: false,
                               setId: true,
                               isExplicitValue: true,
                               format: null,
                               htmlAttributes: htmlAttributes);
        }

        #region RadioButton

        public static MvcHtmlString RadioButton(this LayuiHelper htmlHelper, string name, object value)
        {
            return RadioButton(htmlHelper, name, value, htmlAttributes: (object)null);
        }

        public static MvcHtmlString RadioButton(this LayuiHelper htmlHelper, string name, object value, object htmlAttributes)
        {
            return RadioButton(htmlHelper, name, value, LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString RadioButton(this LayuiHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            // Determine whether or not to render the checked attribute based on the contents of ViewData.
            string valueString = Convert.ToString(value, CultureInfo.CurrentCulture);
            bool isChecked = (!String.IsNullOrEmpty(name)) && (String.Equals(htmlHelper.EvalString(name), valueString, StringComparison.OrdinalIgnoreCase));
            // checked attributes is implicit, so we need to ensure that the dictionary takes precedence.
            RouteValueDictionary attributes = ToRouteValueDictionary(htmlAttributes);
            if (attributes.ContainsKey("checked"))
            {
                return InputHelper(htmlHelper,
                                   InputType.Radio,
                                   metadata: null,
                                   name: name,
                                   value: value,
                                   useViewData: false,
                                   isChecked: false,
                                   setId: true,
                                   isExplicitValue: true,
                                   format: null,
                                   htmlAttributes: attributes);
            }

            return RadioButton(htmlHelper, name, value, isChecked, htmlAttributes);
        }

        public static MvcHtmlString RadioButton(this LayuiHelper htmlHelper, string name, object value, bool isChecked)
        {
            return RadioButton(htmlHelper, name, value, isChecked, htmlAttributes: (object)null);
        }

        public static MvcHtmlString RadioButton(this LayuiHelper htmlHelper, string name, object value, bool isChecked, object htmlAttributes)
        {
            return RadioButton(htmlHelper, name, value, isChecked, LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString RadioButton(this LayuiHelper htmlHelper, string name, object value, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            // checked attribute is an explicit parameter so it takes precedence.
            RouteValueDictionary attributes = ToRouteValueDictionary(htmlAttributes);
            attributes.Remove("checked");
            return InputHelper(htmlHelper,
                               InputType.Radio,
                               metadata: null,
                               name: name,
                               value: value,
                               useViewData: false,
                               isChecked: isChecked,
                               setId: true,
                               isExplicitValue: true,
                               format: null,
                               htmlAttributes: attributes);
        }

        public static MvcHtmlString RadioButtonFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value)
        {
            return RadioButtonFor(htmlHelper, expression, value, htmlAttributes: null);
        }

        public static MvcHtmlString RadioButtonFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes)
        {
            return RadioButtonFor(htmlHelper, expression, value, LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString RadioButtonFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return RadioButtonHelper(htmlHelper,
                                     metadata,
                                     metadata.Model,
                                     ExpressionHelper.GetExpressionText(expression),
                                     value,
                                     null /* isChecked */,
                                     htmlAttributes);
        }

        private static MvcHtmlString RadioButtonHelper(LayuiHelper htmlHelper, ModelMetadata metadata, object model, string name, object value, bool? isChecked, IDictionary<string, object> htmlAttributes)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            RouteValueDictionary attributes = ToRouteValueDictionary(htmlAttributes);

            bool explicitValue = isChecked.HasValue;
            if (explicitValue)
            {
                attributes.Remove("checked"); // Explicit value must override dictionary
            }
            else
            {
                string valueString = Convert.ToString(value, CultureInfo.CurrentCulture);
                isChecked = model != null &&
                            !String.IsNullOrEmpty(name) &&
                            String.Equals(model.ToString(), valueString, StringComparison.OrdinalIgnoreCase);
            }

            return InputHelper(htmlHelper,
                               InputType.Radio,
                               metadata,
                               name,
                               value,
                               useViewData: false,
                               isChecked: isChecked ?? false,
                               setId: true,
                               isExplicitValue: true,
                               format: null,
                               htmlAttributes: attributes);
        }
        #endregion





        #region TextBox

        public static MvcHtmlString TextBox(this LayuiHelper htmlHelper, string name)
        {
            return TextBox(htmlHelper, name, value: null);
        }

        public static MvcHtmlString TextBox(this LayuiHelper htmlHelper, string name, object value)
        {
            return TextBox(htmlHelper, name, value, format: null);
        }

        public static MvcHtmlString TextBox(this LayuiHelper htmlHelper, string name, object value, string format)
        {
            return TextBox(htmlHelper, name, value, format, htmlAttributes: (object)null);
        }

        public static MvcHtmlString TextBox(this LayuiHelper htmlHelper, string name, object value, object htmlAttributes)
        {
            return TextBox(htmlHelper, name, value, format: null, htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString TextBox(this LayuiHelper htmlHelper, string name, object value, string format, object htmlAttributes)
        {
            HtmlHelper html = new HtmlHelper(htmlHelper.ViewContext, htmlHelper.ViewDataContainer, htmlHelper.RouteCollection);
            return html.TextBox(name, value, format, htmlAttributes);
        }

        public static MvcHtmlString TextBox(this LayuiHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            return TextBox(htmlHelper, name, value, format: null, htmlAttributes: htmlAttributes);
        }


        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.TextBoxFor(expression, format: null);
        }

        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format)
        {
            return htmlHelper.TextBoxFor(expression, format, (IDictionary<string, object>)null);
        }

        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return htmlHelper.TextBoxFor(expression, format: null, htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            return htmlHelper.TextBoxFor(expression, format: format, htmlAttributes: LayuiHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.TextBoxFor(expression, format: null, htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this LayuiHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, IDictionary<string, object> htmlAttributes)
        {
            HtmlHelper<TModel> html = new HtmlHelper<TModel>(htmlHelper.ViewContext, htmlHelper.ViewDataContainer, htmlHelper.RouteCollection);
            return html.TextBoxFor<TModel, TProperty>(expression, format, htmlAttributes);
        }
        #endregion
    }
}
