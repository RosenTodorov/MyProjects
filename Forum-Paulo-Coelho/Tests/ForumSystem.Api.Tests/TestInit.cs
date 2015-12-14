﻿namespace ForumSystem.Api.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Http;
    using System.Reflection;
    using MyTested.WebApi;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("ForumSystem.Api"));

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            MyWebApi.IsUsing(WebApiConfig.Config);
        }
    }
}
