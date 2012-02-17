﻿using System;
using System.Collections.Generic;
using System.Web;
using NewLife.Mvc;

/// <summary>
///Urls 的摘要说明
/// </summary>
public class Urls : IRouteConfig
{

    public void Config(RouteConfigManager cfg)
    {
        cfg
            .Static("/static.bmp")
            .Static("", delegate(IRouteContext ctx)
            {
                return ctx.Path.EndsWith(".txt");
            })
            .Redirect("/rootredirect", "/Test")
            .RouteToFactory<RouteFactory>("/specFactory")
            .Route<TestController>("/Test")
            .Route(
            //"/foo.aspx$", typeof(GenericControllerFactory),
                "/Test1$", typeof(TestController1),
                "/Test2", typeof(TestController2),
                "/Factory1", typeof(TestFactory),
                "/Error", typeof(TestError),
                "/Module", typeof(TestModuleRoute),
                ""
            )
            ;
    }
}