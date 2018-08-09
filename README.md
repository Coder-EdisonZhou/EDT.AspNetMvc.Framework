# MyMvcFramework
自己动手写一个简单的ASP.Net MVC框架

**总体结构**

在该解决方案中，一共有两个项目：

[![N|MyAspNetMvcFramework](https://images2015.cnblogs.com/blog/381412/201603/381412-20160309011644757-51819148.jpg)](https://start.spring.io/)
<br/>

　　一个是App，它是一个由最小化的引用环境（只引用了System和System.Web，以及Mvc.Lib）搭建起来的一个Web应用项目，借助MVC核心类库（Mvc.Lib）实现了MVC模式。

　　一个是Lib，它是一个模拟ASP.NET MVC框架的最小化、轻量级的迷你MVC框架，其中Mvc文件夹模拟System.Web.Mvc，Routing文件夹模拟System.Web.Routing，而View则简单地借助NVelocity模板引擎提供View视图服务。

**效果演示**

（1）默认路由 : home/index -> ContentResult
[![N|MyAspNetMvcFramework](https://images2015.cnblogs.com/blog/381412/201603/381412-20160309021321163-1990046935.jpg)](https://start.spring.io/)<br/>
（2）请求JsonResult
[![N|MyAspNetMvcFramework](https://images2015.cnblogs.com/blog/381412/201603/381412-20160309021432288-1843050114.jpg)](https://start.spring.io/)<br/>
（3）请求ViewResult
[![N|MyAspNetMvcFramework](https://images2015.cnblogs.com/blog/381412/201603/381412-20160309021723835-136890602.jpg)](https://start.spring.io/)
<br/>

### 参考博文

URL：<http://www.cnblogs.com/edisonchou/p/5256517.html>

> @EdisonChou
