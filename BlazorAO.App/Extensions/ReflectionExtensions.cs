﻿using System.Linq;
using System.Reflection;

namespace BlazorAO.App.Extensions
{
    public static class ReflectionExtensions
    {
        public static Assembly GetReferencedAssembly(this Assembly assembly, string name)
        {
            var references = assembly.GetReferencedAssemblies().ToDictionary(item => item.Name);
            return Assembly.Load(references[name]);
        }
    }
}
