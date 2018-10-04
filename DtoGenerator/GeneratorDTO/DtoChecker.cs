using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO
{
    public static class DtoChecker
    {
        public static bool IsDto(Type t)
        {
            MethodInfo[] classMethods = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static);
            if (classMethods.Length > 0)
            {
                return false;
            }
            return true;
        }
    }
}
