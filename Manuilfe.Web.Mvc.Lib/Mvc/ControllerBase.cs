using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace Manulife.Web.Mvc.Lib.Mvc
{
    /// <summary>
    /// 控制器基类，封装共有特性与共有方法
    /// </summary>
    public abstract class ControllerBase : IController
    {
        protected HttpContext Context { get; set; }
        protected IDictionary<string, object> RouteData { get; set; }

        public virtual ActionResult Execute(RequestContext context)
        {
            this.Context = context.HttpContext;
            this.RouteData = context.RouteData;
            // 获取ActionName
            var actionName = RouteData["action"].ToString();
            if (string.IsNullOrEmpty(actionName))
            {
                //actionName = RouteData["defaults"];
            }
            // 先找到当前类中的所有方法
            var methods = this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            MethodInfo method = null;
            foreach (var item in methods)
            {
                if (item.Name.Equals(actionName, StringComparison.InvariantCultureIgnoreCase))
                {
                    method = item;
                    break;
                }
            }
            // 如果没有找到指定的action方法
            if (method == null)
            {
                throw new HttpException(404, "Not Found");
            }

            List<object> values = new List<object>();
            var parameters = method.GetParameters();

            foreach (var parameter in parameters)
            {
                var name = parameter.Name;
                var type = parameter.ParameterType;
                // 参数来源：1.Form表单    2.QueryString   3.RouteData
                var value = Context.Request[name];
                if (string.IsNullOrEmpty(value))
                {
                    value = RouteData.ContainsKey(name) ? RouteData[name].ToString() : null;
                }

                if (!string.IsNullOrEmpty(value))
                {
                    // 值类型转换
                    values.Add(Convert.ChangeType(value, type));
                }
                else
                {
                    values.Add(null);
                }
            }

            ActionResult result = method.Invoke(this, values.ToArray()) as ActionResult;
            return result;
        }
    }
}
