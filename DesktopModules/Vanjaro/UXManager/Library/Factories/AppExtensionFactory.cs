﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vanjaro.UXManager.Library.Entities.Interface;

namespace Vanjaro.UXManager.Library
{
    public static partial class Factories
        public class AppExtensionFactory
        {
            internal static List<IAppExtension> Extentions
                    string CacheKey = CacheFactory.GetCacheKey(CacheFactory.Keys.App_Extension);
                                //get all assemblies 
                                IEnumerable<IAppExtension> AssembliesToAdd = from t in System.Reflection.Assembly.LoadFrom(Path).GetTypes()
                                                                             where t != (typeof(IAppExtension)) && (typeof(IAppExtension).IsAssignableFrom(t))
                                                                             select Activator.CreateInstance(t) as IAppExtension;

            internal static List<IAppExtension> ModuleExtentions
                    string CacheKey = CacheFactory.GetCacheKey(CacheFactory.Keys.App_Extension, "Module");
                                //get all assemblies 
                                IEnumerable<IAppExtension> AssembliesToAdd = from t in System.Reflection.Assembly.LoadFrom(Path).GetTypes()
                                                                             where t != (typeof(IAppExtension)) && (typeof(IAppExtension).IsAssignableFrom(t))
                                                                             && t != (typeof(IModuleExtension)) && (typeof(IModuleExtension).IsAssignableFrom(t))
                                                                             select Activator.CreateInstance(t) as IAppExtension;
        }
    }
}