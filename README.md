# MyMvcFramework
自己动手写一个简单的ASP.Net MVC框架

在该解决方案中，一共有两个项目：
　　一个是App，它是一个由最小化的引用环境（只引用了System和System.Web，以及Mvc.Lib）搭建起来的一个Web应用项目，借助MVC核心类库（Mvc.Lib）实现了MVC模式。

　　一个是Lib，它是一个模拟ASP.NET MVC框架的最小化、轻量级的迷你MVC框架，其中Mvc文件夹模拟System.Web.Mvc，Routing文件夹模拟System.Web.Routing，而View则简单地借助NVelocity模板引擎提供View视图服务。

参考博文：http://www.cnblogs.com/edisonchou/p/5256517.html
