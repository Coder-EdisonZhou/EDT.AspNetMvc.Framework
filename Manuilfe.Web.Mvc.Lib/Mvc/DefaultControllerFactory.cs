using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Compilation;

namespace Manulife.Web.Mvc.Lib.Mvc
{
    public static class DefaultControllerFactory
    {
        /// <summary>
        /// 当前项目中所有的控制类型实例
        /// </summary>
        public static IList<Type> AllControllerTypes
        {
            get;
            set;
        }

        /// <summary>
        /// 静态构造函数：当前类第一次加载时会调用静态构造函数
        /// </summary>
        static DefaultControllerFactory()
        {
            AllControllerTypes = new List<Type>();
            // 获得当前所有引用的程序集
            var assemblies = BuildManager.GetReferencedAssemblies();
            // 遍历所有的程序集
            foreach (Assembly assembly in assemblies)
            {
                // 获取当前程序集中所有的类型
                var allTypes = assembly.GetTypes();
                // 遍历所有的类型
                foreach (Type type in allTypes)
                {
                    // 如果当前类型满足条件
                    if (type.IsClass && !type.IsAbstract && type.IsPublic
                        && typeof(IController).IsAssignableFrom(type))
                    {
                        // 将所有Controller加入集合
                        AllControllerTypes.Add(type);
                    }
                }
            }
        }

        /// <summary>
        /// 静态方法：创建控制器
        /// </summary>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public static IController CreateController(string controllerName)
        {
            #region v1.0 简单工厂实现
            //IController controller = null;
            //switch (controllerName.ToLower())
            //{
            //    case "member":
            //        controller = new MemberController();
            //        break;
            //    case "product":
            //        controller = new ProductController();
            //        break;
            //    default:
            //        break;
            //}
            //return controller; 
            #endregion

            #region v2.0 抽象工厂实现第一版
            // 借助反射实现抽象工厂
            //var controllerTypeName = string.Format("Manulife.Web.Mvc.Controllers.{0}Controller", controllerName);
            //IController controller = Assembly.GetExecutingAssembly().CreateInstance(controllerTypeName, true) as IController;
            //return controller;
            #endregion

            #region v2.1 抽象工厂实现第二版
            IController controller = null;
            // 通过反射的方式加载具体实例
            foreach (var controllerItem in AllControllerTypes)
            {
                if (controllerItem.Name.Equals(string.Format("{0}Controller", controllerName), StringComparison.InvariantCultureIgnoreCase))
                {
                    controller = Activator.CreateInstance(controllerItem) as IController;
                    break;
                }
            }

            return controller; 
            #endregion
        }
    }
}
