using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Html
{
    public static class LayuiInputExtensions
    {
        public static MvcHtmlString CheckBox(this HtmlHelper htmlHelper, string name);
        public static MvcHtmlString CheckBox(this HtmlHelper htmlHelper, string name, bool isChecked);
        public static MvcHtmlString CheckBox(this HtmlHelper htmlHelper, string name, bool isChecked, object htmlAttributes);
        public static MvcHtmlString CheckBox(this HtmlHelper htmlHelper, string name, object htmlAttributes);
        public static MvcHtmlString CheckBox(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString CheckBox(this HtmlHelper htmlHelper, string name, bool isChecked, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression);
        public static MvcHtmlString CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes);
        public static MvcHtmlString CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString Hidden(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString Hidden(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes);
        public static MvcHtmlString Hidden(this HtmlHelper htmlHelper, string name, object value);
        public static MvcHtmlString Hidden(this HtmlHelper htmlHelper, string name);
        public static MvcHtmlString HiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression);
        public static MvcHtmlString HiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes);
        public static MvcHtmlString HiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString Password(this HtmlHelper htmlHelper, string name);
        public static MvcHtmlString Password(this HtmlHelper htmlHelper, string name, object value);
        public static MvcHtmlString Password(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes);
        public static MvcHtmlString Password(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString PasswordFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes);
        public static MvcHtmlString PasswordFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString PasswordFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression);
        public static MvcHtmlString RadioButton(this HtmlHelper htmlHelper, string name, object value);
        public static MvcHtmlString RadioButton(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes);
        public static MvcHtmlString RadioButton(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString RadioButton(this HtmlHelper htmlHelper, string name, object value, bool isChecked);
        public static MvcHtmlString RadioButton(this HtmlHelper htmlHelper, string name, object value, bool isChecked, object htmlAttributes);
        public static MvcHtmlString RadioButton(this HtmlHelper htmlHelper, string name, object value, bool isChecked, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value);
        public static MvcHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes);
        public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name, object value, string format, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name, object value, string format, object htmlAttributes);
        public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name, object value);
        public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name, object value, string format);
        public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name);
        public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes);
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes);
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes);
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression);
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format);
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, IDictionary<string, object> htmlAttributes);

    }

    public static class LayuiLabelExtensions
    {
        public static MvcHtmlString Label(this HtmlHelper html, string expression);
        public static MvcHtmlString Label(this HtmlHelper html, string expression, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString Label(this HtmlHelper html, string expression, object htmlAttributes);
        public static MvcHtmlString Label(this HtmlHelper html, string expression, string labelText);
        public static MvcHtmlString Label(this HtmlHelper html, string expression, string labelText, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString Label(this HtmlHelper html, string expression, string labelText, object htmlAttributes);
        internal static MvcHtmlString Label(this HtmlHelper html, string expression, string labelText, IDictionary<string, object> htmlAttributes, ModelMetadataProvider metadataProvider);
        internal static MvcHtmlString Label(this HtmlHelper html, string expression, string labelText, object htmlAttributes, ModelMetadataProvider metadataProvider);
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression);
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes);
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText);
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes);
        internal static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, IDictionary<string, object> htmlAttributes, ModelMetadataProvider metadataProvider);
        internal static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes, ModelMetadataProvider metadataProvider);
        public static MvcHtmlString LabelForModel(this HtmlHelper html);
        public static MvcHtmlString LabelForModel(this HtmlHelper html, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString LabelForModel(this HtmlHelper html, object htmlAttributes);
        public static MvcHtmlString LabelForModel(this HtmlHelper html, string labelText);
        public static MvcHtmlString LabelForModel(this HtmlHelper html, string labelText, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString LabelForModel(this HtmlHelper html, string labelText, object htmlAttributes);
        internal static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, string labelText = null, IDictionary<string, object> htmlAttributes = null);

    }

    public static class LayuiTextAreaExtensions
    {
        // Fields
        private static Dictionary<string, object> implicitRowsAndColumns;
        private const int TextAreaColumns = 20;
        private const int TextAreaRows = 2;

        // Methods
        //static TextAreaExtensions();
        private static Dictionary<string, object> GetRowsAndColumnsDictionary(int rows, int columns);
        public static MvcHtmlString TextArea(this HtmlHelper htmlHelper, string name);
        public static MvcHtmlString TextArea(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString TextArea(this HtmlHelper htmlHelper, string name, object htmlAttributes);
        public static MvcHtmlString TextArea(this HtmlHelper htmlHelper, string name, string value);
        public static MvcHtmlString TextArea(this HtmlHelper htmlHelper, string name, string value, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString TextArea(this HtmlHelper htmlHelper, string name, string value, object htmlAttributes);
        public static MvcHtmlString TextArea(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString TextArea(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, object htmlAttributes);
        public static MvcHtmlString TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression);
        public static MvcHtmlString TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes);
        public static MvcHtmlString TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, object htmlAttributes);
        internal static MvcHtmlString TextAreaHelper(HtmlHelper htmlHelper, ModelMetadata modelMetadata, string name, IDictionary<string, object> rowsAndColumns, IDictionary<string, object> htmlAttributes, string innerHtmlPrefix = null);
    }

    public static class LayuiSelectExtensions
    {
        // Methods
        public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name);
        public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList);
        public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, string optionLabel);
        public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes);
        public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, string optionLabel);
        public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes);
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList);
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes);
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel);
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes);
        private static MvcHtmlString DropDownListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes);
        private static IEnumerable<SelectListItem> GetSelectData(this HtmlHelper htmlHelper, string name);
        private static IEnumerable<SelectListItem> GetSelectListWithDefaultValue(IEnumerable<SelectListItem> selectList, object defaultValue, bool allowMultiple);
        public static MvcHtmlString ListBox(this HtmlHelper htmlHelper, string name);
        public static MvcHtmlString ListBox(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList);
        public static MvcHtmlString ListBox(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString ListBox(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes);
        public static MvcHtmlString ListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList);
        public static MvcHtmlString ListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString ListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes);
        private static MvcHtmlString ListBoxHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes);
        internal static string ListItemToOption(SelectListItem item);
        private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, ModelMetadata metadata, string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple, IDictionary<string, object> htmlAttributes);
    }




}
