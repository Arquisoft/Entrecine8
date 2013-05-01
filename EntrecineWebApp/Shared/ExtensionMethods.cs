using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace EntrecineWebApp.Views.Shared
{
    public static class ExtensionMethods
    {
        public static MvcHtmlString RadioButtonForEnum<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool mostrarTodo
        )
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var names = Enum.GetNames(metaData.ModelType);
            var sb = new StringBuilder();
            foreach (var name in names)
            {

                var description = name;

                var memInfo = metaData.ModelType.GetMember(name);
                if (memInfo != null)
                {
                    var attributes = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                    if (attributes != null && attributes.Length > 0)
                        description = ((DisplayAttribute)attributes[0]).Name;
                }
                var id = string.Format(
                    "{0}_{1}_{2}",
                    htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix,
                    metaData.PropertyName,
                    name
                );

                var radio = htmlHelper.RadioButtonFor(expression, name, new { id = id }).ToHtmlString();
                sb.AppendFormat(
                    "{1} {2}",
                    id,
                    HttpUtility.HtmlEncode(description),
                    radio
                );

                if (!mostrarTodo) break;
            }
            return MvcHtmlString.Create(sb.ToString());
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}